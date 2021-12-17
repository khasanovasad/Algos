/**
 * GoF DEFINITION:
 * Define a family of algorithms, encapsulates each one, and makes them interchangeable. 
 * Strategy lets the algorithm vary independently from clients that use it.
 *
 * CONCEPT:
 * A client can select an algorithm from a set of algorithms dynamically at runtime. This 
 * pattern also provides a simple way to use the selected algorithm.
 * You know that an object can have states and behaviors. And some of these behaviors 
 * may vary among the objects of a class. This pattern focuses on the changing behaviors 
 * that can be associated with an object at a specific time.
 * In our example, you see a Vehicle class. You can create a vehicle object using this 
 * class. Once a Vehicle object is created, you can add and set behaviors to this object. 
 * Inside the client code, you can replace the current behavior with a new behavior too. 
 * Most interestingly, you see that since the behaviors can be changed, the vehicle class is 
 * not defining the behavior; it is simply delegating the task to an object referenced by a 
 * vehicle. The overall implementation can make the concept clearer to you.
 */

namespace DesignPatterns.Behavioural;

public interface IInstructorBehaviour
{
    public string AboutMe();
}

public class TeachesOS : IInstructorBehaviour
{
    public string AboutMe()
    {
        return "Instructor, now, teaches Operating Systems.";
    }
}

public class TeachesDBMS : IInstructorBehaviour
{
    public string AboutMe()
    {
        return "Instructor, now, teaches Database Management Systems.";
    }
}

public class TeachesDSA : IInstructorBehaviour
{
    public string AboutMe()
    {
        return "Instructor, now, teaches Data Structures and Algorithms.";
    }
}

public class InitialBehaviour : IInstructorBehaviour
{
    public string AboutMe()
    {
        return "This is the default behaviour. Instructor, now, does not teach any subject.";
    }
}

public class Instructor
{
    private IInstructorBehaviour _behaviour;
        
    public Instructor()
    {
        _behaviour = new InitialBehaviour();
    }

    public void SerInstructorBehaviour(IInstructorBehaviour behaviour)
    {
        _behaviour = behaviour;
    }

    public string AboutMe()
    {
        return _behaviour.AboutMe();
    }
}