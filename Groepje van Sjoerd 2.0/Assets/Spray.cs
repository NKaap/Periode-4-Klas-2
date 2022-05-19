using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class Spray : MonoBehaviour
{
    // Start is called before the first frame update
    public OVRInput.Button shootButton;
    public ParticleSystem particles;
    private bool grabbed;
    private OVRGrabbable grabbable;


    void Start()
    {
         grabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable.isGrabbed && OVRInput.GetDown(shootButton, grabbable.grabbedBy.GetController()))
        {
            particles.Play();
        }
        else if (grabbable.isGrabbed && OVRInput.GetUp(shootButton, grabbable.grabbedBy.GetController()))
        {
            particles.Stop();
        }
    }
}
