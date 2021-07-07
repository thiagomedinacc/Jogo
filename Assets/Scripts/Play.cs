using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Fases");
    }

    public void Exit() {
         UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void PlayFase1()
    {
        SceneManager.LoadScene("Fase 1");
    }

    public void PlayFase2()
    {
        SceneManager.LoadScene("Fase 2");
    }

    public void PlayFase3()
    {
        SceneManager.LoadScene("Fase 3");
    }

    // Update is called once per frame
}
