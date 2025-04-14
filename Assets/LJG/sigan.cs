using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Subject
{
    public string subjectName;
    public int credit;

    public Subject(string name, int credit)
    {
        this.subjectName = name;
        this.credit = credit;
    }
}

public class sigan : MonoBehaviour
{
    int[,] tableScore = new int[5, 7];
    string[,] timeTable = new string[5, 7];


    public Subject a1 = new Subject("실용영어", 2);
    public Subject a2 = new Subject("기초프로그래밍", 3);
    public Subject a3 = new Subject("자료구조", 3);
    public Subject a4 = new Subject("서버시스템", 3);
    public Subject a5 = new Subject("컴퓨터개론", 3);
    public Subject a6 = new Subject("웹사이트제작", 3);
    public Subject a7 = new Subject("대학생활과 진로탐색", 1);
    public Subject a8 = new Subject("채플", 1);

    public Subject b1 = new Subject("인공지능개론", 3);
    public Subject b2= new Subject("행복한 삶과 진리", 1);
    public Subject b3 = new Subject("인공지능프로그래밍", 3);
    public Subject b4 = new Subject("웹서버구축", 3);
    public Subject b5 = new Subject("디지털리터러시", 2);
    public Subject b6 = new Subject("채플", 1);
    public Subject b7 = new Subject("", 0);
    public Subject b8 = new Subject("", 0);



    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
