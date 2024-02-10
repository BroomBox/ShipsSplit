using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObject2 : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.name + " triggered me");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
