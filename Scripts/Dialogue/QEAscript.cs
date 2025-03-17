using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QEAscript : MonoBehaviour
{
    public GameObject QEA;
    DialogueSystem dialogueSystem;

    void Awake()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        QEA.SetActive(false);
        
    }
    void Update()
    {
        if (dialogueSystem.flag == 1)
        {
            QEA.gameObject.SetActive(true);
        }
        else
        {
            QEA.gameObject.SetActive(false);
        }
    }
}
