using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    bool reduce = false;
    [SerializeField] bool isRotate = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (isRotate)
        {
            Rotate();

        }




    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Character"))
        {

            Destroy(gameObject);

        }


    }


   


    public void Rotate()
    {
        transform.Rotate(new Vector3(0,72*Time.deltaTime,0));

    }












}
