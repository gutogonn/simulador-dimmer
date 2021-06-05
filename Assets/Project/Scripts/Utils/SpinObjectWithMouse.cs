using UnityEngine;

public class SpinObjectWithMouse : MonoBehaviour
{
    private float rotSpeed = 1000;
    private void OnMouseDrag()
    {   
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        Debug.Log(rotX);
        transform.Rotate(Vector3.forward, -rotX);
    }
}
