using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoge : MonoBehaviour
{
    public float a;
    public float b;
    public float c;
    public float d;

    public float x;
    public float y;

    public float walkSpeed = 5.0F;
    public float runSpeed = 10.0F;
    [Range(5,10)]
    public float speed = 8.0F;

    public float parameter;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;

        AFunc();
        BFunc();
        CFunc();
        DFunc();

        parameter = Mathf.InverseLerp(walkSpeed, runSpeed, speed);
    }

    public void AFunc()
    {
        a = y * (1 - x);
    }

    public void BFunc()
    {
        b = y * x;
    }

    public void CFunc()
    {
        c = (1 - y) * (1 - x);
    }

    public void DFunc()
    {
        d = (1 - y) * x;
    }

}
