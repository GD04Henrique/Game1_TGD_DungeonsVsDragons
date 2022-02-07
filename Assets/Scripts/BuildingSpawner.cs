using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawner : MonoBehaviour
{

    public float snapValue = 16;

    public GameObject rabbit; // BOOSTER
    public GameObject giraffe; // OBSTACLE

    public LayerMask actor;

    public int rabbitCost = 2;
    public int giraffeCost = 3;
    public Text costText;
    public Text giraffeCostText;
    public Text balanceText;

    public int balance = 20;

    public GameObject Player;

    void Start()
    {
        costText.text = "x" + rabbitCost;
        balanceText.text = "Coins : " + balance;
        giraffeCostText.text = "x" + giraffeCost;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.one, Mathf.Infinity, actor);
        if (hit)
        {
            // Debug.Log("Actor Detected");
        }


        if (Input.GetButtonDown("Fire1"))
        {
            if (balance >= rabbitCost)
            {
                Instantiate(rabbit, new Vector2(Mathf.RoundToInt(mousePoint.x / snapValue) * snapValue, Mathf.RoundToInt(mousePoint.y / snapValue) * snapValue), Quaternion.identity);
                rabbit.GetComponent<Tower>()._player = Player.GetComponent<PlayerController>();
                balance -= rabbitCost;
                balanceText.text = "Coins : " + balance;
                rabbitCost += 2;
            }

            if (balance < rabbitCost)
            {
                balanceText.text = "Not Enough";
            }
           
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (balance >= giraffeCost)
            {
                Instantiate(giraffe, new Vector2(Mathf.RoundToInt(mousePoint.x / snapValue) * snapValue, Mathf.RoundToInt(mousePoint.y / snapValue) * snapValue), Quaternion.identity);
                giraffe.GetComponent<Tower>()._player = Player.GetComponent<PlayerController>();
                balance -= giraffeCost;
                balanceText.text = "Coins : " + balance;
                giraffeCost += 2;
            }

            if (balance < giraffeCost)
            {
                balanceText.text = "Not Enough";
            }

        }

        if(balance <= 0f)
        {
            balanceText.text = "Coins : 0";
        }

        costText.text = "x" + rabbitCost;
        balanceText.text = "Coins : " + balance;
        giraffeCostText.text = "x" + giraffeCost;
    }
}
