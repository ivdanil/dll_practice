using NumSysLib;

namespace NumSysLib.Tests;

public class ConvertTests
{
    [Theory]
    [InlineData("0", "0")]
    [InlineData("1010", "10")]
    [InlineData("11111111", "255")]
    public void BinaryToDecimal(string input, string expected)
    {
        Assert.Equal(expected, Adapter.Convert(input, 2, 10));
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("10", "1010")]
    [InlineData("255", "11111111")]
    public void DecimalToBinary(string input, string expected)
    {
        Assert.Equal(expected, Adapter.Convert(input, 10, 2));
    }

    [Theory]
    [InlineData("10", "8")]
    [InlineData("17", "15")]
    [InlineData("377", "255")]
    public void OctToDecimal(string input, string expected)
    {
        Assert.Equal(expected, Adapter.Convert(input, 8, 10));
    }

    [Theory]
    [InlineData("8", "10")]
    [InlineData("15", "17")]
    [InlineData("255", "377")]
    public void DecimalToOct(string input, string expected)
    {
        Assert.Equal(expected, Adapter.Convert(input, 10, 8));
    }

    [Theory]
    [InlineData("A", "10")]
    [InlineData("10", "16")]
    [InlineData("FF", "255")]
    public void HexToDecimal(string input, string expected)
    {
        Assert.Equal(expected, Adapter.Convert(input, 16, 10));
    }

    [Theory]
    [InlineData("10", "A")]
    [InlineData("16", "10")]
    [InlineData("255", "FF")]
    public void DecimalToHex(string input, string expected)
    {
        Assert.Equal(expected, Adapter.Convert(input, 10, 16));
    }
}