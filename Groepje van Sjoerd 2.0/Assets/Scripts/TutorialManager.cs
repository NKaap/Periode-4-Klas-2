using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameController controller;

    public bool rotation;
    public bool locomotion;
    public float brightnessFloat;

    public void Start()
    {
        rotation = controller.rotationBool;
        locomotion = controller.locomotionBool;
        brightnessFloat = controller.brightness;
    }
    public void LoadGame(string scene)
    {
        SceneManager.LoadScene(scene);
        //StateNameController.smoothLocomotion = rotation;
        //StateNameController.smoothRotation = locomotion;
        //StateNameController.brightness = brightnessFloat;
    }
}
