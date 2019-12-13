using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform SpawnPoint;
    void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.name == "bulletforhealthscript")
        {
           transform.position = SpawnPoint.transform.position;
        }
    }
      
}
