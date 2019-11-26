using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoAccion : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (AmmoGlobal.LoadedAmmo >= 1)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    AudioSource gunsound = GetComponent<AudioSource>();
                    gunsound.Play();
                    GetComponent<Animation>().Play("Disparo");
                    AmmoGlobal.LoadedAmmo -= 1;
                }
            }
        }
    }

}
