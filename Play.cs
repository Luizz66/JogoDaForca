using System;
using System.Collections.Generic;
using static Colorir.Color;
using static Ferramentas.Remove;

namespace JogoDaForca
{
    internal class Play
    {
        static void Main()
        {
            int tentativas = 6;

            var profissões = new List<string>
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
            var países = new List<string>
            {
                "Brasil",
                "México",
                "Argentina",
                "Uruguai",
                "Chile",
                "Alemanha",
                "Inglaterra",
                "Itália",
                "Grécia",
                "Irlanda",
                "Espanha",
                "França",
                "Nigéria",
                "Egito",
                "Senegal",
                "Angola",
                "Marrocos",
                "Gana",
                "China",
                "Japão",
                "Índia",
                "Indonésia",
                "Coreia do Sul",
                "Estados Unidos",
                "Canadá",
                "Austrália",


            };
            var animais = new List<string>
            {
                "Macaco",
                "Leão",
                "Tigre",
                "Elefante",
                "Girafa",
                "Jacaré",
                "Canguru",
                "Pinguim",
                "Orangotango",
                "Tubarão",
                "Urso",
                "Zebra",
                "Crocodilo",
                "Rinoceronte",
                "Guepardo",
                "Tartaruga",
                "Gorila",
                "Cobra",
                "Morcego",
                "Lobo",
                "Baleia",
                "Gato",
                "Caranguejo",
                "Peixe",
                "Cervo",
            };
            var frutas = new List<string>
            {
                "Abacaxi",
                "Banana",
                "Caju",
                "Cereja",
                "Coco",
                "Caqui",
                "Framboesa",
                "Goiaba",
                "Kiwi",
                "Laranja",
                "Limão",
                "Manga",
                "Melância",
                "Melão",
                "Morango",
                "Pera",
                "Pêssego",
                "Pitanga",
                "Tangerina",
                "Uva",
                "Abacate",
                "Ameixa",
                "Graviola",
                "Maracujá",
                "Acerola",
                "Mamão",
            };

            Random random = new Random();

            List<string> tema;
            string temaSorteado;

            int indiceTema = random.Next(4); //de 0 a 3
            if (indiceTema == 0)
            {
                tema = profissões;
                temaSorteado = "PROFISSÃO";
            }
            else if (indiceTema == 1)
            {
                tema = países;
                temaSorteado = "PAÍS";
            }
            else if (indiceTema == 2)
            {
                tema = animais;
                temaSorteado = "ANIMAL";
            }
            else
            {
                tema = frutas;
                temaSorteado = "FRUTA";
            }

            int indiceList = random.Next(tema.Count);
            string palavra = tema[indiceList];
            string palavraSeled = new string('_', palavra.Length);

            List<char> chutes = new List<char>();
            string boneco = $"| -----\n|    | \n|    O \n|   /|\\ \n|    | \n|   / \\ \n_      ";

            while (tentativas > 0 && palavraSeled.Contains("_"))
            {
                string _ = new string('_', 30);
                ColorBack($"{_}JOGO__DA__FORCA{_}\n\n\n", ConsoleColor.DarkBlue);
                Console.WriteLine("Desafie-se tentando descobrir qual é a palavra oculta em até 6 tentativas (Não considere acentos).\n");
                ColorLine($"Tema: {temaSorteado}\n\n\n", ConsoleColor.DarkYellow);
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
                    $"_      \n");
                Console.WriteLine($"Palavra: {palavraSeled}");
                ColorLine($"\n\nChutes Errados: {string.Join(", ", chutes)}", ConsoleColor.Red);

                char entrada = Console.ReadKey().KeyChar.ToString().ToLower()[0];
                string palavraSemAcento = new string(RemoverAcentos(palavra.ToLower()));

                if (palavraSemAcento.Contains(entrada))
                {
                    for (int i = 0; i < palavraSemAcento.Length; i++)
                    {
                        if (palavraSemAcento[i] == entrada)
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
            else { ColorLine($"\nPARABÉNS, VOCÊ ACERTOU, A PALAVRA É: {palavra} \n\n", ConsoleColor.DarkGreen); }



            Console.ReadKey();
        }

    }
}
