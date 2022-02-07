using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyBehavior : BaseStats
{
    public GameObject coin;

    //[SerializeField]
    public Transform player;

    private Rigidbody2D rb;

    private Vector2 movement;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private Animator _rangeAnim;

    [SerializeField]
    private GameObject _throwBone;

    [SerializeField]
    private float boneSpeed = 6f;

    private float _timeThrowBone = 4f;

    private bool _shoot;

    private GameObject bone;

    [SerializeField]
    private AudioSource _sfxdeath;

    // Start is called before the first frame update
    void Start()
    {
        _rangeAnim = GetComponent<Animator>();
        _health = 10f;
        rb = this.GetComponent<Rigidbody2D>();
        _shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_health <= 0f)
        {
            OnDie();
        }
        _timeThrowBone -= Time.deltaTime;
        Vector3 direction = player.position - transform.position;
        Vector3 stop = player.position - new Vector3(10f,10f,0f);
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        stop.Normalize();
        movement = direction - stop;

        if(_timeThrowBone <= 0f)
        {
            if(bone != null)
            {
                Destroy(bone.gameObject);
            }
            _rangeAnim.SetTrigger("Attack");
            Shoot(player.transform);
            _timeThrowBone = 4f;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    override
    public void OnDie()
    {
        _sfxdeath.Play();
        GameObject clone;
        clone = Instantiate(coin, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Timer._enemyDefeated++;
        base.OnDie();
    }

    private void Shoot(Transform target)
    {
        var destination = Vector3.zero;
        destination = target.position - transform.position;
        bone = Instantiate(_throwBone, transform.position, Quaternion.identity);
        //bone.GetComponent<Rigidbody2D>().AddRelativeForce(destination.normalized * boneSpeed, ForceMode2D.Force);
        bone.GetComponent<Rigidbody2D>().MovePosition(destination);
    }
}
