using UnityEngine;
using System.Collections;

public class Script01 : MonoBehaviour {

	public GameObject gameObj;

	private GameObject bigCube;

	public enum Status {
		None,
		Poison,
		Sleep
	}

	// Use this for initialization
	void Start () {
		int x, y;

		bigCube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		bigCube.AddComponent<Rigidbody> ();
		bigCube.transform.position = new Vector3 (0, 0, 0);
		bigCube.transform.localScale = new Vector3 (3, 3, 3);


		for (y = -5; y < 5; y++) {
			for (x = -5; x < 5; x++) {
				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.AddComponent<Rigidbody>();
				cube.transform.position = new Vector3(x, y, Random.Range (-5,5));
				Debug.Log (x + " " + y + " " + 0);
			}
		}

		for(y = -5; y < 5; y++) {
			for(x = -5; x < 5; x++) {
				Instantiate(gameObj, new Vector3(x, y + 10, Random.Range (-5,5)), Quaternion.identity);
			}
		}

		Debug.Log("ran!");
	}

	// Update is called once per frame
	void Update () {
		float horizontalValue = Input.GetAxis ("Horizontal");
		float verticalValue = Input.GetAxis ("Vertical");

		bigCube.rigidbody.AddForce (horizontalValue * 20, 0, verticalValue * 20);

		if (Input.GetKey ("mouse 0")) {
			Debug.Log ("Mouse down!!!");
		}
	}
}
