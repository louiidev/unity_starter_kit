using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Actor : MonoBehaviour
{

    [SerializeField]
    float speed = 6;

    [SerializeField]
    float startKnockbackTimer = 0.3f;

    [SerializeField]
    float knockBackForce;

    float currentKnockbackTimer = 0;

    Vector2 knockbackDirection = Vector2.zero;

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
    }

    private void Update()
    {
        if (currentKnockbackTimer > 0)
        {
            currentKnockbackTimer = Mathf.Max(0, currentKnockbackTimer - Time.deltaTime);
        }
    }

    public void Move(Vector3 direction)
    {
        if (currentKnockbackTimer <= 0)
        {
            rigidbody2D.velocity = direction.normalized * speed;
        }
        else
        {
            rigidbody2D.velocity = knockbackDirection * knockBackForce;
        }
    }

    public void Knockback(Vector2 direction)
    {
        knockbackDirection = direction.normalized;
        currentKnockbackTimer = startKnockbackTimer;
    }

}
