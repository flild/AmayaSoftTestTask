using CardQuiz.Extensions;
using CardQuiz.Grid.Card;
using CardQuiz.Tools;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CardQuiz.Grid
{
    public class GridModel: IDisposable
    {
        private GridDrawer _gridDrawer;
        private Dictionary<CardView, string> _cardsMap;
        private GameObject greedArea;
        public event Action<CardView, string> ChooseCardEvent;
        public GridModel(GridDrawer gridDrawer)
        {
            _gridDrawer = gridDrawer;
            Init();
        }
        private void Init()
        {
            GameObject greedArea = new GameObject();
            greedArea.transform.position = Vector2.zero;
            _gridDrawer.Initialize(greedArea.transform);
        }
        public void DrawGrid(Vector2Int size, List<CardDataSruct> content)
        {
            CleanGrid();
            if (_cardsMap != null)
            {
                foreach (var card in _cardsMap)
                {
                    card.Key.ChooseThisCardEvent -= OnChooseCard;
                }
            }
            _cardsMap = _gridDrawer.Draw(size, content);
            foreach(var card in _cardsMap)
            {
                card.Key.ChooseThisCardEvent += OnChooseCard;
            }
        }
        public void CleanGrid()
        {
            if(_cardsMap != null)
            {
                foreach (var card in _cardsMap)
                {
                    GameObject.Destroy(card.Key.gameObject);
                }
            }
            _cardsMap = new Dictionary<CardView, string>();
        }
        public void OnChooseCard(CardView card)
        {
            ChooseCardEvent?.Invoke(card, _cardsMap[card]);
        }

        public void Dispose()
        {
            if (_cardsMap != null)
            {
                foreach (var card in _cardsMap)
                {
                    card.Key.ChooseThisCardEvent -= OnChooseCard;
                }
            }
        }
    }
}

