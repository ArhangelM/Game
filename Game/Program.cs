namespace Game
{
    internal class Program
    {
        private static Player player;
        private static string[] quotesForPraise =
        {
            "Неймовірно! Ця перемога була надзвичайно важливою!",
            "Неперевершено! Запам'ятай цю мить, навряд чи це повториться.",
            "Ти зробив це! Але лише тому, що я допоміг тобі"
        };

        private static string[] quotesForRaiseMorale =
        {
            "Я й не сумнівався в твоєму програші!",
            "Ти завжди збираєшся програвати?",
            "Ще одна жахлива гра! Нічого нового."
        };

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
                Console.WriteLine(ex.Message);
            }
        }

        private static void Acquaintance()
        {
            Console.WriteLine("Вітаю в ексклюзивній грі \"Хрестики нолики\"");
            Console.Write("Познайомимось? Я - твій помічник Непереможенко. А як звуть тебе? ");
            string name = Console.ReadLine();
            Console.WriteLine($"Приємно познайомитись, {name}. А скільки тобі років?");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Сталась прикра помилка. Перевір правильність введених даних.");
            }

            if (age < 12)
            {
                throw new Exception("Нажаль, ця гра доступна лише для користувачів старших 12 років. \n" +
                    $"Чекатиму на тебе через {12 - age} років! До зустрічі!");
            }

            player = new Player(name, age);
            Console.Clear();
        }

        private static void Preparation()
        {
            int choice = 0;

            player.ShowStatistics();
            Console.WriteLine("Чи готовий ти зіграти? Чи готовий до поразки? Лише найвідважнішим та найсміливішим" +
                      " усміхається удача! (1 - так / 2 - ні)");

            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 2))
            {
                Console.WriteLine("Сталась прикра помилка. Перевір правильність введених даних.");
            }

            if (choice == 2)
                throw new Exception($"Шкода! Набирайся сміливості та повертайся в гру, {player.Name}");

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

                Console.WriteLine("Обери вид зброї (1 - камінь | 2 - ножиці | 3 - папір)");

                while (!int.TryParse(Console.ReadLine(), out playerStep) || !Enum.IsDefined(typeof(StepType), playerStep))
                    Console.WriteLine("Уважно читай інструкції, інакше не буде навіть шансу на перемогу!" +
                        " Обери вид зброї (1 - камінь | 2 - ножиці | 3 - папір)");

                StepType pcStep = PCStep();
                Condition resultRound = PlayRound((StepType)playerStep, pcStep);

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
                    Console.WriteLine("Цей раунд за тобою! Так тримати!");
                    playerWins++;
                    break;
                case Condition.Lose:
                    Console.WriteLine("Цього раунду ти потерпів невдачу! Але не переймайся, це трапиться ще не один раз");
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
                Console.WriteLine(quotesForPraise[index]);
            }
            else
            {
                int index = random.Next(quotesForRaiseMorale.Length);
                Console.WriteLine(quotesForRaiseMorale[index]);
            }
        }

        private static void ShowScore(int playerWins, int pcWins)
        {
            Console.WriteLine("\t\t\t Поточний рахунок");
            Console.WriteLine($"Гравець {playerWins} - {pcWins} Комп'ютер");
        }
    }
}