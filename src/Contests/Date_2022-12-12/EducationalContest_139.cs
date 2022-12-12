using System.Security.AccessControl;
using NUnit.Framework;

namespace Contests.Date_2022_12_12;

[TestFixture]
public class EducationalContest_139
{
    [Test]
    [TestCase(4, "momo", "YES")]
    [TestCase(8, "labacaba", "YES")]
    [TestCase(10, "codeforces", "NO")]
    [TestCase(5, "uohhh", "NO")]
    [TestCase(16, "isthissuffixtree", "YES")]
    [TestCase(1, "x", "NO")]
    public void P01_Notepad(int n, string str, string expected)
    {
        var ret = "NO";

        var letterSet = new HashSet<string>();

        for (var i = 0; i < n - 1; i++)
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

        Assert.AreEqual(expected, ret, "Calculated incorrectly.");
    }
    
    [Test]
    [TestCase(100, 19)]
    [TestCase(9, 9)]
    [TestCase(42, 13)]
    [TestCase(13, 10)]
    [TestCase(111, 19)]
    [TestCase(5000, 32)]
    public void P00_Extremely_Round(int number, int expected)
    {
        int ret;

        var ordinalCounter = 0; 
        while (number > 10)
        {
            if (number >= 100000)
            {
                number /= 100000;
                ordinalCounter += 5;
                continue;
            }

            if (number >= 10000)
            {
                number /= 10000;
                ordinalCounter += 4;
                continue;
            }
            
            if (number >= 1000)
            {
                number /= 1000;
                ordinalCounter += 3;
                continue;
            }

            if (number >= 100)
            {
                number /= 100;
                ordinalCounter += 2;
                continue;
            }

            number /= 10;
            ordinalCounter += 1;
        }

        ret = number + ordinalCounter * 9;

        Assert.AreEqual(expected, ret, "Calculated incorrectly.");
    }
}