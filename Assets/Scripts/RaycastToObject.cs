using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastToObject : MonoBehaviour
{
    public static string selectedObject;
    public string internalObject;
    public RaycastHit theObject;

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out theObject, 3))
        {
            selectedObject = theObject.transform.gameObject.name;
            internalObject = theObject.transform.gameObject.name;

        }
        else
        {
            selectedObject = null;
            internalObject = null;
        }
        //Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
    }
}
