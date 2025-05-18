using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int maxHealth;
    public int currentHealth;
    public int intelligence;
    public int luck;
    public int charm;

    public int gender;

    public int money;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadStats();
        }
        else
        {
            Destroy(gameObject);
        }
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
}
