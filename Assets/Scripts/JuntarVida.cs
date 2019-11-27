using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarVida : MonoBehaviour
{
    public GameObject Jugador;
    public AudioSource LifePickupSound; // TODO: Cambiar por un sonido de juntarVida

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Jugador)
        {
            LifePickupSound.Play();
            if (HealthGlobal.CurrentHealth < 100)
            {
                if (HealthGlobal.CurrentHealth <= 80)
                {
                    HealthGlobal.CurrentHealth += 20;
                }
                else
                {
                    HealthGlobal.CurrentHealth += 10;
                }
            }
            this.gameObject.SetActive(false);
        }
    }
}
