using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedController))]
[RequireComponent(typeof(SteamVR_TrackedObject))]


public class TimeController : MonoBehaviour {

    public float timeScaleRate;
    private SteamVR_TrackedController controller;
    private SteamVR_TrackedObject mainObject;

    private void Initialize()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        mainObject = GetComponent<SteamVR_TrackedObject>();
    }

	// Use this for initialization
	void Start () {
        Reset();
	}
	
	// Update is called once per frame
	void Update () {

        float dTimeScale = timeScaleRate * Time.unscaledDeltaTime;
        if (controller.gripped) { dTimeScale *= -1; }
        Time.timeScale = Mathf.Clamp01(Time.timeScale + dTimeScale);
	}

    void Reset()
    {
        Initialize();
        controller.SetDeviceIndex((int)mainObject.index);
    }
}
