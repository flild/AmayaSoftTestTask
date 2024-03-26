using CardQuiz.Grid.Card;
using CardQuiz.Tools;
using UnityEngine;
using Zenject;

namespace CardQuiz
{
    public class MouseInput : MonoBehaviour
    {
        [Inject]
        private InputReaderSO _input;
        private void Start()
        {
            _input.MouseClicEvent += OnMouseClick;
        }
        private void OnMouseClick()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out CardView card))
                {
                    card.Choose();
                }
            }
        }
        private void OnDisable()
        {
            _input.MouseClicEvent -= OnMouseClick;
        }
    }
}

