namespace MapStrap.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    internal class DefaultMapCreator
    {
        private readonly IMapperConfigurationExpression expression;

        public DefaultMapCreator(IMapperConfigurationExpression expression)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public void CreateConventionMaps(IEnumerable<Type> types)
        {
            var typeInterfaces = this.GetGenericTypesOf(typeof(IMapFromDomain<>), types);
            foreach (var typeInterface in typeInterfaces)
            {
                foreach (var @interface in typeInterface.Value)
                {
                    this.expression.CreateMap(@interface.GetGenericArguments()[0], typeInterface.Key);
                }
            }
        }

        public void CreateCustomMaps(IEnumerable<Type> types)
        {
            var typeInterfaces = this.GetGenericTypesOf(typeof(IHaveCustomMap<,>), types);
            foreach (var typeInterface in typeInterfaces)
            {
                foreach (var @interface in typeInterface.Value)
                {
                    var method =
                        this.expression.GetType()
                            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                            .FirstOrDefault(m => m.Name == "CreateMap" && m.IsGenericMethodDefinition);

                    if (method == null)
                    {
                        throw new InvalidOperationException(
                            $"No CreateMap method found on {this.expression.GetType().Name}");
                    }

                    var genericMethod = method.MakeGenericMethod(
                        @interface.GetGenericArguments()[0],
                        @interface.GetGenericArguments()[1]);

                    var mappingExpression = genericMethod.Invoke(this.expression, null);

                    var instance = Activator.CreateInstance(typeInterface.Key);
                    var methodInfo = instance.GetType().GetMethod("Map");
                    if (methodInfo == null)
                    {
                        throw new InvalidOperationException(
                            $"There is no Map method defined on {typeInterface.Key.Name}");
                    }

                    methodInfo.Invoke(instance, new[] { mappingExpression });
                }
            }
        }

        public void CreateCustomConfigurations(IEnumerable<Type> types)
        {
            var configurationTypes = GetTypesOf<IHaveCustomConfiguration>(types);
            var maps = configurationTypes.Select(t => (IHaveCustomConfiguration)Activator.CreateInstance(t)).ToList();

            foreach (var map in maps)
            {
                map.Configure(this.expression);
            }
        }

        private IDictionary<Type, IEnumerable<Type>> GetGenericTypesOf(Type interfaceType, IEnumerable<Type> types)
        {
            var typeInterfaces =
                from t in types
                from i in t.GetInterfaces()
                where i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType && !t.IsAbstract && !t.IsInterface
                select new TypeInterface(t, i);

            return typeInterfaces
                .GroupBy(t => t.Type, t => t.Interface)
                .ToDictionary(g => g.Key, g => g.AsEnumerable());
        }

        private static IEnumerable<Type> GetTypesOf<TInterface>(IEnumerable<Type> types)
        {
            return
                from t in types
                where typeof(TInterface).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface
                select t;
        }
    }
}