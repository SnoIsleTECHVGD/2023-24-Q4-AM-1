using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEncounter : MonoBehaviour
{
    public BoxCollider TriggerCollider;
    public bool hasTriggered;

    public UnityEvent EncounterEvents;

    private void OnTriggerEnter(Collider other)
    {
        hasTriggered = true;

        TriggeringEvent();
    }

    public void TriggeringEvent()
    {
        EncounterEvents.Invoke();
    }
}
