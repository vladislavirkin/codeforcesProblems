using NUnit.Framework;

namespace Contests.Date_2022_11_25;

[TestFixture]
public class Contest_835
{
    [Test]
    [TestCase(12,
        new [] { "a", "sururu", "errorgorn", "es", "se", "YesY", "esYesYesYesYesYesYe", "seY", "Yess",
            "sY", "o", "Yes" },
        new [] { "aa", "suurruurruus", "no", "yes", "no", "yes", "yes", "no", "no", "yes", "no", "yes" })]
    public void P00_SSeeeeiinngg_DDoouubbllee(int t, string[] responses, string[] expected)
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
}