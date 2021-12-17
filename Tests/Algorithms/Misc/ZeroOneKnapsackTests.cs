namespace Tests.Algorithms.Misc;

[TestFixture]
public class ZeroOneKnapsackTests
{
    [Test]
    public void Calculate_Should_When()
    {
        int capacity = 6;
        int[] V = { 30, 20, 100, 90, 160 };
        int[] W = { 2, 1, 2, 4, 3 };

        var result = ZeroOneKnapsack.Calculate(V, W, capacity);
        
        Assert.AreEqual(280, result);
    }
}