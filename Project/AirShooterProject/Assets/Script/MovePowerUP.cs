using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MiRGameStudio.AirShooter
{
    public class MovePowerUP : MonoBehaviour
    {
        private enum MovingAI
        {
            MoveLeftDown,
            MoveLeftUp,
            MoveRightUp,
            MoveRightDown
        }
        private float _moveX;
        private float _moveY;
        private MovingAI _state;
        private Vector3 _target;
        private void Start()
        {
            _state = MovingAI.MoveLeftDown;
        }
        private void Update()
        {
            switch (_state)
            {
                case MovingAI.MoveLeftDown:
                    _moveX = 4;
                    _moveY = 0;
                    _target = new Vector3(_moveX, _moveY, 0);
                    Movement(_target);
                    if (transform.position == _target)
                    {
                        _state = MovingAI.MoveRightDown;
                    }
                    break;
                case MovingAI.MoveRightDown:
                    _moveX = -3.15f;
                    _moveY = -5;
                    _target = new Vector3(_moveX, _moveY, 0);
                    Movement(_target);
                    if (transform.position == _target)
                    {
                        _state = MovingAI.MoveLeftUp;
                    }
                    break;
                case MovingAI.MoveLeftUp:
                    _moveX = -9.35f;
                    _moveY = 0;
                    _target = new Vector3(_moveX, _moveY, 0);
                    Movement(_target);
                    if (transform.position == _target)
                    {
                        _state = MovingAI.MoveRightUp;
                    }
                    break;
                case MovingAI.MoveRightUp:
                    _moveX = -3.15f;
                    _moveY = 5;
                    _target = new Vector3(_moveX, _moveY, 0);
                    Movement(_target);
                    if (transform.position == _target)
                    {
                        _state = MovingAI.MoveLeftDown;
                    }
                    break;
            }

        }

        private void Movement(Vector3 Target)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target,5 * Time.deltaTime);
        }
    }
}