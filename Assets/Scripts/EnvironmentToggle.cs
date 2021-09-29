using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentToggle : MonoBehaviour
{
    public Material earthSkybox, moonSkybox, marsSkybox;
    public GameObject earthEnvironment, moonEnvironment, marsEnvironment;
    public GameObject[] spaceHelmets;

    public void ShowEarth()
    {
        Debug.Log("Showing Earth environment");

        RenderSettings.skybox = earthSkybox;

        earthEnvironment.SetActive(true);
        moonEnvironment.SetActive(false);
        marsEnvironment.SetActive(false);

        Physics.gravity = new Vector3(0, -9.807f, 0);

        foreach (GameObject go in spaceHelmets) {
            go.SetActive(false);
        }
    }

    public void ShowMoon()
    {
        Debug.Log("Showing Moon environment");
       
        RenderSettings.skybox = moonSkybox;

        moonEnvironment.SetActive(true);
        earthEnvironment.SetActive(false);
        marsEnvironment.SetActive(false);

        Physics.gravity = new Vector3(0, -1.62f, 0);

        foreach (GameObject go in spaceHelmets)
        {
            go.SetActive(true);
        }
    }

    public void ShowMars()
    {
        Debug.Log("Showing Mars environment");

        RenderSettings.skybox = marsSkybox;

        marsEnvironment.SetActive(true);
        moonEnvironment.SetActive(false);
        earthEnvironment.SetActive(false);

        Physics.gravity = new Vector3(0, -3.711f, 0);

        foreach (GameObject go in spaceHelmets)
        {
            go.SetActive(true);
        }
    }
}
