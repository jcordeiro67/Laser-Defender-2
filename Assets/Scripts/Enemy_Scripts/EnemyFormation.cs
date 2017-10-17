using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class EnemyFormation : MonoBehaviour {
	public float width = 10f;
	public float height = 5f;
	public GameObject enemyPrefab;
	public float speed = 1f;
	public float spawnDelay = 0.3f;

	private bool movingRight = true;
	private float xmin, xmax;

	public void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
	}
	//TODO Determine the size of the formation dynamicaly, and adjust the size to the number of enemies remaining in the formation
	// Use this for initialization
	void Start () {
		
		// the distance from the camera to the plane in z axis.
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)); //Bottom Left Corner of Game Area
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)); //Bottom Right Corner of Game Area

		xmin = leftEdge.x;	//Add the padding to the left side of the game area clamp zone
		xmax = rightEdge.x;	// Add the padding to the right side of the game area clamp zone

		SpawnUntilFull ();
	}
	
	// Update is called once per frame
	void Update () {

		// Move enemy formation right and left at speed
		if(movingRight){
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float formationRightEdge = transform.position.x + (0.5f * width);
		float formationLeftEdge = transform.position.x - (0.5f * width);
		//TODO lower the formation each time it hits an edge
		if(formationLeftEdge <= xmin){
			movingRight = true;

		} else if(formationRightEdge >= xmax){
			movingRight = false;
		}

		if(AllMembersDead()){
			SpawnUntilFull ();
		}
	}

	void SpawnEnemies(){
	//Spawn an Enemy at each position in the enemy formation.
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition ();
		if(freePosition != null){
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition ()){
			Invoke ("SpawnUntilFull", spawnDelay);
		}

	}

	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount == 0){
				return childPositionGameObject;
			} 
		}
		return null;
	}

	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount > 0){
				return false;
			} 
		}
		return true;
	}
}
