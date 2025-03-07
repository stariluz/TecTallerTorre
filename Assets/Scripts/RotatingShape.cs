using UnityEngine;

public class RotatingShape : MonoBehaviour
{
    public float rotationSpeed = 60f; // grados por segundo

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
