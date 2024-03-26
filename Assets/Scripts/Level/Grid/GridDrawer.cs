using CardQuiz.data;
using CardQuiz.Grid.Card;
using UnityEngine;
using System.Collections.Generic;
using CardQuiz.Extensions;

namespace CardQuiz.Tools
{
    [CreateAssetMenu(fileName = "GridDrawer", menuName = "ScriptableObject/Tools/GridDrawer")]
    public class GridDrawer : ScriptableObject
    {
        [SerializeField]
        private CardView _cellPrefab;
        [SerializeField]
        private float offset;
        private Transform _parent;
        private Vector2 _StartPos;

        public void Initialize(Transform parent)
        {
            _parent = parent;
        }
        public Dictionary<CardView, string> Draw(Vector2Int size, List<CardDataSruct> data)
        {
            Dictionary<CardView, string> _cardsMap = new Dictionary<CardView, string>();
            _StartPos = new Vector2
                   (-offset * (size.x - 1) / 2,
                   offset * (size.y - 1) / 2);
            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    var card = Instantiate
                        (_cellPrefab, new Vector2(_StartPos.x + offset * i, _StartPos.y + -offset * j),
                        Quaternion.identity,
                        _parent);
                    var Index2DIn1D = i + j + (size.x - 1) * j;
                    _cardsMap.Add(card, data[Index2DIn1D].CallName);
                    card.SetContent(data[Index2DIn1D].sprite);
                }
            }
            return _cardsMap;
        }


    }

}
