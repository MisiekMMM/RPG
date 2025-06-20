using System;
using System.Data;

namespace RPG;

public static class Utils
{
    public static void Wyczysc()
    {
        Console.Clear();
    }
    public static bool IsAnyNull(object[] table)
    {
        foreach (object o in table)
        {
            if (o == null)
            {
                return true;
            }
        }
        return false;
    }
    public static int FindLastIndex(object[] table)
    {
        for (int i = 0; i < table.Length; i++)
        {
            if (table[i] == null)
            {
                return i;
            }
        }
        return -1;
    }
    public static void DeleteItemFromArray(ref Item[] array, int index)
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        array[index] = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }
    public static void Write(string text, int typeRate = 10)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(typeRate);
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}