using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class Spray : MonoBehaviour
{
    // Start is called before the first frame update
    public float range;

    [SerializeField] private Camera cam;
    [SerializeField] private Shader drawShader;

    private RenderTexture splatMap;
    private Material currentMaterial, drawMaterial;
    private RaycastHit hit;

    [SerializeField] [Range(1, 500)] private float size;
    [SerializeField] [Range(0, 1)] private float strength;

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
