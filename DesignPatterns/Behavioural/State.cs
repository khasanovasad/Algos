/**
 * GoF DEFINITION:
 * Allow an object to alter its behavior when its internal state changes. The object will 
 * appear to change its class.
 * 
 * CONCEPT:
 * The GoF definition is easy to understand. It simply states that an object can change what 
 * it does based on its current state.
 * Suppose that you are dealing with a large-scale application where the codebase 
 * is rapidly growing. As a result, the situation becomes complex, and you may need to 
 * introduce lots of if-else blocks/switch statements to guard the various conditions. The 
 * State pattern fits in such a context. It allows your objects to behave differently based on 
 * their current state, and you can define state-specific behaviors with different classes.
 * In this pattern, you think in terms of your application’s possible states, and you 
 * segregate the code accordingly. Ideally, each of the states is independent of other states. 
 * You keep track of these states, and your code responds according to the behavior of the 
 * current state. For example, suppose that you are watching a program on your television (TV). 
 * Now, if you press the Mute button on the TV’s remote control, there is a state change on 
 * your TV. But there is no change if the TV is already in a switched-off mode.
 * So, the basic idea is that if your code can track the current state of the application, 
 * you can centralize the task, segregate your code, and respond accordingly. 
 */

using System;

namespace DesignPatterns.Behavioural
{
    public interface IPossibleStates
    {
        public string PressOnButton(TV context);
        public string PressOffButton(TV context);
        public string PressMuteButton(TV context);
    }

    public class Off : IPossibleStates
    {
        public Off()
        {
            Console.WriteLine(" --- TV is OFF now. --- ");
        }

        public string PressOnButton(TV context)
        {
            context.CurrentState = new On();
            return $"TV was off. Going from OFF state to ON state.\n";
        }

        public string PressOffButton(TV context)
        {
            return $"TV was off already. No state change.\n";
        }

        public string PressMuteButton(TV context)
        {
            return $"TV is off. No state change.\n";
        }
    }

    public class On : IPossibleStates
    {
        public On()
        {
            Console.WriteLine(" --- TV is ON now. --- ");
        }

        public string PressOnButton(TV context)
        {
            return $"TV was already ON. No state change.\n";
        }

        public string PressOffButton(TV context)
        {
            context.CurrentState = new Off();
            return $"TV was ON. Going from ON state to OFF state.\n";
        }

        public string PressMuteButton(TV context)
        {
            context.CurrentState = new Mute();
            return $"TV was ON. Going from ON state to MUTE state.\n";
        }
    }

    public class Mute : IPossibleStates
    {
        public Mute()
        {
            Console.WriteLine(" --- TV is MUTE now. --- ");
        }

        public string PressOnButton(TV context)
        {
            context.CurrentState = new On();
            return $"TV was MUTE. Going from MUTE state to ON state.\n";
        }

        public string PressOffButton(TV context)
        {
            context.CurrentState = new Off();
            return $"TV was MUTE. Going from MUTE state to OFF state.\n";
        }

        public string PressMuteButton(TV context)
        {
            return $"TV was already MUTE. No state change.\n";
        }
    }

    public class TV 
    { 
        public IPossibleStates CurrentState { get; set; }

        public TV()
        {
            CurrentState = new Off();
        }

        public string ExecuteOnButton()
        {
            return CurrentState.PressOnButton(this);
        }

        public string ExecuteOffButton()
        {
            return CurrentState.PressOffButton(this);
        }

        public string ExecuteMuteButton()
        {
            return CurrentState.PressMuteButton(this);
        }
    }
}
