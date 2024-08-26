using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startlife = 10;
    private int _currentLife;
    public bool destroyOnKill = false;
    public float timeToDestroy;

    public Action OnKill;

    [SerializeField] private FlashColor _flashcolor;
    private bool _isDead = false;


    private void Awake()
    {
        
        Init();
        if (_flashcolor == null)
        {
            _flashcolor = GetComponent<FlashColor>();
        }
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startlife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
        if(_flashcolor != null)
        {
            _flashcolor.Flash();
        }
    }
    private void Kill()
    {
        _isDead = true;
        if(destroyOnKill)
            Destroy(gameObject,timeToDestroy);

        OnKill?.Invoke();
    }
}
