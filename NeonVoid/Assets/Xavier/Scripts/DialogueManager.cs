using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{


    private Queue<string> sentences; // Queue = FIFO list

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }


}