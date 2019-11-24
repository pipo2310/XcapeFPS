using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    // Start is called before the first frame update
public static float DistanceFromTarget;
    public float ToTarget;
 
 void Update ()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            ToTarget = hit.distance;
            DistanceFromTarget = ToTarget;
        }
    }
}
