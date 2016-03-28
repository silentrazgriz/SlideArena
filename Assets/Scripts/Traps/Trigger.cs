using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	public BaseTraps baseTraps;

	void OnTriggerEnter (Collider c) {
		if (c.gameObject.tag == "Player") {
			baseTraps.activateTraps ();
		}
	}
}
