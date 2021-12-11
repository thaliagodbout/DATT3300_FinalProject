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
                promptText.GetComponent<Animator>().SetBool("IsOpen", false);
            } else {
                promptText.GetComponent<Animator>().SetBool("IsOpen", true);
            }

            // If player gives input, start interaction dialogue
            if(Input.GetKeyDown(KeyCode.E)) {
                otherDialogueTrigger.TriggerDialogue();
            }
        } else {
            // Deactivate prompt text
            promptText.GetComponent<Animator>().SetBool("IsOpen", false);

        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Enter collider");

        if (other.tag == "NPC") { // For NPCs
            triggeringObj = other.gameObject; // Get parent GameObject
            otherDialogueTrigger = triggeringObj.GetComponent("DialogueTrigger") as DialogueTrigger;
            triggering = true;
        } else if (other.tag == "PuzzleObject") { // For puzzle objects
            triggeringObj = other.gameObject;
            otherDialogueTrigger = triggeringObj.GetComponent("DialogueTrigger") as DialogueTrigger;
            triggering = true;
        } else if (other.tag == "Portal") { // For well
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
        } else if (other.tag == "Portal") {
            triggering = false;
            triggeringObj = null;
            otherDialogueTrigger.notInDialogue();
        }
    }

    public GameObject getTriggeringObj() {
        return triggeringObj;
    }
}
