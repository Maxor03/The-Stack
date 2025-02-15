using UnityEngine;
using UnityEngine.UIElements;

public class DragWithMouse : MonoBehaviour
{
    private Vector3 screemPoint;
    private Vector3 offset;
    private Rigidbody rb;
    private Vector3 nextPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMouseDown()
    {
        screemPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);



        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screemPoint.z));

        rb.isKinematic = true;

        nextPosition = Vector3.zero;
    }
    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screemPoint.z);

        nextPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;


    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(nextPosition, Vector3.zero) > 0.01f)
        {
            rb.position = nextPosition;
        }
    }
    private void OnMouseUpAsButton()
    {
        rb.isKinematic = false;

        nextPosition = Vector3.zero;
    }
}   





