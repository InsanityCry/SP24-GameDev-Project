using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float sens;

    public Rigidbody selfRB;
    public Camera selfCam;
    public Transform selfLoc;
    private float cameraVerticalRot = 0f;

    Vector3 moveX;
    Vector3 moveZ;

    // Start is called before the first frame update
    void Start()
    {
        selfLoc = GetComponent<Transform>();
        selfCam = GetComponentInChildren<Camera>();
        selfRB = GetComponent<Rigidbody>();

        sens = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement For Player Camera
        float inX = Input.GetAxis("Mouse X") * sens;
        float inY = Input.GetAxis("Mouse Y") * sens;

        cameraVerticalRot -= inY;
        cameraVerticalRot = Mathf.Clamp(cameraVerticalRot, -89.9f, 89.9f);
        selfCam.transform.localEulerAngles = Vector3.right * cameraVerticalRot; //idk why right, but ig vectors
        selfLoc.Rotate(Vector3.up * inX);

        // Movement For Player WASD
        float yrot = selfLoc.localEulerAngles.y;
        Vector3 right = selfCam.transform.right;
        Vector3 forward = selfCam.transform.forward;
        moveX = Input.GetAxis("Horizontal") * right;
        moveZ = Input.GetAxis("Vertical") * forward;
        Vector3 cameraRelativeMovement = moveX + moveZ;
        selfRB.velocity = new Vector3(moveX.x + moveZ.x, 0, moveX.z + moveZ.z).normalized;

    }
}
