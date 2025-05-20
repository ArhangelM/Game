namespace Game
{
    internal class Player
    {
        public string Name { get; }
        public int Age { get; }
        public int NumberGames { get; set; }
        public int NumberWins { get; set; }

        public Player(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void ShowStatistics()
        {
            Console.WriteLine("\t\t\t*****Статистика*****");
            Console.WriteLine($"Нiкнейм: {Name}");
            Console.WriteLine($"Вiк: {Age}");
            Console.WriteLine($"Кiлькiсть зiграних iгор за сесiю: {NumberGames}");
            Console.WriteLine($"Кiлькiсть перемог: {NumberWins}");
        }
    }
}
