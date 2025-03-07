using NUnit.Framework;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public enum PieceType
    {
        Normal,
        Bad
    }
    public PieceType pieceType = PieceType.Normal;
    private AudioSource audioSource;
    public float offsetSeconds;
    public MeshRenderer meshRenderer;
    public Collider collider;
    public bool isLastPiece;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.time = offsetSeconds;
                audioSource.pitch = 1.0f + GameManager.Instance.ComboCounter();
                audioSource.Play();
            }

            if (meshRenderer != null)
            {
                collider.enabled = false;
                if (pieceType == PieceType.Normal)
                    meshRenderer.enabled = false;
            }

            GameManager.Instance.Pop();
            if (isLastPiece)
            {
                GameManager.Instance.Win();
            }

            if (pieceType == PieceType.Bad)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
