using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public static GameTimeManager Instance;

    public int currentDay = 1;
    public int currentHour = 6;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void AdvanceTime(int hours)
    {
        currentHour += hours;
        if (currentHour >= 24)
        {
            currentHour -= 24;
            currentDay++;
        }
    }

    public string GetCurrentSeason()
    {
        if (currentDay <= 30) return "��";
        if (currentDay <= 60) return "����";
        if (currentDay <= 90) return "����";
        return "�ܿ�";
    }

    public int GetCurrentSemester()
    {
        string season = GetCurrentSeason();
        return (season == "��" || season == "����") ? 1 : 2;
    }

    public string GetDisplayText()
    {
        return $"Day {currentDay} - {currentHour}:00 - {GetCurrentSeason()} / {GetCurrentSemester()}�б�";
    }
}
