using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{

    public GameObject Raycastobject;
    public Transform[] ToPoints;
    public Vector3[] ToPointPosition;
    public float MaxDistance;
    public int Loading;
    
    public void TriggerRaycast()
    {
        Loading = 0;
        foreach(Transform T in ToPoints)
        {
            Vector3 fwd = Raycastobject.transform.TransformDirection(ToPointPosition[Loading]);
            Loading++;
            Physics.Raycast(Raycastobject.transform.position, fwd);
            
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;

        Gizmos.DrawRay(transform.position, direction);
    }

    private void Update()
    {
        
        
    }
}


