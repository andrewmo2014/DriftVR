using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    private Rigidbody rb;
    public Transform head;
    public float movementSpeed;

    private void Initialize()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = head.forward;
        rb.velocity = direction * movementSpeed;
	}

    void Reset()
    {
        Initialize();
        rb.useGravity = false;
        rb.freezeRotation = true;
    }

    void OnCollisionEnter(Collision col)
    {

        string nextSceneName = SceneManager.GetActiveScene().name;

        if (col.gameObject.CompareTag("Goal"))
        {
            LevelManager.SharedInstance.AdvanceLevel();
            if (LevelManager.SharedInstance.GetCurrentLevelName() == null)
            {
                nextSceneName = "Main";
            }
        }

        SceneManager.LoadScene(nextSceneName);

    }
}
