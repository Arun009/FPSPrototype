﻿using UnityEngine;
using System.Collections;

public class ShootRayCast : MonoBehaviour {

    public GameObject fPSController;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            push();
        }
        if (Input.GetMouseButtonDown(1))
        {
            pull();
        }
    }

    void push()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if(Physics.Raycast(transform.position, fwd, out hit, float.MaxValue))
        {
            
            if(hit.transform.tag.Equals("Metal"))
            {
                Debug.Log("hit " + hit.transform.tag);
                float massDifference = hit.transform.GetComponent<Rigidbody>().mass - fPSController.GetComponent<Rigidbody>().mass;
                if (massDifference < 0)
                {

                    hit.transform.GetComponent<Rigidbody>().AddForce(transform.forward * ((Mathf.Abs(massDifference)) * 500));
                }
                else
                {
                    fPSController.GetComponent<Rigidbody>().velocity = -transform.forward * 30;

                }
            }
        }
    }

    void pull()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, float.MaxValue))
        {

            if (hit.transform.tag.Equals("Metal"))
            {
                float massDifference = hit.transform.GetComponent<Rigidbody>().mass - fPSController.GetComponent<Rigidbody>().mass;
                if (massDifference < 0)
                {
                    hit.transform.GetComponent<Rigidbody>().AddForce(-transform.forward * ((Mathf.Abs(massDifference)) * 500));
                }
                else
                {
                    fPSController.GetComponent<Rigidbody>().velocity = transform.forward * 30;
                }
            }
        }
    }
}
