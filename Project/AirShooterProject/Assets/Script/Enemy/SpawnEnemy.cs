using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiRGameStudio.AirShooter {
    public class SpawnEnemy : MonoBehaviour
    {
        private ObjectPooler _objectPool;
        private float _moveX;
        private float _moveY;
        [SerializeField]
        private float _nextSpawnEnemy;
        [SerializeField]
        private float _spawnTimeEnemy;
        private void Start()
        {
            _objectPool = ObjectPooler.SharedInstance;
            _moveX = Random.Range(-8.5f, 3f);
            _moveY = 10f;
        }
        private void Update()
        {
            while (Time.time > _nextSpawnEnemy)
            {

                _moveX = Random.Range(-8.5f, 3f);
                _nextSpawnEnemy = Time.time + _spawnTimeEnemy;
                Enemy(_moveX, _moveY);
            }
        }

        private void Enemy(float PosX, float PosY)
        {
            GameObject _enemy = _objectPool.GetEnemy(0);
            _enemy.transform.position = new Vector2(PosX, PosY);
            _enemy.transform.rotation = Quaternion.identity;
            _enemy.SetActive(true);
        }
    }
}