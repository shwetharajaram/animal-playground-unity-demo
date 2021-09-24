using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoundabout : MonoBehaviour
{
    public float rotationAngle; // y-rotation
    private bool rotateObject = true;

    public GameObject roundaboutFrame;
    private Dictionary<int, GameObject> animalsOnRoundabout;

    private void Start()
    {
        animalsOnRoundabout = new Dictionary<int, GameObject>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("R pressed");
            rotateObject = !rotateObject;
        }

        if (rotateObject) {  
            transform.Rotate(0, rotationAngle, 0, Space.Self);

            foreach (GameObject animal in animalsOnRoundabout.Values)
            {
                animal.transform.RotateAround(this.transform.position, Vector3.up, rotationAngle);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("animal on roundabout!");
        int instanceID = collider.gameObject.GetInstanceID();
        if (!animalsOnRoundabout.ContainsKey(instanceID))
        {
            animalsOnRoundabout.Add(instanceID, collider.gameObject);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("animal off roundabout");
        int instanceID = collider.gameObject.GetInstanceID();
        if (animalsOnRoundabout.ContainsKey(instanceID))
        {
            animalsOnRoundabout.Remove(instanceID);
        }
    }
}