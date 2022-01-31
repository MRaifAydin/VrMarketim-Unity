using UnityEngine;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public static class APIManager
{

    public static List<GeneralProduct> GetProduct(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        List<GeneralProduct> items = JsonConvert.DeserializeObject<List<GeneralProduct>>(json);
        return items;
        //return JsonUtility.FromJson<string>(json);
    }
}
