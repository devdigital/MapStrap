namespace MapStrap.Creators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    using global::MapStrap.Models;

    public class DefaultMapCreator : IMapCreator
    {
        public virtual void CreateConventionMaps(IEnumerable<Type> types)
        {
            var typeInterfaces = this.GetGenericTypesOf(typeof(IMapFromDomain<>), types);
            foreach (var typeInterface in typeInterfaces)
            {
                foreach (var @interface in typeInterface.Value)
                {
                    Mapper.CreateMap(@interface.GetGenericArguments()[0], typeInterface.Key);
                }
            }            
        }

        public virtual void CreateCustomMaps(IEnumerable<Type> types)
        {
            var typeInterfaces = this.GetGenericTypesOf(typeof(IHaveCustomMap<,>), types);
            foreach (var typeInterface in typeInterfaces)
            {
                foreach (var @interface in typeInterface.Value)
                {
                    var method = typeof(Mapper).GetMethods(BindingFlags.Static | BindingFlags.Public).First(m => m.Name == "CreateMap" && m.IsGenericMethod);
                    var genericMethod = method.MakeGenericMethod(
                        @interface.GetGenericArguments()[0],
                        @interface.GetGenericArguments()[1]);

                    var mappingExpression = genericMethod.Invoke(null, null);

                    var instance = Activator.CreateInstance(typeInterface.Key);
                    var methodInfo = instance.GetType().GetMethod("Map");
                    methodInfo.Invoke(instance, new[] { mappingExpression });
                }
            }            
        }

        public virtual void CreateCustomConfigurations(IEnumerable<Type> types)
        {
            var configurationTypes = GetTypesOf<IHaveCustomConfiguration>(types);
            var maps = configurationTypes.Select(t => (IHaveCustomConfiguration)Activator.CreateInstance(t)).ToList();

            foreach (var map in maps)
            {
                map.Configure(Mapper.Configuration);
            }            
        }

        protected IDictionary<Type, IEnumerable<Type>> GetGenericTypesOf(Type interfaceType, IEnumerable<Type> types)
        {
            var typeInterfaces =
                (from t in types
                 from i in t.GetInterfaces()
                 where i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType && !t.IsAbstract && !t.IsInterface
                 select new TypeInterface(t, i));

            return typeInterfaces
                        .GroupBy(t => t.Type, t => t.Interface)
                        .ToDictionary(g => g.Key, g => g.AsEnumerable());
        }

        protected static IEnumerable<Type> GetTypesOf<TInterface>(IEnumerable<Type> types)
        {
            return
                (from t in types
                 where typeof(TInterface).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface
                 select t);
        }
    }
}