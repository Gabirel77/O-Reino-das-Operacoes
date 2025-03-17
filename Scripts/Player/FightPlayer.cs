using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer : MonoBehaviour
{

    private Animator m_Animator;

    SpriteRenderer spriteRenderer;

    int dialogue_flag = 0;
    public Transform npc;

    DialogueSystem dialogueSystem;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        //dialogueSystem = FindObjectOfType<DialogueSystem>();
        dialogueSystem = Object.FindFirstObjectByType<DialogueSystem>();

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Abs(transform.position.x - npc.position.x) < 2.0f) && dialogue_flag == 0)
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            Invoke("Delay", 2.0f);

            dialogue_flag = 1;
            //}
        }

    }
    public void Delay()
    {
        dialogueSystem.Next();
    }
}
