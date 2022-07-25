using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiRGameStudio.AirShooter {
    public class HealthEnemy : MonoBehaviour
    {
        [Header("Health")]
        [Tooltip("Darah Enemy"), SerializeField]
        private int _healthEnemy;
        [Tooltip("Darah Enemy"), SerializeField]
        private int _maxHealth;
        [SerializeField] private SpawnAccessoryPlayer _spawnAccessory;
        public AnimEnemy _anim;
        private void OnEnable()
        {
            _healthEnemy = _maxHealth;
        }

        private void Update()
        {
            if (_healthEnemy <= 0)
            {
                Score.instance.CurrScorePlayer += 2;
                _healthEnemy = _maxHealth;
                _spawnAccessory._spawnAccessory = true;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("BulletPlayer"))
            {
                _healthEnemy--;
                _anim._anim.CrossFade("GotHit", 0);
            }
        }
    }
}