using CardQuiz.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
 

namespace CardQuiz.data
{
    [CreateAssetMenu(fileName = "New CardContentData", menuName = "ScriptableObject/Data/Content")]
    public class CardsContentDataSO : ScriptableObject
    {
        [SerializeField]
        private List<CardDataSruct> _cardsContent;
        public List<CardDataSruct> CardsContent
        {
            get {
                return _cardsContent.ToList(); }
        }

    }
}

