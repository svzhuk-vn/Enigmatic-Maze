using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public int nextLevel = 0;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
