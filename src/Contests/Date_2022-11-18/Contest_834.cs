using NUnit.Framework;

namespace Contests.Date_2022_11_18;

[TestFixture]
public class Contest_834
{
    [Test]
    [TestCase(12,
        new [] { "YES", "esYes", "codeforces", "es", "se", "YesY", "esYesYesYesYesYesYe", "seY", "Yess",
            "sY", "o", "Yes" },
        new [] { "no", "yes", "no", "yes", "no", "yes", "yes", "no", "no", "yes", "no", "yes" })]
    public void P00_Yes_Yes(int t, string[] responses, string[] expected)
    {
        var ret = new List<string>(t);
        var markers = new List<char> { 'Y', 'e', 's' };

        for (var i = 0; i < t; i++)
        {
            var response = responses[i].Trim();
            var firstLetter = response[..1].ToCharArray().First(); 

            if (!markers.Contains(firstLetter))
            {
                Console.WriteLine("no");
                ret.Add("no");
                continue;
            }

            var startIndex = markers.FindIndex(x => x == firstLetter);
            var isSuccess = true;
            
            foreach (var letter in response)
            {
                var expectedLetter = markers[startIndex % 3];
                
                if (letter != expectedLetter)
                {
                    isSuccess = false;
                    break;
                }
                
                startIndex++;
            }
            
            Console.WriteLine(isSuccess ? "yes" : "no");
            ret.Add(isSuccess ? "yes" : "no");
        }

        Assert.AreEqual(expected, ret.ToArray(), "Calculated incorrectly.");
    }
    
        public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(
            10,
            new List<List<int>>
            {
                new() { 6, 11 }, 
                new() { 5, 43 },
                new() { 13, 5 },
                new() { 4, 16 },
                new() { 10050, 12345 }, 
                new() { 2, 6 },
                new() { 4, 30 },
                new() { 25, 10 },
                new() { 2, 81 },
                new() { 1, 7 },
            },
            new List<int>
            {
                60,
                200,
                65,
                60,
                120600000,
                10,
                100,
                200,
                100,
                7,
            });
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void P03_MakeItRound(int t, List<List<int>> costs, List<int> expected)
    {
        var ret = new List<int>(t);

        for (var i = 0; i < t; i++)
        {
            var n = costs[i][0];
            var m = costs[i][1];




        }

        Assert.AreEqual(expected, ret.ToArray(), "Calculated incorrectly.");
    }

    private int GetLastNumber(int n)
    {
        while (n % 10 == 0)
        {
            n = n / 10;
        }

        return n % 10;
    }
    
    private bool CheckNumberForExtraTen(int number)
    {
        return number % 2 == 0 || number == 5;
    }
    
    private int GetTheBiggestMultiplier(int number, int sup)
    {
        var lastNumber = GetLastNumber(number);
        if (CheckNumberForExtraTen(lastNumber))
        {
            return GetRoundestNumber(number, lastNumber);
        }

        return GetRoundestNumber(sup);
    }

    private int GetRoundestNumber(int number, int lastNumber = 0)
    {
        var ret = string.Empty;
        var str = number.ToString();
        var digitsCount = str.Length;
        ret += str[..1];

        var secondDigitStr = str[1..2];
        var secondDigit = int.Parse(secondDigitStr);
        
        for (var i = 1; i < digitsCount; i++)
        {
            if (i == 0 && lastNumber > 0)
            {
                ret = CalculateLastNumber(ret, lastNumber, secondDigit);
                continue;
            }

            ret += "0";
        }

        return int.Parse(ret);
    }
    
    private string CalculateLastNumber(string ret, int lastNumber, int secondDigit)
    {
        if (lastNumber % 2 == 0 && secondDigit > 5)
            return ret + "5";
        if (lastNumber == 5 && secondDigit > 8)
            return ret + "8";
        if (lastNumber == 5 && secondDigit > 6)
            return ret + "6";
        if (lastNumber == 5 && secondDigit > 4)
            return ret + "4";
        if (lastNumber == 5 && secondDigit > 2)
            return ret + "2";

        return ret + "0";
    }
}