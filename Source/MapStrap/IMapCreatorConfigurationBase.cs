namespace MapStrap
{
    public interface IMapCreatorConfigurationBase
    {
        IMapCreatorConfigurationBase CreateConventionMaps();

        IMapCreatorConfigurationBase CreateCustomMaps();

        IMapCreatorConfigurationBase CreateCustomConfigurations();   
    }
}