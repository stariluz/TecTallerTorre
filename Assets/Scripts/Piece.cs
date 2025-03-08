using NUnit.Framework;
using Unity.VisualScripting;
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
        collider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
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
            
            Collider[] colliders=transform.parent.gameObject.GetComponentsInChildren<Collider>();
            MeshRenderer[] meshRenderers=transform.parent.gameObject.GetComponentsInChildren<MeshRenderer>();

            foreach(Collider collider in colliders){
                if (meshRenderer != null)
                {
                    collider.enabled=false;
                }
            }
            foreach(MeshRenderer meshRenderer in meshRenderers){
                if (meshRenderer != null)
                {
                    meshRenderer.enabled=false;
                }
            }
        }
    }
}
