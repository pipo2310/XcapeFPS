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
        if (CurrentHealth == 100)
        {
            Vida100.SetActive(true);
            Vida80.SetActive(true);
            Vida60.SetActive(true);
            Vida40.SetActive(true);
            Vida20.SetActive(true);
        }
        else if (CurrentHealth >= 80) {
            Vida100.SetActive(false);
            Vida80.SetActive(true);
            Vida60.SetActive(true);
            Vida40.SetActive(true);
            Vida20.SetActive(true);

            //if (Vida100.transform.localScale.y <= 0.0f)
            //{
            //    Vida100.SetActive(false);
            //}
            //else
            //{
            //    Vida100.transform.localScale = new Vector3(0.0f, 0.05f, 0.0f);
            //}
        }

        else if (CurrentHealth >= 60)
        {
            Vida100.SetActive(false);
            Vida80.SetActive(false);
            Vida60.SetActive(true);
            Vida40.SetActive(true);
            Vida20.SetActive(true);
            //if (Vida80.transform.localScale.y <= 0.0f)
            //{
            //    Vida80.SetActive(false);
            //}
            //else
            //{
            //    Vida80.transform.localScale = new Vector3(0.0f, 0.05f, 0.0f);
            //}
        }

        else if (CurrentHealth >= 40)
        {
            Vida100.SetActive(false);
            Vida80.SetActive(false);
            Vida60.SetActive(false);
            Vida40.SetActive(true);
            Vida20.SetActive(true);
            //if (Vida60.transform.localScale.y <= 0.0f)
            //{
            //    Vida60.SetActive(false);
            //}
            //else
            //{
            //    Vida60.transform.localScale = new Vector3(0.0f, 0.05f, 0.0f);
            //}
        }

        else if (CurrentHealth >= 20)
        {
            Vida100.SetActive(false);
            Vida80.SetActive(false);
            Vida60.SetActive(false);
            Vida40.SetActive(false);
            Vida20.SetActive(true);
            //if (Vida40.transform.localScale.y <= 0.0f)
            //{
            //    Vida40.SetActive(false);
            //    //Critical();
            //    //CriticalLife.SetActive(true);
            //}
            //else
            //{
            //    Vida40.transform.localScale = new Vector3(0.0f, 0.05f, 0.0f);
            //}
        }

        else //if (CurrentHealth >= 0)
        {
            Vida100.SetActive(false);
            Vida80.SetActive(false);
            Vida60.SetActive(false);
            Vida40.SetActive(false);
            Vida20.SetActive(false);
            //if (Vida20.transform.localScale.y <= 0.0f)
            //{
            //    Vida20.SetActive(false);

            //}
            //else
            //{
            //    Vida20.transform.localScale = new Vector3(0.0f, 0.05f, 0.0f);
            //}
        }

      
    }
    /*
    void Critical()
    {

        CriticalLife.SetActive(true);


    }
*/}
