using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarAmmoSMG : MonoBehaviour
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
                AmmoGlobal.LoadedAmmo += 30;
                this.gameObject.SetActive(false);
            }
            else
            {
                AmmoGlobal.CurrentAmmo += 30;
                this.gameObject.SetActive(false);
            }
        }
    }
}
