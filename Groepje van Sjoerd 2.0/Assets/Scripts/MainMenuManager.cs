using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Locomotion rotation;
    public Locomotion locomotion;
    public Slider brightnessSlider;
    public void LoadGame(string scene)
    {
        SceneManager.LoadScene(scene);
        StateNameController.smoothLocomotion = rotation.RotationBool;
        StateNameController.smoothRotation = locomotion.LocomotionBool;
        StateNameController.brightness = brightnessSlider.value;
    }
}
