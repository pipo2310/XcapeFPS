using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState { Wait, Walk, Attack, Die }

public class ZombieController : MonoBehaviour
{
    public GameObject Zombie;
    public GameObject Jugador;
    public GameObject Ammo9mm;
    public GameObject AmmoSMG;
    private GameObject AmmoDrop;
    public GameObject Life;
    private GameObject LifeDrop;
    public GameObject Screenflash;
    public int zombieHealth = 10;
    public float zombieSpeed;
    public float allowedAttackRange = 1;
    private ZombieState currentState;

    private bool isAttacking;
    private bool isDying;

    public AudioSource hurt1;
    public AudioSource hurt2;
    public AudioSource hurt3;
    private int hurtAudio;

    // Start is called before the first frame update
    void Start()
    {
        currentState = ZombieState.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            transform.LookAt(Jugador.transform);
            RaycastHit res;

            switch (currentState)
            {
                case ZombieState.Wait:
                    if (zombieHealth <= 0)
                    {
                        currentState = ZombieState.Die;
                    }
                    else
                    {
                        Zombie.GetComponent<Animation>().Play("Idle");
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out res))
                        {
                            if (res.collider.gameObject == Jugador)
                            {
                                if (res.distance < allowedAttackRange)
                                {
                                    currentState = ZombieState.Attack;
                                }
                                else
                                {
                                    currentState = ZombieState.Walk;
                                }
                            }
                        }
                    }
                    break;
                case ZombieState.Walk:
                    if (zombieHealth <= 0)
                    {
                        currentState = ZombieState.Die;
                    }
                    else
                    {
                        Zombie.GetComponent<Animation>().Play("Walking");
                        zombieSpeed = 0.05f;
                        transform.position = Vector3.MoveTowards(transform.position, Jugador.transform.position, zombieSpeed);
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out res))
                        {
                            if (res.collider.gameObject == Jugador)
                            {
                                if (res.distance < allowedAttackRange)
                                {
                                    currentState = ZombieState.Attack;
                                }
                            }
                            else
                            {
                                currentState = ZombieState.Wait;
                            }
                        }
                    }
                    break;
                case ZombieState.Attack:
                    if (zombieHealth <= 0)
                    {
                        currentState = ZombieState.Die;
                    }
                    else
                    {
                        Zombie.GetComponent<Animation>().Play("Attacking");
                        zombieSpeed = 0;
                        transform.position = Vector3.MoveTowards(transform.position, Jugador.transform.position, zombieSpeed);
                        if (!isAttacking)
                        {
                            StartCoroutine(ZombieDamage());
                        }
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out res))
                        {
                            if (res.collider.gameObject == Jugador)
                            {
                                if (res.distance > allowedAttackRange)
                                {
                                    currentState = ZombieState.Walk;
                                }
                            }
                            else
                            {
                                currentState = ZombieState.Wait;
                            }
                        }
                    }
                    break;
                case ZombieState.Die:
                    if (!isDying)
                    {
                        Zombie.GetComponent<Animation>().Play("Dying");
                        StartCoroutine(EndZombie());
                    }
                    break;
            }
        }
    }

    void DeductPoints(int DamageAmount)
    {
        zombieHealth -= DamageAmount;
    }

    IEnumerator ZombieDamage()
    {
        isAttacking = true;
        hurtAudio = Random.Range(1, 4);
        yield return new WaitForSeconds(0.9f);
        Screenflash.SetActive(true);
        HealthGlobal.CurrentHealth -= 10;
        switch (hurtAudio)
        {
            case 1:
                hurt1.Play();
                break;
            case 2:
                hurt2.Play();
                break;
            case 3:
                hurt3.Play();
                break;
        }
        yield return new WaitForSeconds(0.05f);
        Screenflash.SetActive(false);
        yield return new WaitForSeconds(1);
        isAttacking = false;
    }

    IEnumerator EndZombie()
    {
        isDying = true;
        System.Random rnd = new System.Random();
        yield return new WaitForSeconds(3);
        int randomDrop = rnd.Next(0, 10);
        if (AmmoGlobal.CurrentAmmo == 0 || (HealthGlobal.CurrentHealth >= 30 && randomDrop <= 6))
        {
            if (randomDrop < 4)
            {
                AmmoDrop = Instantiate(Ammo9mm, new Vector3(transform.position.x, Ammo9mm.transform.position.y, transform.position.z), Ammo9mm.transform.rotation);
            } else
            {
                AmmoDrop = Instantiate(AmmoSMG, new Vector3(transform.position.x, AmmoSMG.transform.position.y, transform.position.z), AmmoSMG.transform.rotation);
            }
            AmmoDrop.SetActive(true);
        }
        else
        {
            LifeDrop = Instantiate(Life, new Vector3(transform.position.x, Life.transform.position.y, transform.position.z), Life.transform.rotation);
            LifeDrop.SetActive(true);
        }

        Destroy(gameObject);
    }
}