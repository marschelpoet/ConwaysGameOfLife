namespace CGOL.Console.Extensions;

public static class GenericExtensions
{
    public static void Copy<T>(this T toCopy, ref T copy) where T : new()
    {
        copy ??= new();

        foreach (System.Reflection.PropertyInfo property in typeof(T).GetProperties())
        {
            property.SetValue(copy, property.GetValue(toCopy));
        }
    }
}
