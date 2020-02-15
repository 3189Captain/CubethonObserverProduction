using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public GameObject player; //reference to player
    public Rigidbody rb; //reference to this object's rigidbody
    public float speedMult = 0.25f; //multiplier for AI travel speed
    Vector3 diffVector; //vector calculated by taking the difference between this object's postion and the player

    // Update is called once per frame
    void FixedUpdate()
    {
        diffVector = player.transform.position - transform.position; //calculate diffVector
        transform.rotation = Quaternion.LookRotation(diffVector.normalized); //look towards player
        rb.AddForce(diffVector.normalized * speedMult, ForceMode.VelocityChange); //move towards player
    }
}
