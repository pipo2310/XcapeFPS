using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAccion : MonoBehaviour
{
    public int EnemyHealth = 10;
    public GameObject zombie;
    public GameObject dropAmmo;
    public GameObject dropVida;
    

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
        System.Random rnd = new System.Random();
        yield return new WaitForSeconds(3);
        int randomDrop = rnd.Next(1, 3);
        if (randomDrop == 1)
        {
            Instantiate(dropAmmo, transform.position, dropAmmo.transform.rotation);
            dropAmmo.SetActive(true);
        }
        else
        {
            Instantiate(dropVida, transform.position, dropVida.transform.rotation);
            dropVida.SetActive(true);
        }
        
        Destroy(gameObject);
        //Vida.vidaJugador += 20;
        

    }
}
