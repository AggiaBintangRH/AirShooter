using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiRGameStudio.AirShooter
{

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Animasi))]
    [RequireComponent(typeof(BoundPlayer))]
    [RequireComponent(typeof(SpawnBulletPlayer))]
    public class BasePlayer : MonoBehaviour
    {
        public static BasePlayer instance {get; set; }
        private void Awake()
        {
            instance = this;
        }
        private Rigidbody2D _playerRB;

        [Header("Movement")]
        [Tooltip("Speed Untuk Movement"),SerializeField]
        private float _playerSpeed;
        [Tooltip("Canvas JoyStick")]
        //public FixedJoystick _joystick;

        private float _moveX;
        private float _moveY;
        private void Start()
        {
            _playerRB = GetComponent<Rigidbody2D>();
            //_joystick = FindObjectOfType<FixedJoystick>();
        }
        private void Update()
        {
            UpdateVariable();
        }
        private void FixedUpdate()
        {
            Movement();
        }
        private void Movement()
        {
            //Vector3 direction = Vector3.up * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
            //_playerRB.velocity = new Vector2(direction.x, direction.y) * _playerSpeed;

            _playerRB.velocity = new Vector2(_moveX, _moveY);
        }

        private void UpdateVariable()
        {
            _moveX = Input.GetAxis("Horizontal") * _playerSpeed;
            _moveY = Input.GetAxis("Vertical") * _playerSpeed;
        }
    }
}