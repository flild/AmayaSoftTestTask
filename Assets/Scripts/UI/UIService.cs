using UnityEngine;
using Zenject;

namespace CardQuiz.UI
{
    public class UIService: MonoBehaviour
    {
        [Inject]
        private GameLogic _gameLogic;
        [SerializeField]
        private RestartBtnView _restartBtnPrefab;
        private RestartBtnView _restartBtnInstance;
        private void Start()
        {
            _gameLogic._LastLevelEndEvent += CreateRestartButton;
        }
        public void CreateRestartButton()
        {
            _restartBtnInstance = Instantiate(_restartBtnPrefab, transform);
            _restartBtnInstance.PressRestartEvent += OnPressRestartBtn;

        }
        public void OnPressRestartBtn()
        {
            _restartBtnInstance.PressRestartEvent -= OnPressRestartBtn;
            Destroy(_restartBtnInstance.gameObject);
            _gameLogic.RestartGame();
        }
        private void OnDisable()
        {
            _gameLogic._LastLevelEndEvent -= CreateRestartButton;
        }
    }
}


