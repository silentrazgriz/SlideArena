using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed = 5f;
	public float dashSpeed = 10f;
	public float dashDuration = 0.3f;
	public float dashDelay = 1f;
	public float angularSpeed = 10f;
	public bool isDash = false;
	private float _nextDash = 0f;
	private float _stopDash = 0f;
	private bool _isGround = true;
	private Vector3 _lastVector;
	private Rigidbody _rigidbody;
	private ParticleSystem _particle;


	void Awake () {
		_rigidbody = GetComponent<Rigidbody> ();
		_particle = GetComponent<ParticleSystem> ();
	}

	void FixedUpdate () {
		if (!isDash) {
			Vector3 inputVector = Vector3.zero;
			if (_isGround) {
				inputVector = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
				_lastVector = inputVector;
				_rigidbody.MovePosition (transform.position + inputVector * speed * Time.deltaTime);
			} else {
				_rigidbody.MovePosition (transform.position + _lastVector * speed * Time.deltaTime);
			}

			if (inputVector != Vector3.zero) {
				Quaternion nextRotation = Quaternion.LookRotation (inputVector);
				transform.rotation = Quaternion.Lerp (transform.rotation, nextRotation, angularSpeed * Time.deltaTime);
				transform.eulerAngles = new Vector3 (0f, transform.eulerAngles.y, 0f);
			}

			if (Input.GetKey (KeyCode.Space) && Time.time > _nextDash) {
				isDash = true;
				_stopDash = Time.time + dashDuration;
				_nextDash = _stopDash + dashDelay;
				_rigidbody.useGravity = false;
				_particle.Play ();
			}
		} else {
			_rigidbody.MovePosition (transform.position + _lastVector * dashSpeed * Time.deltaTime);
			
			if (_lastVector != Vector3.zero) {
				Quaternion nextRotation = Quaternion.LookRotation (_lastVector);
				transform.rotation = Quaternion.Lerp (transform.rotation, nextRotation, angularSpeed * Time.deltaTime);
				transform.eulerAngles = new Vector3 (0f, transform.eulerAngles.y, 0f);
			}

			if (Time.time > _stopDash) {
				isDash = false;
				_rigidbody.useGravity = true;
				_particle.Stop ();
			}
		}
	}

	void OnTriggerEnter (Collider c) {
		if (c.gameObject.tag == "TrapDoor") {
			_isGround = false;
		}
	}
	
	void OnCollisionEnter (Collision c) {
		/*if (c.gameObject.tag == "Obstacle" && isDash) {
			isDash = false;
			_rigidbody.useGravity = true;
			_particle.Stop ();
		}*/
		if (c.gameObject.tag == "Obstacle") {
			Debug.Log ("Died");
		}
	}

	/*void Update () {
		if (Input.GetMouseButtonDown (0) && !isDash && Time.time > nextDash) {
			isDash = true;
			nextDash = Time.time + dashDelay;
			_particle.Play ();
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.AddForce (transform.forward * dashForce);
		} else if (_rigidbody.velocity.magnitude < 0.1f && isDash) {
			isDash = false;
		}
	}

	void FixedUpdate () {
		if (!isDash) {
			Vector3 inputVector = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
			_rigidbody.AddForce (inputVector * speed);

			if (_rigidbody.velocity.magnitude > speed)
				_rigidbody.velocity = _rigidbody.velocity.normalized * speed;
		}
	}*/
}
