using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatManager : MonoBehaviour
{
    public int health = 100;
    public int intelligence = 10;
    public int luck = 10;
    public int charm = 10;

    public int money = 0;

    public Dictionary<string, float> subjectGrades;

    private void Awake()
    {
        subjectGrades = new Dictionary<string, float>()
        {
            { "실용영어", 0f },
            { "기초프로그래밍", 0f },
            { "자료구조", 0f },
            { "서버시스템", 0f },
            { "컴퓨터개론", 0f },
            { "웹사이트제작", 0f },
            { "대학생활과 진로 탐색", 0f },
            { "채플", 0f }
        };
    }

    public void SetGrade(string subject, float score)
    {
        if (subjectGrades.ContainsKey(subject))
        {
            subjectGrades[subject] = Mathf.Clamp(score, 0f, 100f);
        }
        else
        {
            Debug.LogWarning($"과목 '{subject}'는 존재하지 않습니다.");
        }
    }

    public float GetGrade(string subject)
    {
        if (subjectGrades.ContainsKey(subject))
        {
            return subjectGrades[subject];
        }
        Debug.LogWarning($"과목 '{subject}'는 존재하지 않습니다.");
        return -1f;
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            return true;
        }
        return false;
    }

    public void IncreaseStat(string statName, int value)
    {
        switch (statName.ToLower())
        {
            case "health":
                health += value;
                break;
            case "intelligence":
                intelligence += value;
                break;
            case "luck":
                luck += value;
                break;
            case "charm":
                charm += value;
                break;
            default:
                Debug.LogWarning($"'{statName}'는 존재하지 않는 스탯입니다.");
                break;
        }
    }
}
