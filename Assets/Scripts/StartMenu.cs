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
    }
	public void PlayLevel1(){

        GameParameters.ConfigureLevel1();
        Application.LoadLevel("GameScene");
        //SceneManager.LoadScene("GameScene");
    }
	
	public void PlayLevel2(){
        GameParameters.ConfigureLevel2();
        Application.LoadLevel("GameScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
	
	public void PlayLevel3(){
        GameParameters.ConfigureLevel3();
        Application.LoadLevel("GameScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
		
	public void QuitGame(){
	   Application.Quit();
	}
}
