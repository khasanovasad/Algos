/**
 * GoF DEFINITION:
 * Define an object that encapsulates how a set of objects interact. Mediator promotes 
 * loose coupling by keeping objects from referring to each other explicitly, and it lets you 
 * vary their interaction independently.
 * 
 * CONCEPT:
 * A mediator is an intermediary through whom a group of objects communicates, but they 
 * cannot refer to each other directly. The mediator takes responsibility for controlling and 
 * coordinating the interactions among them. As a result, you can reduce the direct number 
 * of interconnections among different objects. So, using this pattern, you can reduce the 
 * coupling in an application. 
 */

namespace DesignPatterns.Behavioural;

public interface IMediator
{
    public void Register(Friend friend);
    public string Send(Friend fromFriend, Friend toFriend, string message);
    public string DisplayDetails();
}

public class Mediator : IMediator
{
    List<Friend> _participants = new();

    public void Register(Friend friend)
    {
        _participants.Add(friend);
    }

    public string Send(Friend fromFriend, Friend toFriend, string message)
    {
        if (!_participants.Contains(fromFriend) || !_participants.Contains(toFriend))
        {
            throw new Exception($"{fromFriend.Name} or {toFriend.Name} is not registered.");
        }

        toFriend.Receive(fromFriend, message);
        return $"[{fromFriend.Name}] posts: {message}\n";
    }

    public string DisplayDetails()
    {
        var strBuilder = new StringBuilder();
        strBuilder.Append(" --- Current list of participants: \n\n");
        foreach (var participant in _participants)
        {
            strBuilder.Append(participant.Name).Append('\n');
        }

        return strBuilder.ToString();
    }
}

public class Friend
{
    private IMediator _mediator;
    public string Name { get; set; }

    public Friend(string name, IMediator mediator) 
    {
        Name = name;
        _mediator = mediator; 
    }
    
    public string SendMessage(Friend toFriend, string message)
    {
        return _mediator.Send(this, toFriend, message);
    }

    public string Receive(Friend fromFriend, string message)
    {
        return $"{Name} has received a message from {fromFriend.Name} saying: {message}";
    }
}