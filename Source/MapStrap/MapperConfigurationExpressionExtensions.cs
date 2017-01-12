namespace MapStrap
{
    using System;
    using System.Linq;

    using AutoMapper;

    using MapStrap.Implementation;

    public static class MapperConfigurationExpressionExtensions
    {
        public static void CreateConventionMaps(
            this IMapperConfigurationExpression expression,
            ITypeResolver typeResolver)
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
        }

        public static void CreateCustomMaps(
            this IMapperConfigurationExpression expression,
            ITypeResolver typeResolver)
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

            mapCreator.CreateCustomMaps(types);
        }

        public static void CreateCustomConfigurations(
            this IMapperConfigurationExpression expression,
            ITypeResolver typeResolver)
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

            mapCreator.CreateCustomConfigurations(types);
        }

        public static void CreateMaps(
            this IMapperConfigurationExpression expression, 
            ITypeResolver typeResolver)
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