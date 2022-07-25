using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiRGameStudio.AirShooter {
    public class Animasi : MonoBehaviour
    {
        private Animator _playerAnim;
        private float _moveAnim;
        private BasePlayer _basePlayer;
        private void Start()
        {
            _playerAnim = GetComponentInChildren<Animator>();
        }
        private void Update()
        {
            //float x = BasePlayer.instance._joystick.Horizontal;
            _moveAnim = Input.GetAxis("Horizontal");
            _playerAnim.SetFloat("Movement", _moveAnim);
        }
    }
}