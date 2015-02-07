using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityBuilder : MonoBehaviour {

	public Camera camera;
	public Text magnitude;

	private GameObject[] waypoints = new GameObject[5];
	private int currentWaypoint;

	public GameObject cityBlock;
	private int citySize = 100;
	private int cityScale = 20;
	private int flyzoneSize = 50;

	void buildCity () {
		// replace bottom cube with a low poly plane
		// randomize height of 'building', or optionally hide it randomly
		for (var x = 0; x < citySize; x++) {
			for (var z = 0; z < citySize; z++) {
				Instantiate( cityBlock, 
				            new Vector3(
								(x - flyzoneSize / 2) * cityScale, 
								0, 
								(z - flyzoneSize / 2) * cityScale), 
				            Quaternion.identity);
			}
		}
	}

	void buildWaypoints () {
		for (var i = 0; i < waypoints.Length; i++) {
			waypoints[i] = new GameObject();
			//waypoints[i].AddComponent<
			waypoints[i].transform.position = new Vector3(
				Random.Range(0, flyzoneSize) * cityScale, 
				25 + Random.Range (0, 25), 
				Random.Range (0, flyzoneSize) * cityScale);
		}
	}

	void targetNextWaypoint () {
		if (currentWaypoint < waypoints.Length) {
			currentWaypoint++;
		} else {
			currentWaypoint = Random.Range(0, waypoints.Length - 1);
		}
	}

	void startNavigation () {
		currentWaypoint = -1;
	}

	void continueNavigation () {
		Vector3 target = waypoints [currentWaypoint].transform.position;
		Vector3 direction = target - camera.transform.position;

		magnitude.text = "" + Mathf.Floor (direction.magnitude) + "m";

		if (direction.magnitude < 1) {
			targetNextWaypoint ();
		} else {
			camera.transform.position = Vector3.MoveTowards (camera.transform.position, target, 100 * Time.deltaTime);
		}

		Vector3 cameraTarget = target;
		//cameraTarget.y = 5;

		camera.transform.LookAt (target);
	}

	// Use this for initialization
	void Start () {
		buildCity ();
		buildWaypoints ();
		startNavigation();
		targetNextWaypoint ();
	}

	// Update is called once per frame
	void Update () {
		continueNavigation ();

		//if (Input.GetKey ("")) {
			// drop bomb
		//}
		
		// if another key
			//buildWaypoints ();
			//startNavigation ();
	}
}
