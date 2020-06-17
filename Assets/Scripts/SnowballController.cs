using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballController : MonoBehaviour
{
    private Rigidbody SnowballRB;
    void Start()
    {
        SnowballRB = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");   
        float Vertical = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(Horizontal, 0, Vertical);
        SnowballRB.AddForce(force*.25f);
    }
}
