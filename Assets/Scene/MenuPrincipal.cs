using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string Cena_main;
    public string Creditos;
    public string Retornar;


    public void NewGame()
    {
        SceneManager.LoadScene(Cena_main);
    }

    public void game()
    {
        SceneManager.LoadScene(Creditos);
    }

    public void voltar()
    {
        SceneManager.LoadScene(Retornar);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
