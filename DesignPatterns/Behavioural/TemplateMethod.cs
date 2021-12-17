/**
 * GoF DEFINITION:
 * Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. 
 * Template method lets subclasses redefine certain steps of an algorithm without 
 * changing the algorithm’s structure.
 * 
 * CONCEPT:
 * Using this pattern, you begin with the minimum or essential structure of an algorithm. 
 * Then you defer some responsibilities to the subclasses. As a result, the derived class can 
 * redefine some steps of an algorithm without changing the flow of the algorithm.
 * Simply, this design pattern is useful when you implement a multistep algorithm but 
 * allow customization through subclasses. 
 */

namespace DesignPatterns.Behavioural;

public abstract class TeaService
{
    public string BoilWater()
    {
        return "1. Water is boiled.";
    }

    public abstract string SpecialStep();

    public string Serve()
    {
        return "3. Serve the beverage.";
    }

    public string DisplayAllTheSteps()
    {
        var strBuilder = new StringBuilder();
        strBuilder.Append(BoilWater()).Append('\n');
        strBuilder.Append(SpecialStep()).Append('\n');
        strBuilder.Append(Serve()).Append('\n');
        return strBuilder.ToString();
    }
}

public class BlackTeaService : TeaService
{
    public override string SpecialStep()
    {
        return "2. Add black tea.";
    }
}

public class GreenTeaService : TeaService
{
    public override string SpecialStep()
    {
        return "2. Add green tea.";
    }
}