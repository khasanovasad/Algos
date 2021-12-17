using System;
using NUnit.Framework;
using DesignPatterns.Behavioural;
using System.Text;

namespace Tests.DesignPatterns.Behavioural;

[TestFixture]
public class StrategyTests
{
    [Test]
    public void Strategy_Should_Dynamically_Alter_The_Behaviour()
    {
        const string expectedOutput = "This is the default behaviour. Instructor, now, does not teach any subject.\nInstructor, now, teaches Operating Systems.\nInstructor, now, teaches Database Management Systems.\nInstructor, now, teaches Data Structures and Algorithms.\n";
        var strBuilder = new StringBuilder();
        var instructor = new Instructor();

        strBuilder.Append(instructor.AboutMe()).Append('\n');

        instructor.SerInstructorBehaviour(new TeachesOS());
        strBuilder.Append(instructor.AboutMe()).Append('\n');

        instructor.SerInstructorBehaviour(new TeachesDBMS());
        strBuilder.Append(instructor.AboutMe()).Append('\n');

        instructor.SerInstructorBehaviour(new TeachesDSA());
        strBuilder.Append(instructor.AboutMe()).Append('\n');

        // TestContext.WriteLine(strBuilder.ToString());
        Assert.AreEqual(expectedOutput, strBuilder.ToString());
    }
}