using System.Text;

namespace CodeforcesProblems.Sandbox;

public static class Program
{
    public static void Main()
    {
        var testCasesCount = ReadIntLine();
        for (var i = 0; i < testCasesCount[0]; i++)
        {
            var ret = "NO";
            var numbersCount = ReadIntLine();
            var numbers = ReadIntLine();
            
            numbers.Sort();

            var allDivisors = new HashSet<int>();

            foreach (var number in numbers)
            {
                var divisors = Factorize(number);
                foreach (var divisor in divisors)
                {
                    if (allDivisors.Contains(divisor))
                    {
                        ret = "YES";
                        break;
                    }

                    allDivisors.Add(divisor);
                }

                if (ret == "YES")
                    break;
            }
            
            Console.WriteLine(ret);
        }
    }

    private static HashSet<int> Factorize(int number)
    {
        var ret = new HashSet<int>();
        
        if (number % 2 == 0)
        {
            ret.Add(2);
            number /= 2;
        }
        
        for(var i = 3; i * i <= number; i += 2)
        {
            while (number % i == 0)
                number /= i;
            ret.Add(i);
        }
        
        if (number > 1)
            ret.Add(number);

        return ret;
    }
    
    private static void AddLine(this StringBuilder sb, object s)
    {
        sb.Append(s.ToString());
        sb.Append('\n');
    }
    private static void Print(this StringBuilder sb) => Console.Write(sb.ToString());
    private static List<T> ReadLine<T>(Func<string, T> func) => Console.ReadLine()?.Split(' ').Select(func).ToList();
    private static List<int> ReadIntLine() => ReadLine(int.Parse);
    private static List<long> ReadLongLine() => ReadLine(long.Parse);
    private static List<ulong> ReadUlongLine() => ReadLine(ulong.Parse);
}