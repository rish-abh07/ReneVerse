using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    private Animator anim;
    private Rigidbody playerRb;
    private float dirX;
    private bool isRight;
    private bool flip;

    private enum Movements { idle, walking, kicking, punching, running };

    // Start is called before the first frame update
    void Start()
    {
        anim = Player.GetComponent<Animator>();
        playerRb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovements();

    }
    public void handleMovements()
    {
        Movements state;
        Quaternion newrotation = transform.localRotation;

        dirX = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector3(dirX * 1.5f, playerRb.velocity.y, playerRb.velocity.z);
        if (dirX > 0)
        {

            newrotation = Quaternion.Euler(0.0f, 90f, 0.0f);
            transform.localRotation = newrotation;
            state = Movements.walking;



        }
        else if (dirX < 0)
        {
            newrotation = Quaternion.Euler(0.0f, -90f, 0.0f);
            transform.localRotation = newrotation;
            state = Movements.walking;

        }
        else
        {
            state = Movements.idle;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = Movements.kicking;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            state = Movements.punching;
        }

        anim.SetInteger("state", (int)state);
        Debug.Log((int)state);
    }

}