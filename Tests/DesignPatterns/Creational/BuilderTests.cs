using System;
using NUnit.Framework;
using DesignPatterns.Creational;

namespace Tests.DesignPatterns.Creational
{
    [TestFixture]
    public class BuilderTests
    {
        [Test]
        public void Builder_Should_Correctly_Build_The_Object()
        {
            const uint id = 69;
            const string username = "john_doe";
            const string password = "as8%d2n3dj#8912n";
            const string firstName = "John";
            const string middleName = "Frankie";
            const string lastName = "Doe";
            var dateOfBirth = new DateTime(day: 11, month: 03, year: 1985);
            const string currentAddress = "Linzer Strasse 64, Bach, Austria";
            const string birthPlace = "Sandleitengasse 41, KnierUbl, Austria";

            var userObject = new UserObjectBuilder().WithId(id)
                .WithUsername(username)
                .WithPassword(password)
                .WithFirstName(firstName)
                .WithMiddleName(middleName)
                .WithLastName(lastName)
                .WithDateOfBirth(dateOfBirth)
                .WithCurrentAddress(currentAddress)
                .WithBirthPlace(birthPlace)
                .Build();

            Assert.AreEqual(id, userObject.Value.Id);
            Assert.AreEqual(username, userObject.Value.Username);
            Assert.AreEqual(password, userObject.Value.Password);
            Assert.AreEqual(firstName, userObject.Value.FirstName);
            Assert.AreEqual(middleName, userObject.Value.MiddleName);
            Assert.AreEqual(lastName, userObject.Value.LastName);
            Assert.AreEqual(dateOfBirth, userObject.Value.DateOfBirth);
            Assert.AreEqual(currentAddress, userObject.Value.CurrentAddress);
            Assert.AreEqual(birthPlace, userObject.Value.BirthPlace);
        }
    }
}