using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public bool GameIsPaused = false, ConfigIsClose = true;
	public GameObject PauseMenuUI;
	public GameObject ConfigMenuUI;

	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (GameIsPaused) {
				Resume ();
			} 
			else 
			{
				Pause ();
			}
		}
	}
	//==========PAUSE============
	public void Resume ()
	{
		PauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	public void Pause ()
	{
		PauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	//==========CONFIGS============
	public void ConfigOpen ()
	{
		ConfigMenuUI.SetActive (true);
		//Time.timeScale = 1f;
		ConfigIsClose = false;
	}
	public void ConfigClose ()
	{
		ConfigMenuUI.SetActive (false);
		//Time.timeScale = 0f;
		ConfigIsClose = true;
	}
	//==========BUTTONS=============
	public void OpenOrCloseConfigbtn()
	{
		if (ConfigIsClose)
		{
			ConfigOpen ();
			PauseMenuUI.SetActive (false);
		}
		else 
		{
			ConfigClose ();
			PauseMenuUI.SetActive (true);
		}
	}
	public void MudarCena(string nomeDaCena){
		SceneManager.LoadScene(nomeDaCena);
	}
}
