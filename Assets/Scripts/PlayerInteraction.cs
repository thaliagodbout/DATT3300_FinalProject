using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject triggeringObj;
    private bool triggering;

    public GameObject promptText;
    private DialogueTrigger otherDialogueTrigger;
    // private Animator promptAnimator;

    void Start() {
    }

    void Update() {
        if (triggering) {
            // print("Player is triggering with " + triggeringObj);

            // Activate prompt text
            if (otherDialogueTrigger.isInDialogue()) {
                
                // promptText.SetActive(false);
                promptText.GetComponent<Animator>().SetBool("IsOpen", false);

            } else {
                // promptText.SetActive(true);
                promptText.GetComponent<Animator>().SetBool("IsOpen", true);

            }

            if(Input.GetKeyDown(KeyCode.E)) {
                otherDialogueTrigger.TriggerDialogue();
            }
        } else {
            // Deactivate text
            // promptText.SetActive(false);
            promptText.GetComponent<Animator>().SetBool("IsOpen", false);

        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Enter collider");

        if (other.tag == "NPC") { // For NPCs
            triggeringObj = other.gameObject;
            otherDialogueTrigger = triggeringObj.GetComponent("DialogueTrigger") as DialogueTrigger;
            triggering = true;
        } else if (other.tag == "PuzzleObject") { // For puzzle objects
            triggeringObj = other.gameObject;
            otherDialogueTrigger = triggeringObj.GetComponent("DialogueTrigger") as DialogueTrigger;
            triggering = true;
        }
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("Exit collider");

        if (other.tag == "NPC") {
            triggering = false;
            triggeringObj = null;
            otherDialogueTrigger.notInDialogue();
        } else if (other.tag == "PuzzleObject") {
            triggering = false;
            triggeringObj = null;
            otherDialogueTrigger.notInDialogue();
        }
    }
}
