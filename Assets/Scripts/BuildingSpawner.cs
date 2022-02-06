using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawner : MonoBehaviour
{

    public float snapValue = 16;

    public GameObject rabbit;
    public GameObject giraffe;

    public LayerMask actor;

    public int rabbitCost = 2;
    public int giraffeCost = 3;
    public Text costText;
    public Text giraffeCostText;
    public Text balanceText;

    public int balance = 20;

    void Start()
    {
        costText.text = "Rabbit Cost: " + rabbitCost;
        balanceText.text = "Total Coins : " + balance;
        giraffeCostText.text = "Giraffe Cost: " + giraffeCost;
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
            balanceText.text = "Total Coins : " + balance;
            if (balance >= rabbitCost)
            {
                Instantiate(rabbit, new Vector2(Mathf.RoundToInt(mousePoint.x / snapValue) * snapValue, Mathf.RoundToInt(mousePoint.y / snapValue) * snapValue), Quaternion.identity);
                rabbitCost += 2;
                balance -= rabbitCost;

            }

            if (balance < rabbitCost)
            {
                Debug.Log("Insufficient balance");
            }
           
        }
        if (Input.GetButtonDown("Fire2"))
        {
            balanceText.text = "Total Coins : " + balance;
            if (balance >= giraffeCost)
            {
                Instantiate(giraffe, new Vector2(Mathf.RoundToInt(mousePoint.x / snapValue) * snapValue, Mathf.RoundToInt(mousePoint.y / snapValue) * snapValue), Quaternion.identity);
                giraffeCost += 2;
                balance -= giraffeCost;

            }

            if (balance < giraffeCost)
            {
                Debug.Log("Insufficient balance");
            }

        }

        costText.text = "Rabbit Cost: " + rabbitCost;
        balanceText.text = "Total Coins : " + balance;
        giraffeCostText.text = "Giraffe Cost: " + giraffeCost;
    }
}
