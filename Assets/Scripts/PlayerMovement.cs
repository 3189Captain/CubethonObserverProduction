using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject go;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    // Update is called once per frame
    public delegate void Reach50();
    public static event Reach50 OnReach50;

    public delegate void Reach100();
    public static event Reach100 OnReach100;

    public delegate void Reach150();
    public static event Reach150 OnReach150;

    private void Start()
    {
        go = this.gameObject;
    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if(this.GetComponent<BoxCollider>().enabled == false)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }

		if (Input.GetKey("d"))
		{
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
		{
            FindObjectOfType<GameManager>().EndGame();
		}

        if(go.transform.position.z >= 50 && go.transform.position.z < 100)
        {
            OnReach50?.Invoke();
        }
        if (go.transform.position.z >= 100 && go.transform.position.z < 150)
        {
            OnReach100?.Invoke();
        }
        if (go.transform.position.z >= 150)
        {
            OnReach150?.Invoke();
        }
    }
}
