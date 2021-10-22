using HotChocolate.Types;

namespace GraphQLServer.Data.Models
{
    [InterfaceType(Name = nameof(Base))]
    public interface Base
    {
        string textProperty { get; set; }
        int integerProperty { get; set; }
    }
}
