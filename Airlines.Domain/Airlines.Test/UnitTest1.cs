using Airlines.Domain;

namespace Airplane.Test;
using System.Linq;
public class ClassesTest
{
    [Fact]
    public void TestSumInt()
    {
        var a = 5;
        var b = 7;
        var c = a + b; 
        Assert.Equal(11, c);
    }
}