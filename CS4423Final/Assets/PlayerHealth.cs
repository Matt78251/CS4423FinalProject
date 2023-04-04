using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;
    private int artifacts = 0;
    [SerializeField] private Text heartsText;
    [SerializeField] private Text artifactsText;
    
    void Start()
    {
        health = maxHealth;
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        heartsText.text = "Health: " + health;

        if(health <= 0)
        {
            Debug.Log("Player Died");
            //end game here
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
            if (health < 5)
            {
                health++;
            }
            heartsText.text = "Health: " + health;

        }

        if(collision.gameObject.CompareTag("Artifact"))
        {
            Destroy(collision.gameObject);
            artifacts++;
            artifactsText.text = "Artifacts: " + artifacts;
            
        }
    }
}
