namespace GraphQLServer.Data.Models
{
    public class ObjectWithPolymorphicPropertyType
    {
        public ObjectWithPolymorphicPropertyType(Base interfaceProperty)
        {
            this.interfaceProperty = interfaceProperty;
        }

        public Base interfaceProperty { get; set; }
    }
}
