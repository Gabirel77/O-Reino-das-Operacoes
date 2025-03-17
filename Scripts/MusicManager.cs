using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance; // Singleton

    private AudioSource audioSource;

    // Array ou lista para m�sicas espec�ficas de cada cena
    public AudioClip[] sceneMusic; // Adicione m�sicas no Inspector
    private string currentScene;

    private void Awake()
    {
        // Implementa��o do Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Toca a m�sica inicial da cena atual
        ChangeMusicByScene();
    }

    private void OnEnable()
    {
        // Escuta mudan�as de cena
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Remove a escuta
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        ChangeMusicByScene();
    }

    private void ChangeMusicByScene()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (sceneName != currentScene)
        {
            currentScene = sceneName;

            // Associe m�sicas espec�ficas �s cenas
            switch (sceneName)
            {
                case "Menu":
                    PlayMusic(sceneMusic[0]); // M�sicas adicionadas na ordem no Inspector
                    break;
                case "Tabuleiro":
                    PlayMusic(sceneMusic[0]);
                    break;
                case "Fase1":
                    PlayMusic(sceneMusic[1]);
                    break;
                case "Fase2":
                    PlayMusic(sceneMusic[1]);
                    break;
                case "Fase3":
                    PlayMusic(sceneMusic[1]);
                    break;
                case "Fase4":
                    PlayMusic(sceneMusic[1]);
                    break;
                case "Fase5":
                    PlayMusic(sceneMusic[1]);
                    break;
                case "FIM":
                    PlayMusic(sceneMusic[1]);
                    break;
                default:
                    PlayMusic(null); // Sem m�sica
                    break;
            }
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null && audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }
        else if (clip == null)
        {
            audioSource.Stop();
        }
    }
}
