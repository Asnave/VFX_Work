using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFracturedObjectScript : MonoBehaviour
{
    public GameObject originalObject;
    public GameObject fracturedObject;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown (0))
        {
            SpawnFracturedObject();
        }
    }

    public void SpawnFracturedObject()
    {
        Destroy(originalObject);
        GameObject fractObj = Instantiate(fracturedObject) as GameObject;
        fractObj.GetComponent<ExplodeScript>().Explode();
        
    }
}
