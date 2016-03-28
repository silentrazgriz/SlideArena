using UnityEngine;
using System.Collections;

public class HiddenHammer : BaseTraps {
	public Hammer[] hammers;
	public float hammerDuration;
	public float hammerDelay;
	public bool hideAfterHit;
	private float _nextEnds;
	private float _nextHammer;
	private bool _isActive;

	void Update () {
		if (_isActive) {
			for (int i = 0; i < hammers.Length; i++) {
				float t = ((hammerDuration - (_nextEnds - Time.time)) / hammerDuration);
				if (hideAfterHit) 
					t *= 2;
				if (t > 1) 
					t = 2 - t;
				hammers[i].transform.localPosition = Vector3.Lerp (hammers[i].hammerStart, hammers[i].hammerEnd, t);
			}
			if (Time.time >= _nextEnds) {
				_isActive = false;
			}
		}
		if (Time.time > _nextHammer && !hideAfterHit) {
			resetHammerPosition ();
		}
	}

	public void resetHammerPosition () {
		for (int i = 0; i < hammers.Length; i++) {
			hammers[i].transform.localPosition = hammers[i].hammerStart;
		}
	}

	public override void activateTraps ()
	{
		if (Time.time > _nextHammer) {
			_isActive = true;
			_nextEnds = Time.time + hammerDuration;
			_nextHammer = _nextEnds + hammerDelay;
		}
	}
}
