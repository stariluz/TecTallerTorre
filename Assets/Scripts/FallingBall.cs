using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FallingBall : MonoBehaviour
{
    public float distanceBetweenCubes = 1.5f; // metros
    public float rotationSpeed = 60f; // grados por segundo (de los cubos)
    public float anglePerImpact = 45f; // grados

    private float fallSpeed;
    public InputActionReference fallAction;

    void Start()
    {
        fallSpeed = (distanceBetweenCubes * rotationSpeed) / anglePerImpact;
        Debug.Log("Velocidad de caída calculada: " + fallSpeed + " m/s");
    }

    void Update()
    {
        if (GameManager.Instance.gameState != GameManager.GameState.Playing)
        {
            fallAction.action.actionMap.Disable();
        }
        if (fallAction.action.IsPressed())
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }
}
