using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    public string cena;

    public void LoadScene(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
