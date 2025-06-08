using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour // 여기는 손대지 마셈 전부
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
        subjectStats[Semester.First].Add("실용영어", 0);
        subjectStats[Semester.First].Add("기초프로그래밍", 0);
        subjectStats[Semester.First].Add("대학생활과 진로탐색", 0);
        subjectStats[Semester.First].Add("채플", 0);
        subjectStats[Semester.First].Add("컴퓨터개론", 0);
        subjectStats[Semester.First].Add("IT창의융합", 0);
        subjectStats[Semester.First].Add("서버시스템", 0);
        subjectStats[Semester.First].Add("웹사이트제작", 0);

        subjectStats[Semester.Second].Add("인공지능개론", 0);
        subjectStats[Semester.Second].Add("행복한삶과진리", 0);
        subjectStats[Semester.Second].Add("자료구조", 0);
        subjectStats[Semester.Second].Add("웹서버구축", 0);
        subjectStats[Semester.Second].Add("디지털리터러시", 0);
        subjectStats[Semester.Second].Add("채플1", 0);
        subjectStats[Semester.Second].Add("웹스크립트", 0);
        subjectStats[Semester.Second].Add("컴퓨터네트워크", 0);
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
