namespace Spine
{
    using System;
    using System.Collections.Generic;

    public interface IMapCreator
    {
        void CreateConventionMaps(IEnumerable<Type> types);

        void CreateCustomMaps(IEnumerable<Type> types);

        void CreateCustomConfigurations(IEnumerable<Type> types);
    }
}