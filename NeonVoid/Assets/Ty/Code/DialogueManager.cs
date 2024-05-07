using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public UnityEvent DialogueFinished;


    public UnityEvent DialogueEvent;

    public Animator animator;

    private Queue<string> sentences;



    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Invoke("CursorUnlock", 1);

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            Debug.Log("End of Dialogue");
            DialogueFinished.Invoke();

            return;
        }

        DialogueEvent.Invoke();

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of Conversation.");
    }

    public void CursorUnlock()
    {
        Debug.Log("Unlock Cursor");
        Cursor.lockState = CursorLockMode.None;
    }

    public void CursorLock()
    {
        Debug.Log("Lock Cursor");
        Cursor.lockState = CursorLockMode.Locked;
    }
}