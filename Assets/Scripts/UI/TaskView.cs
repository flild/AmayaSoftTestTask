using UnityEngine;
using TMPro;
using Zenject;

namespace CardQuiz.UI
{
    public class TaskView : MonoBehaviour
    {
        [Inject]
        private GameLogic _gameLogic;
        [SerializeField]
        private TMP_Text _taskLabel;
        private string _baseText = "Find ";
        private void Start()
        {
            _gameLogic._currentAnswer.OnChanged += OnAnswerChange;
            OnAnswerChange(_gameLogic._currentAnswer.Value);
        }
        private void OnAnswerChange(string answer)
        {
            _taskLabel.text = string.Concat(_baseText, answer);
        }
        private void OnDisable()
        {
            _gameLogic._currentAnswer.OnChanged -= OnAnswerChange;
        }
    }
}


