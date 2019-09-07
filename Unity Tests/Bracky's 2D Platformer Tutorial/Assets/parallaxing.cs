using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxing : MonoBehaviour
{

    [SerializeField] private Transform[] backgrounds;                   // array of elements to be parallaxed
    [Range(0, 1)] [SerializeField] private float smoothing = 0.5f;      // how smooth the parallax effect is
    [SerializeField] private Camera mainCamera;                         // the camera to use when calculating parallax

    private float[] scales;                         // array of 'distances' from the camera for parallax movement scale
    private Transform cam;                          // reference to main camera's transform
    private Vector3 previousCamPosition;            // store previous camera position

    // Awake is called before the Start(), before the first frame but after all the game objects are set up
    // NOTE: This is perfect for references
    void Awake()
    {
        // set up camera reference
        cam = mainCamera.transform;
        // cam = Camera.main.gameObject.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // initialize camera position
        previousCamPosition = cam.position;
        // calculate parallax scales from z position of objects
        scales = new float[backgrounds.Length];
        for(int i=0; i<backgrounds.Length; i++)
        {
            scales[i] = backgrounds[i].position.z * -1.0f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // for each background
        for(int i = 0; i<backgrounds.Length; i++)
        {
            // the parallax motion is the opposite to the camera movement, scaled by the depth
            float parallax = (previousCamPosition.x - cam.position.x) * scales[i];
            // calculate new position for the background object
            float backgroundTargetPositionX = backgrounds[i].position.x + parallax;
            // set position of that background object
            Vector3 backgroundTargetPosition = new Vector3 (backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z);
            // fade between current position and target position
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);

        }

        // update previous camera position
        previousCamPosition = cam.position;
    }

}
