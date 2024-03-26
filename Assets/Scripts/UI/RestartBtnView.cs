using System;
using UnityEngine;
using UnityEngine.UI;

namespace CardQuiz
{
    public class RestartBtnView : MonoBehaviour
    {
        [SerializeField]
        private Button RestartBtn;
        public event Action PressRestartEvent;

        private void Start()
        {
            RestartBtn.onClick.AddListener(OnRestartBtnClick);
        }
        public void OnRestartBtnClick()
        {
            PressRestartEvent?.Invoke();
        }
        private void OnDisable()
        {
            RestartBtn.onClick.RemoveAllListeners();
        }
    }
}

