using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SteamVR_TrackedController))]
[RequireComponent(typeof(SteamVR_TrackedObject))]

public class MenuController : MonoBehaviour {

    SteamVR_TrackedController controller;
    SteamVR_TrackedObject mainObject;

    private void Initialize()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        mainObject = GetComponent<SteamVR_TrackedObject>();
    }

	// Use this for initialization
	void Start () {
        Reset();
	}

    void Reset()
    {
        Initialize();
        controller.SetDeviceIndex((int)mainObject.index);
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.gripped)
        {
            LevelManager.SharedInstance.ResetToFirstLevel();
            SceneManager.LoadScene("Play");
        }
    }
}
