using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MiRGameStudio.AirShooter
{
    public class SpawnBulletPlayer : MonoBehaviour
    {
        private ObjectPooler _objectPool;
        private PowerUp _powerUp;
        public bool _isPress;

        [Header("Spawn Bullet")]
        [Tooltip("Posisi Petama Bullet Muncul"), SerializeField]
        private Transform _gunPos;
        public float _nextSpawnBullet;
        public float _spawnTimeBullet = .3f;
        private void Start()
        {
            _gunPos = GameObject.Find("GunPlacePlayer").GetComponent<Transform>();

            _objectPool = ObjectPooler.SharedInstance;
            _powerUp = PowerUp.instance;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) || FireButton._isPress)
            {
                UpdateBullet();
            }
        }
        public void UpdateBullet()
        {
            if (_powerUp.powerUp == 0)
            {
                while (Time.time > _nextSpawnBullet)
                {
                    _nextSpawnBullet = Time.time + _spawnTimeBullet;
                    Bullet(_gunPos.position.x, _gunPos.position.y, 0);
                }
            }
            else if (_powerUp.powerUp == 1)
            {
                while (Time.time > _nextSpawnBullet)
                {
                    _nextSpawnBullet = Time.time + _spawnTimeBullet;
                    Bullet(_gunPos.position.x + .35f, _gunPos.position.y, 0);
                    Bullet(_gunPos.position.x - .35f, _gunPos.position.y, 0);
                }
            }
            else if (_powerUp.powerUp == 2)
            {
                while (Time.time > _nextSpawnBullet)
                {
                    _nextSpawnBullet = Time.time + _spawnTimeBullet;
                    Bullet(_gunPos.position.x, _gunPos.position.y + .15f, 0);
                    Bullet(_gunPos.position.x + .7f, _gunPos.position.y + 0.05f, -20);
                    Bullet(_gunPos.position.x - .7f, _gunPos.position.y + 0.05f, 20);
                }
            }
            else if (_powerUp.powerUp == 3)
            {
                while (Time.time > _nextSpawnBullet)
                {
                    _nextSpawnBullet = Time.time + _spawnTimeBullet;
                    Bullet(_gunPos.position.x, _gunPos.position.y + .15f, 0);
                    Bullet(_gunPos.position.x + .4f, _gunPos.position.y + 0.07f, -15);
                    Bullet(_gunPos.position.x - .4f, _gunPos.position.y + 0.07f, 15);
                    Bullet(_gunPos.position.x + 0.7f, _gunPos.position.y -.01f, -30);
                    Bullet(_gunPos.position.x - 0.7f, _gunPos.position.y -.1f, 30);
                }
            }
        }
        private void Bullet(float PosX, float PosY, float RotZ)
        {
            GameObject _bullet = _objectPool.GetBulletPLayer(0);
            _bullet.transform.position = new Vector2(PosX, PosY);
            _bullet.transform.rotation = Quaternion.Euler(0, 0, RotZ);
            _bullet.SetActive(true);
        }

        private void Bullet2(float PosX, float PosY, float RotZ)
        {
            GameObject _bullet2 = _objectPool.GetBulletPLayer(0);
            _bullet2.transform.position = new Vector2(PosX, PosY);
            _bullet2.transform.rotation = Quaternion.Euler(0, 0, RotZ);
            _bullet2.SetActive(true);
        }
        private void Bullet3(float PosX, float PosY, float RotZ)
        {
            GameObject _bullet3 = _objectPool.GetBulletPLayer(0);
            _bullet3.transform.position = new Vector2(PosX, PosY);
            _bullet3.transform.rotation = Quaternion.Euler(0,0,RotZ);
            _bullet3.SetActive(true);
        }
        private void Bullet4(float PosX, float PosY, float RotZ)
        {
            GameObject _bullet4 = _objectPool.GetBulletPLayer(0);
            _bullet4.transform.position = new Vector2(PosX, PosY);
            _bullet4.transform.rotation = Quaternion.Euler(0, 0, RotZ);
            _bullet4.SetActive(true);
        }
        private void Bullet5(float PosX, float PosY, float RotZ)
        {
            GameObject _bullet5 = _objectPool.GetBulletPLayer(0);
            _bullet5.transform.position = new Vector2(PosX, PosY);
            _bullet5.transform.rotation = Quaternion.Euler(0, 0, RotZ);
            _bullet5.SetActive(true);
        }
    }
}