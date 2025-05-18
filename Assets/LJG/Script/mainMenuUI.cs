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
        // 저장된 데이터 불러오기
    }

    public void OnSettingsClicked()
    {
        // 설정 메뉴
        Debug.Log("설정 메뉴 열기");
    }
}
