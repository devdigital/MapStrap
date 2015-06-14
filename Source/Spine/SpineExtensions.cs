namespace Spine
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using global::Spine.Configuration;
    using global::Spine.Strategies;

    public static class SpineExtensions
    {
        public static IMapCreatorConfiguration SelectDtosFromAssemblies(
            this Spine spine,
            IEnumerable<Assembly> assemblies)
        {
            return SelectDtosFromAssemblies(spine, assemblies, true);
        }

        public static IMapCreatorConfiguration SelectDtosFromAssemblies(
            this Spine spine, 
            IEnumerable<Assembly> assemblies, bool publicOnly)
        {
            if (spine == null)
            {
                throw new ArgumentNullException("spine");
            }

            if (assemblies == null)
            {
                throw new ArgumentNullException("assemblies");
            }

            var types = new AssemblyDtoSelectionStrategy(assemblies, publicOnly).GetTypes();
            return new DefaultMapCreatorConfiguration(spine.MapCreator, types);
        }
    }
}