using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject CurrentLocation;
    public GameObject EnemySystem;
    public bool isAttacking;
    public bool isCurrent;
    public Material StandardMaterial;
    public Material AttackingMaterial;
    public bool BeingAttacked;
    public Renderer MeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        CurrentLocation = null;
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

    private void OnTriggerEnter(Collider Player)
    {
        Debug.Log(Player.name);
        Debug.Log(this.gameObject);
        CurrentLocation = this.gameObject;
        EnemySystem.GetComponent<EnemyTurn>().CurrentLocation = this.gameObject;
    }

    private void OnTriggerStay(Collider Player)
    {
        Debug.Log(this.gameObject);
        if (isAttacking == true)
        {
            BeingAttacked = true;
        }
    }

    private void OnTriggerExit(Collider Player)
    {
        BeingAttacked = false;
        EnemySystem.GetComponent<EnemyTurn>().CurrentLocation = null;
    }

}
