using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraFollow : MonoBehaviour
{
    public Transform Camera;
    public Transform Player;
    public Transform Enemy;

    private void Update()
    {
        Camera.LookAt(Player);
        Camera.LookAt(Enemy);


    }
}
