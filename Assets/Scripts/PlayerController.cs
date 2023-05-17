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
    public bool cameraoffsetisRight ;
    private float velocity = 1.5f;
    public float speed = 1.5f;
    public float accelerate = 0.1f;

    private enum Movements { idle,  kicking, punching, walking };

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
        playerRb.velocity = new Vector3(dirX * speed, playerRb.velocity.y, playerRb.velocity.z);
        
        if (dirX > 0)
        {

            newrotation = Quaternion.Euler(0.0f, 90f, 0.0f);
            transform.localRotation = newrotation;
            velocity += Time.deltaTime * accelerate;
           state = Movements.walking;
           
            cameraoffsetisRight = false;


        }
        else if (dirX < -0.5)
        {
            newrotation = Quaternion.Euler(0.0f, -90f, 0.0f);
            transform.localRotation = newrotation;
            state = Movements.walking;
            velocity += Time.deltaTime * accelerate;
            cameraoffsetisRight = true;

        }
        else
        {
            state = Movements.idle;
            velocity = 1.5f;
        }
        speed = velocity * 4;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = Movements.kicking;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            state = Movements.punching;
        }

        anim.SetInteger("state", (int)state);
        anim.SetFloat("Velocity", velocity); 
        Debug.Log(dirX);
        Debug.Log(velocity);
    }

}