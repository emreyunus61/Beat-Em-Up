using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;

    public bool is_Player;


    private void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
    }


    public void ApplyDamage(float damage, bool knockDwon)
    {

        if (characterDied)
            return;

         health -= damage;

        //3,42


        if (health <= 0f)
        {
            animationScript.Death();
            characterDied = true;

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
                if (Random.Range(0,2) > 0)
                {
                    animationScript.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0,3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }// if is player


    }//aply damage


  

}//class
