using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using X360;

public class PlayerInputHook : MonoBehaviour
{
    public PlayerInput[] PlayerInputs;

    private X360_InputManager _inputManager;

    private void Start()
    {
        _inputManager = X360_InputManager.Instance;
        if(_inputManager != null)
        {
            InitInputs();
        }
        else
        {
            Debug.LogError(gameObject.name + " :: no instance of X360_InputManager");
            Destroy(this);
        }
    }
    void Update()
    {
        for (int i = 0; i < PlayerInputs.Length; i++)
        {
            if(PlayerInputs[i] != null)
            {
                PlayerInputs[i].Execute();
            }
        }
    }

    private void InitInputs()
    {
        for (int i = 0; i < PlayerInputs.Length; i++)
        {
            if(PlayerInputs[i] != null)
            {
                PlayerInputs[i].Controller = _inputManager.GetController(PlayerInputs[i].PlayerNumber);
            }
        }
    }
}
