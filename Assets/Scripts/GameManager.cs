using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("Set right way")]
    [SerializeField] private GameObject[] trueObjects;
    [Header("Set wrong way")]
    [SerializeField] private GameObject[] falseObjects;
    [Tooltip("Set start point")]
    [SerializeField] private GameObject startPoint;
    [Tooltip("Set end point")]
    [SerializeField] public GameObject endPoint;
    [SerializeField] private float pathSpeed = 1;
    //[SerializeField] private float time = 10;
    [SerializeField] private int nextStep = 0;

    void Start()
    {
        StartCoroutine(ShowTrueObjects()); 
        //time = (float)trueObjects.Length;
        Invoke("ShowFalseObjects", trueObjects.Length);
        startPoint.GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator ShowTrueObjects()
    {
        for (int i = 0; i < trueObjects.Length; i++)
        {
            trueObjects[i].GetComponent<SpriteRenderer>().enabled = true;
            trueObjects[i].GetComponent<ItemManager>().condition = true; //������������� ��������� ��� frienly square
            yield return new WaitForSeconds(pathSpeed);
        }                     
    }

    void ShowFalseObjects()
    {
        foreach (GameObject obj in falseObjects)
        {
            obj.GetComponent<SpriteRenderer>().enabled = true;
            obj.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void TruePath()
    {
        nextStep +=1; //������ �������� ��������� ������� �������
        if (nextStep < trueObjects.Length) // fix ���� ��� �� ������ ���� ������ �������
        {
            trueObjects[nextStep].GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("nextStep: " + nextStep);
        }
    }
}
