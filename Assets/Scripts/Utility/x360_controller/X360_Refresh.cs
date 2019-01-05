using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace X360
{
    public class X360_Refresh : MonoBehaviour
    {
        private X360_InputManager _inputManager;

        private void Start()
        {
            _inputManager = X360_InputManager.Instance;
            if(_inputManager == null)
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            _inputManager.UpdateControllers();
        }
    }
}

