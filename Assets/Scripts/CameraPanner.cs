using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanner : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    public float zoomSize = 5f;
    public float zoomLimitMax = 2f;
    public float zoomLimitMin = 4f;

    public Transform followTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        /*

        if(Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y); 

        transform.position = pos; */

        enableZoom();

        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
    }

    public void enableZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(zoomSize > zoomLimitMax)
            zoomSize -= 1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(zoomSize < zoomLimitMin)
            zoomSize += 1;
        }
        GetComponent<Camera>().orthographicSize = zoomSize;
    }
}
