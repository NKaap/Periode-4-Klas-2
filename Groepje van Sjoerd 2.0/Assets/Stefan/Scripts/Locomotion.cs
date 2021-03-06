using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Locomotion : MonoBehaviour
{
    // Start is called before the first frame update
    public OVRPlayerController ovrRig;
    public GameObject teleportEmpty;
    public TextMeshProUGUI textMesh;
    public bool RotationBool = true;
    public bool LocomotionBool = true;

    public void ChangeLocomotion()
    {
        if (LocomotionBool == true)
        {
            ovrRig.GetComponent<OVRPlayerController>().EnableLinearMovement = false;
            teleportEmpty.SetActive(true);
            textMesh.text = "TELEPORTATION";
            LocomotionBool = false;
        }
        else if (LocomotionBool == false)
        {
            ovrRig.GetComponent<OVRPlayerController>().EnableLinearMovement = true;
            teleportEmpty.SetActive(false);
            textMesh.text = "SMOOTH LOCOMOTION";
            LocomotionBool = true;
        }
    }

    public void ChangeRotation()
    {
        if (RotationBool == true)
        {
            ovrRig.SnapRotation = false;
            textMesh.text = "SMOOTH TURNING";
            RotationBool = false;
        }
        else if (RotationBool == false)
        {
            ovrRig.SnapRotation = true;
            textMesh.text = "SNAP TURNING";
            RotationBool = true;
        }
    }
}
