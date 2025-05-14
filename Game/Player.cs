namespace Game
{
    internal class Player
    {
        public string Name { get; }
        public int Age { get; }
        public int NumberGames { get; }
        public int NumberWins { get; }

        public Player(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void ShowStatistics()
        {
            Console.WriteLine("\t\t\t*****Статистика*****");
            Console.WriteLine($"Нiкнейм: {Name}");
            Console.WriteLine($"Вік: {Age}");
            Console.WriteLine($"Кiлькість зiграних iгор за сесiю: {NumberWins}");
            Console.WriteLine($"Кiлькість перемог: {NumberWins}");
        }
    }
}
