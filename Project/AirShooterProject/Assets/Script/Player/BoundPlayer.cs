using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiRGameStudio.AirShooter
{
    public class BoundPlayer : MonoBehaviour
    {
        [Header("Batas Pergerakan Player")]
        [Tooltip("Batas Atas"), SerializeField]
        private float _batasYMax;
        [Tooltip("Batas Bawah"), SerializeField]
        private float _batasYMin;
        [Tooltip("Batas Kanan"), SerializeField]
        private float _batasXMax;
        [Tooltip("Batas Kiri"), SerializeField]
        private float _batasXMin;

        private float _clampX;
        private float _clampY;

        private void Update()
        {
            BatasPlayerBegerak(_batasXMax, _batasXMin, _batasYMax, _batasYMin);
        }
        private void BatasPlayerBegerak(float XMax, float XMin, float YMax, float YMin)
        {
            _clampX = Mathf.Clamp(transform.position.x, XMin, XMax);
            _clampY = Mathf.Clamp(transform.position.y, YMin, YMax);
            transform.position = new Vector2(_clampX, _clampY);
        }
    }
}