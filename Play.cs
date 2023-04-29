using System;
using System.Collections.Generic;
using static Colorir.Color;
using System.Linq;

namespace JogoDaForca
{
    internal class Play
    {
        static void Main()
        {
            int tentativas = 6;
            var strings = new List<string>
            {
                "enfermagem",
                "fisioterapia",
                "medicina",
                "nutriçao",
                "odontologia",
                "radiologia",
                "biologia",
                "astronomia",
                "fisica",
                "geologia",
                "quimica",
                "engenharia",
                "antropologia",
                "psicologia",
                "administraçao",
                "arquitetura",
                "jornalismo",
                "pedagogia",
                "design",
                "meteorologia",
                "economia",
                "direito",
                "marketing",
                "biomedicina",

            };
            Random random = new Random();

            int indice = random.Next(strings.Count);
            string palavra = strings[indice];
            string palavraSeled = new string('_', palavra.Length);

            List<char> chutes = new List<char>();
            string boneco = $"| -----\n|    | \n|    O \n|   /|\\ \n|    | \n|   / \\ \n_      ";

            while (tentativas > 0 && palavraSeled.Contains("_"))
            {
                ColorLine("_____________________JOGO__DA__FORCA______________________\n\n\n", ConsoleColor.White);
                Console.WriteLine("Desafie-se tentando descobrir qual é a palavra oculta em até 6 tentativas.\n", ConsoleColor.DarkGreen);
                ColorLine("Tema: PROFISSÃO\n\n\n", ConsoleColor.DarkYellow);
                ColorLine($"Tentativas Restantes: {tentativas}\n\n", ConsoleColor.DarkGreen);
                Console.WriteLine($"| -----\n" +
                    $"|    | \n" +
                    $"|    " +
                    $"{(tentativas <= 5 ? "O" : " ")} \n" +
                    $"|   " +
                    $"{(tentativas <= 3 ? "/" : " ")}" +
                    $"{(tentativas <= 4 ? "|" : " ")}" +
                    $"{(tentativas <= 2 ? "\\" : " ")} \n" +
                    $"|    " +
                    $"{(tentativas <= 4 ? "|" : " ")} \n" +
                    $"|   " +
                    $"{(tentativas <= 1 ? "/" : " ")} " +
                    $"{(tentativas == 0 ? "\\" : " ")} \n" +
                    $"_      ");
                Console.WriteLine(palavraSeled);
                ColorLine($"\n\nChutes Errados: {string.Join(", ", chutes)}", ConsoleColor.Red);

                char entrada = Console.ReadKey().KeyChar.ToString().ToLower()[0];

                if (palavra.Contains(entrada))
                {
                    for (int i = 0; i < palavra.Length; i++)
                    {
                        if (palavra[i] == entrada)
                        {
                            palavraSeled = palavraSeled.Remove(i, 1).Insert(i, entrada.ToString());

                        }
                    }
                    Console.WriteLine(palavraSeled);
                    Console.Clear();
                }
                else
                {
                    chutes.Add(entrada);
                    Console.Clear();
                    tentativas--;
                    if (chutes.Contains(entrada)) { continue; }
                }
            }
            if (tentativas == 0)
            {
                Console.WriteLine(boneco);
                ColorLine($"\nVOCÊ PERDEU, A PALAVRA É: {palavra} \n\n", ConsoleColor.DarkRed);
            }
            else { ColorLine($"\nPARABÉNS, VOCÊ ACERTOU, A PALAVRA É: {palavra} \n\n", ConsoleColor.Green); }



            Console.ReadKey();

        }
    }
}
