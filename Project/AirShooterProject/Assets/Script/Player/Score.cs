using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MiRGameStudio.AirShooter
{
    public class Score : MonoBehaviour
    {
        public static Score instance { get; set; }
        private void Awake()
        {
            instance = this;
        }
        [Tooltip("Current Score"), SerializeField]
        private int _currScore;

        public int CurrScorePlayer
        {
            get
            {
                return _currScore;
            }
            set
            {
                _currScore = value;
            }
        }

    }
}