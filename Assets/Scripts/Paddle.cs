using System;
using UnityEngine;
public class Paddle : MonoBehaviour
{
    public Rigidbody2D rigibody { get; private set; }
    
    public Vector2 direction { get; private set; }

    public float speed = 30f;
    public float maxBounceAngle = 75f;

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }

    public void ResetPaddle()
    {
        transform.position = new Vector2(0f, transform.position.y);
        rigibody.velocity = Vector2.zero;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            rigibody.AddForce(direction * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            Vector3 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x = contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigibody.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Math.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);
            
            Quaternion rotation = Quaternion.AngleAxis(newAngle,Vector3.forward);
            ball.rigibody.velocity = rotation * Vector2.up * ball.rigibody.velocity.magnitude;
        }
    }
}