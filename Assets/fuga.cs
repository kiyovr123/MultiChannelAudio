using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuga : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float radius;
    [SerializeField]
    private float yPosition;

    public float x;
    public float y;
    public float z;

    // Use this for initialization
    void Start()
    {
        speed = 1.0f;
        radius = 2.0f;
        yPosition = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        x = radius * Mathf.Sin(Time.time * speed);
        y = radius * Mathf.Cos(Time.time * speed);

        z = yPosition;

        transform.position = new Vector3(x, y, z);
    }
}
