using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class thwompGround : MonoBehaviour
{

    [SerializeField] private UnityEvent thwompIsHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Triggers when something hits the collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Ground Trigger");
        
        thwompIsHit.Invoke();

    }


}
