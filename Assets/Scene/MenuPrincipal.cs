using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string Cena_main;
    public string Creditos;
    public string Retornar;

    public AudioSource trilha_MenuPrincipal;
    public AudioSource trilha_Gameplay_fase1;



    public void NewGame()
    {
        SceneManager.LoadScene(Cena_main);
        trilha_MenuPrincipal.Stop();
        trilha_Gameplay_fase1.Play();
    }

    public void game()
    {
        SceneManager.LoadScene(Creditos);
        trilha_MenuPrincipal.Play();
    }

    public void voltar()
    {
        SceneManager.LoadScene(Retornar);
    }

    public void Quit()
    {
        Application.Quit();
        trilha_MenuPrincipal.Stop();
    }
}
