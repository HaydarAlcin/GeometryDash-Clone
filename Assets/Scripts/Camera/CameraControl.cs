using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Target; 
    public float smoothSpeed = 0.125f;
    public Vector2 Offset;
    PlayerController playerController;

    private void Start()
    {
        playerController = Target.gameObject.GetComponent<PlayerController>();
    }
    private void LateUpdate()
    {
        

        if (playerController.isTouchThePortal)
        {
            Vector3 desiredPosition = new Vector3(Target.position.x, Target.position.y + Offset.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        else
        {
            Vector3 newPosition = new Vector3(Target.position.x + Offset.x, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
