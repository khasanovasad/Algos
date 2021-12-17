/**
 * GoF DEFINITION:
 * Use sharing to support large numbers of fine-grained objects efficiently. 
 * 
 * CONCEPT:
 * This pattern may look simple, but if you do not identify the core concepts, the 
 * implementations may appear to be complex. Let’s start with a basic but detailed 
 * explanation before you implement this pattern.
 *
 * Sometimes you need to handle lots of objects that are very similar but not exactly 
 * the same. The constraint is that you cannot create all of them to lessen resource and 
 * memory usage. The Flyweight pattern is made to handle these scenarios.
 *
 * Now the question is how to do that? To understand this, let’s quickly revisit the 
 * fundamentals of object-oriented programming. A class is a template or blueprint, and an 
 * object is an instance of that. An object can have states and behaviors. For example, if you 
 * are familiar with the game of football (or soccer, as it’s known in the United States), you can 
 * say that Ronaldo or Beckham are objects from the Footballer class. You may notice that 
 * they have states like “playing state” or “non-playing state.” In the playing state, they can 
 * show different skills (or behaviors)—they can run, they can kick, they can pass the ball, and 
 * so forth. To begin with object-oriented programming, you can ask the following questions.
 *   • What are the possible states of my objects?
 *   • What are the different functions (behaviors) that they can perform in those states? 
 *
 * Once you get the answers to these questions, you are ready to proceed. Now come 
 * back to the Flyweight pattern. Here your job is to identify.
 *   • What are the states of my objects?
 *   • Which part of these states can be changed?
 *
 * Once you identify the answers, you break the states into two parts, called intrinsic 
 * (which does not vary) and extrinsic (which can vary). Now you understand that if you 
 * make objects with intrinsic states that can be shared among all objects. For the extrinsic 
 * part, the user or client needs to pass the information. So, whenever you need to have 
 * an object, you can get the object with intrinsic states, and then you can configure the 
 * object on the fly by passing the extrinsic states. Following this technique, you can reduce 
 * unnecessary object creations and memory usage.
 *
 * A flyweight is a shared object that can be used in multiple contexts simultaneously. The 
 * flyweight acts as an independent object in each context—it’s indistinguishable from an instance 
 * of the object that’s not shared. Flyweights cannot make assumptions about the context in which 
 * they operate. The key concept here is the distinction between intrinsic and extrinsic state. 
 * The intrinsic state is stored in the flyweight; it consists of information that’s independent of 
 * the flyweight’s context, thereby making it sharable. The extrinsic state depends on and varies 
 * with the flyweight’s context and, therefore, can’t be shared. Client objects are responsible for 
 * passing the extrinsic state to the flyweight when it needs it.
 */

namespace DesignPatterns.Structural;

public interface IVehicle
{
    public string AboutMe(string color);
}

public class Car : IVehicle
{
    private string _description;

    public Car(string description)
    {
        _description = description;
    }

    public string AboutMe(string color)
    {
        return $"{_description} with {color} color.";
    }
}

public class Bus : IVehicle
{
    private string _description;

    public Bus(string description)
    {
        _description = description;
    }

    public string AboutMe(string color)
    {
        return $"{_description} with {color} color.";
    }
}

public class FutureVehicle : IVehicle
{
    private string _description;

    public FutureVehicle(string description)
    {
        _description = description;
    }

    public string AboutMe(string color)
    {
        return $"{_description} with blue color.";
    }
}

public class VehicleFactory
{
    private Dictionary<string, IVehicle> _vehicles = new Dictionary<string, IVehicle>();
        
    public int TotalObjectsCreated
    {
        get { return _vehicles.Count; }
    }

    public IVehicle GetVehicleFromVehicleFactory(string vehicleType)
    {
        IVehicle vehicle = null;
        if (_vehicles.ContainsKey(vehicleType))
        {
            vehicle = _vehicles[vehicleType];
        }
        else
        {
            switch (vehicleType)
            {
                case "car":
                    vehicle = new Car("One car is created");
                    _vehicles.Add("car", vehicle);
                    break;
                case "bus":
                    vehicle = new Bus("One bus is created");
                    _vehicles.Add("bus", vehicle);
                    break;
                case "future":
                    vehicle = new FutureVehicle("Vehicle 2050 is created");
                    _vehicles.Add("future", vehicle);
                    break;
                default:
                    throw new ArgumentException("Vehicle Factory can give cars and busses only.");
            }
        }

        return vehicle;
    }

}