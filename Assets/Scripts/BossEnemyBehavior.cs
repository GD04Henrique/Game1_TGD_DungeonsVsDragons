using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBehavior : BaseStats
{
    public GameObject coin;

    //[SerializeField]
    public Transform player;

    private Rigidbody2D rb;

    private Vector2 movement;

    [SerializeField]
    private float moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
       // rb.rotation = angle;
        direction.Normalize();
        movement = direction;
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
        GameObject clone;
        clone = Instantiate(coin, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        base.OnDie();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Attack(other.gameObject);
    }

    public void Attack(GameObject opponent)
    {
        if(opponent.CompareTag("Booster"))
        {
            opponent.GetComponent<BaseStats>().TakeDamage(30);
        }
        if(opponent.CompareTag("Obstacle"))
        {
            opponent.GetComponent<BaseStats>().TakeDamage(20);
        }
        if(opponent.CompareTag("Player"))
        {
            opponent.GetComponent<PlayerController>().TakeDamage(20);
        }
    }
}
