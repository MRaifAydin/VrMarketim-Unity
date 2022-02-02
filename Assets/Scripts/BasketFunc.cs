using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class BasketFunc : MonoBehaviour
{

    GameObject selectedObject;
    int i = 0;
    string products;
    Transform transferText;
    GameObject transferObj;
    Transform basketButtonText;
    GameObject basketButtonObj;
    Transform purchaseButtonText;
    GameObject purchaseButtonObj;
    int deneme = 0;

    // Start is called before the first frame update

    void Start()
    {
        transferObj = GameObject.Find("CashierBoard");
        transferText = transferObj.transform.Find("Canvas/Text");
        basketButtonObj = GameObject.Find("Basket-Button");
        basketButtonText = basketButtonObj.transform.Find("Canvas/Text");
        purchaseButtonObj = GameObject.Find("Purchase-Button");
        purchaseButtonText = purchaseButtonObj.transform.Find("Canvas/Text");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            selectedObject = GameObject.Find(RaycastToObject.selectedObject);
            if (selectedObject.tag == "Product")
            {
                GameObject duplicateObj = Instantiate(selectedObject);
                duplicateObj.transform.SetParent(GameObject.Find("basket-alt").transform.parent, false);
                duplicateObj.transform.localPosition = new Vector3(0, 0, 0);
                duplicateObj.transform.localScale = Vector3.one;
                duplicateObj.AddComponent<Rigidbody>();
                Debug.Log(duplicateObj.name.Replace("(Clone)", ""));
                products += duplicateObj.name.Replace("(Clone)", "") + ",";
                i++;
                transferText.GetComponent<UnityEngine.UI.Text>().text += duplicateObj.name.Replace("(Clone)", "") + "\n";
            }


            if (selectedObject.name == "Basket-Button")
            {
                Basket pBasket = new Basket();
                pBasket.AccountId = 367;
                pBasket.Products = "" + products;
                string response = APIManager.CreateBasket("http://localhost:5002/api/baskets", pBasket);
                int numberEnd = response.IndexOf(",");
                int numberStart = response.IndexOf(":") + 1;
                deneme = Convert.ToInt32(response.Substring(6, numberEnd - numberStart));

                basketButtonText.GetComponent<UnityEngine.UI.Text>().text = "Başarılı";
            }

            if (selectedObject.name == "Purchase-Button")
            {
                Purchase pPurchase = new Purchase();
                pPurchase.basketId = deneme;
                Debug.Log(APIManager.CreatePurchase("http://localhost:5002/api/purchase", pPurchase));

                purchaseButtonText.GetComponent<UnityEngine.UI.Text>().text = "Başarılı";
            }
        }

        //Input.GetKeyUp(KeyCode.Joystick1Button0)






    }
}
