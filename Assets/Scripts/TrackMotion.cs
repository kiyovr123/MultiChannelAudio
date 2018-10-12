using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PointerState
{
    Rotator,
    XPan,
    YPan,
    Center,
    Fixration,
    Default,
}

//track motion
public class TrackMotion : MonoBehaviour
{
    //private PointerState pointerState;

    //[SerializeField]
    //private float speed = 10;
    //[SerializeField]
    //private Vector3 defaultPos;
    //[SerializeField]
    //private float radius = 2f;
    //[SerializeField]
    //private Vector2 cursorPos = new Vector2(0f, 0f);

    //[SerializeField]
    //private Transform center;

    //private float x;
    //private float y;
    //private float z;
    //private float zPos;


    //public float Speed
    //{
    //    get { return speed; }
    //    set { speed = value; }
    //}

    //void Start()
    //{
    //    SetPointerState(PointerState.Center);
    //    radius = 2f;
    //    speed = 4f;
    //    zPos = 0.5f;
    //}

    //void Update()
    //{
    //    UpdateTransform();
    //}
    //public void Hoge()
    //{

    //}

    //private void SetPointerState(PointerState state)
    //{
    //    pointerState = state;
    //}

    //public void SetRotateState()
    //{
    //    SetPointerState(PointerState.Rotator);
    //}

    //public void SetDefaultState()
    //{
    //    SetPointerState(PointerState.Default);
    //}

    //public void SetXPanState()
    //{
    //    SetPointerState(PointerState.XPan);
    //}

    //public void SetYPan()
    //{
    //    SetPointerState(PointerState.YPan);
    //}


    //public void UpdateTransform()
    //{
    //    switch (pointerState)
    //    {
    //        case PointerState.Rotator:
    //            RotateState();
    //            break;
    //        case PointerState.XPan:
    //            XPanState();
    //            break;
    //        case PointerState.YPan:
    //            break;
    //        case PointerState.Center:
    //            break;
    //        case PointerState.Fixration:
    //            break;
    //        case PointerState.Default:
    //            DefaultState();
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //private void DefaultState()
    //{
    //    x = center.position.x;
    //    y = center.position.y;
    //    transform.position = new Vector3(x, y, z);
    //}

    //[SerializeField]
    //private bool xPlus;

    //private void XPanState()
    //{
    //    if (xPlus)
    //    {
    //        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    //        if (transform.position.x >= 3)
    //        {
    //            xPlus = false;
    //        }
    //    }
    //    else
    //    {
    //        transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
    //        if (transform.position.x <= -3)
    //        {
    //            xPlus = true;
    //        }
    //    }
    //}

    //private void RotateState()
    //{
    //    cursorPos.x = center.position.x;
    //    cursorPos.y = center.position.y;

    //    x = cursorPos.x + radius * Mathf.Sin(Time.time * speed);
    //    y = cursorPos.y + radius * Mathf.Cos(Time.time * speed);
    //    z = zPos;
    //    transform.position = new Vector3(x, y, z);
    //}

}

