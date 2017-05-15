using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // Target that the camera will follow 
    public GameObject target;
    public Vector3 targetPosition;

    // Camera movespeed
    public float moveSpeed;

    // State
    private static bool cameraExists;

    // Camera
    private Camera cam;
    private Vector3 minBounds;
    private Vector3 maxBounds;
    private float halfHeight;
    private float halfWidth;

	// Use this for initialization
	void Start () {
		// If the camera already exists
        if (cameraExists) {
            // Destroy it so it won't get cloned
            Destroy(gameObject);
        } else {
            // Make it exist and don't destroy it, keeping its current position
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        // Sets the camera position to follow the target
        targetPosition = new Vector3(target.transform.position.x,
                                     target.transform.position.y,
                                     transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
	}
}
