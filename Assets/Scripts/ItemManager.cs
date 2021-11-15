using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemManager : MonoBehaviour
{
    [SerializeField] public bool condition;
    GameManager gameManager;
    GameObject endPath;
    LevelManager levelManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        endPath = gameManager.endPoint;
    }

    private void OnMouseEnter() //OnMouseEnter works fine
    {
        if (condition && gameManager.gameStart)
        {
            Debug.Log("True path!");
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
            gameManager.TruePath();
            this.condition = false;
            this.GetComponent<BoxCollider2D>().enabled = false; //fix только одно нажатие на кнопку
        }

        else if (!condition && gameManager.gameStart)
        {
            Debug.Log("False path!");
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
            levelManager.Restart();
        }

        if (this.name == endPath.name)
        {
            Debug.Log(">>>YouWIn<<<");
            levelManager.nextLevel += 1;
            levelManager.NextLevel(levelManager.nextLevel);
        }
    }
}
