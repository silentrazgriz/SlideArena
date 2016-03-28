using UnityEngine;
using System.Collections;

public class SpinningLog : MonoBehaviour {
	public float angularSpeed;

	void Update () {
		transform.Rotate (new Vector3 (0f, angularSpeed * Time.deltaTime, 0f));
	}
}
