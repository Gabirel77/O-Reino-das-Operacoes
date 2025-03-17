using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    int c = 1;
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }
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
            if(c==0)
            {
                Application.Quit();
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }
}
