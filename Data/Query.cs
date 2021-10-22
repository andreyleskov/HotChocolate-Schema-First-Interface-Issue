using GraphQLServer.Data.Models;
using GraphQLServer.Data.Repositories;

namespace GraphQLServer.Data
{
    public class Query
    {
        public ObjectWithPolymorphicPropertyType retrieveObjectWithPolymorphicPropertyType(string textProperty, int integerProperty)
        {
            return AbstractRepository.RetrieveObjectWithPolymorphicPropertyType(textProperty, integerProperty);
        }
    }
}
