using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {
	public Camera mainCamera;
	public Vector3 deltaPosition;

	void Update () {
		mainCamera.transform.position = transform.position + deltaPosition;
	}
}
