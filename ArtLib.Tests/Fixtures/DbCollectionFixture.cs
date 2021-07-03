using Xunit;

namespace ArtLibTests.Fixtures
{
    [CollectionDefinition("Db")]
    public class DbCollectionFixture : ICollectionFixture<DbFixture>
    {

    }
}
