namespace GraphQLServer.Data.Models
{
    public class SimpleObject : Base
    {
        public SimpleObject() { }

        public SimpleObject(string textProperty, int integerProperty)
        {
            this.textProperty = textProperty;
            this.integerProperty = integerProperty;
        }

        public string textProperty { get; set; }
        public int integerProperty { get; set; }
    }
}
