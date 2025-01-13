using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()

    {
        //SceneManager.LoadScene "NumeroEscenaX" también valdría, pero ahora utilizamos uno que cargue directamente la siguiente escenaa en cola
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 1);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
