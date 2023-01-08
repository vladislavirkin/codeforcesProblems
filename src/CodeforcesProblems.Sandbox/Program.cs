namespace CodeforcesProblems.Sandbox;

public static class Program
{
    public static void Main()
    {
        var testCasesCount = ReadIntLine();
        for (var j = 0; j < testCasesCount[0]; j++)
        {
            var str = Console.ReadLine();
            var numbers = ReadIntLine();

            var ret = "NO";
        
            numbers.Sort();

            // Numbers contained 2 items as least.
            if (numbers.Last() != numbers.First())
            {
                ret = "YES";
                var tmp = numbers.First();
                numbers[0] = numbers.Last();
                numbers[^1] = tmp;
            }

            Console.WriteLine(ret);
            if (ret == "YES")
            {
                for (var i = 0; i < numbers.Count; i++)
                    Console.Write(i == numbers.Count - 1 ? $"{numbers[i]}\n" : $"{numbers[i]} ");
            }
        }
    }
    
    private static List<T> ReadLine<T>(Func<string, T> func) => Console.ReadLine()?.Split(' ').Select(func).ToList();
    private static List<int> ReadIntLine() => ReadLine(int.Parse);
}