using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfGrabbing : MonoBehaviour
{
    public OVRGrabbable grabbable;
    public void FixedUpdate()
    {
        if (grabbable.isGrabbed == true)
        {
            OVRGrabber grabber = grabbable.grabbedBy;
            grabber.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }
        if (grabbable.isGrabbed == false)
        {
            //grabber.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        }
    }
}