using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    public static class Ferramentas
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


        public static string RemoverAcentos(string texto)
        {
            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            StringBuilder resultado = new StringBuilder();

            foreach (char letra in textoNormalizado)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letra) != UnicodeCategory.NonSpacingMark)
                {
                    resultado.Append(letra);
                }
            }

            return resultado.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
