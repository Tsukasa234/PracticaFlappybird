using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    [Range(0,1000)]
    private float force;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
    }
}
