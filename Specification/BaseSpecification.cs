namespace Specification
{


    public abstract class IBaseSpecification<T>
    {
        public abstract bool IsSatisfiedBy(T item);
    }


    class CommonFilter<T> where T : class, new()
    {
        IEnumerable<T> Filter(IEnumerable<T> source, IBaseSpecification<T> spec)
        {

            foreach (var item in source)
            {
                if (spec.IsSatisfiedBy(item))
                    yield return item;
            }
        }
    }

    public class ProductColorSpecification : IBaseSpecification<Product>
    {
        private Color _color;

        public ProductColorSpecification(Color color)
        {
            _color = color;
        }

        public override bool IsSatisfiedBy(Product item)
        {
            return item.Color == _color;
        }
    }


    public abstract class CompositeSpecification<T> : IBaseSpecification<T>

    {

        protected readonly IBaseSpecification<T>[] items;

        public CompositeSpecification(params IBaseSpecification<T>[] items)

        {

            this.items = items;

        }

    }

    public class AndSpecification<T> : CompositeSpecification<T>

    {

        public AndSpecification(params IBaseSpecification<T>[] items) : base(items)

        {

        }

        public override bool IsSatisfiedBy(T t)

        {

            // Any -> OrSpecification

            return items.All(i => i.IsSatisfiedBy(t));

        }

    }


    public class OrSpecification<T> : CompositeSpecification<T> where T : class

    {

        public OrSpecification(params IBaseSpecification<T>[] items) : base(items)

        {

        }

        public override bool IsSatisfiedBy(T t)

        {

            // Any -> OrSpecification

            return items.Any(i => i.IsSatisfiedBy(t));

        }

    }

    //public class AndSpecification<T> : CompositeSpecification<T>
    //{
    //    ISpecification<T> left;
    //    ISpecification<T> right;

    //    public AndSpecification(ISpecification<T> left, ISpecification<T> right)
    //    {
    //        this.left = left;
    //        this.right = right;
    //    }

    //    public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) && right.IsSatisfiedBy(candidate);
    //}
}
