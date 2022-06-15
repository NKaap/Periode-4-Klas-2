using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidbody : MonoBehaviour
{
    public GameObject target;
    public GameObject sprayGun;
    private OVRGrabbable grabbable;
    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            if (grabbable.isGrabbed == false)
            {
                target = other.gameObject;
                Vector3 pos = target.transform.position;
                Quaternion rot = target.transform.rotation;
                gameObject.transform.SetParent(sprayGun.transform);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.transform.position = pos;
                gameObject.transform.rotation = new Quaternion(0,0,0,0);

                gameObject.GetComponent<MeshCollider>().convex = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            if (grabbable.isGrabbed == true)
            {
                gameObject.GetComponent<MeshCollider>().convex = true;
            }
        }
    }
}
