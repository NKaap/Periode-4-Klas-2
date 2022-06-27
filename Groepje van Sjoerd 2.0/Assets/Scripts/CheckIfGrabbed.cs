using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfGrabbed : MonoBehaviour
{
    public OVRGrabbable grabbable;
    public OVRGrabber controller;
    public bool m_isGrabbed;

    private void Awake()
    {
        grabbable = GetComponent<OVRGrabbable>();
    }

    private void FixedUpdate()
    {
        controller = grabbable.grabbedBy;
        if (grabbable.isGrabbed == true)
        {
            m_isGrabbed = true;
            GrabbingFunction(controller);
        }
        else if (grabbable.isGrabbed == false)
        {
            m_isGrabbed = false;
            GrabbingFunction(controller);
        }
    }

    public void GrabbingFunction(OVRGrabber origin)
    {
        if (m_isGrabbed == true)
        {
            origin.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }
        else if (m_isGrabbed == false)
        {
            origin.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        }
    }
}
