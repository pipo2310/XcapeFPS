using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonitor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Vida100;
    public GameObject Vida80;
    public GameObject Vida60;
    public GameObject Vida40;
    public GameObject Vida20;
    //public GameObject CriticalLife;
    public int CurrentHealth;

    // Update is called once per frame
    public void Update()
    {
       // CriticalLife.SetActive(false);
        CurrentHealth = Vida.vidaJugador;
        if (CurrentHealth==80) {
            if (Vida100.transform.localScale.y <= 0.0f)
            {
                Vida100.SetActive(false);
            }
            else
            {
                Vida100.transform.localScale = new Vector3(0.0f, 0.05f, 0.0f);
            }
        }

        if (CurrentHealth == 60)
        {
            if (Vida80.transform.localScale.y <= 0.0f)
            {
                Vida80.SetActive(false);
            }
            else
            {
                Vida80.transform.localScale = new Vector3(0.0f, 0.05f, 0.0f);
            }
        }

        if (CurrentHealth == 40)
        {
            if (Vida60.transform.localScale.y <= 0.0f)
            {
                Vida60.SetActive(false);
            }
            else
            {
                Vida60.transform.localScale = new Vector3(0.0f, 0.05f, 0.0f);
            }
        }

        if (CurrentHealth == 20)
        {
            if (Vida40.transform.localScale.y <= 0.0f)
            {
                Vida40.SetActive(false);
                //Critical();
                //CriticalLife.SetActive(true);
            }
            else
            {
                Vida40.transform.localScale = new Vector3(0.0f, 0.05f, 0.0f);
            }
        }

        if (CurrentHealth == 0)
        {
            if (Vida20.transform.localScale.y <= 0.0f)
            {
                Vida20.SetActive(false);
                
            }
            else
            {
                Vida20.transform.localScale = new Vector3(0.0f, 0.05f, 0.0f);
            }
        }

      
    }
    /*
    void Critical()
    {

        CriticalLife.SetActive(true);


    }
*/}
