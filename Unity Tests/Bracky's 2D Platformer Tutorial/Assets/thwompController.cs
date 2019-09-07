using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class thwompController : MonoBehaviour
{

    [SerializeField] private GameObject block;                      // block to move for thwomp
    [SerializeField] private Vector3 direction = new Vector3(0.0f, -1.0f, 0.0f);                     // direction for block to slide
    [Range(0, 15)] [SerializeField] private float fallSpeed = 10.0f;  // falling speed of thwomp
    [Range(0, 15)] [SerializeField] private float resetSpeed = 5.0f; // reset speed of thwomp

    private bool triggered = false;
    private bool rising = false;                                    // the block is resetting
    private bool touchdown = false;                                 // the block has hit something
    private float threashold = 0.001f;                               // threashold for block being at it's original position

    private Vector3 initialPosition;
    private Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        // set initial position of block
        initialPosition = block.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // block is falling
        if (triggered && !rising)
        {
            // start motion of block per direction/speed inputs
            block.transform.Translate(direction * fallSpeed * Time.deltaTime);
        }
        // block is rising
        else if (rising)
        {
            // start motion of block per direction/speed inputs
            block.transform.position = Vector3.MoveTowards(currentPosition, initialPosition, resetSpeed);
            currentPosition = block.transform.position;
            // if the block is back where it started
            if(Vector3.Distance(currentPosition,initialPosition) < threashold)
            {
                // enter idle state
                rising = false;
                triggered = false;
            }
        }
    }

    // fall function causes block to fall at speed specified
    public void Fall()
    {
        //Debug.Log("Triggered");
        triggered = true;

    }

    public void Touchdown()
    {
        //Debug.Log("Touchdown");
        // set current position
        currentPosition = block.transform.position;
        // enter rising state
        touchdown = true;
        triggered = false;
        rising = true;
    }
}
