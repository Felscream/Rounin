//source https://lcmccauley.wordpress.com/2015/04/20/x360-input-tutorial-unity-p1/
using UnityEngine;
using XInputDotNetPure;
using System.Collections.Generic;

namespace X360
{
    // Stores states of a single gamepad button
    public struct XButton
    {
        public ButtonState prev_state;
        public ButtonState state;
    }

    // Stores state of a single gamepad trigger
    public struct TriggerState
    {
        public float prev_value;
        public float current_value;
    }

    // Rumble (vibration) event
    class XRumble
    {
        public float timer;    // Rumble timer
        public float fadeTime; // Fade-out (in seconds)
        public Vector2 power;  // Intensity of rumble

        public void Update()
        {
            this.timer -= Time.unscaledDeltaTime;
        }
    }
    public class X360_controller
    {
        private GamePadState prev_state; // Previous gamepad state
        private GamePadState state;      // Current gamepad state

        private int gamepadIndex;        // Numeric index (1,2,3 or 4
        private PlayerIndex playerIndex;    // XInput 'Player' index
        private List<XRumble> rumbleEvents; // Stores rumble events

        // Button input map (explained soon!)
        private Dictionary<string, XButton> inputMap;

        // States for all buttons/inputs supported
        private XButton A, B, X, Y; // Action (face) buttons
        private XButton DPad_Up, DPad_Down, DPad_Left, DPad_Right;

        private XButton Guide;       // Xbox logo button}
        private XButton Back, Start;
        private XButton L3, R3;      // Thumbstick buttons
        private XButton LB, RB;      // 'Bumper' (shoulder) buttons
        private TriggerState LT, RT; // Triggers

        // Constructor
        public X360_controller(int index)
        {
            // Set gamepad index
            gamepadIndex = index - 1;
            playerIndex = (PlayerIndex)gamepadIndex;

            // Create rumble container and input map
            rumbleEvents = new List<XRumble>();
            inputMap = new Dictionary<string, XButton>();
        }
        public void Update()
        {
            // Get current state
            state = GamePad.GetState(playerIndex);

            // Check gamepad is connected
            if (state.IsConnected)
            {
                A.state = state.Buttons.A;
                B.state = state.Buttons.B;
                X.state = state.Buttons.X;
                Y.state = state.Buttons.Y;

                DPad_Up.state = state.DPad.Up;
                DPad_Down.state = state.DPad.Down;
                DPad_Left.state = state.DPad.Left;
                DPad_Right.state = state.DPad.Right;

                Guide.state = state.Buttons.Guide;
                Back.state = state.Buttons.Back;
                Start.state = state.Buttons.Start;
                L3.state = state.Buttons.LeftStick;
                R3.state = state.Buttons.RightStick;
                LB.state = state.Buttons.LeftShoulder;
                RB.state = state.Buttons.RightShoulder;

                // Read trigger values into trigger states
                LT.current_value = state.Triggers.Left;
                RT.current_value = state.Triggers.Right;
                UpdateInputMap();
                HandleRumble();
            }

        }
        public void Refresh()
        {
            // This 'saves' the current state for next update
            prev_state = state;

            // Check gamepad is connected
            if (state.IsConnected)
            {
                A.prev_state = prev_state.Buttons.A;
                B.prev_state = prev_state.Buttons.B;
                X.prev_state = prev_state.Buttons.X;
                Y.prev_state = prev_state.Buttons.Y;

                DPad_Up.prev_state = prev_state.DPad.Up;
                DPad_Down.prev_state = prev_state.DPad.Down;
                DPad_Left.prev_state = prev_state.DPad.Left;
                DPad_Right.prev_state = prev_state.DPad.Right;

                Guide.prev_state = prev_state.Buttons.Guide;
                Back.prev_state = prev_state.Buttons.Back;
                Start.prev_state = prev_state.Buttons.Start;
                L3.prev_state = prev_state.Buttons.LeftStick;
                R3.prev_state = prev_state.Buttons.RightStick;
                LB.prev_state = prev_state.Buttons.LeftShoulder;
                RB.prev_state = prev_state.Buttons.RightShoulder;

                // Read previous trigger values into trigger states
                LT.prev_value = prev_state.Triggers.Left;
                RT.prev_value = prev_state.Triggers.Right;
                UpdateInputMap();
            }

        }
        // Return numeric gamepad index
        public int Index { get { return gamepadIndex; } }

