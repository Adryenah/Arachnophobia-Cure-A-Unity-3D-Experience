using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 5.0f; // Speed of the camera movement
    public float smoothing = 2.0f; // Controls the camera's movement smoothness
    public float angleLimit = 80.0f; // Limit for up/down camera rotation to prevent flipping

    private Vector2 mouseLook;
    private Vector2 smoothV;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse movement
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        // Clamping the vertical look rotation to prevent flipping
        mouseLook.y = Mathf.Clamp(mouseLook.y, -angleLimit, angleLimit);

        // Apply the rotation to the camera (considering the clamped vertical rotation)
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        transform.parent.rotation = Quaternion.AngleAxis(mouseLook.x, transform.parent.up);
    }

}
