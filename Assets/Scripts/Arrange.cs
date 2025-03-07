using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Arrange : MonoBehaviour
{
    public GameObject objectToArrange;
    public int numberOfObjects = 5;
    public float verticalOffset = 2.0f;
    public float rotationIncrement = 10.0f;
    public Transform container;

    [ContextMenu("Arrange Objects")]
    void ArrangeObjects()
    {
        for (int i = container.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(container.GetChild(i).gameObject);
        }
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y - i * verticalOffset, transform.position.z);
            Quaternion rotation = Quaternion.Euler(0, i * -rotationIncrement, 0);
            GameObject newObject = Instantiate(objectToArrange, position, rotation, container);
            newObject.name = objectToArrange.name + "_" + i;
        }
    }
}