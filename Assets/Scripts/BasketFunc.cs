using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasketFunc : MonoBehaviour
{

    GameObject selectedObject;
    int i = 0;
    string[] products = new string[50];

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find(RaycastToObject.selectedObject) != null)
        {
            selectedObject = GameObject.Find(RaycastToObject.selectedObject);
            if (selectedObject.tag == "Product" && Input.GetKeyUp(KeyCode.Mouse0))
            {
                GameObject duplicateObj = Instantiate(selectedObject);
                duplicateObj.transform.SetParent(GameObject.Find("basket-alt").transform.parent, false);
                duplicateObj.transform.localPosition = new Vector3(0, 0, 0);
                duplicateObj.transform.localScale = Vector3.one;
                duplicateObj.AddComponent<Rigidbody>();
                Debug.Log(duplicateObj.name.Replace("(Clone)", ""));
                products[i] = duplicateObj.name.Replace("(Clone)", "");
                i++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int j = 0; j < products.Length; j++)
            {
                Debug.Log(products[j]);
            }
        }




    }
}
