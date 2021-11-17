using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("Set right way")]
    [SerializeField] private GameObject[] pathObjects;
    [Header("Set wrong way")]
    private GameObject[] allObjects;
    [Tooltip("Set start point")]
    [SerializeField] private GameObject startPoint;
    [Tooltip("Set end point")]
    [SerializeField] public GameObject endPoint;
    [SerializeField] private float pathSpeed = 1;
    //[SerializeField] private float time = 10;
    private int nextStep = 0;
    public bool gameStart = false;

    void Start()
    {
        StartCoroutine(ShowPathObjects()); 
        //time = (float)pathObjects.Length;
        Invoke("ShowAllObjects", pathObjects.Length);
        startPoint.GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator ShowPathObjects()
    {
        for (int i = 0; i < pathObjects.Length; i++)
        {
            pathObjects[i].GetComponent<SpriteRenderer>().enabled = true;
            pathObjects[i].GetComponent<ItemManager>().condition = true; //устанавливаем состояние для frienly square
            yield return new WaitForSeconds(pathSpeed);
        }                     
    }

    void ShowAllObjects()
    {
        allObjects = GameObject.FindGameObjectsWithTag("Square"); // TODO
        foreach (GameObject obj in allObjects)
        {
            obj.GetComponent<SpriteRenderer>().enabled = true;
            obj.GetComponent<BoxCollider2D>().enabled = true;
            gameStart = true;
            
        }
    }

    public void TruePath()
    {
        nextStep +=1; //делаем активный следующий елемент массива
        if (nextStep < pathObjects.Length) // fix след шаг не должен быть больше массива
        {
            pathObjects[nextStep].GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("nextStep: " + nextStep);
        }
    }
}
