using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public PlayerMovement movement;
	Vector3 powerUpPos;

	public delegate void HasCollided();
	public static event HasCollided OnHasCollided;
	
	void OnCollisionEnter(Collision collisionInfo)
	{
		Debug.Log(collisionInfo.collider.name);

		if(collisionInfo.collider.tag == "Obstacle")
		{
			movement.enabled = false;
			OnHasCollided?.Invoke();
			FindObjectOfType<GameManager>().EndGame();
		}

		if(collisionInfo.collider.tag == "PowerUp")
		{
			this.GetComponent<BoxCollider>().enabled = false;
			this.GetComponent<Rigidbody>().freezeRotation = true;
			this.GetComponent<Rigidbody>().useGravity = false;
			//this.transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
			powerUpPos = this.transform.position;
		}
	}

	private void Update()
	{
		if(this.GetComponent<BoxCollider>().enabled == false)
		{
			
			if ((this.transform.position - powerUpPos).magnitude >= 100f)
			{
				this.GetComponent<BoxCollider>().enabled = true;
				this.GetComponent<Rigidbody>().freezeRotation = false;
				this.GetComponent<Rigidbody>().useGravity = true;
			}
		}
	}
}
