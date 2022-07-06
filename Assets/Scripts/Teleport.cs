using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("CardboardMain");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void teleportPlayer()
    {
        player.transform.position = new Vector3(6.65f, 2.68f, 63f);
    }
}
