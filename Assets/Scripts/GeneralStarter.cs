using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStarter : MonoBehaviour
{
    public List<GeneralProduct> generalProductList;
    // Start is called before the first frame update
    void Start()
    {

        generalProductList = APIManager.GetProducts("http://localhost:5002/api/products");

        GameObject boardsObject = GameObject.Find("Boards");

        List<GameObject> boardsArray = new List<GameObject>();
        Debug.Log(boardsArray.Count);
        for (int i = 0; i < boardsObject.transform.childCount; i++)
        {
            boardsArray.Add(boardsObject.transform.GetChild(i).gameObject);
            Debug.Log(boardsArray[i]);
            if (generalProductList.Find(x => x.name.Contains(boardsArray[i].transform.name.Replace("-Board", ""))) != null)
            {
                GameObject transferObj = boardsArray[i];
                Transform transferText = transferObj.transform.Find("Canvas/Text");
                //Debug.Log(transferText.GetComponent<UnityEngine.UI.Text>().text);
                transferText.GetComponent<UnityEngine.UI.Text>().text = generalProductList.Find(x => x.name == boardsArray[i].transform.name.Replace("-Board", "")).pcs.ToString() + "TL";
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
