using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    // Start is called before the first frame update
    public static int vidaJugador = 100;
    public int vidaInterna;
    public GameObject displayVida;
    public void Update()
    {
        vidaInterna = vidaJugador;
        displayVida.GetComponent<Text> ().text = "Vida: " + vidaJugador;
        if (vidaJugador==0) {
            SceneManager.LoadScene(2);
        }


    }
}
