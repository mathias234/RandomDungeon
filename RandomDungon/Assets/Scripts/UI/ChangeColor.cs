using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;
namespace RandomDungeon.UI {
    [AddComponentMenu("UI/Change Color")]
    public class ChangeColor : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
        public Image image;

        public Color onClick;
        public Color onHover;

        public void OnPointerClick(PointerEventData eventData) {
            image.color = onClick;
        }

        public void OnPointerEnter(PointerEventData eventData) {
            image.color = onHover;
        }

        public void OnPointerExit(PointerEventData eventData) {
            image.color = onClick;
        }
    }
}