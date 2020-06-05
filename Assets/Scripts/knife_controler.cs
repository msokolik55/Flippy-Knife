using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife_controler : MonoBehaviour {

    public Rigidbody rb;

    private Vector2 startSwipe;
    private Vector2 endSwipe;
    public float force = 5f;
    public float torque = 20f;
    private float startTime;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            startSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Swipe();
        }
	}

    void Swipe() {
        rb.isKinematic = false;
        startTime = Time.time;
        Vector2 swipe = endSwipe - startSwipe;
        Debug.Log(swipe);
        rb.AddForce(swipe * force, ForceMode.Impulse);
        rb.AddTorque(0f, 0f, torque, ForceMode.Impulse);
    }

    void OnTriggerEnter()
    {

        rb.isKinematic = true;
    }

    void onCollisiononEnter ()
    {
        float timeInAir = Time.time - startTime;

        if (!rb.isKinematic && timeInAir >= 0.1f)
        {

        }

        Debug.Log("FAIL");
    }
}
