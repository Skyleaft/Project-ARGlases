using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    private Transform transform;

    public Vector3 axis;
    public int angle;
    public bool isRotated;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRotated)
        {
            transform.Rotate(axis,angle,Space.Self);
        }
    }
}
