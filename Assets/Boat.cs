using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour
{

    public float speed;
    public float turnSpeed;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.AddTorque(0f, h * turnSpeed, 0f);
        rb.AddForce(transform.forward * v * speed);

    }
}
