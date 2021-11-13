using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] trueObjects; //в инспекторе устанавливаем правильный путь
    private GameObject[] falseObjects;
    [SerializeField] private float time = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeActive());
        time = (float)trueObjects.Length;
        Invoke("ShowFalseObjects", time);
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
            yield return new WaitForSeconds(1f);
        }                     

    }

    void ShowFalseObjects()
    {
        falseObjects = GameObject.FindGameObjectsWithTag("Square");
        foreach (GameObject obj in falseObjects)
        {
            obj.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

}
