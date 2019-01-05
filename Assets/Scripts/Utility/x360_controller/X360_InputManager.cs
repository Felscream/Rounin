using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace X360
{
    public class X360_InputManager : MonoBehaviour
    {
        public int GamePadCount = 1;

        private List<X360_controller> _controllers;

        private static X360_InputManager _instance;
        public static X360_InputManager Instance {
            get {
                if(_instance == null)
                {
                    Debug.LogError("No instance of X360_InputManager");
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                InitManager();
            }
            else
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            UpdateControllers();
        }

        public void UpdateControllers()
        {
            for (int i = 0; i < _controllers.Count; ++i)
            {
                _controllers[i].Update();
            }
        }

        public X360_controller GetController(int index)
        {
            for(int i = 0; i < _controllers.Count; ++i)
            {
                if(_controllers[i].Index == index - 1)
                {
                    return _controllers[i];
                }
            }
            Debug.LogError("[GamepadManager]: " + index + " is not a valid gamepad index!");
            return null;
        }

        public int ConnectedTotal()
        {
            int total = 0;

            for (int i = 0; i < _controllers.Count; ++i)
            {
                if (_controllers[i].IsConnected)
                    total++;
            }

            return total;
        }

        public bool GetButtonAny(string button)
        {
            for (int i = 0; i < _controllers.Count; ++i)
            {
                if (_controllers[i].IsConnected && _controllers[i].GetButton(button))
                    return true;
            }

            return false;
        }

        public bool GetButtonDownAny(string button)
        {
            for (int i = 0; i < _controllers.Count; ++i)
            {
                if (_controllers[i].IsConnected && _controllers[i].GetButtonDown(button))
                    return true;
            }

            return false;
        }

        private void InitManager()
        {
            GamePadCount = Mathf.Clamp(GamePadCount, 1, 4);
            _controllers = new List<X360_controller>();
            for (int i = 0; i < GamePadCount; ++i)
            {
                _controllers.Add(new X360_controller(i + 1));
            }
        }
    }
}

