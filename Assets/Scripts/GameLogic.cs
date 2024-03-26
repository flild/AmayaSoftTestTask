using UnityEngine;
using CardQuiz.Grid;
using CardQuiz.Tools;
using CardQuiz.Grid.Card;
using System;
using CardQuiz.data;
using CardQuiz.Extensions;
using Zenject;

namespace CardQuiz
{
    public class GameLogic: IDisposable, IInitializable 
    {
        
        private GridModel _grid;
        [Inject]
        private ParticleSystem _starParticle;
        private LevelDataPrepare _levelPrepare;
        [Inject]
        private CardsContentDataSO _content;
        [Inject]
        private LevelsSizeDataSO _levelSettings;
        [Inject]
        private GridDrawer _gridDrawer;
        private int _currentLevel = int.MinValue;
        public ReactiveProperty<string> _currentAnswer = new ReactiveProperty<string>();
        public event Action _LastLevelEndEvent;


        public void Initialize()
        {
            _grid = new GridModel(_gridDrawer);
            _levelPrepare = new LevelDataPrepare();
            Subscribe();
            TryToNextLevel();
        }
        public bool TryToNextLevel()
        {
            _currentLevel = _currentLevel == int.MinValue ? 0 : _currentLevel+1;

            if (_currentLevel >= _levelSettings.Levels.Count)
            {
                _LastLevelEndEvent?.Invoke();
                return false;
            }
            else
            {
                StartLevel(_currentLevel);
                return true;
            }
        }
        public void RestartGame()
        {
            _currentLevel = 0;
            StartLevel(_currentLevel);
        }
        private void StartLevel(int number)
        {
            var levelCards = _levelPrepare.GetRandomCards(_levelSettings.Levels[number], _content.CardsContent);
            _currentAnswer.Value = _levelPrepare.GetRandomAnswer(levelCards);
            _grid.DrawGrid(_levelSettings.Levels[number], levelCards);

        }
        private bool CheckAnswer(string answer)
        {
            return _currentAnswer.Value == answer;

        }
        private void OnClickAtCard(CardView card, string id)
        {
            if (CheckAnswer(id))
            {
                card.PlayCorrectAnswerEffect(_starParticle);
                TryToNextLevel();
            }
            else
            {
                card.PlayWrongAnswerEffect();
            }
        }
        private void Subscribe()
        {
            _grid.ChooseCardEvent += OnClickAtCard;
        }
        public void Dispose()
        {
            _grid.ChooseCardEvent -= OnClickAtCard;
            _grid.Dispose();
        }


    }
}

