using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour {

	public GameObject[] bridgePrefabs;

	private Transform playerTransform;
	private float spawnOnZ = 0.0f;
	private float bridgeLength = 25.0f;
	private int bridgesOnScreen = 7;
	private List<GameObject> activeBridges;
	private float saveZone = 100.0f;
	private int lastPrefabIndex = 0;

	// Use this for initialization
	void Start () {

		activeBridges = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < bridgesOnScreen; i++) {

			if (i < 1) {

				SpawnBridge (0);
			} else {

				SpawnBridge ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (playerTransform.position.z - saveZone > (spawnOnZ - bridgesOnScreen * bridgeLength)) {

			SpawnBridge ();
			DeleteBridge ();
		}
	}

	private void SpawnBridge(int prefabFlag = -1){

		GameObject myObject;
		if (prefabFlag == -1) {
			
			myObject = Instantiate (bridgePrefabs [RandomIndex ()]) as GameObject;
		} else {

			myObject = Instantiate (bridgePrefabs [prefabFlag]) as GameObject;
		}
		myObject.transform.SetParent (transform);
		myObject.transform.position = Vector3.forward * spawnOnZ;
		spawnOnZ += bridgeLength;
		activeBridges.Add (myObject);
	}

	private void DeleteBridge(){

		Destroy (activeBridges [0]);
		activeBridges.RemoveAt (0);
	}

	private int RandomIndex(){

		if (bridgePrefabs.Length <= 1)
			return 0;

		int randInd = lastPrefabIndex;

		while (randInd == lastPrefabIndex) {

			randInd = Random.Range (1, bridgePrefabs.Length);
		}

		lastPrefabIndex = randInd;
		return randInd;
	}
}
