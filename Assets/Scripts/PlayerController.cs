 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private RaycastHit2D hit;

    private GameObject _Enemy;

    [SerializeField]
    private BuildingSpawner _coins;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private Animator anim;

    private int _enemyTrigger;

    public int maxHealth = 100;
    public int CurrentHealth;

    public HealthBar_Controller healthbar;

    public int attack = 10;
    
    void Start()
    {
        _enemyTrigger = 0;
        boxCollider = GetComponent<BoxCollider2D>();
        anim.GetComponent<Animator>();
        CurrentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("Attack");
            if(_enemyTrigger == 1)
            {
                _Enemy.GetComponent<BaseStats>().OnDie();
                _enemyTrigger--;
            }
            //Enemy.OnDie();
        }

        if(CurrentHealth == 0f)
        {
            SceneManager.LoadScene("End Game");
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        //Swap Sprite direction
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // move in direction by casting a box first, if box returns null, free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * _speed * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * _speed * Time.deltaTime, 0, 0);
        }
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Debug.Log("HIT COIN");
            _coins.balance++;
            Destroy(collision.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemyTrigger = 1;
            _Enemy = collision.gameObject;
            //Debug.Log("HIT ENEMY");
        }

        /**if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("HIT COIN");
            //ollision.gameObject.GetComponent<BuildingSpawner>().snapValue++;
            _coins.balance++;
            Destroy(collision.gameObject);
        }**/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _enemyTrigger = 0;
        _Enemy = null;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        healthbar.SetHealth(CurrentHealth);
        Debug.Log("taking damage, health: " + CurrentHealth);
    }


}
