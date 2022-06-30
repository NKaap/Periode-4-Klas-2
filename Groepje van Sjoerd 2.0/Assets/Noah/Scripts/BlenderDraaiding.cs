using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderDraaiding : MonoBehaviour
{
    public GameObject Button;
    public GameObject blender;

    [Header("BlenderSetting")]
    public bool blenderOnBase;
    public bool blenderIsOn;
    public RaycastHit hit;
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
        if(blenderIsOn == false)
        {
            blenderIsOn = false;
            blenderAnim.Play("StopBlender");
            blenderSound.Stop();
        }


        float distance = Mathf.Abs(transform.position.y - blender.transform.position.y);

        if(distance < 0.75f)
        {
            blenderOnBase = true;
        } else
        {
            blenderOnBase = false;
        }
    }

    public void ToggleBlender()
    {
        if(blenderOnBase == true)
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
}
