using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarVida : MonoBehaviour
{
    public AudioSource LifePickupSound;//Cambiar por un sonido de juntarVida
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        LifePickupSound.Play();

            Vida.vidaJugador += 20;            
            this.gameObject.SetActive(false);
        
    }
}
