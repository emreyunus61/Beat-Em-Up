using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
  
{

    public GameObject gamePlayScn;



    // Start is called before the first frame update
    void Start()
    {
        //gamePlay();
    }
    private void Awake()
    {
        gamePlay();
    }


    public void gamePlay()
    {
        StartCoroutine(timewait2());
    }

    IEnumerator timewait2()
    {

        gamePlayScn.SetActive(true);
        yield return new WaitForSecondsRealtime(3.5f);
        gamePlayScn.SetActive(false);


    }


    


    // Update is called once per frame
    void Update()
    {
        
    }
}
