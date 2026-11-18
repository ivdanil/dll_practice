using NumSysLib;

Console.WriteLine(Adapter.Convert("FF", 16, 10));
Console.WriteLine(Adapter.Convert("255", 10, 2));
Console.WriteLine(Adapter.Convert("17", 8, 16));
Console.WriteLine(Adapter.Convert("ff", 16, 8));

try
{
    Console.WriteLine(Adapter.Convert("129", 8, 2));
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Console.WriteLine(Adapter.Convert("10", 5, 2));
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}