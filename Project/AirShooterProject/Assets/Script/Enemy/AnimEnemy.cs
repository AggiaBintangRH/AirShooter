using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEnemy : MonoBehaviour
{
    public Animator _anim;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

}
