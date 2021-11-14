using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemManager : MonoBehaviour
{

    public bool condition;
    GameManager gameManager;
    GameObject endPath;
    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        levelManager = GameObject.Find("GameManager").GetComponent<LevelManager>();
        endPath = gameManager.endPoint;
    }

    // Update is called once per frame
    void Update()

    {
        
    }

    private void OnMouseDown() //OnMouseEnter works fine
    {
        if (condition)
        {
            Debug.Log("True path!");
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
            gameManager.TruePath();
            this.condition = false;
            this.GetComponent<BoxCollider2D>().enabled = false; //fix только одно нажатие на кнопку
        }

        else if (!condition)
        {
            Debug.Log("False path!");
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
            levelManager.Restart();
        }

        if (this.name == endPath.name)
        {
            Debug.Log(">>>YouWIn<<<");
            levelManager.NextLevel(0);
        }
    }
}
