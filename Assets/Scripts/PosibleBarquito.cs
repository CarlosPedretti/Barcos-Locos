using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PosibleBarquito : MonoBehaviour
{
	float verticalInput;
	float movementFactor;
	float horizontalInput;
	float steerFactor;
	public float speed = 1.0f;
	public float steerSpeed = 1.0f;
	public float movementThresold = 10.0f;

	void Update()
    {
		Movement();
		Steer();

	}

	void Movement()
	{
		verticalInput = Input.GetAxis("Vertical");
		movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThresold);
		transform.Translate(0.0f, 0.0f, movementFactor * speed);
	}

	void Steer()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		steerFactor = Mathf.Lerp(steerFactor, horizontalInput * verticalInput, Time.deltaTime / movementThresold);
		transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);
	}
}