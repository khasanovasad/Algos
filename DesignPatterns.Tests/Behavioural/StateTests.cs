using System;
using NUnit.Framework;
using DesignPatterns.Behavioural;
using System.Text;

namespace Tests.DesignPatterns.Behavioural;

[TestFixture]
public class StateTests
{
    [Test]
    public void State_Should_Change_Or_Not_Change_State_According_To_The_Current_State()
    {
        const string expectedOutput = "TV was off already. No state change.\n\nTV is off. No state change.\n\nTV was off. Going from OFF state to ON state.\n\nTV was already ON. No state change.\n\nTV was ON. Going from ON state to MUTE state.\n\nTV was already MUTE. No state change.\n\nTV was MUTE. Going from MUTE state to OFF state.\n\n";

        var strBuilder = new StringBuilder();
        var tv = new TV();

        /// OFF -> MUTE -> ON -> ON -> MUTE -> MUTE -> OFF
        strBuilder.Append(tv.ExecuteOffButton()).Append('\n');
        strBuilder.Append(tv.ExecuteMuteButton()).Append('\n');
        strBuilder.Append(tv.ExecuteOnButton()).Append('\n');
        strBuilder.Append(tv.ExecuteOnButton()).Append('\n');
        strBuilder.Append(tv.ExecuteMuteButton()).Append('\n');
        strBuilder.Append(tv.ExecuteMuteButton()).Append('\n');
        strBuilder.Append(tv.ExecuteOffButton()).Append('\n');

        // TestContext.WriteLine(strBuilder.ToString());
        Assert.AreEqual(expectedOutput, strBuilder.ToString());
    }
}