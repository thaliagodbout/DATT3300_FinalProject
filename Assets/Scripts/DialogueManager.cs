using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Animator dialogueBoxAnimator;

    private Queue<string> sentences;
    public FirstPersonMovement playerMovementController;
    public PlayerInteraction playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        Debug.Log("Starting conversation with " + dialogue.name);
        
        dialogueBoxAnimator.SetBool("IsOpen", true);
        playerMovementController.disableControls();

        nameText.text = dialogue.name;

        sentences.Clear();

        // Add all sentences to queue
        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        // Display all enqueued sentences
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) { // No more sentences
            EndDialogue();
            return;
        }
        
        // Otherwise, still have sentences
        string sentence = sentences.Dequeue();

        // dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        Debug.Log("End of conversation.");

        // Handle post-dialogue actions depending on object
        if (playerInteraction.getTriggeringObj().tag == "NPC") {
            playerMovementController.enableControls();
            dialogueBoxAnimator.SetBool("IsOpen", false);

        } else if (playerInteraction.getTriggeringObj().tag == "Portal") {
            playerMovementController.enableControls();
            dialogueBoxAnimator.SetBool("IsOpen", false);
            FindObjectOfType<LevelLoader>().LoadNextLevel();

        } else if (playerInteraction.getTriggeringObj().tag == "PuzzleObject") {
            playerMovementController.enableControls();
            dialogueBoxAnimator.SetBool("IsOpen", false);

        } else if (playerInteraction.getTriggeringObj().tag == "PickUpItem") {
            playerMovementController.enableControls();
            dialogueBoxAnimator.SetBool("IsOpen", false);
            
        } else {
            playerMovementController.enableControls();
            dialogueBoxAnimator.SetBool("IsOpen", false);
        }
        // playerMovementController.enableControls();

    }

}
