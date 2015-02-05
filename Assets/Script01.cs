using UnityEngine;
using System.Collections;

public class Script01 : MonoBehaviour {

	public GameObject gameObj;

	public enum Status {
		None,
		Poison,
		Sleep
	}

	// Use this for initialization
	void Start () {
		int x, y;

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

	}
}
