using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Vector3 offset;
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    PlayerController controller;
    void Start()
    {
        controller = player.GetComponent<PlayerController>();

        transform.position = player.transform.position - new Vector3(-5, -1.7f, 5);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.cameraoffsetisRight)
        {
            offset = new Vector3(-offsetX, offsetY, offsetZ);
            transform.position = player.transform.position - offset;
            
           
        }
        else
        {
            offset = new Vector3(offsetX, offsetY, offsetZ);
            transform.position = player.transform.position - offset;
            
        }
    }
}
