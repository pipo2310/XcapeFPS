using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameParameters.ConfigureNewGame();

    }
	public void PlayLevel1() {
        GameParameters.ConfigureLevel1();
        SceneManager.LoadScene("GameScene");
    }
	
	public void PlayLevel2() {
        GameParameters.ConfigureLevel2();
        SceneManager.LoadScene("GameScene");
    }
	
	public void PlayLevel3() {
        GameParameters.ConfigureLevel3();
        SceneManager.LoadScene("GameScene");
    }
		
	public void QuitGame() {
	   Application.Quit();
	}
}
