namespace MapStrap
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using global::MapStrap.Configuration;
    using global::MapStrap.Strategies;
    
    public static class MapStrapExtensions
    {
        public static IMapCreatorConfiguration SelectDtosFromAssemblies(
            this MapStrap mapStrap,
            IEnumerable<Assembly> assemblies)
        {
            return SelectDtosFromAssemblies(mapStrap, assemblies, true);
        }

        public static IMapCreatorConfiguration SelectDtosFromAssemblies(
            this MapStrap mapStrap, 
            IEnumerable<Assembly> assemblies, bool publicOnly)
        {
            if (mapStrap == null)
            {
                throw new ArgumentNullException("mapStrap");
            }

            if (assemblies == null)
            {
                throw new ArgumentNullException("assemblies");
            }

            var types = new AssemblyDtoSelectionStrategy(assemblies, publicOnly).GetTypes();
            return new DefaultMapCreatorConfiguration(mapStrap.MapCreator, types);
        }
    }
}