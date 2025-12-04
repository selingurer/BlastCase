using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BasePanel : MonoBehaviour, IPanel
    {
        [SerializeField] private RectTransform rectTransform;
        private void Start()
        {
            FitSafeArea();
        }

        public void FitSafeArea()
        {
            var safe = Screen.safeArea;

            rectTransform = GetComponent<RectTransform>();
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -safe.y);
        }
    }
}