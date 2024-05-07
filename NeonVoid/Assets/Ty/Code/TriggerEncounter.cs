using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEncounter : MonoBehaviour
{
    public BoxCollider TriggerCollider;
    public bool hasTriggered;

    public UnityEvent EncounterEvents;

    public UnityEvent EncounterEventsWaited;

    public int TriggerSeconds { get; set; } = 2;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Here");
        if(hasTriggered == false)
        {
            TriggeringEvent();
            hasTriggered = true;
        }
    }

    public void TriggeringEvent()
    {
        EncounterEvents.Invoke();
    }

    public IEnumerator TriggeringEventInSec()
    {

        yield return new WaitForSeconds(TriggerSeconds);

        EncounterEventsWaited.Invoke();
    }

    public void InvokeTheSec()
    {
        StartCoroutine(TriggeringEventInSec());
    }
}
