using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ensure that there is a 2d collider attached to sense when to thwomp
//[RequireComponent (typeof(Collider2D))];

public class thwompDetect : MonoBehaviour
{
    [SerializeField] private GameObject block;                      // block to move for thwomp
    [SerializeField] private Vector3 direction;                     // direction for block to slide
    [Range(0, 15)] [SerializeField] private float fallSpeed = 10.0f;  // falling speed of thwomp
    [Range(0, 15)] [SerializeField] private float resetSpeed = 5.0f; // reset speed of thwomp
    //public bool triggered = false;                                 // if the block has been triggered
    //public bool touchdown = false;                                  // if the block has hit something

    private bool triggered = false;
    private bool rising = false;                                    // the block is resetting
    private bool touchdown = false;                                 // the block has hit something

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // block is falling
        if(triggered && !rising)
        {
            // start motion of block per direction/speed inputs
            block.transform.Translate(direction * fallSpeed * Time.deltaTime);
            // check if the block has hit something
            if(touchdown)
            {
                touchdown = false;
                triggered = false;
                rising = true;
            }
        }
        // block is rising
        else if (rising)
        {
            // start motion of block per direction/speed inputs
            block.transform.Translate(-direction * resetSpeed * Time.deltaTime);
        }
    }

    /*
    // called when the block hits something
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player trigger");
            // start the block moving
            triggered = true;
        }

    }
    */
}
