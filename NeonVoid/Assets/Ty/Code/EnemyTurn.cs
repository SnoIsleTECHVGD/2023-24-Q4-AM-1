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
    public Transform Enemy;
    public LayerMask Player;
    public RaycastHit hit;
    public Ray ray;

    Vector3 fwd;

    private void Start()
    {
        fwd = Raycastobject.transform.TransformDirection(ToPointPosition[Loading]);
        TriggerRaycast();
    }

    public void TriggerRaycast()
    {
        Loading = 0;
        foreach(Transform T in ToPoints)
        {
            ray = new Ray(Enemy.position, ToPointPosition[Loading] - Enemy.position);

            Debug.Log(Loading);
            Physics.Raycast(ray);
            if (Physics.Raycast(ray, out hit, Player))
            {
                Debug.Log("Player Found");
            }
            else
            {
                Loading++;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 direction = Enemy.transform.TransformDirection(fwd) * 5;

        Gizmos.DrawRay(Raycastobject.transform.position, fwd);
    }
   
    private void Update()
    {

        
    }
}


