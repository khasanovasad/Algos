using System;
using System.Text;

namespace DesignPatterns.Behavioural
{
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
}
