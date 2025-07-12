using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floaterCount = 4;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;

    void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        if (transform.position.y < 0f)
        {

            float displacementMultiplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f),transform.position, ForceMode.Acceleration);
            
            Vector3 drag = new Vector3(
                displacementMultiplier * -rb.velocity.x * waterDrag * Time.fixedDeltaTime * 0.5f,
                displacementMultiplier * -rb.velocity.y * waterDrag * Time.fixedDeltaTime,
                displacementMultiplier * -rb.velocity.z * waterDrag * Time.fixedDeltaTime * 0.5f);
            rb.AddForce(drag, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
