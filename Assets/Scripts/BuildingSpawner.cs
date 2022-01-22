using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    
    public float snapValue = 20;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Blocking")))
        {
            Vector2 mousePoint = hit.point;

            
            mousePoint.x = Round(mousePoint.x);
            mousePoint.y = Round(mousePoint.y);

            transform.position = mousePoint;
        }

    }

    private float Round(float input)
    {
        return snapValue * Mathf.Round(input / snapValue);
    }
}
