using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoSMG : MonoBehaviour
{
	public GameObject TheSMG;
	public AudioSource SMGSound;
	public int cantAmmo;
	public int disparando=0;
	public GameObject UpCurs;
    public GameObject DownCurs;
    public GameObject LeftCurs;
    public GameObject RightCurs;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            cantAmmo = AmmoGlobal.LoadedAmmo;
            if (Input.GetButton("Fire1"))
            {
                if (cantAmmo >= 1)
                {
                    if (disparando == 0)
                    {
                        StartCoroutine(SMGFire());
                    }
                }
            }
        }
    }
	IEnumerator SMGFire(){
		disparando=1;
		UpCurs.GetComponent<Animator>().enabled = true;
        DownCurs.GetComponent<Animator>().enabled = true;
        LeftCurs.GetComponent<Animator>().enabled = true;
        RightCurs.GetComponent<Animator>().enabled = true;
		AmmoGlobal.LoadedAmmo-=1;
		SMGSound.Play();
		TheSMG.GetComponent<Animator>().enabled = true;
		yield return new WaitForSeconds(0.1f);
		TheSMG.GetComponent<Animator>().enabled = false;
		UpCurs.GetComponent<Animator>().enabled = false;
        DownCurs.GetComponent<Animator>().enabled = false;
        LeftCurs.GetComponent<Animator>().enabled = false;
        RightCurs.GetComponent<Animator>().enabled = false;
		disparando=0;
	}
}
