using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiRGameStudio.AirShooter
{
    public class SpawnAccessoryPlayer : MonoBehaviour
    {
        private ObjectPooler _objectPool;
        public SpawnBulletEnemy _spawnBullet;
        public bool _spawnAccessory;
        private void Start()
        {
            _objectPool = ObjectPooler.SharedInstance;
        }

        private void Update()
        {
            if(_spawnAccessory)
            {
                SpawnAccessory();
                _spawnAccessory = false;
                _spawnBullet._isFire = false;
                this.gameObject.SetActive(false);
            }
        }
        private void SpawnAccessory()
        {
            GameObject _accessory = _objectPool.GetAccessoryPlayer(0);
            _accessory.transform.position = transform.position;
            _accessory.transform.rotation = Quaternion.identity;
            _accessory.SetActive(true);
        }
    }
}