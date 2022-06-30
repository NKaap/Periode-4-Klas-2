using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeTP : MonoBehaviour
{
    public GameObject leftController;
    public OVRInput.Button input;
    public Transform player;
    public Transform destination;

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();

        if (OVRInput.Get(input))
        {
            player.position = destination.position;
        }
    }
}
