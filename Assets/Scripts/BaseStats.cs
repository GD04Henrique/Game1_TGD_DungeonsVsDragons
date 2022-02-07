using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [SerializeField]
    protected float _health = 100f;

    public bool isAlive => _health > 0f;

    virtual
    public void OnHit(float damage)
    {
        _health -= damage;
        if(_health <= 0f)
        {
            _health = 0f;
            OnDie();
        }
    }

    virtual
    public void OnDie()
    {
        _health = 0f;
        Destroy(gameObject);
    }

    virtual
    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    virtual
    public void PrintHealth()
    {
        Debug.Log("ENEMY HEALTH: " + _health);
    }
}
