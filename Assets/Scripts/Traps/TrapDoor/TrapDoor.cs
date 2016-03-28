using UnityEngine;
using System.Collections;

public class TrapDoor : BaseTraps {
	public GameObject floor, trapDoor;
	public float trapDuration = 2f;
	public float trapDelay = 0.5f;
	private float _nextTrap = 0f;
	private float _nextClose = 0f;
	private bool _isActive = false;

	void Update () {
		if (_isActive && Time.time > _nextClose) {
			_isActive = false;
			floor.SetActive (true);
			trapDoor.SetActive (false);
		}
	}

	public override void activateTraps () {
		if (Time.time > _nextTrap) {
			floor.SetActive (false);
			trapDoor.SetActive (true);

			_isActive = true;
			_nextClose = Time.time + trapDuration;
			_nextTrap = _nextClose + trapDelay;
		}
	}
}
