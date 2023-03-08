﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaForca
{
    internal class Program
    {
        public static void ColorirLinha(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
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

            while (tentativas > 0 && palavraSeled.Contains("_"))
            {
                ColorirLinha("_____________________JOGO__DA__FORCA______________________\n\n\n", ConsoleColor.White);
                Console.WriteLine("Desafie-se tentando descobrir qual é a palavra oculta em até 6 tentativas.\n", ConsoleColor.DarkGreen);
                ColorirLinha("Tema: PROFISSÃO\n\n\n", ConsoleColor.DarkYellow);
                ColorirLinha($"Tentativas Restantes: {tentativas}\n\n", ConsoleColor.DarkGreen);
                Console.WriteLine($"|----- ");
                Console.WriteLine($"|    | ");
                Console.WriteLine($"|    {(tentativas <= 5 ? "O" : " ")} ");
                Console.WriteLine($"|   {(tentativas <= 3 ? "/" : " ")}{(tentativas <= 4 ? "|" : " ")}{(tentativas <= 2 ? "\\" : " ")} ");
                Console.WriteLine($"|    {(tentativas <= 4 ? "|" : " ")} ");
                Console.WriteLine($"|   {(tentativas <= 1 ? "/" : " ")} {(tentativas == 0 ? "\\" : " ")} ");
                Console.WriteLine($"_      \n\n");
                Console.WriteLine(palavraSeled);
                ColorirLinha($"\n\nChutes Errados: {string.Join(", ", chutes)}", ConsoleColor.Red);

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
                }
            }
            if (tentativas == 0)
            {
                Console.WriteLine($"|----- ");
                Console.WriteLine($"|    | ");
                Console.WriteLine($"|    {(tentativas <= 5 ? "O" : " ")} ");
                Console.WriteLine($"|   {(tentativas <= 3 ? "/" : " ")}{(tentativas <= 4 ? "|" : " ")}{(tentativas <= 2 ? "\\" : " ")} ");
                Console.WriteLine($"|    {(tentativas <= 4 ? "|" : " ")} ");
                Console.WriteLine($"|   {(tentativas <= 1 ? "/" : " ")} {(tentativas == 0 ? "\\" : " ")} ");
                Console.WriteLine($"_      \n\n");
                ColorirLinha($"\nVOCÊ PERDEU, A PALAVRA É: {palavra} \n\n", ConsoleColor.DarkRed);
            }
            else { ColorirLinha($"\nPARABÉNS, VOCÊ ACERTOU, A PALAVRA É: {palavra} \n\n", ConsoleColor.Green); }



            Console.ReadKey();

        }
    }
}