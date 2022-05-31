using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderDraaiding : MonoBehaviour
{
    public GameObject Button;

    [Header("BlenderSetting")]
    public bool blenderIsOn;
    public Animator blenderAnim;
    public AudioSource blenderSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleBlender();
        }
    }

    public void ToggleBlender()
    {
        blenderIsOn = !blenderIsOn;
        if (blenderIsOn == false)
        {
            blenderAnim.Play("StopBlender");
            blenderSound.Stop();
        }
        if (blenderIsOn == true)
        {
            blenderAnim.Play("BlenderOn");
            blenderSound.Play();
        }
    }
}
