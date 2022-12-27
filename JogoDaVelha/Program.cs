using System.Drawing;
using System.Globalization;

namespace JogoDaVelha
{
    class Program
    {
        static string player1;
        static string player2;
        static string[,] ticTacToe = new string[3, 3];
        static string winNamePlayer ="";
        static int countWinnerX = 0;
        static int countWinnerO = 0;
        static string row;
        static int rowInt;

        static void ConvertInputRow()
        {
            if (row == "A")
            {
                rowInt = 0;
            }
            else if (row == "B")
            {
                rowInt = 1;
            }
            else
            {
                rowInt = 2;
            }
        }

        static void ShowRules()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("           REGRAS DO JOGO DA VELHA");
            Console.ResetColor();

            Console.WriteLine(" > O jogo é composto por dois competidores");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" > O primeiro jogador recebe  X");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" > O segundo jogador recebe   O");
            Console.ResetColor();

            Console.WriteLine(" > As jogadas são alternadas");
            Console.WriteLine(" > A cada jogada, é preciso informar uma combinação de linha e coluna");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" > Linhas: A, B e C  |  Colunas: 0, 1 e 2");
            Console.ResetColor();

            Console.WriteLine(" > Vence o jogador que conseguir formar primeiro uma linha com três");
            Console.WriteLine("   símbolos iguais, seja ela na horizontal, vertical ou diagonal");
            Console.WriteLine();
            Console.WriteLine("Cerquilha de exemplo");
            Console.WriteLine("                       0 | 1 | 2");
            Console.WriteLine("                     A   |   |  ");
            Console.WriteLine("                      ---|---|---");
            Console.WriteLine("                     B   |   |  ");
            Console.WriteLine("                      ---|---|---");
            Console.WriteLine("                     C   |   |  ");
        }

        static void GetNamesPlayers()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" VAMOS COMEÇAR");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Player 1, informe seu nome: ");
            player1 = Console.ReadLine().ToUpper();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" Player 2, informe seu nome: ");
            player2 = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.ResetColor();
        }

        static void Play() 
        {
            int collun;
            string oxSimbol;

            for (int i = 0; i < 9; i++)
            {

                if(i % 2 == 0)
                {
                    Console.WriteLine();
                    Console.Write($"{player1}, informe a linha (A, B ou C): ");
                    row = Console.ReadLine().ToUpper();
                    Console.Write($"Agora informe a coluna (0, 1 ou 2): ");
                    collun = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    oxSimbol = "X";

                    ConvertInputRow();
                }
                else
                {
                    Console.WriteLine();
                    Console.Write($"{player2}, informe a linha (A, B ou C): ");
                    row = Console.ReadLine().ToUpper();
                    Console.Write($"Agora informe a coluna (0, 1 ou 2): ");
                    collun = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    oxSimbol = "O";

                    ConvertInputRow();
                }

                ticTacToe[rowInt, collun] = oxSimbol;

                Console.WriteLine("    0 | 1 | 2");
                Console.WriteLine();
                //O primeiro for é row
                //o segundo for é Col
                for (int j = 0; j < 3; j++)
                {
                    Console.Write((char)('A' + j) + "   ");
                    for (int x = 0; x < 3; x++)
                    {
                        Console.Write(ticTacToe[j, x] + "  ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("    --------");
                }

                //se alguém ganhar: break
                if(Winner() == true)
                {
                    break;
                }
            }
           
           if(winNamePlayer == player1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"O ganhador(a) dessa partida é {player1}");
                Console.ResetColor();
            }
            else if(winNamePlayer == player2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"O ganhador(a) dessa partida é {player2}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Houve empate");
            }


            ShowOptions();
        }

        static bool Winner()
        {
            if (
                (ticTacToe[0, 0] == "X" && ticTacToe[0, 1] == "X" && ticTacToe[0, 2] == "X") ||
                (ticTacToe[1, 0] == "X" && ticTacToe[1, 1] == "X" && ticTacToe[1, 2] == "X") ||
                (ticTacToe[2, 0] == "X" && ticTacToe[2, 1] == "X" && ticTacToe[2, 2] == "X") ||

                (ticTacToe[0, 0] == "X" && ticTacToe[1, 0] == "X" && ticTacToe[2, 0] == "X") ||
                (ticTacToe[0, 1] == "X" && ticTacToe[1, 1] == "X" && ticTacToe[2, 1] == "X") ||
                (ticTacToe[0, 2] == "X" && ticTacToe[1, 2] == "X" && ticTacToe[2, 2] == "X") ||

                (ticTacToe[0, 2] == "X" && ticTacToe[1, 1] == "X" && ticTacToe[2, 0] == "X") ||
                (ticTacToe[0, 0] == "X" && ticTacToe[1, 1] == "X" && ticTacToe[2, 2] == "X")
               )
            {
                winNamePlayer = player1;
                countWinnerX++;
                return true;

            }
            else if (
                (ticTacToe[0, 0] == "O" && ticTacToe[0, 1] == "O" && ticTacToe[0, 2] == "O") ||
                (ticTacToe[1, 0] == "O" && ticTacToe[1, 1] == "O" && ticTacToe[1, 2] == "O") ||
                (ticTacToe[2, 0] == "O" && ticTacToe[2, 1] == "O" && ticTacToe[2, 2] == "O") ||

                (ticTacToe[0, 0] == "O" && ticTacToe[1, 0] == "O" && ticTacToe[2, 0] == "O") ||
                (ticTacToe[0, 1] == "O" && ticTacToe[1, 1] == "O" && ticTacToe[2, 1] == "O") ||
                (ticTacToe[0, 2] == "O" && ticTacToe[1, 2] == "O" && ticTacToe[2, 2] == "O") ||

                (ticTacToe[0, 2] == "O" && ticTacToe[1, 1] == "O" && ticTacToe[2, 0] == "O") ||
                (ticTacToe[0, 0] == "O" && ticTacToe[1, 1] == "O" && ticTacToe[2, 2] == "O")
                     ) 
            {
                winNamePlayer = player2;
                countWinnerO++;
                return true;
            }
            return false;
        }

        static void ShowOptions()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=- OPÇÕES =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1 - Jogar novamente");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("2 - Placar");
            Console.ResetColor();

            Console.WriteLine("0 - Sair do programa");
            Console.WriteLine();
            Console.Write("Digite a alternativa desejada: ");
            int optionUser = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (optionUser)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine();
                    Console.WriteLine(" -=-=-=- Let's play again! -=-=-=- ");
                    Console.ResetColor();

                    Array.Clear(ticTacToe);
                    Play();
                    break;
                case 2:
                    ShowScore();
                    break;
                case 0:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=- Programa encerrado =-=-=-=-=-=-=-=-=-=-=-=-");
                    Console.ResetColor();

                    break;
            }

        }

        static void ShowScore()
        {
            if (countWinnerO > countWinnerX)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Parabéns {player2} você é o(a) ganhador(a) atual");
                Console.ResetColor();

                Console.WriteLine($"{player2} --> {countWinnerO} pontos");
                Console.WriteLine("            X               ");
                Console.WriteLine($"{player1} --> {countWinnerX} pontos ");
            }
            else if (countWinnerO < countWinnerX)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Parabéns {player1} você é o(a) ganhador(a) atual");
                Console.ResetColor();

                Console.WriteLine($"   {player1} --> {countWinnerX} pontos");
                Console.WriteLine("            X               ");
                Console.WriteLine($"   {player2} --> {countWinnerO} pontos ");

            }
            else
            {
                Console.WriteLine("               Parece que ambos estão empatados,");
                Console.WriteLine("               continuem jogado para virar o jogo!");
            }

            ShowOptions();
        }

        

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=- JOGO DA VELHA =-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Ver as regras OU seguir direto para o jogo? (Regras/Jogar): ");
            string decisionStartOrRules = Console.ReadLine().ToLower();

            if(decisionStartOrRules == "regras") 
            {
                ShowRules();

                GetNamesPlayers();

                Play();
            }
            else
            {
                GetNamesPlayers();

                Play();
            }



        }
    }
}