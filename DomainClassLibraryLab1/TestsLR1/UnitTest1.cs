namespace TestsLR1;
using System.Linq;  // для запросов

public class Class1Test    //этот класс на самом деле наследуется от Object
{
    // Существуют факты и теории
    // факты - методы, применяют один метод
    // теория - проверяют несколько значений (?)
    [Fact]
    public void TestInts()
    {
        var a = 0;
        var b = 2;
        var c = a + b;
        Assert.Equal(2, c);
    }
}