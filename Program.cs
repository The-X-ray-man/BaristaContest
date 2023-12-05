namespace Svetli_BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> quantities = new Dictionary<int, string>()
            { 
            {  50, "Cortado" },
            {  75, "Espresso" },
            { 100, "Capuccino" },
            { 150 , "Americano" },
            { 200 , "Latte" }
            };
            Queue<int> coffees = new Queue<int> (Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> milks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Dictionary<string, int> madeBeverages = new Dictionary<string, int>();
            while (coffees.Count >0 && milks.Count > 0)
            {
                int coffee = coffees.Dequeue();
                int milk = milks.Pop();
                if (quantities.ContainsKey(coffee + milk))
                {
                    string beverageType = quantities[coffee + milk];
                    if (!madeBeverages.ContainsKey(beverageType)) madeBeverages.Add(beverageType, 0);
                    madeBeverages[beverageType] ++;
                }
                else milks.Push(milk - 5);
            }
            if (coffees.Count == 0 && milks.Count == 0) Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            else Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            Console.Write("Coffee left: ");
            if (coffees.Count != 0) Console.WriteLine(string.Join(", ", coffees)); else Console.WriteLine("none");
            Console.Write("Milk left: ");
            if (milks.Count != 0) Console.WriteLine(string.Join (", ", milks)); else Console.WriteLine("none");
            foreach(var beverage in madeBeverages.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{beverage.Key}: {beverage.Value}");
            }
        }
    }
}
