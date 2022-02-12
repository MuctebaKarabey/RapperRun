using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
  
   
    public GameObject bar;
    public  float value;
    public bool firsttouch=false;
    public bool bool_touch = false;
    public Animator animator;

    public GameObject characters;

    GameObject activeChild = null;

    public bool failed = false;

    public bool finish = false;
    public GameObject barText;

    public int counter=0;
    int index;
 
    bool rotating = false;

    public bool success=false;

    Vector3 euler;



    void Start()
    {


        animator = GetComponent<Animator>();

        value = 0;

     

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {



       




        if (rotating)
        {

            transform.Rotate(new Vector3(0, 90, 0),Time.deltaTime*75);
            Vector3 playerHeadEulerAngles = transform.rotation.eulerAngles;
            playerHeadEulerAngles.y = Mathf.Clamp(playerHeadEulerAngles.y, -360, euler.y+90);
            transform.rotation = Quaternion.Euler(playerHeadEulerAngles);
            StartCoroutine(RotateTime(1.80f));

        }



        if (finish == true && gameObject.transform.GetChild(1).gameObject.active)
        {

            transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(transform.position.x,transform.position.y+3),Time.deltaTime*5);

            

        }

        if(gameObject.transform.GetChild(3).gameObject.active && value >= 50)
        {
            value = 50;
            bar.transform.localScale = new Vector3(value / 50, 1, 1);


        }




    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("GoodItem"))
        {
            bool_touch = true;



          


            if (value < 50)
            {
                value += 2;
                bar.transform.localScale = new Vector3(value / 50, 1, 1);

               
            }


 

            if (value >= 50 && gameObject.transform.GetChild(3).gameObject.active == false)
            {

    
                foreach (Transform child in transform)
                {
                    if (child.gameObject.activeSelf)
                    {
                        activeChild = child.gameObject;
                        index = activeChild.transform.GetSiblingIndex();
                        Debug.Log(index);
                        break;
                    }
                }

                activeChild.SetActive(false);
                gameObject.transform.GetChild(index +1).gameObject.SetActive(true);

                barText.transform.GetChild(index).gameObject.SetActive(false);
                barText.transform.GetChild(index+1).gameObject.SetActive(true);



                gameObject.transform.GetChild(index + 1).GetComponent<Animator>().SetTrigger("rotate");
                gameObject.transform.GetChild(index + 1).GetComponent<Animator>().SetTrigger("walk");

            



                value = 0;
                bar.transform.localScale = new Vector3(value / 50, 1, 1);

            }







        }



        if (other.gameObject.CompareTag("RightRotateCollider"))
        {

            euler= transform.rotation.eulerAngles; 

            rotating = true;



        }



        if (other.gameObject.CompareTag("Finish"))
        {

            finish = true;

        }


        if (other.gameObject.CompareTag("FinishCollider"))
        {

            success = true;
        }



        if (other.gameObject.CompareTag("Door"))
        {

            Destroy(other.gameObject);

        }


        if (other.gameObject.CompareTag("BadItem"))
        {
            firsttouch = true;

           


            Destroy(other.gameObject);


            if (value <= 2 && gameObject.transform.GetChild(0).gameObject.active==false)
            {
                foreach (Transform child in transform)
                {
                    if (child.gameObject.activeSelf)
                    {
                       activeChild = child.gameObject;
                      index=activeChild.transform.GetSiblingIndex();
                        Debug.Log(index);
                        break;
                    }
                }

                activeChild.SetActive(false);
                gameObject.transform.GetChild(index-1).gameObject.SetActive(true);


                value = 50;
                bar.transform.localScale = new Vector3(value / 50, 1, 1);

            }

            if (value >= 2)
            {
                value -= 2;

              

                bar.transform.localScale = new Vector3(value / 50, 1, 1);

            }

   
            

        }

        if (other.gameObject.CompareTag("Fail"))
        {

            failed = true;


        }



    }

    IEnumerator RotateTime(float time)
    {

        

        yield return new WaitForSeconds(time);
        rotating = false;
       
    }

    



}



   

















