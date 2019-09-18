using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieFollow : MonoBehaviour
{
    public GameObject Jugador;
    public float targetDistance;
    public float AllowedRange = 10;
    public GameObject Enemigo;
    public float velocidadEnemigo;
    public int Attack;
    public RaycastHit Disparo;
    public int estaAtacando;
    public GameObject Screenflash;
    public AudioSource hurt1;
    public AudioSource hurt2;
    public AudioSource hurt3;
    public int elegirSonido;
    private void Update()
    {
        transform.LookAt(Jugador.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Disparo)) {
            targetDistance = Disparo.distance;
            if (targetDistance<AllowedRange)
            {
                velocidadEnemigo = 0.05f;
                if (Attack==0) {
                    Enemigo.GetComponent<Animation>().Play("Walking");
                    transform.position = Vector3.MoveTowards (transform.position, Jugador.transform.position, velocidadEnemigo);
                }
            }
            else
            {
                velocidadEnemigo = 0;
                Enemigo.GetComponent<Animation>().Play("Idle");
            }
        }

        if (Attack==1)
        {
            if (estaAtacando == 0)
            {
                StartCoroutine(enemyDamage());
            }
            velocidadEnemigo = 0;
            Enemigo.GetComponent<Animation>().Play("Attacking");
        }
    }
    public void OnTriggerEnter()
    {
        Attack = 1;
    }
    public void OnTriggerExit()
    {
        Attack = 0;
    }
    IEnumerator enemyDamage()
    {
        estaAtacando = 1;
        elegirSonido = Random.Range(1, 4);
        yield return new WaitForSeconds(0.9f);
        Screenflash.SetActive(true);
        Vida.vidaJugador -= 10;
        if (elegirSonido == 1)
        {
            hurt1.Play();
        }
        if (elegirSonido == 2)
        {
            hurt2.Play();
        }
        if (elegirSonido == 3)
        {
            hurt3.Play();
        }
        yield return new WaitForSeconds(0.05f);
        Screenflash.SetActive(false);
        yield return new WaitForSeconds(1);
        estaAtacando = 0;
    }

}
