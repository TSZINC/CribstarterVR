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
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
