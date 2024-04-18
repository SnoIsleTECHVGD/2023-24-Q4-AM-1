using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{

    public GameObject Raycastobject;
    public Transform[] ToPoints;
    public float MaxDistance;
    public int Loading;
 public void TriggerRaycast()
    {
        Loading = 0;
        foreach(Transform T in ToPoints)
        {

            Loading++;
            // if(Physics.Raycast(RaycastObject))
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


