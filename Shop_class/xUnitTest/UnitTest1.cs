namespace xUnitTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var a = 5;
        var b = 6;
        var c = a + b;
        Assert.Equal(11, c);
    }

    [Fact]
    public void Test2()
    {
        var a = "das";
        var b = 6;
        var c = a + b;
        Assert.Equal("das6", c);
    }
}