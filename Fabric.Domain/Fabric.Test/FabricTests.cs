namespace Fabric.Test;

public class FabricTests : IClassFixture<FabricFixture>
{
    private readonly FabricFixture _fixture;

    public FabricTests(FabricFixture fixture)
    { _fixture = fixture; }
    [Fact]
    public void Test1()
    {

    }
}