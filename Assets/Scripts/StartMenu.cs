using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	
	public void PlayLevel1(){
        GameParameters.cellsPerSide = 6;
        GameParameters.minZombiesPerCellCount = 0;
        GameParameters.maxZombiesPerCellCount = 1;
        SceneManager.LoadScene("GameScene");
    }
	
	public void PlayLevel2(){
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void PlayLevel3(){
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
		
	public void QuitGame(){
	   Application.Quit();
	}
}
