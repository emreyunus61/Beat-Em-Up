using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public GameObject gameOverScreen;
    public GameObject EndScrn;
    public static bool gameOver;
    public static bool missionComplate;

    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;

    public bool is_Player;

    private HealthUI health_UI;
    private HealthUI1 health_UI1;


    private void Start()
    {
        gameOver = false;
        missionComplate = false;
    }


    private void Update()
    {
        PlayerDeath();
    }


    private void FixedUpdate()
    {
        zombiiDeath();

    }


    private void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();

         health_UI1 = GetComponent<HealthUI1>();
        if (is_Player)
        {
            health_UI = GetComponent<HealthUI>();
            //
        }
    }


    public void ApplyDamage(float damage, bool knockDwon)
    {

        if (characterDied)
            return;

        health -= damage;
       

        //display health UI
        if (is_Player)
        {
            health_UI.DisplayHealth(health);
            
        }
        if (gameObject.tag == "Enemy")
        {

            health_UI1.DisplayHealth(health); //BUrasý
        }

        if (health <= 0f)
        {
            animationScript.Death();
            characterDied = true;

            //if (gameObject.tag == "Enemy")
            //{

            //    if (gameObject.tag == "Ground")
            //    {
            //        gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            //    }
            //}
            StartCoroutine(timewait());

            //if is player deactive enemy script
            if (is_Player)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG)
                    .GetComponent<EnemyMovement>().enabled = false;
            }
            return;

           

        }




        if (!is_Player)
        {
            if (knockDwon)
            {
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }// if is player





    }//aply damage



    public void Destroy()
    {
        Destroy(gameObject);
    }

    IEnumerator timewait()
    {
        if (gameObject.tag == "Enemy")
        {
            yield return new WaitForSecondsRealtime(2.02f);//202
            Destroy();
        }

    }
    IEnumerator timewait1()
    {

        if (gameObject.tag == "Player")
        {
            yield return new WaitForSecondsRealtime(2f);
            gameOverScreen.SetActive(true);

        }

    }
    



    //IEnumerator timewait3()
    //{

    //    if (gameObject.tag == "Enemy")
    //    {
    //        yield return new WaitForSecondsRealtime(2f);
    //        EndScrn.SetActive(true);

    //    }

    //}

    IEnumerator timewait2()
    {

        if (gameObject.name == "EnemyZombi")
        {

            yield return new WaitForSecondsRealtime(2f);
            EndScrn.SetActive(true);

        }

    }





    public void PlayerDeath()
    {
        if (gameObject.tag == "Player")
        {
            if (health <= 0f)
            {
                gameOver = true;
                StartCoroutine(timewait1());
                // gameOverScreen.SetActive(true);
                this.GetComponent<PlayerMovement>().enabled = false;
                this.GetComponent<PlayerAttack>().enabled = false;


            }

        }
    }



    public void zombiiDeath()
    {
        if (gameObject.tag == "Enemy")
        {
            // GameObject.FindGameObjectsWithTag("EnemyZombi");
            if (health <= 0f)
            {
                missionComplate = true;
                StartCoroutine(timewait2());
                // gameOverScreen.SetActive(true);
                this.GetComponent<EnemyMovement>().enabled = false;
                //this.GetComponent<PlayerAttack>().enabled = false;

               
            }

        }
    }


}//class
