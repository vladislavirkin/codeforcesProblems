using NUnit.Framework;

namespace Contests.Date_2022_12_11;

[TestFixture]
public class Contest_837
{
    [Test]
    [TestCase(new [] { 9, 5, 14 }, "NO")]
    [TestCase(new [] { 32, 48, 7 }, "YES")]
    [TestCase(new [] { 2, 2, 2, 2, 2, 2, 2, 2, 2 }, "YES")]
    [TestCase(new [] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, "NO")]
    [TestCase(new [] { 1, 2, 3, 4, 5 }, "YES")]
    [TestCase(new [] { 6 }, "NO")]
    public void P02_Hossam_and_Trainees(int[] numbers, string expected)
    {
        var ret = "NO";
        Array.Sort(numbers);

        var allDivisors = new HashSet<int>();

        foreach (var number in numbers)
        {
            var divisors = Factorize(number);
            if (divisors.Any(divisor => !allDivisors.Add(divisor)))
            {
                ret = "YES";
            }

            if (ret == "YES")
                break;
        }
        
        Assert.AreEqual(expected, ret, "Calculated incorrectly.");
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
    
    [Test]
    [TestCase(new [] { 6, 2, 3, 8, 1 }, 2)]
    [TestCase(new [] { 7, 2, 8, 3, 2, 10 }, 4)]
    [TestCase(new [] { 5, 5 }, 2)]
    [TestCase(new [] { 5, 5, 5 }, 6)]
    [TestCase(new [] { 5, 5, 5, 5, 5, 5 }, 30)]
    [TestCase(new [] { 7, 2, 2, 2, 2, 10, 10, 10, 10, 10 }, 40)]
    public void P00_Hossam_and_Combinatorics(int[] numbers, int expected)
    {
        long ret;
        Array.Sort(numbers);

        var max = numbers.Last();
        var min = numbers.First();

        if (max == min)
        {
            var count = numbers.Length;
            ret = count * (count - 1);
        }
        else
        {
            var maxCount = numbers.Count(x => x == max);
            var minCount = numbers.Count(x => x == min);
            ret = 2 * maxCount * minCount;
        }

        Assert.AreEqual(expected, ret, "Calculated incorrectly.");
    }
}