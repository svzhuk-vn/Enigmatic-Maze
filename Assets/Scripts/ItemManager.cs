using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public bool condition;
    public GameManager gameManager;
    public GameObject endPath;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        endPath = gameManager.endPoint;
    }

    // Update is called once per frame
    void Update()

    {
        
    }

    private void OnMouseDown()
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
        }

        if (this.name == endPath.name)
        {
            Debug.Log(">>>YouWIn<<<");
        }
    }
}
