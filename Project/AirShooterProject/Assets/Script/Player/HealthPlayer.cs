using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiRGameStudio.AirShooter {
    public class HealthPlayer : MonoBehaviour
    {
        public static HealthPlayer instance { get; set; }
        [Header("Health")]
        [Tooltip("Slider Health"), SerializeField]
        private Slider _healthSlider;
        [Tooltip("Besarnya HP"), SerializeField]
        private int _maxHealth;
        [Tooltip("Current HP"),SerializeField]
        private int _healthPlayer;
        
        [Header("Life")]
        [Tooltip("Nyawa Player"),SerializeField]
        private int _nyawaPlayer = 3;
        [Tooltip("Image Nyawa Player"), SerializeField]
        private GameObject[] _imageNyawaPlayer;
        public int SetHealth
        {
            get
            {
                return _healthPlayer;
            }
            set
            {
                _healthPlayer = value;
            }
        }
        public int SetLife
        {
            get
            {
                return _nyawaPlayer;
            }
            set
            {
                _nyawaPlayer = value;
            }
        }

        private void Start()
        {
            _healthSlider.maxValue = _maxHealth;
            _healthSlider.value = _maxHealth;
            SetHealth = _maxHealth;

           
        }
        private void Update()
        {
            LifeCalculate(_nyawaPlayer);
            HealthCalculate(_healthPlayer);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("BulletEnemy"))
            {
                SetHealth -= 50;
                _healthSlider.value = SetHealth;
            }
        }

        private void HealthCalculate(int Health)
        {
            if(Health <= 0)
            {
                _nyawaPlayer--;
                SetHealth = _maxHealth;
                _healthSlider.value = _maxHealth;
            }
        }
        private void LifeCalculate(int Nyawa)
        {
            for (int i = 0; i < _imageNyawaPlayer.Length; i++)
            {
                if (i < Nyawa)
                {
                    _imageNyawaPlayer[i].SetActive(true);
                }
                else if (i >= Nyawa)
                {
                    _imageNyawaPlayer[i].SetActive(false);
                }
            }
        }
    }
}