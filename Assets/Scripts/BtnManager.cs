using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void LoadRankingScene()
    {
        SceneManager.LoadScene("Ranking");
    }
}
