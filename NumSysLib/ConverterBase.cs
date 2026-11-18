namespace NumSysLib;

internal abstract class ConverterBase
{
    public abstract int Base { get; }
    public abstract string Digits { get; }

    private string _value = "0";

    public string Value
    {
        get => _value;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ошибка ввода данных, проверьте вводимые данные");

            value = value.Trim().ToUpper();
            foreach (char c in value)
            {
                if (!Digits.Contains(c))
                    throw new ArgumentException("Ошибка ввода данных, проверьте вводимые данные");
            }
            _value = value;
        }
    }

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