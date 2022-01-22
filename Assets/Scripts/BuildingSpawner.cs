using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    
    public float snapValue = 20;

    public GameObject rabbit;

    public LayerMask actor;


    // Update is called once per frame
    void Update()
    {
        
        
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero, Mathf.Infinity, actor);
        if (hit)
        {
            Debug.Log("Actor Detected");
        }


        if (Input.GetKeyDown("space"))
        {
            Instantiate(rabbit, new Vector2(mousePoint.x, mousePoint.y), Quaternion.identity);
            
        }
    }
}
