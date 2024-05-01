using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneTrigger : MonoBehaviour
{
    

    public bool hasTriggered;

    public UnityEvent SceneEvents;

    private void Start()
    {
        if (hasTriggered == false)
        {
            SceneEvents.Invoke();
            hasTriggered = true;
        }
            
    }

    
}
