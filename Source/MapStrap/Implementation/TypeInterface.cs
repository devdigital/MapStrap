namespace MapStrap.Implementation
{
    using System;

    internal class TypeInterface
    {
        public TypeInterface(Type type, Type @interface)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (@interface == null)
            {
                throw new ArgumentNullException(nameof(@interface));
            }

            this.Type = type;
            this.Interface = @interface;
        }

        public Type Type { get; }

        public Type Interface { get; }
    }
}