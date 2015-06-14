namespace Spine
{
    using System;

    using global::Spine.Configuration;
    using global::Spine.Creators;

    public class Spine
    {
        private IMapCreator mapCreator;

        public Spine()
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

        public Spine WithMapCreator(IMapCreator mapCreator)
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