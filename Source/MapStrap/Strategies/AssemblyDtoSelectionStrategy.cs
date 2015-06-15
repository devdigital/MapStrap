namespace MapStrap.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class AssemblyDtoSelectionStrategy : IDtoSelectionStrategy
    {
        private readonly IEnumerable<Assembly> assemblies;

        private readonly bool publicOnly;

        public AssemblyDtoSelectionStrategy(IEnumerable<Assembly> assemblies, bool publicOnly)
        {
            if (assemblies == null)
            {
                throw new ArgumentNullException("assemblies");
            }

            this.assemblies = assemblies;
            this.publicOnly = publicOnly;
        }

        public IEnumerable<Type> GetTypes()
        {
            return this.assemblies.SelectMany(a => this.publicOnly ? a.GetExportedTypes() : a.GetTypes());
        }
    }
}