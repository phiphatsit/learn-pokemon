using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 0.125f;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 targetPos = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPos, speed);
            transform.position = smoothedPosition;
        } 
    }
}
