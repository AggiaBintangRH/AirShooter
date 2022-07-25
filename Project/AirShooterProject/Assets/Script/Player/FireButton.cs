using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace MiRGameStudio.AirShooter
{
    public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public static bool _isPress;
        public void OnPointerDown(PointerEventData eventData)
        {
            _isPress = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPress = false;
        }
    }
}