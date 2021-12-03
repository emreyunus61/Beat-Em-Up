using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{

    public GameObject CanvasObject;
    //public GameObject PlayScrn;


    //private void OnCollisionEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("sfafsa");
    //        EndScrn.gameObject.SetActive(true);
    //    }
    //}



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EnemyZombi")
        {
            
            CanvasObject.gameObject.SetActive(true);
        }
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
           // Debug.Log("sdknlksfds");
           // PlayScrn.gameObject.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false; // THIS IS THE POINT
            //CanvasObject.SetActive(true);

        }
    }


    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == ("Player"))
    //    {
            
    //        gameObject.GetComponent<BoxCollider>().enabled = false; // THIS IS THE POINT
    //       // gameObject.GetComponent<AudioSource>().enabled = true;
    //    }
    //}


}
