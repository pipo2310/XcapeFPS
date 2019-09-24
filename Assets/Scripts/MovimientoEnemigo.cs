using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject Enemigo;
    public float velocidadEnemigo;
    public int moveTrigger;
    private void Update()
    {
        if (moveTrigger == 1) {
        velocidadEnemigo = 0.02f;
        transform.position = Vector3.MoveTowards(transform.position, Jugador.transform.position, velocidadEnemigo);
    }
    }
}
