using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsTrigger : MonoBehaviour
{
    public GameObject Reward;
    private void OnTriggerEnter(Collider other)
    {
        Reward.SetActive(true);
    }
}
