using System.Text;

namespace CodeforcesProblems.Sandbox;

public static class Program
{
    public static void Main()
    {
        var testCasesCount = ReadIntLine();
        for (var j = 0; j < testCasesCount[0]; j++)
        {
            var numbers = ReadIntLine();
            var str = Console.ReadLine();

            var ret = "NO";

            var letterSet = new HashSet<string>();

            for (var i = 0; i < numbers[0] - 1; i++)
            {
                var substr = str.Substring(i, 2);
                if (letterSet.Contains(substr))
                {
                    ret = "YES";
                    break;
                }

                if (i > 0)
                    letterSet.Add(str.Substring(i - 1, 2));
            }
            
            Console.WriteLine(ret);
        }
    }
    
    private static List<T> ReadLine<T>(Func<string, T> func) => Console.ReadLine()?.Split(' ').Select(func).ToList();
    private static List<int> ReadIntLine() => ReadLine(int.Parse);
}