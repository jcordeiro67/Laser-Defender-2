using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int startingLives = 3;
	[Tooltip("Health (float): The Players starting health")]
	public float health = 50f;
	[Tooltip("Speed (float): The players speed along horizontal axis")]
	public float speed = 12f;
	[Tooltip("Padding (float): The offset from the game area edge to prevent the player from going outside the play area")]
	public float padding = 1f;

	private float xmin, xmax;
	private float currentHealth;
	private int currentLives;

	// Use this for initialization
	void Start () {
		currentLives = startingLives - 1;
		currentHealth = health;
		// the distance from the camera to the plane in z
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)); //Bottom Left Corner of Game Area
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)); //Bottom Right Corner of Game Area

		xmin = leftMost.x + padding;	//Add the padding to the left side of the game area clamp zone
		xmax = rightMost.x - padding;	// Add the padding to the right side of the game area clamp zone
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey (KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed * Time.deltaTime;	//Moves the player left independant of frame when the left arrow is pressed
		} 

		else if (Input.GetKey (KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;	//Moves the player right independant of frame when the left arrow is pressed
		}

		// Restrict the player to the game space
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);	//Clamp the transform.x of the player to the xmin and xmax
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);	//Set the position of the player inside the clamp zone
	}

	void OnTriggerEnter2D(Collider2D col){

		Projectile laser = col.gameObject.GetComponent <Projectile> ();

		if(laser){
			ApplyDamage (laser.GetDamage ());
			laser.Hit ();
		}
	}

	void ApplyDamage(float damage){
		currentHealth -= damage;

		if(currentHealth <= 0){
			Destroy (gameObject);
			currentLives -= 1;
		}

		//TODO count player lives and respawn player if lives exist
		if(currentLives > 0){
			//respawnPlayer
		} else {
			//endGame
		}
	}
}
