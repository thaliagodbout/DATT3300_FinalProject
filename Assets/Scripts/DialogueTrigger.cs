using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool inDialogue = false;

    public bool getKeyAfterDialogue = false;
    public string key;

    public void TriggerDialogue() {
        if (!inDialogue) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            inDialogue = true;
        } else {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    public void notInDialogue() {
        inDialogue = false;
    }

    public bool isInDialogue() {
        return inDialogue;
    }
}
