using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPositionRotation : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

    private void Awake()
    {
        offset = target.transform.position - transform.position;
    }

    void Update()
    {
        transform.position = target.transform.position - offset;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
