namespace GraphQLServer.Data.Models
{
    public class ObjectWithPolymorphicPropertyType
    {
        public ObjectWithPolymorphicPropertyType(SimpleObject interfaceProperty)
        {
            this.interfaceProperty = interfaceProperty;
        }

        public SimpleObject interfaceProperty { get; set; }
    }
}
