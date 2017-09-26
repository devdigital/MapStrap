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

        private IEnumerable<Type> types;

        public AssemblyTypeResolver(IEnumerable<Assembly> assemblies, bool publicOnly = true)
        {
            this.assemblies = assemblies ?? throw new ArgumentNullException(nameof(assemblies));
            this.publicOnly = publicOnly;
        }

        public IEnumerable<Type> GetTypes()
        {
            return this.types
                   ?? (this.types =
                       this.assemblies.SelectMany(a => this.publicOnly ? a.GetExportedTypes() : a.GetTypes()));
        }
    }
}