using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
   
    public GameObject pauseMenuUI;
    public GameObject player;

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
			if(GameIsPaused){
				Resume();
			}else{
				Pause();
			}
		}
    }
	
	public void Resume(){
        Debug.Log("resume from pause");
        player.GetComponent<FirstPersonController>().enabled = true;
        pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	
	
	void Pause(){
        Debug.Log("on pause");
        player.GetComponent<FirstPersonController>().enabled = false;
        pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
        Cursor.visible = true;
	}
	
	public void LoadMenu(){
        Debug.Log("menu");
        SceneManager.LoadScene("StartMenu");
        player.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
	
	public void QuitGame(){
		Debug.Log("quit");
		Application.Quit();
	}
	
}
