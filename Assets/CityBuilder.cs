using UnityEngine;
using System.Collections;

public class CityBuilder : MonoBehaviour {

	public GameObject cityBlock;
	public Camera camera;

	// Use this for initialization
	void Start () {
		for (var x = -25; x < 25; x++) {
			for (var z = 5; z < 55; z++) {
				Instantiate( cityBlock, 
				            new Vector3(
								x * 20, 
								0, 
								z * 20), 
				            Quaternion.identity);
			}
		}
	
		Debug.Log(cityBlock.transform.localScale.z);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("")) {

		}
	}
}
