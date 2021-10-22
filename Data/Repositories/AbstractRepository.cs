using GraphQLServer.Data.Models;

namespace GraphQLServer.Data.Repositories
{
    internal static class AbstractRepository
	{
		static AbstractRepository() {}

		public static ObjectWithPolymorphicPropertyType RetrieveObjectWithPolymorphicPropertyType(string textProperty, int integerProperty)
		{
			SimpleObject interfaceProperty = new (textProperty, integerProperty);
			return new ObjectWithPolymorphicPropertyType(interfaceProperty);
		}
    }
}
