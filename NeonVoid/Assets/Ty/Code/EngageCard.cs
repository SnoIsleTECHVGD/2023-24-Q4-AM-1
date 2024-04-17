using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EngageCard : MonoBehaviour
{

    public UnityEvent Card;

    public bool Used;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Used == true)
        {
            Destroy(gameObject);
        }
    }

    public void Engaged()
    {
        Destroy(gameObject);
    }
}
