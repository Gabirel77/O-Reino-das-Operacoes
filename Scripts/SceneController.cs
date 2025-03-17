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
        if (!isLoading) // Previne múltiplas chamadas simultâneas
        {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        isLoading = true;

        // Inicia a animação de transição
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);

        // Incrementa o índice da cena e limita ao intervalo
        i = Mathf.Clamp(i + 1, 0, 8);
        Debug.Log("Carregando cena: " + i);

        string sceneName = GetSceneNameByIndex(i);
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Carrega a cena de forma assíncrona
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            while (!operation.isDone)
            {
                yield return null; // Espera até o carregamento concluir
            }

            // Transição de início após o carregamento
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
                Debug.LogWarning("Índice de cena inválido: " + index);  
                return null;
        }
    }
}