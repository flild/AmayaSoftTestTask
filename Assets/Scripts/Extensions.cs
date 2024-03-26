using System;
using UnityEngine;

namespace CardQuiz.Extensions
{
    /// <summary>
    /// ��������� ��������� ������ ��� ��������
    /// </summary>
    [Serializable]
    public struct CardDataSruct
        {

        public Sprite sprite;
        /// <summary>
        /// ��� �������, ������� ����� �������������� ��� ������ ������� "find CallName"
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


