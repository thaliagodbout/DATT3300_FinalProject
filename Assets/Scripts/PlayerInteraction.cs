using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject triggeringNPC;
    private bool triggering;

    public GameObject promptText;
    private DialogueTrigger otherDialogueTrigger;

    void Start() {

    }

    void Update() {
        if (triggering) {
            // print("Player is triggering with " + triggeringNPC);

            // Activate prompt text
            promptText.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E)) {
                otherDialogueTrigger.TriggerDialogue();
            }
        } else {
            // Deactivate text
            promptText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "NPC") {
            triggeringNPC = other.gameObject;
            otherDialogueTrigger = triggeringNPC.GetComponent("DialogueTrigger") as DialogueTrigger;
            triggering = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "NPC") {
            triggering = false;
            triggeringNPC = null;
            otherDialogueTrigger.notInDialogue();
        }
    }
}
