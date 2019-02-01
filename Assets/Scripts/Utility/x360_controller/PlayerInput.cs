using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using X360;
using SA;

[CreateAssetMenu(menuName = "Inputs/PlayerInput")]
public class PlayerInput : ScriptableObject
{
    [Range(1, 4)] public int PlayerNumber;
    public StateManagerVariables PlayerStates;
    public X360_controller Controller;
    public bool RightYInverted = false;
    public bool LeftYInverted;

    public void Execute()
    {
        if(Controller != null && PlayerStates != null & PlayerStates.Value != null)
        {
            Movement();

            CameraControls();

            GeneralControls();
        }
    }

    private void Movement()
    {
        PlayerStates.Value.MovementVariables.Horizontal = Controller.Stick_L.X;
        PlayerStates.Value.MovementVariables.Vertical = LeftYInverted ? -Controller.Stick_L.Y : Controller.Stick_L.Y;

        PlayerStates.Value.MovementVariables.MoveAmount = Mathf.Clamp01(Mathf.Abs(Controller.Stick_L.X) + Mathf.Abs(Controller.Stick_L.Y));
    }

    private void CameraControls()
    {
        PlayerStates.Value.CameraVariables.Horizontal = Controller.Stick_R.X;
        PlayerStates.Value.CameraVariables.Vertical = RightYInverted ? -Controller.Stick_R.Y : Controller.Stick_R.Y;
    }

    private void GeneralControls()
    {
        PlayerStates.Value.InputVariables.LeftTrigger = Controller.GetTrigger_L();
        if (PlayerStates.Value.InputVariables.RightTriggerReleased)
        {
            PlayerStates.Value.InputVariables.RightTrigger = Controller.GetTrigger_R();
        }
        else
        {
            PlayerStates.Value.InputVariables.RightTrigger = 0f;
            if (Controller.GetTrigger_R() == 0f)
            {
                PlayerStates.Value.InputVariables.RightTriggerReleased = true;
            }
        }
            

        PlayerStates.Value.InputVariables.ADown = Controller.GetButtonDown(InputConstants.A);
        PlayerStates.Value.InputVariables.A = Controller.GetButton(InputConstants.A);
        PlayerStates.Value.InputVariables.RightShoulder = Controller.GetButtonDown(InputConstants.RB);

        PlayerStates.Value.InputVariables.XDown = Controller.GetButtonDown(InputConstants.X);
    }
}

