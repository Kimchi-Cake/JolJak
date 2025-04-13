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
            { "�ǿ뿵��", 0f },
            { "�������α׷���", 0f },
            { "�ڷᱸ��", 0f },
            { "�����ý���", 0f },
            { "��ǻ�Ͱ���", 0f },
            { "������Ʈ����", 0f },
            { "���л�Ȱ�� ���� Ž��", 0f },
            { "ä��", 0f }
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
            Debug.LogWarning($"���� '{subject}'�� �������� �ʽ��ϴ�.");
        }
    }

    public float GetGrade(string subject)
    {
        if (subjectGrades.ContainsKey(subject))
        {
            return subjectGrades[subject];
        }
        Debug.LogWarning($"���� '{subject}'�� �������� �ʽ��ϴ�.");
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
                Debug.LogWarning($"'{statName}'�� �������� �ʴ� �����Դϴ�.");
                break;
        }
    }
}
