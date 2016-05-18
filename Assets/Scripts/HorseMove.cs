using UnityEngine;
using System.Collections;

public class HorseMove : MonoBehaviour {

	private NavMeshAgent agent;
	private HorseLocomotion hr;

	public GameObject ethan;
	private Vector3 nextTarget;
	public bool findNext;
	public bool timerOn;
	public float x = 0;
	public float y = 0;

	public float timer = 0f;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		hr = GetComponent<HorseLocomotion> ();

		Vector3 r = transform.position - ethan.transform.position;
		nextTarget = transform.position + r;
		agent.destination = new Vector3(nextTarget.x, transform.position.y, nextTarget.z);
		findNext = false;
		timerOn = false;


	}
	void Update () {
		x = nextTarget.x;
		y = nextTarget.z;
		if (!timerOn && transform.position.x == nextTarget.x && transform.position.z == nextTarget.z) {
			timerOn = true;
			hr.shouldRun = false;
			hr.shouldWalk = false;
			hr.shouldMove = false;
			findNext = true;
		}

		if (timerOn) {
			timer += Time.deltaTime;
			if (timer >= 5) {
				timerOn = false;
				timer = 0f;
				hr.shouldWalk = true;
				hr.shouldMove = true;
				agent.speed = hr.WALKING_SPEED;
			} else {
				agent.speed = 0f;
			}
		}

		if (findNext) {
			float new_x = Random.Range (-350, 110);
			float new_z = Random.Range (-110, 350);
			nextTarget = new Vector3 (new_x, transform.position.y, new_z);
			agent.destination = nextTarget;
			findNext = false;
		}

		if (Vector3.Distance (transform.position, nextTarget) <= 20) {
			hr.shouldWalk = true;
			hr.shouldRun = false;
		} else {
			hr.shouldWalk = false;
			hr.shouldRun = true;
		}




	}
}
