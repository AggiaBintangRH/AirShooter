using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiRGameStudio.AirShooter
{
    public class BaseEnemy : MonoBehaviour
    {
        private enum MovingAI
        {
            Move,
            FireBullet
        }
        private Rigidbody2D _enemyRB;

        [Header("Movement")]
        [Tooltip("Movement Speed Enemy"), SerializeField]
        private float _speedEnemy;
        [Tooltip("Enum Moving AI"),SerializeField]
        private MovingAI _state;

        public SpawnBulletEnemy _spawnBullet;

        [Header("Facing Player")]
        [Tooltip("Smooth Rot Speed"), SerializeField]
        private float _smoothSpeed;
        [Tooltip("Player"), SerializeField]
        private GameObject _playerTransfrom;
        private Vector3 _dir;
        private Quaternion _rot;

        [Header("Target Move AI")]
        [Tooltip("Untuk Membuat Vector2 Target")]
        private float _moveX;
        private float _moveY;
        private float _finalMoveX;
        private float _finalMoveY;
        private Vector3 _targetMove;
        private void Start()
        {
            _enemyRB = GetComponent<Rigidbody2D>();
            _playerTransfrom = GameObject.FindGameObjectWithTag("Player");

        }
        private void OnEnable()
        {
            
            
            _moveX = Random.Range(-8.5f, 3f);
            _moveY = Random.Range(3f, 4f);
            _finalMoveX = Mathf.Round(_moveX * 100.0f) * 0.01f;
            _finalMoveY = Mathf.Round(_moveY * 100.0f) * 0.01f;
            _targetMove = new Vector3(_finalMoveX, _finalMoveY, 0);


            _state = MovingAI.Move;

        }
        private void Update()
        {
            //Facing Player
            _dir = transform.position - _playerTransfrom.transform.position;
            _rot = Quaternion.FromToRotation(Vector3.up, _dir);
            //Moving AI
            switch (_state)
            {
                case MovingAI.Move:
                    Movement(_targetMove);
                    if (transform.position == _targetMove)
                    {
                        _state = MovingAI.FireBullet;
                    }
                    break;
                case MovingAI.FireBullet:
                    transform.rotation = _rot;
                    _spawnBullet._isFire = true;
                    break;
            }
        }

        private void Movement(Vector3 Target)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, _speedEnemy * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("BulletPlayer"))
            {
                SpawnBulletEnemy.instance._isFire = false;
            }
        }
    }
}