using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public AudioSource ReloadSound;
    public GameObject CrossObject;
    public GameObject MechanicsObject;
    public int ClipCount;
    public int ReserveCount;
    public int ReloadAvailable;
    //public DisparoAccion GunComponent;

    void Start()
    {
        //GunComponent = GetComponent<DisparoAccion>();
    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            ClipCount = AmmoGlobal.LoadedAmmo;
            ReserveCount = AmmoGlobal.CurrentAmmo;

            if (ReserveCount == 0)
            {
                ReloadAvailable = 0;
            }
            else
            {
                ReloadAvailable = 10 - ClipCount;
            }

            if (Input.GetButtonDown("Reload"))
            {
                if (ReloadAvailable >= 1)
                {
                    if (ReserveCount <= ReloadAvailable)
                    {
                        AmmoGlobal.LoadedAmmo += ReserveCount;
                        AmmoGlobal.CurrentAmmo -= ReserveCount;
                        ActionReload();
                    }
                    else
                    {
                        AmmoGlobal.LoadedAmmo += ReloadAvailable;
                        AmmoGlobal.CurrentAmmo -= ReloadAvailable;
                        ActionReload();
                    }
                }
                StartCoroutine(EnableScripts());

            }
        }
    }

    IEnumerator EnableScripts()
    {
        yield return new WaitForSeconds(1.1f);
        //GunComponent.enabled = true;
        CrossObject.SetActive(true);
        MechanicsObject.SetActive(true);
    }

    void ActionReload()
    {
        //GunComponent.enabled = false;
        CrossObject.SetActive(false);
        MechanicsObject.SetActive(false);
        ReloadSound.Play();
        GetComponent<Animation>().Play("Reload");
    }
}
