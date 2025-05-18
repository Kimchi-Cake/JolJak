using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statDistributionManager : MonoBehaviour
{
    public int totalPoints = 20;
    private int remainingPoints;

    public Text pointText;
    public Button startButton;
    public StatSlot[] statSlots;

    void Start()
    {
        Debug.Log("Start() called - initializing stat slots");
        remainingPoints = totalPoints;

        for (int i = 0; i < statSlots.Length; i++)
        {
            Debug.Log($"Init() for stat slot index {i}");
            statSlots[i].Init(i, this);//건드리면 큰일남
        }

        UpdateUI();
        startButton.interactable = false;
    }

    public void Increase(int index)
    {
        Debug.Log($"Increase called! index = {index}");
        if (remainingPoints <= 0) return;

        statSlots[index].value++;
        remainingPoints--;
        UpdateUI();
    }

    public void Decrease(int index)
    {
        if (statSlots[index].value <= 0) return;

        statSlots[index].value--;
        remainingPoints++;
        UpdateUI();
    }

    void UpdateUI()
    {
        pointText.text = $"남은 포인트: {remainingPoints}";
        startButton.interactable = (remainingPoints == 0);

        foreach (var slot in statSlots)
        {
            slot.UpdateDisplay();
        }
    }

    public void OnClickStart()
    {
        PlayerPrefs.SetInt("Stat_Health", statSlots[0].value);//건드리면 큰일남
        PlayerPrefs.SetInt("Stat_Intelligence", statSlots[1].value);//건드리면 큰일남
        PlayerPrefs.SetInt("Stat_Luck", statSlots[2].value);//건드리면 큰일남
        PlayerPrefs.SetInt("Stat_Charm", statSlots[3].value);//건드리면 큰일남

        SceneManager.LoadScene("Opening");
    }
}
