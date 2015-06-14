namespace Spine.Models
{
    using System;

    internal class TypeInterface
    {
        private readonly Type type;

        private readonly Type @interface;

        public TypeInterface(Type type, Type @interface)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (@interface == null)
            {
                throw new ArgumentNullException("interface");
            }

            this.type = type;
            this.@interface = @interface;
        }

        public Type Type
        {
            get
            {
                return this.type;
            }
        }

        public Type Interface
        {
            get
            {
                return this.@interface;
            }
        }
    }
}