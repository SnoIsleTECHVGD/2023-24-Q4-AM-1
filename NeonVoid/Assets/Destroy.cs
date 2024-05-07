using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        GameObject[] gameMusicObjects = GameObject.FindGameObjectsWithTag("GameMusic");

        foreach (GameObject obj in gameMusicObjects)
        {
            Destroy(obj);
        }
    }
}