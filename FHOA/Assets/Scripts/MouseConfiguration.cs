using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// Allows basic mouse configuration while in-game
/// </summary>
public class MouseConfiguration : MonoBehaviour
{
    // public variables
    public bool invertYAxis = false;        // flag determining whether to initially reverse the y-axis
    public bool invertXAxis = false;        // flag determining whether to initially reverse the x-axis

    // private variables
    FirstPersonController fpsController;    // script controlling basic fps character movement

    // Start is called before the first frame update
    void Start()
    {
        // retrieve reference to first person controller script
        fpsController = GetComponent<FirstPersonController>();

        // if player initialized look inversions to true, reverse appropriate look sensitivities
        if (invertXAxis)
            fpsController.MouseLook.XSensitivity *= -1;
        if (invertYAxis)
            fpsController.MouseLook.YSensitivity *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
