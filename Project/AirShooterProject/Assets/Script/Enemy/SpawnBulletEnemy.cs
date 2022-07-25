using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiRGameStudio.AirShooter
{
    public class SpawnBulletEnemy : MonoBehaviour
    {
        public static SpawnBulletEnemy instance { get; set; }
        public bool _isFire;
        private ObjectPooler _objectPool;

        [Header("Spawn Bullet")]
        [Tooltip("Posisi Petama Bullet Muncul"), SerializeField]
        private Transform _gunPos;
        public float _nextSpawnBullet = 2f;
        public float _spawnTimeBullet = 1f;
        private void Awake()
        {
            instance = this;
        }
        private void OnEnable()
        {
            _objectPool = ObjectPooler.SharedInstance;
        }

        private void Update()
        {
            if (_isFire)
            {
                while (Time.time > _nextSpawnBullet)
                {
                    _nextSpawnBullet = Time.time + _spawnTimeBullet;
                    Bullet(_gunPos.position.x, _gunPos.position.y);
                }
            }
        }
        private void Bullet(float PosX, float PosY)
        {
            GameObject _bullet = _objectPool.GetBulletEnemy(0);
            _bullet.transform.position = new Vector2(PosX, PosY);
            _bullet.transform.rotation = _gunPos.transform.rotation;
            _bullet.SetActive(true);
        }
    }
}