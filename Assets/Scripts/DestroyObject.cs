using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
	void OnTriggerEnter (Collider c) {
		Destroy (c.gameObject);
	}
}
