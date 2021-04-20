using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // References
    private Rigidbody2D rb;
    

    // Arrow Settings
    public float arrowSpeed;
    public int damage;
    public float direction;
    public float arrowTime;
    public float knockbackStrength;
    // Start is called before the first frame update
    void Start()
    {   
        rb = gameObject.GetComponent<Rigidbody2D>();

        // Set arrow velocity when it is instantiatedWA
        rb.velocity = arrowSpeed*Vector2.right*direction;

        // Start arrow timer to destroy the arrow 
        StartCoroutine(ArrowTime());
    }
    IEnumerator ArrowTime(){
        yield return new WaitForSeconds(arrowTime);
        Destroy(gameObject);
    }

    // Called when the arrow collides with something
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Enemy"){
            EnemyHealth enemyScript = collider.GetComponent<EnemyHealth>();

            // Call enemy hurt function
            enemyScript.StartCoroutine(enemyScript.Hit(damage, knockbackStrength*direction));
                
            // Destroy the arrow
            Destroy(gameObject);
        }   else if (collider.tag == "Wall"){
                
            // Destroy the arrow
            Destroy(gameObject);
        }
    }
}

