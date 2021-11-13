using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    [Header("Set right way")]
    public GameObject[] trueObjects; //в инспекторе устанавливаем friendly path
    [Header("Set wrong way")]
    public GameObject[] falseObjects; //в инспекторе устанавливаем enemy
    public GameObject startPoint;
    public GameObject endPoint;
    [SerializeField] private float time = 10;
    [SerializeField] private int nextStep = 0;
    //private ItemManager script;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeActive()); 
        time = (float)trueObjects.Length;
        Invoke("ShowFalseObjects", time);
        //trueObjects[0].GetComponent<BoxCollider2D>().enabled = true; //start point
        startPoint.GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator ChangeActive()
    {
        /*foreach (GameObject trueObject in gameObjects)
        {
            trueObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
        }*/

        for (int i = 0; i < trueObjects.Length; i++)
        {
            //gameObjects[i].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
            //trueObjects[i].SetActive(true);
            trueObjects[i].GetComponent<SpriteRenderer>().enabled = true;
            trueObjects[i].GetComponent<ItemManager>().condition = true; //устанавливаем состояние для frienly square
            yield return new WaitForSeconds(1f);
        }                     

    }

    void ShowFalseObjects()
    {
        //falseObjects = GameObject.FindGameObjectsWithTag("Square");
        foreach (GameObject obj in falseObjects)
        {
            obj.GetComponent<SpriteRenderer>().enabled = true;
            obj.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void TruePath()
    {
        nextStep +=1; //делаем активный следующий елемент массива
        if (nextStep < trueObjects.Length) // fix след шаг не должен быть больше массива
        {
            trueObjects[nextStep].GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("nextStep: " + nextStep);
        }
    }

}
