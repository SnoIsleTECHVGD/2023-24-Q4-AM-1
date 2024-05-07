using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathTrigger : MonoBehaviour
{


    public UnityEvent DeathEvent;

    public UnityEvent EnemyDeathEvent;

    public void PlayerDeathEventTrigger()
    {
        DeathEvent.Invoke();
    }

    public void EnemyDeathEventTrigger()
    {
        EnemyDeathEvent.Invoke();
    }
}
