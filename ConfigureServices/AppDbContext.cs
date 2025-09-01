using ConfigureServices.Domain;
using ConfigureServices.Mediator;
using ConfigureServices.Mediator.ComplexModelNs;

using ConfigureServices.Models.ComplexModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConfigureServices
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Внутренний класс для временного сохранения State, т.к. после SaveChanges State Меняется на Unchanged
        /// </summary>
        internal class EntityWithState : BaseEntity
        {

            public BaseEntity Entity { get; init; }

            public int State { get; init; }
        }

        private readonly IServiceProvider _sp;


        public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider sp) : base(options)
        {
            _sp = sp;
        }



        public DbSet<ComplexModel> ComplexModels { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=contract-manager;Trusted_Connection=True;MultipleActiveResultSets=true");
            //   optionsBuilder.UseNpgsql("Host=localhost;Database=complex-models;Username=TNE_USER;Password=123123");
            optionsBuilder.UseLowerCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }








        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            List<EntityWithState> trackedEntities = await OnBeforeSaving();


            var currentTransaction = Database.CurrentTransaction;

            if (currentTransaction != null)
            {
                try
                {
                    var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
                    await OnAfterSaving(trackedEntities);
                    return result;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception("Сущность была изменена с момента последнего чтения");
                }
            }
            else
            {
                using var transaction = await Database.BeginTransactionAsync();
                try
                {
                    var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
                    await OnAfterSaving(trackedEntities);

                    await transaction.CommitAsync();
                    return result;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Сущность была изменена с момента последнего чтения");
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            //  return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        async Task ProcessOfType<TEntity>(List<EntityWithState> trackedEntities) where TEntity : BaseEntity, new()
        {
            IEventProcessor<TEntity> eventProcessor = _sp.GetService<IEventProcessor<TEntity>>();

            // если не зарегистрировано обработчика, то выход
            if (eventProcessor == null) return;

            foreach (EntityWithState entityWithState in trackedEntities.Where(p => p.Entity is TEntity))
            {

                await eventProcessor.Process((TEntity)entityWithState.Entity, entityWithState.State);

            }
        }


        private async Task OnAfterSaving(List<EntityWithState> trackedEntities)
        {

            await ProcessOfType<ComplexModel>(trackedEntities);
            await ProcessOfType<Product>(trackedEntities);

        }



        private Task<List<EntityWithState>> OnBeforeSaving()
        {
            var entities = ChangeTracker.Entries<BaseEntity>()
                .Where(p => p.State != EntityState.Unchanged)
                .Select(p => new EntityWithState
                {
                    Entity = p.Entity,
                    State = (int)p.State
                }
                ).ToList();
            return Task.FromResult(entities);
        }
    }
}
