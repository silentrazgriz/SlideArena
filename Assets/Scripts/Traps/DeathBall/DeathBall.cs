using UnityEngine;
using System.Collections;

public class DeathBall : BaseTraps {
	public GameObject ball, spawn;
	public float ballForce = 500f;
	public float trapDelay = 1f;
	private float _nextSpawn = 0f;

	public override void activateTraps () {
		if (Time.time > _nextSpawn) {
			GameObject instance = (GameObject)Instantiate (ball, spawn.transform.position, Quaternion.identity);
			instance.transform.SetParent (transform);
			instance.GetComponent<Rigidbody> ().AddForce (spawn.transform.forward * ballForce);

			_nextSpawn = Time.time + trapDelay;
		}
	}
}
