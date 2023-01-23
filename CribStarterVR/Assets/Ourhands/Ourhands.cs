using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class Ourhands : MonoBehaviour
{

    // public values to set in Unity, private used only in script
    public GameObject ourHandsPrefab;
    public InputDeviceCharacteristics ourControllerCharecteristics;

    private InputDevice ourDevice;
    private Animator ourHandAnimator;

    // Start is called before the first frame update
    void Start()
    {
        InitializeOurHands();
    }
    void InitializeOurHands()
    {
        //check for our controllerscharacteristics
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ourControllerCharecteristics, devices);

        //If Device identified, Instantiate a Hand
        if (devices.Count > 0)
        {
            ourDevice = devices[0];
            GameObject newHand = Instantiate(ourHandsPrefab, transform);
            ourHandAnimator = newHand.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Change Animate poistion or re-initialize
        if (ourDevice.isValid)
        {
            UpdateOurHands();
        }
        else
        {
            InitializeOurHands();
        }
    }
    void UpdateOurHands()
    {
        if (ourDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            ourHandAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            ourHandAnimator.SetFloat("Trigger", 0);
        }

        if (ourDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            ourHandAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            ourHandAnimator.SetFloat("Grip", 0);
        }
    }
}
