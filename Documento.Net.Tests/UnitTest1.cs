using Documento.Net.Entities;

namespace Documento.Net.Tests;

public class RgTests
{
    [Fact]
    public void Test1()
    {
        new Cpf("000000000");
        Assert.True(true);
    }
}