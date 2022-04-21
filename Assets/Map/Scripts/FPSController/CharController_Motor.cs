using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharController_Motor : MonoBehaviour {

	public float speed = 10.0f;
	public float sensitivity = 30.0f;
	public float WaterHeight = 15.5f;
	private Rigidbody rb;
	public bool isGrounded;
	CharacterController character;
	public GameObject cam;
	float moveFB, moveLR;
	float rotX, rotY;
	public bool webGLRightClickRotation = true;
	float gravity = -9.8f;
	public float jumpHeight = 7f;
	public float cursorlockstate = 1f;
	private bool pauseToggle;
	public GameObject pauseMenu;
	public GameObject questMenu;

	void LockCursor() {
		cursorlockstate = 1f;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void UnlockCursor() {
		cursorlockstate = 0f;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	void Start()
	{
		pauseMenu.SetActive(false);
		questMenu.SetActive(false);
		LockCursor();
		rb = GetComponent<Rigidbody>();
		character = GetComponent<CharacterController> ();
		if (Application.isEditor) {
			webGLRightClickRotation = false;
			sensitivity = sensitivity * 1.5f;
		}
		PlayerPrefs.SetFloat("vases", 0f);
	}

	public void ResumeGame() {
		pauseMenu.SetActive(false);
		questMenu.SetActive(false);
		cursorlockstate=1f;
		LockCursor();
	}

	public void BackToMainMenu() {
		UnlockCursor();
		SceneManager.LoadScene("MenuScene");
	}
	public void QuitGame() {
		Application.Quit();
	}
	void CheckForWaterHeight(){
		if (transform.position.y < WaterHeight) {
			gravity = 0f;			
		} else {
			gravity = -9.8f;
		}
	}
	void OnCollisionEnter()
	{
		print("Grounded? Yes");
		isGrounded = true;
	}
	
	void OnCollisionExit()
	{
		print("Grounded? No");
		isGrounded = false;
	}

	void Jump()
	{
		if (isGrounded)
		{
			if (Input.GetKeyDown("space"))
			{
				rb.AddForce(Vector3.up * jumpHeight);
			}
		}
	}

	void Update(){
		if (cursorlockstate == 1f) {
			Jump();
			moveFB = Input.GetAxis ("Horizontal") * speed;
			moveLR = Input.GetAxis ("Vertical") * speed;

			rotX = Input.GetAxis ("Mouse X") * sensitivity;
			rotY = Input.GetAxis ("Mouse Y") * sensitivity;

			CheckForWaterHeight ();


			Vector3 movement = new Vector3 (moveFB, gravity, moveLR);



			if (webGLRightClickRotation) {
				if (Input.GetKey (KeyCode.Mouse0)) {
					CameraRotation (cam, rotX, rotY);
				}
			} else if (!webGLRightClickRotation) {
				CameraRotation (cam, rotX, rotY);
			}

			movement = transform.rotation * movement;
			character.Move (movement * Time.deltaTime);
		}

		void CameraRotation(GameObject cam, float rotX, float rotY){		
			transform.Rotate (0, rotX * Time.deltaTime, 0);
			cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(pauseMenu.activeSelf)
			{
				LockCursor();
				pauseMenu.SetActive(false);
				cursorlockstate = 1f;
			}
			if(questMenu.activeSelf)
			{
				LockCursor();
				questMenu.SetActive(false);
				cursorlockstate = 1f;
			}
			else
			{
				UnlockCursor();
				pauseMenu.SetActive(true);
				questMenu.SetActive(false);
				cursorlockstate = 0f;
			}
		}

		if (Input.GetKeyDown("q")) 
		{
			if(!questMenu.activeSelf)
			{
				if(!pauseMenu.activeSelf)
				{
					UnlockCursor();
					questMenu.SetActive(true);
					cursorlockstate = 0f;
				}
			}
			else
			{
				LockCursor();
				questMenu.SetActive(false);
				cursorlockstate = 1f;
			}
		}
	}
}
