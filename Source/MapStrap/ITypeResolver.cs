namespace MapStrap
{
    using System;
    using System.Collections.Generic;

    public interface ITypeResolver
    {
        IEnumerable<Type> GetTypes();
    }
}