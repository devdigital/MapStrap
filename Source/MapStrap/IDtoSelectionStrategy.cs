namespace MapStrap
{
    using System;
    using System.Collections.Generic;

    public interface IDtoSelectionStrategy
    {
        IEnumerable<Type> GetTypes();
    }
}