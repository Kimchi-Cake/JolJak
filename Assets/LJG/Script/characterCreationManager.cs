using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterCreationManager : MonoBehaviour
{
    [Header("ĳ����")]//�ǵ帮�� ū�ϳ� 
    public Transform maleChar;
    public Transform femaleChar;

    [Header("��ġ")]//�ǵ帮�� ū�ϳ�
    public Vector3 frontPos;
    public Vector3 maleBackPos;
    public Vector3 femaleBackPos;

    [Header("����")]//�ǵ帮�� ū�ϳ�
    public Light maleLight;
    public Light femaleLight;

    [Header("UI")]//�ǵ帮�� ū�ϳ�
    public Toggle toggleMale;
    public Toggle toggleFemale;
    public Button startButton;

    private int selectedGender = -1; //�ǵ帮�� ū�ϳ�

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
        PlayerPrefs.SetInt("Gender", selectedGender);//�ǵ帮�� ū�ϳ�
        SceneManager.LoadScene("StatDistribution");
    }
}
