using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI1 : MonoBehaviour
{


    private Image health_UI1;


   void Awake()
    {

        health_UI1 = GameObject.FindWithTag(Tags.HEALTH_UI1).GetComponent<Image>();
    }



    public void DisplayHealth(float value)
    {
        if (gameObject.name == "EnemyZombi")// buraasý
        {
            value /= 100f;

            if (value < 0f)
                value = 0f;
            health_UI1.fillAmount = value;
        }
       
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
