using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speed;
    private Touch touch;

    bool RightRotate = false;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(transform.rotation.eulerAngles.y);


        if (RightRotate)
        {
            float zPos = Mathf.Clamp(transform.position.z, 33.5f,40);
            transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
        }
        else
        {

            float xPos = Mathf.Clamp(transform.position.x, -3.17f, 3.5f);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }



        transform.Translate(0, 0, speed * Time.deltaTime);

        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);






            if (touch.phase == TouchPhase.Moved)
            {
               

                if (transform.rotation.y == 0 || transform.rotation.y == 180)
                {
                    RightRotate = false;
                   
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime,
                 transform.position.y,
                 transform.position.z), 0.5f
                 );

                  
                }
              
             
                else 
                {
                    RightRotate = true;
                    

                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,
             transform.position.y,
             transform.position.z + -touch.deltaPosition.x * speed * Time.deltaTime), 0.5f
             );



                }






            }
        }




    }
}
