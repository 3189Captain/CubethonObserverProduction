using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 25f;
    Vector3 wayPoint;

    // Update is called once per frame
    void Start()
    {
        ChooseHeading();
    }
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
        if((transform.position - wayPoint).magnitude < 3)
        {
            ChooseHeading();
        }
    }

    void ChooseHeading()
    {
        wayPoint = Random.insideUnitSphere * 47;
        wayPoint.y = 1;
        transform.LookAt(wayPoint);
    }
}
