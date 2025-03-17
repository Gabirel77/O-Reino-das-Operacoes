using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    [SerializeField] Animator transitionAnim;
    private int i = 0;
    private bool isLoading = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        if (!isLoading) // Previne m�ltiplas chamadas simult�neas
        {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        isLoading = true;

        // Inicia a anima��o de transi��o
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);

        // Incrementa o �ndice da cena e limita ao intervalo
        i = Mathf.Clamp(i + 1, 0, 8);
        Debug.Log("Carregando cena: " + i);

        string sceneName = GetSceneNameByIndex(i);
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Carrega a cena de forma ass�ncrona
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            while (!operation.isDone)
            {
                yield return null; // Espera at� o carregamento concluir
            }

            // Transi��o de in�cio ap�s o carregamento
            transitionAnim.SetTrigger("Start");
        }

        // Reseta `isLoading` ao final
        isLoading = false;
    }

    private string GetSceneNameByIndex(int index)
    {
        switch (index)
        {
            case 1: return "Tabuleiro";
            case 2: return "Fase1";
            case 3: return "Fase2";
            case 4: return "Fase3";
            case 5: return "Fase4";
            case 6: return "Fase5";
            case 7: return "FIM";
            case 8:
                i = 0; // Reseta ao voltar ao menu
                return "Menu";
            default:
                Debug.LogWarning("�ndice de cena inv�lido: " + index);  
                return null;
        }
    }
}