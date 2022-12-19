using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 _Vector2;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _Vector2 = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Wall")
        {
            var Speed = rb.velocity.magnitude;
            var direction = Vector2.Reflect(_Vector2.normalized, collision.GetContact(0).normal);

            rb.velocity = direction * Mathf.Max(Speed, 10f);
        }
       
        
    }
}
