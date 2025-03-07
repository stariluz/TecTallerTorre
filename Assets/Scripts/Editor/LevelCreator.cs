using UnityEngine;
using UnityEditor;

public class LevelCreator : EditorWindow
{
    // Variables to be assigned in the window
    Transform container = null;
    GameObject objectToDuplicate = null;
    int quzntity = 30;
    float verticalOffset = 1.0f;
    float rotationIncrement = 10.0f;

    [MenuItem("Tools/Level Creator")]
    public static void ShowWindow()
    {
        GetWindow<LevelCreator>("Level Creator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Level Creator Tool", EditorStyles.boldLabel);

        // Fields to assign the variables in the window
        container = (Transform)EditorGUILayout.ObjectField("Container", container, typeof(Transform), true);
        objectToDuplicate = (GameObject)EditorGUILayout.ObjectField("Object to Arrange", objectToDuplicate, typeof(GameObject), false);
        quzntity = EditorGUILayout.IntField("Number of Objects", quzntity);
        verticalOffset = EditorGUILayout.FloatField("Vertical Offset", verticalOffset);
        rotationIncrement = EditorGUILayout.FloatField("Rotation Increment", rotationIncrement);

        if (GUILayout.Button("Create Level"))
        {
            for (int i = container.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(container.GetChild(i).gameObject);
            }
            for (int i = 0; i < quzntity; i++)
            {
                Vector3 position = new Vector3(container.position.x, container.position.y - i * verticalOffset, container.position.z);
                Quaternion rotation = Quaternion.Euler(0, i * -rotationIncrement, 0);
                GameObject newObject = (GameObject)PrefabUtility.InstantiatePrefab(objectToDuplicate, container);
                newObject.transform.SetPositionAndRotation(position, rotation);
                newObject.name = objectToDuplicate.name + "_" + i;
            }
        }
    }
}
