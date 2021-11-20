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
    SoundManager soundManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        endPath = gameManager.endPoint;
    }

    private void OnMouseDown() //OnMouseEnter works fine
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
            //levelManager.Restart();
            gameManager.gameStart = false;
            gameManager.textRestart.gameObject.SetActive(true);
            soundManager.PlaySound(soundManager.loseSound);
            StartCoroutine(levelManager.Restart(3f));
        }

        if (this.name == endPath.name)
        {
            Debug.Log("YouWin!");
            soundManager.PlaySound(soundManager.winSound);
            levelManager.nextLevel += 1;
            levelManager.NextLevel(levelManager.nextLevel);
        }
    }
}
