using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScript : MonoBehaviour
{

    public GameObject Face1;
    public GameObject Face2;
    public GameObject Face3;
    public GameObject Face4;
    public GameObject Face5;

    public int FaceState { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FaceState == 1)
        {
            Face1.SetActive(true);
            Face2.SetActive(false);
            Face3.SetActive(false);
            Face4.SetActive(false);
            Face5.SetActive(false);
        }
        if (FaceState == 3)
        {
            Face1.SetActive(false);
            Face2.SetActive(true);
            Face3.SetActive(false);
            Face4.SetActive(false);
            Face5.SetActive(false);
        }
        if (FaceState == 5)
        {
            Face1.SetActive(false);
            Face2.SetActive(false);
            Face3.SetActive(false);
            Face4.SetActive(false);
            Face5.SetActive(true);
        }
        if (FaceState == 6)
        {
            Face1.SetActive(true);
            Face2.SetActive(false);
            Face3.SetActive(false);
            Face4.SetActive(false);
            Face5.SetActive(false);
        }
        if (FaceState == 7)
        {
            Face1.SetActive(false);
            Face2.SetActive(false);
            Face3.SetActive(false);
            Face4.SetActive(true);
            Face5.SetActive(false);
        }
        if (FaceState == 8)
        {
            Face1.SetActive(true);
            Face2.SetActive(false);
            Face3.SetActive(false);
            Face4.SetActive(false);
            Face5.SetActive(false);
        }
    }
    

    public void AddNumber()
    {
        FaceState++;
    }
}
