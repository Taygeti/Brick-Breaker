using System.Collections;
using UnityEngine;
public class Ball : MonoBehaviour
{
    public Rigidbody2D rigibody { get; private set; }

    public float speed = 500f;

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
       ResetBall();
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rigibody.velocity = Vector2.zero;
        
        Invoke(nameof(SetRandomTrajectory),1f);
    }
    
    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = 1f;

        rigibody.AddForce((force.normalized * speed));
    }
    
}
