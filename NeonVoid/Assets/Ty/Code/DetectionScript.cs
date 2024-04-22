using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{

    public GameObject CurrentLocation;
    public GameObject EnemySystem;
    public bool isAttacking;

    public Material StandardMaterial;
    public Material AttackingMaterial;

    public Renderer MeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking == true)
        {
            MeshRenderer.material = AttackingMaterial;
        }
        else
        {
            MeshRenderer.material = StandardMaterial;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        EnemySystem.GetComponent<EnemyTurn>().CurrentLocation = CurrentLocation;
    }


}
