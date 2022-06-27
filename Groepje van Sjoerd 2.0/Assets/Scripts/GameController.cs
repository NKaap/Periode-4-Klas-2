using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class GameController : MonoBehaviour
{
    public Volume globalVolume;
    public ColorAdjustments colorAdjustments;
    public OVRPlayerController ovrRig;
    public GameObject teleportEmpty;

    public bool locomotionBool;
    public bool rotationBool;
    public float brightness;
    void Start()
    {
        locomotionBool = StateNameController.smoothLocomotion;
        rotationBool = StateNameController.smoothRotation;
        brightness = StateNameController.brightness;

        VolumeProfile profile = globalVolume.sharedProfile;
        globalVolume.profile.TryGet(out colorAdjustments);
        Debug.Log(colorAdjustments);
        colorAdjustments.postExposure.value = brightness;

        if (locomotionBool == true)
        {
            ovrRig.GetComponent<OVRPlayerController>().EnableLinearMovement = false;
            teleportEmpty.SetActive(true);
        }
        else if (locomotionBool == false)
        {
            ovrRig.GetComponent<OVRPlayerController>().EnableLinearMovement = true;
            teleportEmpty.SetActive(false);
        }

        if (rotationBool == true)
        {
            ovrRig.SnapRotation = false;
        }
        else if (rotationBool == false)
        {
            ovrRig.SnapRotation = true;
        }
    }
}
