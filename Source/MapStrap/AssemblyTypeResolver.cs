namespace MapStrap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class AssemblyTypeResolver : ITypeResolver
    {
        private readonly IEnumerable<Assembly> assemblies;

        private readonly bool publicOnly;

        public AssemblyTypeResolver(IEnumerable<Assembly> assemblies, bool publicOnly = true)
        {
            if (assemblies == null)
            {
                throw new ArgumentNullException(nameof(assemblies));
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