        // Return gamepad connection state
        public bool IsConnected { get { return state.IsConnected; } }

        void UpdateInputMap()
        {
            inputMap[InputConstants.A] = A;
            inputMap[InputConstants.B] = B;
            inputMap[InputConstants.X] = X;
            inputMap[InputConstants.Y] = Y;

            inputMap[InputConstants.DPad_Up] = DPad_Up;
            inputMap[InputConstants.DPad_Down] = DPad_Down;
            inputMap[InputConstants.DPad_Left] = DPad_Left;
            inputMap[InputConstants.DPad_Right] = DPad_Right;

            inputMap[InputConstants.Guide] = Guide;
            inputMap[InputConstants.Back] = Back;
            inputMap[InputConstants.Start] = Start;

            // Thumbstick buttons
            inputMap[InputConstants.L3] = L3;
            inputMap[InputConstants.R3] = R3;

            // Shoulder ('bumper') buttons
            inputMap[InputConstants.LB] = LB;
            inputMap[InputConstants.RB] = RB;
        }
        public bool GetButton(string button)
        {
            if (this.IsConnected)
            {
                return inputMap[button].state
                  == ButtonState.Pressed ? true : false;
            }
            return false;
        }
        public bool GetButtonDown(string button)
        {
            if (this.IsConnected)
            {
                return (inputMap[button].prev_state == ButtonState.Released &&
                                inputMap[button].state == ButtonState.Pressed) ? true : false;
            }
            return false;

        }
        public bool GetButtonUp(string button)
        {
            if (this.IsConnected)
            {
                return (inputMap[button].prev_state == ButtonState.Pressed &&
                    inputMap[button].state == ButtonState.Released) ? true : false;

            }
            return false;
        }
        void HandleRumble()
        {
            // Ignore if there are no events
            if (rumbleEvents.Count > 0)
            {
                Vector2 currentPower = new Vector2(0, 0);

                for (int i = 0; i < rumbleEvents.Count; ++i)
                {
                    // Update current event
                    rumbleEvents[i].Update();

                    if (rumbleEvents[i].timer > 0)
                    {
                        // Calculate current power
                        float timeLeft = Mathf.Clamp(rumbleEvents[i].timer / rumbleEvents[i].fadeTime, 0f, 1f);
                        currentPower = new Vector2(Mathf.Max(rumbleEvents[i].power.x * timeLeft, currentPower.x),
                                                   Mathf.Max(rumbleEvents[i].power.y * timeLeft, currentPower.y));

                        // Apply vibration to gamepad motors
                        GamePad.SetVibration(playerIndex, currentPower.x, currentPower.y);
                    }
                    else
                    {
                        // Remove expired event
                        rumbleEvents.Remove(rumbleEvents[i]);
                        if (rumbleEvents.Count == 0)
                        {
                            GamePad.SetVibration(playerIndex, 0.0f, 0.0f);
                        }
                    }
                }
            }
        }
        public void AddRumble(float timer, Vector2 power, float fadeTime)
        {
            XRumble rumble = new XRumble
            {
                timer = timer,
                power = power,
                fadeTime = fadeTime
            };

            rumbleEvents.Add(rumble);
        }
        // Return axes of left thumbstick
        public GamePadThumbSticks.StickValue Stick_L
        {
            get { return state.ThumbSticks.Left; }
        }
        public float GetStickRaw_LX()
        {
            float x = 0.0f;
            if (state.ThumbSticks.Left.X < 0.0f)
            {
                x = -1.0f;
            }
            else if (state.ThumbSticks.Left.X > 0.0f)
            {
                x = 1.0f;
            }
            return x;
        }
        // Return axes of right thumbstick
        public GamePadThumbSticks.StickValue Stick_R
        {
            get{ return state.ThumbSticks.Right; }
            
        }
        public float GetTrigger_L() { return state.Triggers.Left; }

        // Return axis of right trigger
        public float GetTrigger_R() { return state.Triggers.Right; }
        public bool GetTriggerTap_L()
        {
            return (LT.prev_value == 0f && LT.current_value >= 0.1f) ? true : false;
        }

        // Check if right trigger was tapped - on CURRENT frame
        public bool GetTriggerTap_R()
        {
            return (RT.prev_value == 0f && RT.current_value >= 0.1f) ? true : false;
        }
    }

}
