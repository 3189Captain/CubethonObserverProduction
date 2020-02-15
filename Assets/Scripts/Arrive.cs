using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    public GameObject player; //reference to player
    public float speed; //multiplier for AI travel speed
    Vector3 playerVector; //vector calculated by taking the difference between this object's postion and the player

    // Update is called once per frame
    void Update()
    {
        speed = 5f;
        playerVector = player.transform.position;
        playerVector.y = 1;
        transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
        transform.LookAt(playerVector);

        if ((player.transform.position - transform.position).magnitude < 10)
        {
            speed = speed / 2;
            transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
            transform.LookAt(playerVector);
        }
        if((player.transform.position - transform.position).magnitude < 5)
        {
            speed = speed / 10;
            transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
            transform.LookAt(playerVector);
            Debug.Log("made it!");
        }
    }
}