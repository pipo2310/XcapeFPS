using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarAmmo : MonoBehaviour
{
    public GameObject Jugador;
    public AudioSource AmmoPickupSound;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Jugador)
        {
            AmmoPickupSound.Play();
            if (AmmoGlobal.LoadedAmmo == 0)
            {
                AmmoGlobal.LoadedAmmo += 10;
                this.gameObject.SetActive(false);
            }
            else
            {
                AmmoGlobal.CurrentAmmo += 10;
                this.gameObject.SetActive(false);
            }
        }
    }
}
