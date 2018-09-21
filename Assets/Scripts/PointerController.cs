using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerController : MonoBehaviour
{
    //座標の最大と最小
    //正方形にする
    private static readonly float FIELD_MAX = 4f;
    private static readonly float FIELD_MIN = -4f;
    private static readonly Vector3 CENTER_VALUE = new Vector3(0, 0, 0);
    private static readonly float MAX_DISTANCE = 100f;
    private static readonly float DEFAULT_Z_POS = 10f;

    private Camera mainCamera;
    private Vector3 touchScreenPosition;
    private Vector3 touchWorldPosition;

    private bool isSelected = false;
    [SerializeField]
    private float xPos = 1;
    [SerializeField]
    private float yPos = 1;

    [SerializeField]
    private Transform pointerTransform;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        MouseInput();
        UpdateMouseTransform();
        MousePositionCalculater();
    }

    private void UpdateMouseTransform()
    {
        if (isSelected)
        {
            touchScreenPosition = Input.mousePosition;
            touchScreenPosition.x = Mathf.Clamp(touchScreenPosition.x, 0.0f, Screen.width);
            touchScreenPosition.y = Mathf.Clamp(touchScreenPosition.y, 0.0f, Screen.height);
            touchScreenPosition.z = DEFAULT_Z_POS;
            touchWorldPosition = mainCamera.ScreenToWorldPoint(touchScreenPosition);
            this.transform.position = touchWorldPosition;
        }
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InitRaycast();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSelected = false;
        }
    }

    private void InitRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float maxDistance = MAX_DISTANCE;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);

        if (hit.collider)
        {
            if (hit.collider.gameObject.name == "Pointer")
            {
                isSelected = true;
            }
        }
    }

    private void MousePositionCalculater()
    {
        xPos = Mathf.InverseLerp(-2.63f, 2.65f, pointerTransform.position.x);
        yPos = Mathf.InverseLerp(-1.86f, 3.41f, pointerTransform.position.y);
    }

    public float GetMouseXPos()
    {
        return xPos;
    }

    public float GetMouseYPos()
    {
        return yPos;
    }

}
