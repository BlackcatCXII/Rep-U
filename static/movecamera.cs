using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void LateUpdate()
    {
        if (cameraPosition != null)
        {
            transform.position = cameraPosition.position;
            transform.rotation = cameraPosition.rotation;
        }
        else
        {
            Debug.LogWarning("Camera position reference is not set.");
        }
    }
}
