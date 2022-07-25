using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiRGameStudio.AirShooter
{
    public class PowerUp : MonoBehaviour
    {
        public static PowerUp instance;
        private void Awake()
        {
            instance = this;
        }

        public int powerUp;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("PowerUp") )
            {
                if (powerUp < 3)
                {
                    powerUp += 1;
                } else if(powerUp >= 3)
                {
                    powerUp = 3;
                    Score.instance.CurrScorePlayer += 20;
                }
                collision.gameObject.SetActive(false);
            }
        }
    }
}