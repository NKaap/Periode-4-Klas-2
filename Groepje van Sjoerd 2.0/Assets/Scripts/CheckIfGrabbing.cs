using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfGrabbing : MonoBehaviour
{
    //public OVRGrabbable grabbable;
    public OVRGrabber grabber;

    private void FixedUpdate()
    {
        if (grabber.grabbedObject == null)
        {
            if (grabber.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled == false)
            {
                grabber.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            }
        }
        else
        {
            if (grabber.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled == true)
            {
                grabber.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            }
        }
    }

    //public void FixedUpdate()
    //{
    //    if (grabbable.isGrabbed == true)
    //    {
    //        grabber = grabbable.grabbedBy;
    //        grabber.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
    //    }
    //    if (grabbable.isGrabbed == false)
    //    {
    //        grabber.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
    //    }
    //}
}