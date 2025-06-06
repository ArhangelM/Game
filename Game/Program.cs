﻿namespace Game
{
    internal class Program
    {
        private static Player player;
        private static string[] quotesForPraise =
        {
            "Неймовiрно! Ця перемога була надзвичайно важливою!",
            "Неперевершено! Запам'ятай цю мить, навряд чи це повториться.",
            "Ти зробив це! Але лише тому, що я допомiг тобi"
        };

        private static string[] quotesForRaiseMorale =
        {
            "Я й не сумнiвався в твоєму програшi!",
            "Ти завжди збираєшся програвати?",
            "Ще одна жахлива гра! Нiчого нового."
        };

        private const int MIN_AGE = 12;

        static void Main(string[] args)
        {          
            try
            {
                Acquaintance();

                while (true)
                {
                    Preparation();
                    PlayGame();
                }
            }
            catch(Exception ex)
            {
                ColorWriteLine(ex.Message, ConsoleColor.DarkRed);
            }
        }

        private static void Acquaintance()
        {
            Console.WriteLine("Вiтаю в ексклюзивнiй грi \"Хрестики нолики\"");
            Console.Write("Познайомимось? Я - твiй помiчник Непереможенко. А як звуть тебе? ");
            string name = Console.ReadLine();
            Console.WriteLine($"Приємно познайомитись, {name}. А скiльки тобi рокiв?");

            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
                ColorWriteLine("Сталась прикра помилка. Перевiр правильнiсть введених даних.", ConsoleColor.DarkRed);

            if (age < MIN_AGE)
            {
                throw new Exception("Нажаль, ця гра доступна лише для користувачiв старших 12 рокiв. \n" +
                    $"Чекатиму на тебе через {MIN_AGE - age} рокiв! До зустрiчi!");
            }

            player = new Player(name, age);
            Console.Clear();
        }

        private static void Preparation()
        {
            int choice = 0;

            player.ShowStatistics();
            Console.WriteLine("Чи готовий ти зiграти? Чи готовий до поразки? Лише найвiдважнiшим та найсмiливiшим" +
                      " усмiхається удача! (1 - так / 2 - нi)");

            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 2))
                ColorWriteLine("Сталась прикра помилка. Перевiр правильнiсть введених даних.", ConsoleColor.DarkRed);

            if (choice == 2)
                throw new Exception($"Шкода! Набирайся смiливостi та повертайся в гру, {player.Name}");

            Console.Clear();
            Console.WriteLine("Гра розпочинається!");
        }

        private static void PlayGame()
        {
            int playerStep;
            int playerWins = 0;
            int pcWins = 0;

            player.NumberGames++;

            while(playerWins < 2 && pcWins < 2) 
            {
                ShowScore(playerWins, pcWins);

                Console.WriteLine("Обери вид зброї (1 - камiнь | 2 - ножицi | 3 - папiр)");

                while (!int.TryParse(Console.ReadLine(), out playerStep) || !Enum.IsDefined(typeof(StepType), playerStep))
                    ColorWriteLine("Уважно читай iнструкцiї, iнакше не буде навiть шансу на перемогу!" +
                        " Обери вид зброї (1 - камiнь | 2 - ножицi | 3 - папiр)", ConsoleColor.DarkRed);

                StepType pcStep = PCStep();
                Condition resultRound = PlayRound((StepType)playerStep, pcStep);

                UIManager.VisualizationRound((StepType)playerStep, pcStep);
                CheckRoundResult(resultRound, ref playerWins, ref pcWins);
            }

            CheckWinnerInBattle(playerWins);
        }

        private static StepType PCStep()
        {
            Random random = new Random();
            int pcStep = random.Next(1, Enum.GetValues(typeof(StepType)).Length + 1);
            return (StepType)pcStep;
        }

        private static Condition PlayRound(StepType playerStep, StepType pcStep)
        {
            Condition result = default;

            switch (playerStep)
            {
                case StepType.Rock:
                    result = pcStep switch
                    {
                        StepType.Scissors => Condition.Win,
                        StepType.Paper => Condition.Lose,
                        _ => Condition.Draw
                    };
                    break;

                case StepType.Scissors:
                    result = pcStep switch
                    {
                        StepType.Paper => Condition.Win,
                        StepType.Rock => Condition.Lose,
                        _ => Condition.Draw
                    };
                    break;

                case StepType.Paper:
                    result = pcStep switch
                    {
                        StepType.Rock => Condition.Win,
                        StepType.Scissors => Condition.Lose,
                        _ => Condition.Draw
                    };
                    break;
            }

            return result;
        }

        private static void CheckRoundResult(Condition resultRound, ref int playerWins, ref int pcWins)
        {
            switch (resultRound)
            {
                case Condition.Win:
                    ColorWriteLine("Цей раунд за тобою! Так тримати!", ConsoleColor.Green);
                    playerWins++;
                    break;
                case Condition.Lose:
                    ColorWriteLine("Цього раунду ти потерпiв невдачу! Але не переймайся, це трапиться ще не один раз", ConsoleColor.DarkRed);
                    pcWins++;
                    break;
                case Condition.Draw:
                    Console.WriteLine("Ваша удача однакова. Продовжуйте, щоб знайти переможця!");
                    break;
            }
        }

        private static void CheckWinnerInBattle(int playerWins)
        {
            Random random = new Random();

            if (playerWins >= 2)
            {                
                player.NumberWins++;

                int index = random.Next(quotesForPraise.Length);
                ColorWriteLine(quotesForPraise[index], ConsoleColor.Green);
            }
            else
            {
                int index = random.Next(quotesForRaiseMorale.Length);
                ColorWriteLine(quotesForRaiseMorale[index], ConsoleColor.DarkRed);
            }
        }

        private static void ShowScore(int playerWins, int pcWins)
        {
            Console.WriteLine("\t\t\t Поточний рахунок");
            Console.WriteLine($"Гравець {playerWins} - {pcWins} Комп'ютер");
        }

        private static void ColorWriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}