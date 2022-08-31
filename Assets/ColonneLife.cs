using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColonneLife : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] int _hp;

    [SerializeField] UnityEvent _onAttack;
    [SerializeField] UnityEvent _onDie;

    [SerializeField] AnimationCurve _animCurve;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _hp--;
        _onAttack.Invoke();
        _animator.SetInteger("HP", _hp);

        if(_hp <= 0)
        {
            _onDie.Invoke();
        }
    }
}
