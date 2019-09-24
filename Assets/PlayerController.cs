using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            GetComponent<Rigidbody>().AddRelativeForce(25, 0, 0);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            GetComponent<Rigidbody>().AddRelativeForce(-25, 0, 0);
        }

        float dx = (Input.mousePosition.x - Screen.width / 2) / 200;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.rotation = Quaternion.Euler(0, dx, 0) * transform.rotation;
        }
    }
}
