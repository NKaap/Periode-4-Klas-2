using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Brightness : MonoBehaviour
{
    public Volume globalVolume;
    public ColorAdjustments colorAdjustments;
    public Slider slider;
    // public ColorAdjustments colorAdjustmentLayer;
    // Start is called before the first frame update
    void Start()
    {
        VolumeProfile profile = globalVolume.sharedProfile;
        globalVolume.profile.TryGet(out colorAdjustments);
        Debug.Log(colorAdjustments);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BrightnessControl()
    {
        colorAdjustments.postExposure.value = slider.value;
    }
}
