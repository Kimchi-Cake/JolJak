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


    public Subject a1 = new Subject("�ǿ뿵��", 2);
    public Subject a2 = new Subject("�������α׷���", 3);
    public Subject a3 = new Subject("�ڷᱸ��", 3);
    public Subject a4 = new Subject("�����ý���", 3);
    public Subject a5 = new Subject("��ǻ�Ͱ���", 3);
    public Subject a6 = new Subject("������Ʈ����", 3);
    public Subject a7 = new Subject("���л�Ȱ�� ����Ž��", 1);
    public Subject a8 = new Subject("ä��", 1);

    public Subject b1 = new Subject("�ΰ����ɰ���", 3);
    public Subject b2= new Subject("�ູ�� ��� ����", 1);
    public Subject b3 = new Subject("�ΰ��������α׷���", 3);
    public Subject b4 = new Subject("����������", 3);
    public Subject b5 = new Subject("�����и��ͷ���", 2);
    public Subject b6 = new Subject("ä��", 1);
    public Subject b7 = new Subject("", 0);
    public Subject b8 = new Subject("", 0);



    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
