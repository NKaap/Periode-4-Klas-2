using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class Spray : MonoBehaviour
{
    public GameObject raycastObject;
    public OVRInput.Button shootButton;
    public ParticleSystem particles;
    private bool grabbed;
    private OVRGrabbable grabbable;

    public Color paintColor;

    public float radius = 1;
    public float strength = 1;
    public float hardness = 1;

    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable.isGrabbed && OVRInput.Get(shootButton, grabbable.grabbedBy.GetController()))
        {  
            Ray ray = new Ray(raycastObject.transform.position, raycastObject.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, .4f))
            {
                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);
                //transform.position = hit.point;
                Paintable p = hit.collider.GetComponent<Paintable>();
                if (p != null)
                {
                    PaintManager.instance.paint(p, hit.point, radius, hardness, strength, paintColor);
                }
            }
            particles.Play();
        }
        else if (grabbable.isGrabbed && OVRInput.GetUp(shootButton, grabbable.grabbedBy.GetController()))
        {
            particles.Stop();
        }
    }
}
