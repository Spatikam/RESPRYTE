using UnityEngine;
using UnityEngine.UI;

public class enemiehscript : MonoBehaviour
{
    public float damage = 1; // Amount of damage the enemy inflicts

    private void Start()
    {
        
    }


    // Called when the Collider2D other enters the trigger
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            hh playerHealth = other.gameObject.GetComponent<hh>();
            if (playerHealth != null)
            {
                playerHealth.health_2 -= damage; // Apply damage to player health
            }
            
        }
        if (other.gameObject.CompareTag("water_ball"))
        {
            Score_handle.score += 5;
            Char_mov.spirit_killed += 1;
            Destroy(gameObject);
        }
    }
}
