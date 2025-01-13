using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static bool JuegaPausa = false;
    [SerializeField] GameObject pausa;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (JuegaPausa)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pausa.SetActive(false);
        Time.timeScale = 1f;
        JuegaPausa = false;
    }
    public void Pause()
    {
        pausa.SetActive(true);
        Time.timeScale = 0;
        JuegaPausa = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
