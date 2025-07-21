using System;
using System.Globalization;
using System.Text;

public class Tools
{
    public static void ColorLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    public static void ColorBack(string text, ConsoleColor color)
    {
        Console.BackgroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    public static string RemoveAccents(string txt)
    {
        string txtNormalizado = txt.Normalize(NormalizationForm.FormD);
        StringBuilder resultado = new StringBuilder();

        foreach (char letra in txtNormalizado)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(letra) != UnicodeCategory.NonSpacingMark)
            {
                resultado.Append(letra);
            }
        }

        return resultado.ToString().Normalize(NormalizationForm.FormC);
    }
}

