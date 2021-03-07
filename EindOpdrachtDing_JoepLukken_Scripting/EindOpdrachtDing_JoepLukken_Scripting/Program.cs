using System;

namespace EindOpdrachtDing_JoepLukken_Scripting
{
    class Program
    {
        static void Menu()
        {
            int gameBegin;

            Console.WriteLine("Hello, choose one of the following: \n");
            Console.WriteLine("[1] Read the rules");
            Console.WriteLine("[2] Start the game");
            Console.WriteLine("[3] Exit the game");
            gameBegin = int.Parse(Console.ReadLine());

            if (gameBegin == 1)
            {
                Rules();
            }
            else if (gameBegin == 2)
            {
                StartGame();
            }
            else if (gameBegin == 3)
            {
                End();
            }
            else
            {
                Console.WriteLine("\n PLEASE TRY AGAIN!\n");
                Menu();
            }

            static void Rules()
            {
                Console.WriteLine("\nThese are the rules: \n");
                Console.WriteLine("This is a 1v1 game.");
                Console.WriteLine("Each player has 10 lifes.");
                Console.WriteLine("And each player has two dice that go from 1-11.");
                Console.WriteLine("The game ends when one player gets to 0 lifes.");
                Console.WriteLine("So yea it's just a luck based game");
                Console.WriteLine("\nHave fun :)");
                Continue();
                StartGame();
            }

            static void Continue()
            {
                Console.WriteLine("\nPLEASE PRESS ENTER TO CONTINUE");
                Console.ReadLine();
                Console.Clear();
            }

            static void End()
            {
                Console.WriteLine("\nEnding game...");
            }

            static void StartGame()
            {
                Console.WriteLine("\nStarting game...\n");

                Game();
            }

            static void Game()
            {
                string Player1;
                string Player2;

                Console.WriteLine("Player 1 what is your name?");
                Player1 = Console.ReadLine();
                Console.WriteLine($"Player 1, your name is {Player1}\n");

                Console.WriteLine("PLayer 2 what is your name?");
                Player2 = Console.ReadLine();
                Console.WriteLine($"Player 2, your name is {Player2}\n");

                Continue();
                //-------------------------------
                int d11Roll;

                Random rnd = new Random();

                d11Roll = rnd.Next(1, 11);

                int rollDice(int sides)
                {
                    return rnd.Next(1, sides + 1);
                }

                int lifesP1 = 10;
                int lifesP2 = 10;

                int dice1 = rollDice(11);
                int dice2 = rollDice(11);
                int totalP1 = dice1 + dice2;

                int dice3 = rollDice(11);
                int dice4 = rollDice(11);
                int totalP2 = dice3 + dice4;
                //-------------------------------
                RoundBattle();
                //-------------------------------
                void RoundBattle()
                {
                    Console.WriteLine($"{Player1} : {lifesP1} lifes");
                    Console.WriteLine($"{Player2} : {lifesP2} lifes\n");

                    Console.WriteLine($"{Player1} rolled {totalP1}");
                    Console.WriteLine($"{Player2} rolled {totalP2}\n");

                    if(totalP1 < totalP2)
                    {
                        Console.WriteLine($"{Player1} lost to {Player2}, {Player1} will lose one life!");
                        lifesP1--;
                    }else if(totalP2 < totalP1)
                    {
                        Console.WriteLine($"{Player2} lost to {Player1}, {Player2} will lose one life!");
                        lifesP2--;
                    }
                    else
                    {
                        Console.WriteLine("A tie!!");
                    }
                    Continue();
                }
                while(lifesP1 > 0 && lifesP2 > 0)
                {
                    dice1 = rollDice(11);
                    dice2 = rollDice(11);
                    totalP1 = dice1 + dice2;

                    dice3 = rollDice(11);
                    dice4 = rollDice(11);
                    totalP2 = dice3 + dice4;

                    RoundBattle();
                }

                if(lifesP1 < 1)
                {
                    Console.WriteLine("\nUh oh! someone lost :D");
                    Continue();

                    Console.WriteLine($"Looks to me like {Player1} lost");
                    Console.WriteLine($"This makes {Player2} the winner!!");
                    Console.WriteLine("That was the game\n");
                    Console.WriteLine("PRESS ENTER TO GO BACK TO MAIN MENU");
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                }else if (lifesP2 < 1)
                {
                    Console.WriteLine("\nUh oh! someone lost :D");
                    Continue();

                    Console.WriteLine($"Looks to me like {Player2} lost");
                    Console.WriteLine($"This makes {Player1} the winner!!");
                    Console.WriteLine("That was the game\n");
                    Console.WriteLine("PRESS ENTER TO GO BACK TO MAIN MENU");
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                }
            }

            



        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
