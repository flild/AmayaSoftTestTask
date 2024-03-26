using System;
using UnityEngine;

namespace CardQuiz.Tools
{
    [CreateAssetMenu(fileName = "InputReadear", menuName = "ScriptableObject/InputReader")]
    public class InputReaderSO : ScriptableObject, PlayerInput.IMainMapActions
    {
        private PlayerInput _gameInput;
        public event Action MouseClicEvent;
        private void OnEnable()
        {
            _gameInput ??= new PlayerInput();
            _gameInput.MainMap.SetCallbacks(this);
            EnableMainMap();
        }
        public void EnableMainMap()
        {
            _gameInput.Enable();
        }
        public void DisableMainMap()
        {
            _gameInput.Disable();
        }
        public void OnMouseClick(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if(context.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
                MouseClicEvent?.Invoke();
        }
    }

}
