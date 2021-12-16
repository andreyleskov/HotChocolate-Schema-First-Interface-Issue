using System.Threading.Tasks;
using GraphQLServer.Data.Models;
using GraphQLServer.Data.Repositories;

namespace GraphQLServer.Data
{
    public class Query
    {
        public Task<ObjectWithPolymorphicPropertyType> retrieveObjectWithPolymorphicPropertyType(string textProperty, int integerProperty)
        {
            return Task.FromResult(AbstractRepository.RetrieveObjectWithPolymorphicPropertyType(textProperty, integerProperty));
        }
    }
}
