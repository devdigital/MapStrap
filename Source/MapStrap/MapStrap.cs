namespace MapStrap
{
    using System;

    using global::MapStrap.Configuration;
    using global::MapStrap.Creators;    

    public class MapStrap
    {
        private IMapCreator mapCreator;

        public MapStrap()
        {
            this.mapCreator = new DefaultMapCreator();
        }

        public IMapCreator MapCreator
        {
            get
            {
                return this.mapCreator;
            }          
        }

        public MapStrap WithMapCreator(IMapCreator mapCreator)
        {
            if (mapCreator == null)
            {
                throw new ArgumentNullException("mapCreator");
            }

            this.mapCreator = mapCreator;
            return this;
        }

        public IMapCreatorConfiguration SelectDtos(IDtoSelectionStrategy selectionStrategy)
        {
            if (selectionStrategy == null)
            {
                throw new ArgumentNullException("selectionStrategy");
            }

            var types = selectionStrategy.GetTypes();
            return new DefaultMapCreatorConfiguration(this.mapCreator, types);
        }
    }   
}