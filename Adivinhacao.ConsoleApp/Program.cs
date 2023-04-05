using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adivinhacao.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        inicio:
            int Pontos = 1000, pontosPerdidos, dificuldade, Tentativas;
            int[] Chute = new int[15];

            Random rnd = new Random();
            int[] sistemNum = new int[15];

            string result = "";

            try
            {
                Console.Title = "Jogo de adivinhação";

                Console.WriteLine("Escolha o nível de dificuldade:");
                Console.WriteLine("1 - Fácil | 2 - Médio | 3 - Difícil");
                Console.Write("Escolha: ");

                int esc = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                switch (esc)
                {
                    case 1:
                        dificuldade = 15;
                        break;

                    case 2:
                        dificuldade = 10;
                        break;

                    case 3:
                        dificuldade = 5;
                        break;


                    default:
                        Console.WriteLine();
                        Console.Write("Modo inválido,tente novamente...");
                        Console.ReadLine();

                        Console.Clear();
                        goto inicio;
                }

                Tentativas = dificuldade;

                for (int i = 0; i < dificuldade; i++)
                {
                    Console.WriteLine("Tentativa " + (i + 1) + " de 20");
                    Console.WriteLine("-------------------------------");
                    Console.Write("Qual é o seu chute do " + (i + 1) + "º número?");

                    sistemNum[i] = rnd.Next(1, 20);
                    Chute[i] = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("***************************************");
                    Console.WriteLine("*   Score atual: " + Pontos + " | Tentativas: " + (Tentativas - 1) + " *");
                    Console.WriteLine("***************************************");

                    Console.WriteLine();

                    if (Chute[i] != sistemNum[i])
                    {
                        pontosPerdidos = Math.Abs((Chute[i] - sistemNum[i]) / 2);
                        Pontos -= pontosPerdidos;

                        Tentativas--;

                        if (Pontos == 0 || Tentativas == 0)
                        {
                            break;
                        }
                    }
                }

                Console.WriteLine("--------------Resultados--------------");
                for (int j = 0; j < dificuldade; j++)
                {
                    if (Chute[j] != sistemNum[j])
                    {
                        result = " != ";
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (Chute[j] == sistemNum[j])
                    {
                        result = " = ";
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine((j + 1) + "º - " + Chute[j] + result + sistemNum[j]);
                }

                Console.ResetColor();
                Console.WriteLine();

            #region Saida
            sair:
                Console.WriteLine();

                Console.WriteLine("Gostaria de jogar novamente? (S/N)");
                ConsoleKeyInfo Opc = Console.ReadKey();

                if (Opc.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    goto inicio;
                }
                else if (Opc.Key == ConsoleKey.N)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida,tente novamente...");
                    goto sair;
                }
            }
            catch (Exception)
            {
                Console.Write("Erro, pressione qualquer botão para continuar...");
                Console.ReadKey();

                Console.Clear();
                goto inicio;
            }
            #endregion
        }
    }
}
