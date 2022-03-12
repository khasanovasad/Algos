using System;
using NUnit.Framework;
using DesignPatterns.Structural;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Tests.Structural;

[TestFixture]
public class FlyweightTests
{
    [Test]
    public void Flyweight_Should_Reuse_Already_Created_Objects()
    {
        string GetRandomColor()
        {
            Random random = new Random();
            int randomNumber = random.Next(100);
            if (randomNumber % 2 == 0)
            {
                return "red";
            }
            else
            {
                return "green";
            }
        }

        var stringBuilder = new StringBuilder();
        var vehicleFactory = new VehicleFactory();
        IVehicle vehicle;

        for (int i = 0; i < 3; ++i)
        {
            vehicle = vehicleFactory.GetVehicleFromVehicleFactory(vehicleType: "car");
            stringBuilder.Append(vehicle.AboutMe(GetRandomColor())).Append('\n');
        }
        TestContext.WriteLine($"Number of distinct IVehicle objects created: {vehicleFactory.TotalObjectsCreated}");
            
        for (int i = 0; i < 5; ++i)
        {
            vehicle = vehicleFactory.GetVehicleFromVehicleFactory(vehicleType: "bus");
            stringBuilder.Append(vehicle.AboutMe(GetRandomColor())).Append('\n');
        }
        TestContext.WriteLine($"Number of distinct IVehicle objects created: {vehicleFactory.TotalObjectsCreated}");

        for (int i = 0; i < 2; ++i)
        {
            vehicle = vehicleFactory.GetVehicleFromVehicleFactory(vehicleType: "future");
            stringBuilder.Append(vehicle.AboutMe(GetRandomColor())).Append('\n');
        }
        TestContext.WriteLine($"Number of distinct IVehicle objects created: {vehicleFactory.TotalObjectsCreated}");

        TestContext.WriteLine(stringBuilder.ToString());
        Assert.AreEqual(3, vehicleFactory.TotalObjectsCreated);
    }
}