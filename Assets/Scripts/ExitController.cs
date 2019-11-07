using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameParameters.level == 1)
        {
            GameParameters.ConfigureLevel2();
            Debug.Log("Pasar al nivel 2");
            Time.timeScale = 1f;
            //Application.LoadLevel("GameScene");

            SceneManager.LoadScene("GameScene");

        }
        else if (GameParameters.level == 2)
        {
            GameParameters.level = 3;
            //GameParameters.level = 2;
            Debug.Log("Pasar al nivel 3");
        }
    }
}
