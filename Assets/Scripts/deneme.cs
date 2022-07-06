using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    GameObject duplicateObj;
    Transform transferText;
    GameObject transferObj;
    GeneralStarter _generalStarter;

    BasketButton _basket;
    //int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        transferObj = GameObject.Find("CashierBoard");
        transferText = transferObj.transform.Find("Canvas/Text");
        //_basket = new BasketButton();
        _basket = GameObject.Find("Basket-Button").GetComponent<BasketButton>();
        _generalStarter = GameObject.Find("GeneralStarter").GetComponent<GeneralStarter>();
    }

    // Update is called once per frame
    void Update()
    {
        //toBasket();

    }

    public void toBasket()
    {

        duplicateObj = Instantiate(gameObject);
        //GameObject duplicateObj = Instantiate(gameObject);
        duplicateObj.transform.SetParent(GameObject.Find("basket-alt").transform.parent, false);
        duplicateObj.transform.localPosition = new Vector3(0, 0, 0);
        duplicateObj.transform.localScale = Vector3.one;
        duplicateObj.AddComponent<Rigidbody>();
        duplicateObj.name.Replace("(Clone)", "");
        
        for (int i = 0; i < _generalStarter.generalProductList.Count; i++)
        {
            if (duplicateObj.name.Replace("(Clone)", "") == _generalStarter.generalProductList[i].name)
            {
                _basket.products += _generalStarter.generalProductList[i].id+",";  
            }
        }

        //i++;
        transferText.GetComponent<UnityEngine.UI.Text>().text += duplicateObj.name.Replace("(Clone)", "") + "\n";





    }
}
