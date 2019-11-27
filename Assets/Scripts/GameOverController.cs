using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private bool secondsFlag;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (secondsFlag)
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 4 seconds.
        yield return new WaitForSeconds(3);

        secondsFlag = true;
    }
}
