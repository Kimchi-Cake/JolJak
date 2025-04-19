using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class courseManager : MonoBehaviour
{
    public static courseManager Instance;

    public GameObject courseBlockPrefab;
    public Transform courseBlockParent;

    public int maxCost = 25;          
    public int currentCost = 0;

    public List<courseData> courseList = new List<courseData>();

    void Awake()
    {
        Instance = this; 
    }

    void Start()
    {
        courseList.Add(new courseData("�ڷᱸ��", 2, Color.green));
        courseList.Add(new courseData("�����α׷���", 3, Color.cyan));
        courseList.Add(new courseData("����ȸȭ", 1, Color.yellow));

        foreach (var course in courseList)
        {
            GameObject block = Instantiate(courseBlockPrefab, courseBlockParent);
            block.GetComponent<courseBlockScript>().Init(course);
        }
    }

    public void AddCost(int cost)
    {
        currentCost += cost;
    }

    public bool CanAfford(int cost)
    {
        return currentCost + cost <= maxCost;
    }
}