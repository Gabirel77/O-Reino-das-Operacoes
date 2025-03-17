using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase1 : MonoBehaviour
{
    public Transform player;
    public string cena;

    private void Start()
    {      

        // Verifica se a fase j� foi conclu�da
        if (PlayerPrefs.GetInt(cena, 0) == 1)
        {
            gameObject.SetActive(false); // Desativa o trigger se a fase j� foi conclu�da
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerPrefs.GetInt(cena, 0) == 0)
        {
            SceneController.instance.NextLevel();

            // Marca a fase como conclu�da
            PlayerPrefs.SetInt(cena, 1);
            PlayerPrefs.Save(); // Garante que os dados sejam salvos
        }
    }
}