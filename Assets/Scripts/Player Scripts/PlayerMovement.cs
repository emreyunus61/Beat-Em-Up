using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;
    private Rigidbody rb;
    public float speed = 10f;
    public bool theGround = true;

    public float walk_Speed = 2f;
    public float z_Speed = 1.5f;

    private float rotation_Y = -90f;
    private float rotation_Speed = 15f;


    // Start is called before the first frame update


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
       
       player_Anim = GetComponentInChildren<CharacterAnimation>();


    }

    // Update is called once per frame
    void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //transform.Translate(horizontal, 0, vertical);

        //if (Input.GetButtonDown("Jump") && theGround)
        //{
        //    rb.AddForce(new Vector3(0, 11 , 0), ForceMode.Impulse);
        //    theGround = false;
        //}
        
        RotatePlayer(); //bunlar kalck
        AnimatePlayerWalk();
    }


    //zýplama
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Ground" || collision.gameObject.name == "Enemy")
    //        {
    //        theGround = true;
    //    }
    //}
  



    void FixedUpdate()
    {
        DetectMovement();
    }

    void  DetectMovement()//HAREKET
    {

        myBody.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed),myBody.velocity.y,Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed));
        
    }


    void RotatePlayer() //Dönüþ
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) >0 )
        {
            transform.rotation = Quaternion.Euler(0f, rotation_Y, 0f);
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)<0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f); 
        }

    }
    
    void AnimatePlayerWalk() 
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            player_Anim.Walk(true);
        }
        else
        {
            player_Anim.Walk(false);
        }

    }

}
