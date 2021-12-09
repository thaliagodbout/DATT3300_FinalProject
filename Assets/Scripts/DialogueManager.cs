using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        Debug.Log("Starting conversation with " + dialogue.name);
        // nameText = GetComponent<TMP_Text>();
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
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue() {
        Debug.Log("End of conversation.");
    }

}
