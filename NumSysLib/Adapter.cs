namespace NumSysLib;

/// <summary>
/// Перевод чисел между системами счисления 2, 8, 10 и 16.
/// </summary>
public static class Adapter
{
    /// <summary>
    /// Переводит число из одной системы счисления в другую.
    /// </summary>
    /// <param name="value">Число в виде строки.</param>
    /// <param name="fromBase">Исходная система счисления (2, 8, 10 или 16).</param>
    /// <param name="toBase">Целевая система счисления (2, 8, 10 или 16).</param>
    /// <returns>Число в целевой системе счисления.</returns>
    /// <exception cref="ArgumentException">
    /// Число содержит недопустимые символы или указана неподдерживаемая система счисления.
    /// </exception>
    public static string Convert(string value, int fromBase, int toBase)
    {
        long number;
        if (fromBase == 10)
        {
            if (!long.TryParse(value, out number) || number < 0)
                throw new ArgumentException("Ошибка ввода данных, проверьте вводимые данные");
        }
        else
        {
            ConverterBase from = Create(fromBase);
            from.Value = value;
            number = from.ToDecimal();
        }

        if (toBase == 10)
            return number.ToString();

        return Create(toBase).FromDecimal(number);
    }

    private static ConverterBase Create(int numBase)
    {
        if (numBase == 2) return new Binary();
        if (numBase == 8) return new Oct();
        if (numBase == 16) return new Hex();
        throw new ArgumentException("Поддерживаются системы счисления 2, 8, 10 и 16");
    }
}