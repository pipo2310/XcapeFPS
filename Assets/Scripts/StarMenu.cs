using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarMenu : MonoBehaviour
{
	
	public void PlayLevel1(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void PlayLevel2(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void PlayLevel3(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
		
	public void QuitGame(){
	   Debug.Log("QUIT");
	   Application.Quit();
	}
}
