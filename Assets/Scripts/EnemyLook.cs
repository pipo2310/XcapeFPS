using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    public GameObject Jugador;
    private void Update()
    {
        transform.LookAt(Jugador.transform);
    }
}
