namespace Spine
{
    using System;

    public static class DtoSelectionExtensions
    {
        public static void CreateMaps(this IMapCreatorConfiguration mapCreatorConfiguration)
        {
            if (mapCreatorConfiguration == null)
            {
                throw new ArgumentNullException("mapCreatorConfiguration");
            }

            mapCreatorConfiguration
                .CreateConventionMaps()
                .CreateCustomMaps()
                .CreateCustomConfigurations();
        }
    }
}