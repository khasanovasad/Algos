using System;
using DesignPatterns.Creational;
using NUnit.Framework;

namespace Tests.DesignPatterns.Creational
{
    [TestFixture]
    public class PrototypeTests
    {
        [Test]
        public void Prototype_Clone_Should_Create_New_Object_Based_On_The_Prototype()
        {
            var sourceFile = new SourceFile();
            sourceFile.Content.Add("using System;");
            sourceFile.Content.Add("Console.WriteLine(\"Hello, World!\")");

            SourceFile clonedObject = sourceFile.Clone();
            
            Assert.AreNotSame(sourceFile, clonedObject);
            
            // this is true because of shallow copy
            Assert.AreSame(sourceFile.Content, clonedObject.Content);
            Assert.AreEqual(sourceFile.Content[0], clonedObject.Content[0]);
            Assert.AreEqual(sourceFile.Content[1], clonedObject.Content[1]);
            Assert.AreEqual(sourceFile.LinesOfCode, clonedObject.LinesOfCode);
        }
    }
}