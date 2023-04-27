using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;
    private int artifacts = 0;
    public int deathInt = 0;
    public AudioSource heartAudio;
    public AudioSource artifactAudio;
    public AudioSource damageAudio;
    [SerializeField] private Text heartsText;
    [SerializeField] private Text artifactsText;
    public static int totalHearts1 = 5;
    public static int totalArtifacts1 = 0;
    public static int totalHearts2 = 5;
    public static int totalArtifacts2 = 0;
    public static int totalHearts3 = 5;
    public static int totalArtifacts3 = 0;

    //Scene currentScene = SceneManager.GetActiveScene ();
    //string sceneName = currentScene.name;
    
    void Start()
    {
        health = maxHealth;
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        heartsText.text = "Health: " + health + "/5";
        damageAudio.Play();
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            totalHearts1-=damage;
        }
        if(SceneManager.GetActiveScene().name == "Level2")
        {
            totalHearts2 -= damage;
        }
        if(SceneManager.GetActiveScene().name == "Level3")
        {
            totalHearts3 -= damage;
        }

        if(health <= 0)
        {
            //death of player
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + deathInt);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Heart") && (health < 5))
        {
            //collision.GetComponent<HeartAudio>().HeartCollect();
            heartAudio.Play();
            Destroy(collision.gameObject);
            if (health < 5)
            {
                health++;
                if(SceneManager.GetActiveScene().name == "Level1")
                {
                    totalHearts1++;
                }
                if(SceneManager.GetActiveScene().name == "Level2")
                {
                    totalHearts2++;
                }
                if(SceneManager.GetActiveScene().name == "Level3")
                {
                    totalHearts3 ++;
                }
                
            }
            heartsText.text = "Health: " + health + "/5";

        }

        if(collision.gameObject.CompareTag("Artifact"))
        {
            //collision.GetComponent<ArtifactAudio>().ArtifactCollect();
            artifactAudio.Play();
            Destroy(collision.gameObject);
            artifacts++;
            if(SceneManager.GetActiveScene().name == "Level1")
            {
                totalArtifacts1++;
            }
            if(SceneManager.GetActiveScene().name == "Level2")
            {
                totalArtifacts2++;
            }
            if(SceneManager.GetActiveScene().name == "Level3")
            {
                totalArtifacts3 ++;
            }
            artifactsText.text = "Artifacts: " + artifacts + "/7";
            
        }
    }
}
