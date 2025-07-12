using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatController : MonoBehaviour
{
    public Rigidbody rb;

    private bool RTClicked = false;
    private bool LTClicked = false;
    private void Update()
    {

        if(RTClicked == false && Input.GetAxisRaw("Horizontal") > 0)
        {
            RTClicked = true;
        }

        if (LTClicked == false && Input.GetAxisRaw("Horizontal") < 0)
        {
            LTClicked = true;

        }
        if (Input.GetKeyDown(KeyCode.A) || LTClicked) {
            LTClicked = false;
            rb.AddForce(transform.forward, ForceMode.VelocityChange);
            rb.AddTorque(-transform.up / 2, ForceMode.Impulse);
            rb.AddTorque(transform.forward / 10, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.D) || RTClicked)
        {
            RTClicked = false;
            rb.AddForce(transform.forward, ForceMode.VelocityChange);
            rb.AddTorque(transform.up / 2, ForceMode.Impulse);
            rb.AddTorque(-transform.forward / 10, ForceMode.Impulse);
        }
    }
}