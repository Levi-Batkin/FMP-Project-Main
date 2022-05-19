using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteMenuController : MonoBehaviour {

	private bool pauseToggle;
	public GameObject pauseMenu, helpMenu;

	void LockCursor() 
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void UnlockCursor() 
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	void Start()
	{
		UnlockCursor();
	}

	public void BackToMainMenu() {
		SceneManager.LoadScene("MenuScene");
	}
	public void QuitGame() {
		Application.Quit();
	}

}
