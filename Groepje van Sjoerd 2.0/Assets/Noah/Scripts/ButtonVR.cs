using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    [Header("Button Settings")]
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public GameObject presser;
    AudioSource sound;
    bool isPressed;

    [Header("Mix Settings")]
    public GameObject blenderMes;


    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0, 0.003f);
            presser = collision.gameObject;
            onPress.Invoke();
            //sound.Play();
            isPressed = true;
            blenderMes.GetComponent<BlenderDraaiding>().ToggleBlender();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0, 0.015f);
            onRelease.Invoke();
            isPressed = false;
            blenderMes.GetComponent<BlenderDraaiding>().ToggleBlender();
        }
    }

    public void JeMama()
    {
        Debug.Log("Knop aangeraakt");
    }

    public void JeMama2()
    {
        Debug.Log("Knop los");
    }


}
