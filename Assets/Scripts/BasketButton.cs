using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketButton : MonoBehaviour
{

    // Start is called before the first frame update

    public string products;
    public int deneme = 0;
    Transform basketButtonText;
    GameObject basketButtonObj;
    public Basket pBasket;



    void Start()
    {
        basketButtonObj = GameObject.Find("Basket-Button");
        basketButtonText = basketButtonObj.transform.Find("Canvas/Text");
        pBasket = new Basket();
        pBasket.AccountId = 15;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void basketFunc()
    {
        //pBasket.AccountId = 95634;
        pBasket.Products = "" + products.Remove(products.Length-1,1);
        string response = APIManager.CreateBasket("http://localhost:5002/api/baskets", pBasket);
        int numberEnd = response.IndexOf(",");
        int numberStart = response.IndexOf(":") + 1;
        deneme = Convert.ToInt32(response.Substring(6, numberEnd - numberStart));
        Debug.Log(products);

        basketButtonText.GetComponent<UnityEngine.UI.Text>().text = "Başarılı";
    }
}
