namespace NumSysLib;

internal abstract class ConverterBase
{
    public abstract int Base { get; }
    public abstract string Digits { get; }

    public string Value { get; set; } = "0";

    public long ToDecimal()
    {
        long result = 0;
        foreach (char c in Value)
            result = result * Base + Digits.IndexOf(c);
        return result;
    }

    public string FromDecimal(long number)
    {
        if (number == 0)
            return "0";

        string result = "";
        while (number > 0)
        {
            result = Digits[(int)(number % Base)] + result;
            number = number / Base;
        }
        return result;
    }
}