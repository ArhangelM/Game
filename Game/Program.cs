namespace Game
{
    internal class Program
    {
        private static Player player;
        static void Main(string[] args)
        {          
            try
            {
                Acquaintance();
                Preparation();
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
            player.ShowStatistics();
        }

        private static void Preparation()
        {
            Console.WriteLine("Чи готовий ти зіграти? Чи готовий до поразки? Лише найвідважнішим та найсміливішим" +
                      " усміхається удача! (1 - так / 2 - ні)");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 2))
            {
                Console.WriteLine("Сталась прикра помилка. Перевір правильність введених даних.");
            }

            if (choice == 2)
                throw new Exception($"Шкода! Набирайся сміливості та повертайся в гру, {player.Name}");
        }
    }
}