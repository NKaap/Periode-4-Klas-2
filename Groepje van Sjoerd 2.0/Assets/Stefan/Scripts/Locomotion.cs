using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Locomotion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ovrRig;
    public TextMeshProUGUI textMesh;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLocomotion(bool LocomotionBool = true)
    {
        if (LocomotionBool == true)
        {
            ovrRig.GetComponent<OVRPlayerController>().EnableLinearMovement = false;
            textMesh.text = "TELEPORTATION";
            LocomotionBool = false;
        }
        else if (LocomotionBool == false)
        {
            ovrRig.GetComponent<OVRPlayerController>().EnableLinearMovement = true;
            textMesh.text = "SMOOTH LOCOMOTION";
            LocomotionBool = true;
        }
    }

    public void ChangeRotation(bool RotationBool = true)
    {
        if (RotationBool == true)
        {
            ovrRig.GetComponent<OVRPlayerController>().SnapRotation = false;
            textMesh.text = "SMOOTH TURNING";
            RotationBool = false;
        }
        else if (RotationBool == false)
        {
            ovrRig.GetComponent<OVRPlayerController>().SnapRotation = true;
            textMesh.text = "SNAP TURNING";
            RotationBool = true;
        }
    }
}
