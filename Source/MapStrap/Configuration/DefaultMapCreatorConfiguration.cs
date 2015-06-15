namespace MapStrap.Configuration
{
    using System;
    using System.Collections.Generic;

    internal class DefaultMapCreatorConfiguration : IMapCreatorConfiguration
    {
        private readonly IMapCreator mapCreator;

        private readonly IEnumerable<Type> types;

        public DefaultMapCreatorConfiguration(IMapCreator mapCreator, IEnumerable<Type> types)
        {
            if (mapCreator == null)
            {
                throw new ArgumentNullException("mapCreator");
            }

            if (types == null)
            {
                throw new ArgumentNullException("types");
            }

            this.mapCreator = mapCreator;
            this.types = types;
        }

        public IMapCreatorConfigurationBase CreateConventionMaps()
        {
            this.mapCreator.CreateConventionMaps(this.types);
            return this;
        }

        public IMapCreatorConfigurationBase CreateCustomMaps()
        {
            this.mapCreator.CreateCustomMaps(this.types);
            return this;
        }

        public IMapCreatorConfigurationBase CreateCustomConfigurations()
        {
            this.mapCreator.CreateCustomConfigurations(this.types);
            return this;
        }
    }
}