using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoGlobal : MonoBehaviour
{
    public static int CurrentAmmo;
    public static int LoadedAmmo;
    
    public GameObject AmmoDisplay;
    public GameObject LoadedDisplay;

    private int InternalAmmo;
    private int InternalLoaded;

    void Update()
    {
        InternalAmmo = CurrentAmmo;
        InternalLoaded = LoadedAmmo;
        AmmoDisplay.GetComponent<Text>().text = "" + InternalAmmo;
        LoadedDisplay.GetComponent<Text>().text = "" + LoadedAmmo;
    }
}
