using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	public float range = 50f;
	public float angularSpeed = 360f;
	private PlayerMovement _movement;

	void Awake () {
		_movement = GetComponent<PlayerMovement> ();
	}

	void Update () {
		if (!_movement.isDash) {
			Quaternion nextRotation = Quaternion.LookRotation (getWorldCoordinate () - transform.position);
			transform.rotation = Quaternion.Lerp (transform.rotation, nextRotation, angularSpeed * Time.deltaTime);
		}
	}

	public Vector3 getWorldCoordinate () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		LayerMask layer = 1 << LayerMask.NameToLayer ("Mouse");

		Vector3 result = Vector3.zero;
		result.y = transform.position.y;

		if (Physics.Raycast (ray, out hit, range, layer)) {
			result.x = hit.point.x;
			result.z = hit.point.z;
		}

		return result;
	}
}
