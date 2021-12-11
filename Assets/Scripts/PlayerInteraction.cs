using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject triggeringObj;
    private bool triggering;

    public GameObject promptText;
    private DialogueTrigger otherDialogueTrigger;
    private PuzzleDialogueTrigger puzzleDialogueTrigger;

    private string inventoryItem;

    void Start() {

    }

    void Update() {
        if (triggering) {
            // Activate prompt text
            if ((triggeringObj.tag != "PuzzleObject") && (otherDialogueTrigger.isInDialogue())) {
                promptText.GetComponent<Animator>().SetBool("IsOpen", false);

            } else if ((triggeringObj.tag == "PuzzleObject") && (puzzleDialogueTrigger.isInDialogue())) {
                promptText.GetComponent<Animator>().SetBool("IsOpen", false);
                // TODO: add custom text for puzzle prompt dialogue!
            } else if (triggeringObj.tag == "PickUpItem") {
                promptText.GetComponent<Animator>().SetBool("IsOpen", true);

            } else {
                // if (triggeringObj.tag != "PuzzleObject") {
                promptText.GetComponent<Animator>().SetBool("IsOpen", true);
                // }
            }

            // If player gives input, start interaction dialogue
            if(Input.GetKeyDown(KeyCode.E)) {
                if (triggeringObj.tag == "PuzzleObject") {
                    puzzleObjectInteraction();
                } else if (triggeringObj.tag == "PickUpItem") {
                    pickUpItemInteraction();
                    otherDialogueTrigger.TriggerDialogue();

                } else {
                    otherDialogueTrigger.TriggerDialogue();
                }
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
            puzzleDialogueTrigger = triggeringObj.GetComponent("PuzzleDialogueTrigger") as PuzzleDialogueTrigger;
            triggering = true;
            Debug.Log("Triggering puzzle object!!");

        } else if (other.tag == "PickUpItem") { // For pickup items
            triggeringObj = other.gameObject;
            otherDialogueTrigger = triggeringObj.GetComponent("DialogueTrigger") as DialogueTrigger;
            triggering = true;
            Debug.Log("Triggering pickup item");

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
            puzzleDialogueTrigger.notInDialogue();

        } else if (other.tag == "Portal") {
            triggering = false;
            triggeringObj = null;
            otherDialogueTrigger.notInDialogue();

        } else if (other.tag == "PickUpItem") {
            triggering = false;
            triggeringObj = null;
            otherDialogueTrigger.notInDialogue();
        }
    }

    public GameObject getTriggeringObj() {
        return triggeringObj;
    }

    private void puzzleObjectInteraction() {
        PuzzleObject puzzleObject = triggeringObj.GetComponent("PuzzleObject") as PuzzleObject;

        if (puzzleObject.getRequiredKey() == inventoryItem) { // Can be solved
            puzzleDialogueTrigger.TriggerSolvableDialogue();

            inventoryItem = "";
            puzzleObject.solve();

        } else if (puzzleObject.isSolved()) { // Already solved
            puzzleDialogueTrigger.TriggerSolvedDialogue();

        } else { // Cannot be solved
            puzzleDialogueTrigger.TriggerInitialDialogue();

        }

    }

    private void pickUpItemInteraction() {
        if (triggeringObj.GetComponent("ItemPickup") != null) {
            ItemPickup item = triggeringObj.GetComponent("ItemPickup") as ItemPickup;

            inventoryItem = item.key;
            triggeringObj.SetActive(false);

            Debug.Log("Picked up " + item.key);
        }
    }
}
