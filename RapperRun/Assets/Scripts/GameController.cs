using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
 {

    public GameObject player;
    public GameObject failScreen;
    public GameObject successScreen;
    Player playerscript;
    Movement movescript;
    void Start()
    {
        playerscript = player.GetComponent<Player>();
        movescript= player.GetComponent<Movement>();


    }



    void Update()
    {

        Fail();
        Success();

        
    }

    [System.Obsolete]
    public void Fail()
    {
        
        if(playerscript.value==0  && playerscript.firsttouch==true && player.transform.GetChild(0).gameObject.active)
        {
            movescript.enabled = false;

            playerscript.firsttouch = false;

            failScreen.SetActive(true);

        }

        if(player.transform.GetChild(0).gameObject.active && playerscript.failed == true)
        {
            movescript.enabled = false;

           // playerscript.firsttouch = false;

            failScreen.SetActive(true);


        }






    }



    public void Success()
    {

        if (playerscript.success)
        {
            successScreen.SetActive(true);
            movescript.enabled = false;

        }




    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }











 }
