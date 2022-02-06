using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : BaseStats
{
    [SerializeField]
    private PlayerController _player;

    private int _OGplayerAttack;
    // Start is called before the first frame update
    void Start()
    {
        if(CompareTag("Booster"))
        {
            _health = 50;
            _OGplayerAttack = _player.GetComponent<PlayerController>().attack;
            _player.GetComponent<PlayerController>().attack *= 2;
        }   

        if(CompareTag("Obstacle"))
        {
            _health = 75;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if(this._health <= 0)
        {
            if(CompareTag("Booster"))
            {
                _player.GetComponent<PlayerController>().attack = _OGplayerAttack;
            }
            Destroy(gameObject);
        }
    }
}
