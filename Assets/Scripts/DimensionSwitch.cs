using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

//Class emits the dimension switch event. If you want the camera filter, you should add prefab and connect the event to it.
//Toggles objects on/off
public class DimensionSwitch : MonoBehaviour
{
    public UnityEvent dimensionSwitchEvent;

    //TODO should probably move this to some other class that keeps track of this stuff.
    List<GameObject> deactivatedObjects = new List<GameObject>();

    bool inSpirit = false;

    string currentMap = "boss";

    void Start()
    {
        dimensionSwitchEvent.AddListener(ToggleDimensionObjects);
        dimensionSwitchEvent.AddListener(SwitchPlayingMusic);

        var objectsToDeactivate = GameObject.FindGameObjectsWithTag("SpiritOnly");
        deactivatedObjects.AddRange(objectsToDeactivate);
        foreach (var obj in objectsToDeactivate)
            obj.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dimensionSwitchEvent.Invoke();
        }
    }

    void ToggleDimensionObjects()
    {
        Debug.Log("toggling Dimension Objects");

        inSpirit = !inSpirit;
        foreach (var obj in deactivatedObjects)
            obj.SetActive(true);
        deactivatedObjects.Clear();

        var objectsToDeactivate = !inSpirit ? GameObject.FindGameObjectsWithTag("SpiritOnly") : GameObject.FindGameObjectsWithTag("MaterialOnly");
        deactivatedObjects.AddRange(objectsToDeactivate);

        foreach (var obj in objectsToDeactivate)
            obj.SetActive(false);
    }

    public void UpdateCurrentMap(string name)
    {
        string[] validNames = new string[] { "tutorial", "level1", "boss" };
        if (validNames.Contains(name))
            currentMap = name;
        else
            Debug.LogWarning("Not a valid map name");
    }

    public void SwitchPlayingMusic()
    {
        if (inSpirit)
            FindObjectOfType<AudioManager>().ReplaceMusic($"{currentMap}_mat", $"{currentMap}_soul");
        else
            FindObjectOfType<AudioManager>().ReplaceMusic($"{currentMap}_soul", $"{currentMap}_mat");
    }
}
