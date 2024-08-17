using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HurdleInSpace : MonoBehaviour
{
    private float avgMass = 80f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.mass = avgMass * Random.Range(0.7f, 1.5f);
        rb.AddForce(Vector3.left * 3 * avgMass, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-0.7f, 0.7f) * avgMass, ForceMode2D.Impulse);
    }
}
