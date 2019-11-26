using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoSMG : MonoBehaviour
{
    public int DamageAmount;
    public float TargetDistance;
    public float AllowedRange = 15.0f;
	public RaycastHit hit;
	public GameObject TheBullet;
	public GameObject Blood;
	
  void Start(){
	  DamageAmount=4;
  }

    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (AmmoGlobal.LoadedAmmo >= 1)
            {
                if (Input.GetButton("Fire1"))
                {
                    RaycastHit Shot;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                    {
                        TargetDistance = Shot.distance;
                        if (TargetDistance < AllowedRange)
                        {
                            //Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                            {
                                Debug.Log("Hello: " + hit.transform.tag);
                                if (hit.transform.tag == "Zombie")
                                {
                                    Instantiate(Blood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                                }
                                else
                                {
                                    Instantiate(TheBullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                                }

                                if (hit.collider.tag == "ZombieHead")
                                {
                                    Debug.Log("Le has dado en la cabeza con la SMG " + hit.transform.tag);
                                    DamageAmount = 10;
                                    Instantiate(Blood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                                }
                            }
                            Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                            DamageAmount = 4;
                        }
                    }
                }
            }
        }
    }
}
