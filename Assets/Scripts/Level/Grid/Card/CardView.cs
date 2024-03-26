using DG.Tweening;
using System;
using UnityEngine;

namespace CardQuiz.Grid.Card
{
    public class CardView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _content;
        private float _easeInBounceDuration = 0.5f;
        public event Action<CardView> ChooseThisCardEvent;

        public void SetContent(Sprite image)
        {
            _content.sprite = image;
        }
        public void PlayCorrectAnswerEffect(ParticleSystem _startsEffect)
        {
            _startsEffect.transform.position = transform.position;
            _startsEffect.Play();
        }
        public void PlayWrongAnswerEffect()
        {
            _content.transform.DOShakePosition(_easeInBounceDuration, strength: 0.4f, randomness: 0)
                .SetLink(gameObject);
        }
        public void Choose()
        {
            ChooseThisCardEvent?.Invoke(this);
        }

    }
}

