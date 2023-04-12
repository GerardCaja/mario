using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isGameOver;

    public Text coinText;

    int coins;
  

    public void GameOver()
    {
        isGameOver = true;

        // Llamar funcion de forma normal
        // LoadScene();

        // invocamos la funcion despues de 1.5 segundos
        //Invoke("LoadScene", 2.5f);

        //Llamamos la corutina LoadScene
        StartCoroutine("LoadScene");
    }

    /*void LoadScene()
    {
        SceneManager.LoadScene(2);
    }*/

    IEnumerator LoadScene()
    {
        //Esto para la corutina durante 2.5 segundos
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(2);
    }

    public void AddCoin()
    {
        coins++;
        coinText.text = coins.ToString();
    }
}
