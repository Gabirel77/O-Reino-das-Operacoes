using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizGameController : MonoBehaviour
{
    public Animator characterAnimator;
    public Button[] answerButtons; // Lista de botões (não apenas 2, para permitir escalabilidade)
    public TextMeshProUGUI questionText;
    public Canvas quizCanvas;
    public int playerHealth = 3;

    private int currentQuestionIndex = 0;

    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string correctAnswer;
        public string[] wrongAnswers; // Lista de respostas erradas
    }

    public List<Question> questions = new List<Question>(); // Perguntas configuráveis

    private List<string> currentAnswers = new List<string>(); // Respostas embaralhadas

    void Start()
    {
        characterAnimator.SetBool("punch_fight", false);
        characterAnimator.SetBool("damaged_fight", false);

        SetupQuestion();
    }

    void SetupQuestion()
    {
        // Configura pergunta e embaralha as respostas
        Question currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.questionText;

        currentAnswers.Clear();
        currentAnswers.Add(currentQuestion.correctAnswer);
        currentAnswers.AddRange(currentQuestion.wrongAnswers);
        ShuffleAnswers(currentAnswers);

        // Atribuir respostas aos botões
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentAnswers[i];

            // Remover os listeners anteriores e adicionar novos
            answerButtons[i].onClick.RemoveAllListeners();

            if (currentAnswers[i] == currentQuestion.correctAnswer)
                answerButtons[i].onClick.AddListener(HandleCorrectAnswer);
            else
                answerButtons[i].onClick.AddListener(HandleWrongAnswer);
        }
    }

    void HandleCorrectAnswer()
    {
        characterAnimator.SetBool("punch_fight", true);
        Invoke("NextQuestion", 0.5f);
    }

    void HandleWrongAnswer()
    {
        playerHealth--;
        characterAnimator.SetBool("damaged_fight", true);

        if (playerHealth <= 0)
        {
            Debug.Log("Game Over");
            Invoke("GameOver", 1);
            // lógica de Game Over aqui, como reiniciar o jogo ou terminar
        }

        Invoke("FinishDamageAnimation", 0.8f);
    }
    void GameOver()
    {
        SceneManager.LoadScene("GAMEOVER");
    }
    void NextQuestion()
    {
        characterAnimator.SetBool("punch_fight", false);
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            SetupQuestion();
        }
        else
        {
            StartCoroutine(EndQuizWithDelay());
        }
    }

    void FinishDamageAnimation()
    {
        characterAnimator.SetBool("damaged_fight", false);
    }

    IEnumerator EndQuizWithDelay()
    {
        quizCanvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Tabuleiro"); // Troque "Tabuleiro" pela sua cena de destino
    }

    // Função para embaralhar as respostas
    void ShuffleAnswers(List<string> answers)
    {
        for (int i = 0; i < answers.Count; i++)
        {
            string temp = answers[i];
            int randomIndex = Random.Range(0, answers.Count);
            answers[i] = answers[randomIndex];
            answers[randomIndex] = temp;
        }
    }
}
