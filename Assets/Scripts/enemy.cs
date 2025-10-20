using UnityEngine;

public class EnemyFollo : MonoBehaviour
{
    private Transform target;
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; // Simplified GetComponent call
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() // Use FixedUpdate for physics-based updates
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (target != null) // Check if the target is assigned
        {
            Vector2 direction = (target.position - transform.position).normalized; // Get normalized direction
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime); // Use MovePosition for smooth physics-based movement
        }
    }

}