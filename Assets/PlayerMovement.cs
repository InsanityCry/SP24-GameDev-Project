using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody selfRB;
    public Camera selfCam;
    public Transform selfLoc;

    private float LRMove;
    private float FBMove;
    
    // Start is called before the first frame update
    void Start()
    {
        selfLoc = GetComponent<Transform>();
        selfCam = GetComponentInChildren<Camera>();
        selfRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LRMove = Input.GetAxis("Horizontal");
        FBMove = Input.GetAxis("Vertical");
        float moveX = LRMove * 100 * Time.deltaTime;
        float moveZ = FBMove * 100 * Time.deltaTime;
        selfRB.velocity = new Vector3(moveX, 0, moveZ);
        selfLoc.rotation = new Quaternion(0, 0, 0, 0);
    }
}
