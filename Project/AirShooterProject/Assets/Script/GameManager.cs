using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace MiRGameStudio.AirShooter
{
    public class GameManager : MonoBehaviour
    {
        private Score _score;

        [Tooltip("Canvas Current Score"), SerializeField]
        private TMP_Text _currentScore;
        [Tooltip("Canvas Current Score"), SerializeField]
        private TMP_Text _highScore;

        private void Start()
        {
            _score = Score.instance;
        }

        private void Update()
        {
            _currentScore.text = _score.CurrScorePlayer.ToString();
        }
    }
}