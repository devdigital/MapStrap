namespace MapStrap
{
    using System;
    using System.Linq;

    using AutoMapper;

    using MapStrap.Implementation;

    public static class MapperConfigurationExpressionExtensions
    {
        public static void CreateMaps(this IMapperConfigurationExpression expression, ITypeResolver typeResolver)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (typeResolver == null)
            {
                throw new ArgumentNullException(nameof(typeResolver));
            }

            var types = typeResolver.GetTypes().ToList();
            var mapCreator = new DefaultMapCreator(expression);

            mapCreator.CreateConventionMaps(types);
            mapCreator.CreateCustomMaps(types);
            mapCreator.CreateCustomConfigurations(types);
        }
    }
}