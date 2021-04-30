using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [Header("References")]
    public DialogueManager dm;

    [Header("Dialogue Settings")]
    [TextArea(3, 5)]
    public string[] dialogue;
    public bool playerInRange;
    
    // Start is called before the first frame update
    void Start()
    {
        dm = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !dm.displayingText){
            dm.dialogue = dialogue;
            StartCoroutine(dm.StartDialogue());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            playerInRange = true;
        }
    }   
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            playerInRange = false;
        }
    }
}