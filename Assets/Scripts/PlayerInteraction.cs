using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject triggeringNPC;
    private bool triggering;

    public GameObject npcText;

    void Start() {

    }

    void Update() {
        if (triggering) {
            // print("Player is triggering with " + triggeringNPC);

            // Activate text
            npcText.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E)) {
                FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            }
        } else {
            // Deactivate text
            npcText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "NPC") {
            triggering = true;
            triggeringNPC = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "NPC") {
            triggering = false;
            triggeringNPC = null;
        }
    }
}
