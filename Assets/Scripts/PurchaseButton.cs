using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    // Start is called before the first frame update

    //int deneme = 954792;
    Transform purchaseButtonText;
    GameObject purchaseButtonObj;
    BasketButton _basket;
    void Start()
    {
        purchaseButtonObj = GameObject.Find("Purchase-Button");
        purchaseButtonText = purchaseButtonObj.transform.Find("Canvas/Text");
        _basket = GameObject.Find("Basket-Button").GetComponent<BasketButton>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PurchaseFunction()
    {
        Purchase pPurchase = new Purchase();
        pPurchase.basketId = _basket.deneme;
        Debug.Log(APIManager.CreatePurchase("http://localhost:5002/api/purchase", pPurchase));

        purchaseButtonText.GetComponent<UnityEngine.UI.Text>().text = "Başarılı";
    }
}
