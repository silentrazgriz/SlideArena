using UnityEngine;
using System.Collections;

public class ApplyForce : MonoBehaviour {
	public Vector3 forceApplied;
	private Rigidbody _rigidbody;

	void Awake () {
		_rigidbody = GetComponent<Rigidbody> ();
		_rigidbody.AddForce (forceApplied);
	}
}
