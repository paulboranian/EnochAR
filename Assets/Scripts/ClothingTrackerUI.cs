using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingTrackerUI : MonoBehaviour
{
    public Button enterClosetButton;
    public Button toggleClothing;
    public GameObject welcomeScreen;
    private List<Material> BodyMaterials = new List<Material>();

    private void Awake()
    {

        enterClosetButton.onClick.AddListener(Dismiss);
        toggleClothing.onClick.AddListener(ToggleClothing);

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Dismiss() => welcomeScreen.SetActive(false);

    private void ToggleClothing()
    {

       

    }

    private void ApplyClothing()
    {



    }

}
