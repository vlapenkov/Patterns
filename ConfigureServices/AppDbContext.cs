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

        private readonly IServiceProvider _sp;


        public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider sp) : base(options)
        {
            _sp = sp;
        }



        public DbSet<ComplexModel> ComplexModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=contract-manager;Trusted_Connection=True;MultipleActiveResultSets=true");
            //   optionsBuilder.UseNpgsql("Host=localhost;Database=complex-models;Username=TNE_USER;Password=123123");
            optionsBuilder.UseLowerCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


        /// <summary>
        /// Класс для временного сохранения State, т.к. после SaveChanges State Меняется на Unchanged
        /// </summary>
        class SuapEntityWithState : BaseEntity {

            public BaseEntity Entity { get; set; }

            public int State { get; set; }
        }





        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            List<SuapEntityWithState> trackedEntities = await OnBeforeSaving2();


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


        async Task ProcessOfType<T>(List<SuapEntityWithState> trackedEntities) where T : BaseEntity, new()
        {
            IEventProcessor<T> eventProcessor = _sp.GetRequiredService<IEventProcessor<T>>();            

            foreach (SuapEntityWithState entityWithState in trackedEntities. Where(p=>p.Entity is T)) //
            {               
                {
                    entityWithState.Entity.State = entityWithState.State;

                    await eventProcessor.Process(entityWithState.Entity as T);
                }
            }
        }


        private async Task OnAfterSaving(List<SuapEntityWithState> trackedEntities)
        {

            await ProcessOfType<ComplexModel>(trackedEntities);

        }



        private Task<List<BaseEntity>> OnBeforeSaving()
        {
            var entities = ChangeTracker.Entries<BaseEntity>()
                .Where(p => p.State != EntityState.Unchanged)
                .Select(p => p.Entity).ToList();
            return Task.FromResult(entities);
        }

        private Task<List<SuapEntityWithState>> OnBeforeSaving2()
        {
            var entities = ChangeTracker.Entries<BaseEntity>()
                .Where(p => p.State != EntityState.Unchanged)
                .Select(p => new SuapEntityWithState
                {
                    Entity = p.Entity,
                    State = (int)p.State
                }
                ).ToList();
            return Task.FromResult(entities);
        }
    }
}
