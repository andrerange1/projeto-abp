using System.Diagnostics.CodeAnalysis;

namespace Bcx.Platform.Common.Specification
{
    public static class SpecificationExtensions
    {
        public static ISpecification<T> And<T>([NotNull] this ISpecification<T> left, [NotNull] ISpecification<T> right)
            => new AndSpecification<T>(left, right);
        
        public static ISpecification<T> Or<T>([NotNull] this ISpecification<T> left, [NotNull] ISpecification<T> right)
            => new OrSpecification<T>(left, right);
        
        public static ISpecification<T> Not<T>([NotNull] this ISpecification<T> specification)
            => new NotSpecification<T>(specification);
    }
}
