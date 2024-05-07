using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathTrigger : MonoBehaviour
{


    public UnityEvent DeathEvent;


    public void DeathEventTrigger()
    {
        DeathEvent.Invoke();
    }
}
