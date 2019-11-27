using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthGlobal : MonoBehaviour
{
    public static int CurrentHealth;

    public GameObject displayVida;

    private int vidaInterna;
    
    public void Update()
    {
        vidaInterna = CurrentHealth;
        displayVida.GetComponent<Text> ().text = "Vida: " + CurrentHealth;
        if (CurrentHealth<=0) {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
