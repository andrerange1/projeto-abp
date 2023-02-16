using System;
using System.Collections.Generic;
using System.Text;

namespace Bcx.Platform.Common.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }
}
