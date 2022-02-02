using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStarter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        List<GeneralProduct> generalProductList = APIManager.GetProducts("http://localhost:5002/api/products");

        GameObject boardsObject = GameObject.Find("Boards");

        string[] boardsArray = new string[boardsObject.transform.childCount];
        for (int i = 0; i < boardsObject.transform.childCount; i++)
        {
            boardsArray[i] = GameObject.Find("Boards").transform.GetChild(i).name;
            //Debug.Log(boardsArray[i]);
            if (generalProductList.Find(x => x.name.Contains(boardsArray[i].Replace("-Board", ""))) != null)
            {
                GameObject transferObj = GameObject.Find(boardsArray[i]);
                Transform transferText = transferObj.transform.Find("Canvas/Text");
                Debug.Log(transferText.GetComponent<UnityEngine.UI.Text>().text);
                transferText.GetComponent<UnityEngine.UI.Text>().text = generalProductList.Find(x => x.name == boardsArray[i].Replace("-Board", "")).pcs.ToString();
                transferObj = null;
                transferText = null;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
