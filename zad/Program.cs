namespace zad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> listOfNumbers = new List<int>();
            while (n>0)
            {
                int number = int.Parse(Console.ReadLine());
                listOfNumbers.Add(number);
                n--;
            }
            Console.WriteLine($"sum={listOfNumbers.Sum()}");
            Console.WriteLine($"min = {listOfNumbers.Min()}");
        }
    }
}
