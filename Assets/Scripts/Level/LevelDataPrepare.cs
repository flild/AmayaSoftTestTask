using CardQuiz.data;
using CardQuiz.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CardQuiz
{
    public class LevelDataPrepare
    {
        private List<string> _usedAnswer;

        public LevelDataPrepare()
        {
            Reset();
        }
        public List<CardDataSruct> GetRandomCards(Vector2Int Size, List<CardDataSruct> data)
        {
            var _data = data;
            var _resultList = new List<CardDataSruct>();
            for(int i = 0; i <Size.x*Size.y; i++)
            {
                var item = _data[Random.Range(0, _data.Count)];
                _resultList.Add(item);
                _data.Remove(item);
            }
            return _resultList;
        }

        public string GetRandomAnswer(List<CardDataSruct> Answers)
        {
            List<CardDataSruct> exceptedAnswers = new List<CardDataSruct>();
            for (int i = 0; i < Answers.Count; i++)
            {
                if (!_usedAnswer.Contains(Answers[i].CallName))
                {
                    exceptedAnswers.Add(Answers[i]);
                }
            }
            if(exceptedAnswers.Count == 0)
            {
                exceptedAnswers = Answers;
                Reset();
            }
            var result = exceptedAnswers[Random.Range(0, exceptedAnswers.Count)].CallName;
            _usedAnswer.Add(result);
            return result;
        }
        public void Reset()
        {
            _usedAnswer = new List<string>();
        }

    }

}
