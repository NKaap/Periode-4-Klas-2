using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using UnityEngine.UI;
using TMPro;

public class Spray : MonoBehaviour
{
    public GameObject raycastObject;
    public OVRInput.Button shootButton;
    public UnitySimpleLiquid.LiquidContainer container;
    public ParticleSystem particles;
    private bool grabbed;
    private OVRGrabbable grabbable;
    public float score;
    public int multiplier;

    public TMP_Text multiplierTMP;
    public TMP_Text scoreTMP;

    public Vector3 oldPos;
    public Vector3 currentPos;

    public Color paintColor;

    public float radius = 1;
    public float strength = 1;
    public float hardness = 1;

    public bool ifCapsule;

    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        multiplier = 1;
    }

    //private IEnumerator CheckMoving()
    //{
    //    oldPos = grabbable.grabbedBy.gameObject.transform.localPosition;
    //    yield return new WaitForSeconds(1f);
    //    currentPos = grabbable.grabbedBy.gameObject.transform.localPosition;
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        #region particle color
        ParticleSystem.MainModule settings = particles.main;
        settings.startColor = container.LiquidColor;
        paintColor = container.LiquidColor;
        #endregion

        if (ifCapsule == true)
        {
            if (container.FillAmountPercent > 0f)
            {
                if (grabbable.isGrabbed && OVRInput.Get(shootButton, grabbable.grabbedBy.GetController()))
                {
                    container.FillAmountPercent += -0.01f * Time.fixedDeltaTime;

                    currentPos = grabbable.grabbedBy.gameObject.transform.localPosition;

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

                            //StartCoroutine(CheckMoving());

                            //if ((currentPos - oldPos).sqrMagnitude > 0.05)
                            //{
                            Debug.Log(grabbable.grabbedBy.transform.parent.transform.parent.gameObject.transform.localRotation.z);

                            if (grabbable.grabbedBy.transform.parent.transform.parent.gameObject.transform.localRotation.z < 0.60f && grabbable.grabbedBy.transform.parent.transform.parent.gameObject.transform.localRotation.z > 0.20f || grabbable.grabbedBy.transform.parent.transform.parent.gameObject.transform.localRotation.z > -0.60f && grabbable.grabbedBy.transform.parent.transform.parent.gameObject.transform.localRotation.z < -0.20f)
                                {
                                    
                                    multiplier = 2;
                                    multiplierTMP.enabled = true;
                                }
                                else if (grabbable.grabbedBy.transform.parent.transform.parent.gameObject.transform.localRotation.z > 0.60f && grabbable.grabbedBy.transform.parent.transform.parent.gameObject.transform.localRotation.z < 0.20f || grabbable.grabbedBy.transform.parent.transform.parent.gameObject.transform.localRotation.z < -0.60f && grabbable.grabbedBy.transform.parent.transform.parent.gameObject.transform.localRotation.z > -0.20f)
                                {
                                    multiplier = 1;
                                    multiplierTMP.enabled = false;
                                }

                                score += ((10 * multiplier) * 0.1f);
                                scoreTMP.text = score.ToString();
                            //}      
                        }
                    }
                    particles.Play();
                }
                else if (grabbable.isGrabbed && OVRInput.GetUp(shootButton, grabbable.grabbedBy.GetController()))
                {
                    particles.Stop();
                    multiplier = 1;
                    multiplierTMP.enabled = false;
                }
            }
            else if (container.FillAmountPercent <= 0.01f)
            {
                particles.Stop();
                multiplier = 1;
                multiplierTMP.enabled = false;
            }
        }
        else if (grabbable.isGrabbed && OVRInput.GetUp(shootButton, grabbable.grabbedBy.GetController()))
        {
            particles.Stop();
            multiplier = 1;
            multiplierTMP.enabled = false;
        }
        else if (ifCapsule == false)
        {
            if (particles.isPlaying)
            {
                particles.Stop();
                multiplier = 1;
                multiplierTMP.enabled = false;
            }
        }
    }
}
