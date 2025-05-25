using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour // ����� �մ��� ���� ����
{
    public static PlayerStats Instance;

    public int maxHealth;
    public int currentHealth;
    public int intelligence;
    public int luck;
    public int charm;

    public int gender;

    public int money;


    public enum Semester
    {
        First,
        Second
    }

    public Semester currentSemester = Semester.First;

    public Dictionary<Semester, Dictionary<string, int>> subjectStats = new Dictionary<Semester, Dictionary<string, int>>()
    {
        { Semester.First, new Dictionary<string, int>() },
        { Semester.Second, new Dictionary<string, int>() }
    };

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitSubjectStats();
            LoadStats();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitSubjectStats()
    {
        subjectStats[Semester.First].Add("�ǿ뿵��", 0);
        subjectStats[Semester.First].Add("�������α׷���", 0);
        subjectStats[Semester.First].Add("���л�Ȱ�� ����Ž��", 0);
        subjectStats[Semester.First].Add("ä��", 0);
        subjectStats[Semester.First].Add("��ǻ�Ͱ���", 0);
        subjectStats[Semester.First].Add("ITâ������", 0);
        subjectStats[Semester.First].Add("�����ý���", 0);
        subjectStats[Semester.First].Add("������Ʈ����", 0);

        subjectStats[Semester.Second].Add("�ΰ����ɰ���", 0);
        subjectStats[Semester.Second].Add("�ູ�ѻ������", 0);
        subjectStats[Semester.Second].Add("�ڷᱸ��", 0);
        subjectStats[Semester.Second].Add("����������", 0);
        subjectStats[Semester.Second].Add("�����и��ͷ���", 0);
        subjectStats[Semester.Second].Add("ä��1", 0);
        subjectStats[Semester.Second].Add("����ũ��Ʈ", 0);
        subjectStats[Semester.Second].Add("��ǻ�ͳ�Ʈ��ũ", 0);
    }

    public void AddSubjectStat(string subject, int amount)
    {
        if (subjectStats[currentSemester].ContainsKey(subject))
            subjectStats[currentSemester][subject] += amount;
    }

    public void LoadStats()
    {
        gender = PlayerPrefs.GetInt("Gender", 0);

        maxHealth = PlayerPrefs.GetInt("Stat_Health", 0);
        intelligence = PlayerPrefs.GetInt("Stat_Intelligence", 0);
        luck = PlayerPrefs.GetInt("Stat_Luck", 0);
        charm = PlayerPrefs.GetInt("Stat_Charm", 0);

        currentHealth = maxHealth;
        money = 0;
    }

    public void SaveStats()
    {
        PlayerPrefs.SetInt("Gender", gender);

        PlayerPrefs.SetInt("Stat_Health", maxHealth);
        PlayerPrefs.SetInt("Stat_Intelligence", intelligence);
        PlayerPrefs.SetInt("Stat_Luck", luck);
        PlayerPrefs.SetInt("Stat_Charm", charm);
        PlayerPrefs.Save();
    }

    public void LoadSubjectStats()
    {
        foreach (var sem in subjectStats)
        {
            var keys = new List<string>(sem.Value.Keys);
            foreach (var key in keys)
            {
                int val = PlayerPrefs.GetInt($"SubStat_{sem.Key}_{key}", 0);
                subjectStats[sem.Key][key] = val;
            }
        }
    }

    public void SaveSubjectStats()
    {
        foreach (var sem in subjectStats)
        {
            foreach (var subject in sem.Value)
            {
                PlayerPrefs.SetInt($"SubStat_{sem.Key}_{subject.Key}", subject.Value);
            }
        }
    }
}
