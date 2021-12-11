using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDialogueTrigger : MonoBehaviour
{
    public Dialogue initialDialogue;
    public Dialogue solvableDialogue;
    public Dialogue solvedDialogue;

    private bool inDialogue = false;

    public void TriggerInitialDialogue() {
        if (!inDialogue) {
            FindObjectOfType<DialogueManager>().StartDialogue(initialDialogue);
            inDialogue = true;
        } else {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    public void TriggerSolvableDialogue() {
        if (!inDialogue) {
            FindObjectOfType<DialogueManager>().StartDialogue(solvableDialogue);
            inDialogue = true;
        } else {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    public void TriggerSolvedDialogue() {
        if (!inDialogue) {
            FindObjectOfType<DialogueManager>().StartDialogue(solvedDialogue);
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
