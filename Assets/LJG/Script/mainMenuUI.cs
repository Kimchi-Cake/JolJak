using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuUI : MonoBehaviour
{
    public void OnNewGameClicked()
    {
        SceneManager.LoadScene("CharacterCreation");
    }

    public void OnContinueClicked()
    {
        // ����� ������ �ҷ�����
    }

    public void OnSettingsClicked()
    {
        // ���� �޴�
        Debug.Log("���� �޴� ����");
    }
}
