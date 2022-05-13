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
		pauseMenu.SetActive(false);
		helpMenu.SetActive(false);
		LockCursor();
	}

	public void ResumeGame() 
	{
		pauseMenu.SetActive(false);
		helpMenu.SetActive(false);
		LockCursor();
	}

	public void BackToMainMenu() {
		UnlockCursor();
		SceneManager.LoadScene("MenuScene");
	}
	public void QuitGame() {
		Application.Quit();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(pauseMenu.activeSelf)
			{
				Debug.Log("e");
				LockCursor();
				pauseMenu.SetActive(false);
			}
			if(helpMenu.activeSelf)
			{
				LockCursor();
				helpMenu.SetActive(false);
			}
			else
			{
				UnlockCursor();
				pauseMenu.SetActive(true);
			}
		}

		if (Input.GetKeyDown("h")) 
		{
			if(!helpMenu.activeSelf)
			{
				if(!pauseMenu.activeSelf)
				{
					UnlockCursor();
					helpMenu.SetActive(true);
				}
			}
			else
			{
				LockCursor();
				helpMenu.SetActive(false);
			}
		}
	}

}
