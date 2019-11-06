using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAccion : MonoBehaviour
{
    public int EnemyHealth = 10;
    public GameObject zombie;

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    void Update()
    {
        if (EnemyHealth <= 0)
        {
            this.GetComponent<zombieFollow>().enabled = false;
            zombie.GetComponent<Animation>().Play("Dying");
            StartCoroutine(EndZombie());
            
            //Destroy(gameObject);
        }
    }

    IEnumerator EndZombie()
    {
        
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        Vida.vidaJugador += 20;
        

    }
}
