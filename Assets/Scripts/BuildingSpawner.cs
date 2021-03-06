using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawner : MonoBehaviour
{

    public float snapValue = 20;

    public GameObject rabbit;

    public LayerMask actor;

    public int rabbitCost = 2;
    public Text costText;
    public Text balanceText;

    public int balance = 20;

    void Start()
    {
        costText.text = "Rabbit Cost: " + rabbitCost;
        balanceText.text = "Total Coins : " + balance;
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


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            balanceText.text = "Total Coins : " + balance;
            if (balance >= rabbitCost)
            {
                Instantiate(rabbit, new Vector2(mousePoint.x, mousePoint.y), Quaternion.identity);
                rabbitCost += 2;
                balance -= rabbitCost;

            }

            if (balance < rabbitCost)
            {
                Debug.Log("Insufficient balance");
            }
           
        }

        costText.text = "Rabbit Cost: " + rabbitCost;
        balanceText.text = "Total Coins : " + balance;
    }
}
