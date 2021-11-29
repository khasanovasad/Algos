using System;
using NUnit.Framework;
using DesignPatterns.Behavioural;
using System.Text;

namespace Tests.DesignPatterns.Behavioural
{
    [TestFixture]
    public class MediatorTests
    {
        [Test]
        public void Mediator_Test()
        {
            const string expectedOutput = "[Chris] posts: Hello, Rocky. Can we do a collab?\n\n[Rocky] posts: Hello, Chris. Yes. Absolutely!\n\n";

            var strBuilder = new StringBuilder();
            IMediator mediator = new Mediator();
            var friend1 = new Friend("Chris", mediator);
            var friend2 = new Friend("Rocky", mediator);

            mediator.Register(friend1);
            mediator.Register(friend2);

            // friend3 is not registered
            var friend3 = new Friend("Virgil", mediator);

            strBuilder.Append(friend1.SendMessage(friend2, "Hello, Rocky. Can we do a collab?")).Append('\n');
            strBuilder.Append(friend2.SendMessage(friend1, "Hello, Chris. Yes. Absolutely!")).Append('\n');

            // TestContext.WriteLine(strBuilder.ToString());
            var exception = Assert.Throws<Exception>(() => friend3.SendMessage(friend1, "Wtf?"));
            Assert.AreEqual(exception.Message, "Virgil or Chris is not registered.");
            Assert.AreEqual(expectedOutput, strBuilder.ToString());
        }
    }
}
