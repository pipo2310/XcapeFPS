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
        if (Vida.vidaJugador < 100)
        {
            if (Vida.vidaJugador <= 80)
            {
                Vida.vidaJugador += 20;
            }
            else
            {
                Vida.vidaJugador += 10;
            }
        }
        this.gameObject.SetActive(false);
    }
}
