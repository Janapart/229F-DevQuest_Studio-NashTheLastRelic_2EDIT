using UnityEngine;

public class PendulumSwing : MonoBehaviour
{
     public Rigidbody rb;
    public float swingForce = 5f;
    private bool swingingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (swingingRight)
            rb.AddTorque(Vector3.forward * swingForce, ForceMode.Force);
        else
            rb.AddTorque(Vector3.back * swingForce, ForceMode.Force);

        // เปลี่ยนทิศทุกๆ 2 วินาที
        if (Time.time % 2 < 0.1f)
            swingingRight = !swingingRight;
    }
}
