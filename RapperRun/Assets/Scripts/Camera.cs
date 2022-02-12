using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    public Vector3 distance;
    [SerializeField] float smooth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = Vector3.Lerp(this.transform.position,target.transform.position+distance, smooth);


        
    }
}
