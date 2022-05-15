using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharControllerFinish : MonoBehaviour {

	public float speed = 10.0f;
	public float sensitivity = 350.0f;
	public float WaterHeight = 15.5f;
	private Rigidbody rb;
	public bool isGrounded;
	CharacterController character;
	public GameObject cam;
	float moveFB, moveLR;
	float rotX, rotY;
	public float gravity = -9.8f;
	public float jumpHeight = 50f;
	public float cursorlockstate = 1f;
	private bool pauseToggle;
	private Ray ray;
    private RaycastHit hit;
	public LayerMask groundlayer;
	Vector3 movement;

	public void LockCursor() {
		cursorlockstate = 1f;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void UnlockCursor() {
		cursorlockstate = 0f;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	void Start()
	{
		LockCursor();
		rb = GetComponent<Rigidbody>();
		character = GetComponent<CharacterController> ();
		sensitivity = sensitivity * 1;
	}

	void CheckForWaterHeight(){
		if (transform.position.y < WaterHeight) {
			gravity = 0f;			
		} else {
			gravity = -9.8f;
		}
	}

	void Update()
	{
		if (cursorlockstate == 1f)
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * 2f, Color.red);

			moveFB = Input.GetAxis ("Horizontal") * speed;
			moveLR = Input.GetAxis ("Vertical") * speed;

			rotX = Input.GetAxis ("Mouse X") * (sensitivity * 1.5f);
			rotY = Input.GetAxis ("Mouse Y") * (sensitivity * 1.5f);

			CheckForWaterHeight ();

			CameraRotation (cam, rotX, rotY);

 			movement = new Vector3 (moveFB, movement.y, moveLR);

			//var velocity2 = rb.velocity.y;
			movement = transform.rotation * movement;
			if (isGrounded == true)
			{
				if (Input.GetKeyDown("space"))
				{
					Debug.Log("Jump!");
					//character = Mathf.Sqrt(jumpHeight * -10000 * gravity);
					movement.y += Mathf.Sqrt(jumpHeight * -10f * gravity);
				}
				if (Input.GetKeyDown("m"))
				{
					//character = Mathf.Sqrt(jumpHeight * -10000 * gravity);
					movement.y += Mathf.Sqrt(jumpHeight * -1000f * gravity);
				}
			}
			else
			{
				movement.y += gravity * Time.deltaTime;
			}
			character.Move(movement * Time.deltaTime);

		}

		void CameraRotation(GameObject cam, float rotX, float rotY)
		{		
			transform.Rotate (0, rotX * Time.deltaTime, 0);
			cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
		}
	}

}
