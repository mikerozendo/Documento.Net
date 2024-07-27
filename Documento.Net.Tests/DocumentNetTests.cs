namespace Documento.Net.Tests;

public class DocumentNetTests
{
    [Theory]
    [InlineData("000000000")]
    [InlineData("111111111")]
    [InlineData("222222222")]
    [InlineData("333333333")]
    [InlineData("11.111.111-1")]
    [InlineData("22.222.222-2")]
    public void IsValid_False_RegexMatchesForRg (string documentNumber)
    {
        //Arrange
        var documentNet = new DocumentNet(documentNumber);

        //Act
        var isValid = documentNet.IsValid();

        //Assert
        Assert.False(isValid);
    }

    [Theory]
    [InlineData("00000000000")]
    [InlineData("11111111111")]
    [InlineData("22222222222")]
    [InlineData("33333333333")]
    [InlineData("111.111.111-11")]
    [InlineData("222.222.222-22")]
    [InlineData("333.333.333-33")]

    public void IsValid_False_RegexMatchesForCpf(string documentNumber)
    {
        //Arrange
        var documentNet = new DocumentNet(documentNumber);

        //Act
        var isValid = documentNet.IsValid();

        //Assert
        Assert.False(isValid);
    }

    [Theory]
    [InlineData("00000000000000")]
    [InlineData("11111111111111")]
    [InlineData("22222222222222")]
    [InlineData("33333333333333")]
    [InlineData("11.111.111/1111-11")]
    [InlineData("22.222.222/2222-22")]
    [InlineData("33.333.333/3333-33")]
    public void IsValid_False_RegexMatchesForCnpj(string documentNumber)
    {
        //Arrange
        var documentNet = new DocumentNet(documentNumber);

        //Act
        var isValid = documentNet.IsValid();

        //Assert
        Assert.False(isValid);
    }

    [Theory]
    [InlineData("000000000000000")]
    [InlineData("111111111111111")]
    [InlineData("222222222222222")]
    [InlineData("333333333333334")]
    [InlineData("111111111")]
    [InlineData("22222222")]
    [InlineData("33333333")]
    public void IsValid_False_DocumentTypeIsOutros(string documentNumber)
    {
        //Arrange
        var documentNet = new DocumentNet(documentNumber);

        //Act
        var isValid = documentNet.IsValid();

        //Assert
        Assert.False(isValid);
    }
}