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

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        Vector3 stop = player.position - new Vector3(10f,10f,0f);
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        stop.Normalize();
        movement = direction - stop;
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
}
