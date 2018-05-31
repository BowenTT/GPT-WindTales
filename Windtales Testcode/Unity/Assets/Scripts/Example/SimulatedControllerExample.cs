using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SimulatedControllerExample : MonoBehaviour
{

    [Header("gameplay options")]
    [SerializeField]
    private DeviceManager.DeviceType deviceType;
    double flowRate;
    [SerializeField]
    [Tooltip("The amount which the player needs to blow in order to jump")]
    private double blowthreshold;
    private Text text;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();

        DeviceManager.Instance.SetDeviceType(deviceType);
        DeviceManager.Instance.InitMinMax();
	}
	
	// Update is called once per frame
	void Update ()
    {
        flowRate = DeviceManager.Instance.FlowLMin;
        flowRate = System.Math.Round(flowRate, 1);
        text.text = "Current flow: " + DeviceManager.Instance.FlowLMin + "; Flow state: " + DeviceManager.Instance.CurrentFlowState;
	}
}
