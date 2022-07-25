using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiRGameStudio.AirShooter
{
    public class BulletPlayer : MonoBehaviour
    {
        private Rigidbody2D _bulletRB;
        [Header("Movement")]
        [Tooltip("Kecepatan Laju Bullet"), SerializeField]
        private float _bulletSpeed;

        private void Start()
        {
            _bulletRB = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            DestroyBullet();
        }

        private void FixedUpdate()
        {
            _bulletRB.velocity = transform.up * _bulletSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                this.gameObject.SetActive(false);
            }
        }
        private void DestroyBullet()
        {
            StartCoroutine(WaitTime(2));
        }

        IEnumerator WaitTime(float TimeSecond)
        {
            yield return new WaitForSeconds(TimeSecond);
            this.gameObject.SetActive(false);
        }
    }
}