using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CardQuiz.data
{
    [CreateAssetMenu(fileName = "LevelSizes", menuName = "ScriptableObject/Data/LevelSizes")]
    public class LevelsSizeDataSO : ScriptableObject
    {
        [SerializeField]
        private List<Vector2Int> _levels;

        public List<Vector2Int> Levels
        {
            get { 
                return _levels.ToList();
                 }
        }
    }
}

