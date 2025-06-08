using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterCreationManager : MonoBehaviour
{
    [Header("캐릭터")]//건드리면 큰일남 
    public Transform maleChar;
    public Transform femaleChar;

    [Header("위치")]//건드리면 큰일남
    public Vector3 frontPos;
    public Vector3 maleBackPos;
    public Vector3 femaleBackPos;

    [Header("조명")]//건드리면 큰일남
    public Light maleLight;
    public Light femaleLight;

    [Header("UI")]//건드리면 큰일남
    public Toggle toggleMale;
    public Toggle toggleFemale;
    public Button startButton;

    private int selectedGender = -1; //건드리면 큰일남

    void Start()
    {
        startButton.interactable = false;


        maleChar.position = maleBackPos;
        femaleChar.position = femaleBackPos;

        maleLight.intensity = 0.4f;
        femaleLight.intensity = 0.4f;
    }

    public void OnToggleMale(bool isOn)
    {
        if (!isOn) return;

        selectedGender = 0;
        maleChar.position = frontPos;
        femaleChar.position = femaleBackPos;
        maleLight.intensity = 1.2f;
        femaleLight.intensity = 0.4f;
        startButton.interactable = true;
    }

    public void OnToggleFemale(bool isOn)
    {
        if (!isOn) return;

        selectedGender = 1;
        femaleChar.position = frontPos;
        maleChar.position = maleBackPos;
        femaleLight.intensity = 1.2f;
        maleLight.intensity = 0.4f;
        startButton.interactable = true;
    }

    public void OnClickStart()
    {
        if (selectedGender == -1) return;
        PlayerPrefs.SetInt("Gender", selectedGender);//건드리면 큰일남
        SceneManager.LoadScene("StatDistribution");
    }
}
