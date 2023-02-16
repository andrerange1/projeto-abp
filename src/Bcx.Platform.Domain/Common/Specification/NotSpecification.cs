using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcx.Platform.Common.Specification
{
    public class NotSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Specification { get; set; }
        public NotSpecification(ISpecification<T> specification)
        {
            Specification = specification;
        }
        public bool IsSatisfiedBy(T item) => !Specification.IsSatisfiedBy(item);
    }
}
