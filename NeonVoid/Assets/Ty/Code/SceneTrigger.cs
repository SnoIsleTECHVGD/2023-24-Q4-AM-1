using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneTrigger : MonoBehaviour
{
    public UnityEvent SceneEvents;

    private void Start()
    {
            SceneEvents.Invoke(); 
    }

    
}
