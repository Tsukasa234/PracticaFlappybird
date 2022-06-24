using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 2.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(speed, 0f);
        rb.velocity = Vector2.left * speed;
    }
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
