using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarVida : MonoBehaviour
{
    public AudioSource AmmoPickupSound;//Cambiar por un sonido de juntarVida
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        AmmoPickupSound.Play();

            Vida.vidaJugador += 20;            
            this.gameObject.SetActive(false);
        
    }
}
