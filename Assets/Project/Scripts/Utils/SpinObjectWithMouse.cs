using UnityEngine;

public class SpinObjectWithMouse : MonoBehaviour
{
    private float rotSpeed = 1000;

    [SerializeField] private Transform lightSource;
    [SerializeField] private Transform bulbSource;

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.forward, -rotX);

        Material bulbMat = bulbSource.GetComponent<MeshRenderer>().materials[2];
        bulbMat.SetColor("_EmissionColor", new Vector4(bulbMat.color.r, bulbMat.color.g, bulbMat.color.b, 0) * (transform.eulerAngles.z / 100));
        
        lightSource.GetComponent<Light>().spotAngle = transform.eulerAngles.z / 2;
        if (lightSource.GetComponent<Light>().spotAngle > 150) lightSource.GetComponent<Light>().spotAngle = 150;
    }
}
