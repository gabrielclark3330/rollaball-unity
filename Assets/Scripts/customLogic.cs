using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customLogic : MonoBehaviour
{
    public GameObject pivot;


    void Update()
    {
        transform.RotateAround(pivot.transform.position, Vector3.up, 30 * Time.deltaTime);
    }
}
