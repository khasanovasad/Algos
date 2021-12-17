namespace Tests.DesignPatterns.Behavioural;

[TestFixture]
public class TemplateMethodTests
{
    [Test]
    public void TemplateMethod_Should_Customize_The_Algorithm()
    {
        const string expectedBlackTeaServiceOutput = "1. Water is boiled.\n2. Add black tea.\n3. Serve the beverage.\n";
        const string expectedGreenTeaServiceOutput = "1. Water is boiled.\n2. Add green tea.\n3. Serve the beverage.\n";

        TeaService blackTea = new BlackTeaService();
        TeaService greenTea = new GreenTeaService();

        TestContext.WriteLine(expectedBlackTeaServiceOutput);
        TestContext.WriteLine(expectedGreenTeaServiceOutput);

        Assert.AreEqual(expectedBlackTeaServiceOutput, blackTea.DisplayAllTheSteps());
        Assert.AreEqual(expectedGreenTeaServiceOutput, greenTea.DisplayAllTheSteps());
    }
}