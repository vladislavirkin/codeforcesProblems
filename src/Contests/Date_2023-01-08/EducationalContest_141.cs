using NUnit.Framework;

namespace Contests.Date_2023_01_08;

[TestFixture]
public class EducationalContest_141
{
    [Test]
    [TestCase(new [] { 9, 5, 14 }, "YES")]
    [TestCase(new [] { 3, 3, 6, 6 }, "YES")]
    [TestCase(new [] { 10, 10 }, "NO")]
    [TestCase(new [] { 1, 2, 3, 4, 5 }, "YES")]
    [TestCase(new [] { 1, 4, 4 }, "YES")]
    public void P00_Make_It_Beautiful(int[] numbers, string expectedAnswer)
    {
        var ret = "NO";
        
        Array.Sort(numbers);

        // Numbers contained 2 items as least.
        if (numbers.Last() != numbers.First())
        {
            ret = "YES";
            numbers[0] += numbers.Last();
            numbers[^1] = numbers[0] - numbers[^1];
            numbers[0] -= numbers[^1];
        }

        Assert.AreEqual(expectedAnswer, ret, "Calculated incorrectly.");
    }
}