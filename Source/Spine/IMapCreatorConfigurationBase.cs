namespace Spine
{
    public interface IMapCreatorConfigurationBase
    {
        IMapCreatorConfigurationBase CreateConventionMaps();

        IMapCreatorConfigurationBase CreateCustomMaps();

        IMapCreatorConfigurationBase CreateCustomConfigurations();   
    }
}