using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeDelay : MonoBehaviour
{
    public float DelaySeconds;

    public UnityEvent DelayedEvents;

    public bool CanInvoke { get; set; }

    private void Update()
    {
        if(CanInvoke == true)
        {
            Invoke("InvokeCommand", DelaySeconds);
            CanInvoke = false;
        }
    }



    public void InvokeCommand()
    {
        DelayedEvents.Invoke();
    }
}
