using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Health : MonoBehaviour
{
    public Transform SpawnPoint;
    void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.name == "bulletforhealthscript")
        {
            transform.position = new Vector3(69, 2, 2);
        }
    }
      
}
