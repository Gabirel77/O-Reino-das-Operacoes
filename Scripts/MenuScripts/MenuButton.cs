using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    public string cena;
    int c = 1;

    /*public IEnumerator LoadScene(string cena)
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(cena);
    }*///-> desnecessário se usarmos a função next level 
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            c = 1;
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("pressed", true);
                c = 0;
            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
                c = 1;
            }
            if(thisIndex==0 && c==0)
            {
                //StartCoroutine(LoadScene(cena)); -> jeito anterior de trocar de cena
                SceneController.instance.NextLevel(); //chama a função dentro do scene controller
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }
}
    