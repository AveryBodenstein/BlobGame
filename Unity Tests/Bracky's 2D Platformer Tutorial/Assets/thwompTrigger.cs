using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class thwompTrigger : MonoBehaviour
{

    [SerializeField] private UnityEvent thwompIsTriggered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Triggers when something enters the trigger zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the player initiated the trigger
        if (collision.CompareTag("Player"))
        {
            // tell the thwomp to fall
            thwompIsTriggered.Invoke();
        }
    }
}
