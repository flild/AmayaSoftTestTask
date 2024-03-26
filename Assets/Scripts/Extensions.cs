using System;
using UnityEngine;

namespace CardQuiz.Extensions
{
    /// <summary>
    /// структура содеращая данные для карточки
    /// </summary>
    [Serializable]
    public struct CardDataSruct
        {

        public Sprite sprite;
        /// <summary>
        /// Имя объекта, которое будет использоваться для показа задания "find CallName"
        /// </summary>
        public String CallName;
        }
    public class ReactiveProperty<T>
    {
        public event Action<T> OnChanged;

        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }
    }
}


