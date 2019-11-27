using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonitor : MonoBehaviour
{
    public GameObject Vida100;
    public GameObject Vida80;
    public GameObject Vida60;
    public GameObject Vida40;
    public GameObject Vida20;
    //public GameObject CriticalLife;
    private int InternalHealth;

    // Update is called once per frame
    public void Update()
    {
       // CriticalLife.SetActive(false);
        InternalHealth = HealthGlobal.CurrentHealth;
        if (InternalHealth == 100)
        {
            Vida100.SetActive(true);
            Vida80.SetActive(true);
            Vida60.SetActive(true);
            Vida40.SetActive(true);
            Vida20.SetActive(true);
        }
        else if (InternalHealth >= 80) {
            Vida100.SetActive(false);
            Vida80.SetActive(true);
            Vida60.SetActive(true);
            Vida40.SetActive(true);
            Vida20.SetActive(true);
        }
        else if (InternalHealth >= 60)
        {
            Vida100.SetActive(false);
            Vida80.SetActive(false);
            Vida60.SetActive(true);
            Vida40.SetActive(true);
            Vida20.SetActive(true);
        }
        else if (InternalHealth >= 40)
        {
            Vida100.SetActive(false);
            Vida80.SetActive(false);
            Vida60.SetActive(false);
            Vida40.SetActive(true);
            Vida20.SetActive(true);
        }
        else if (InternalHealth >= 20)
        {
            Vida100.SetActive(false);
            Vida80.SetActive(false);
            Vida60.SetActive(false);
            Vida40.SetActive(false);
            Vida20.SetActive(true);
        }
        else
        {
            Vida100.SetActive(false);
            Vida80.SetActive(false);
            Vida60.SetActive(false);
            Vida40.SetActive(false);
            Vida20.SetActive(false);
        }
    }
}
