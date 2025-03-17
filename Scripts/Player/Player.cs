using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator m_Animator;

    SpriteRenderer spriteRenderer;
    private float fixedZ = -7f;
    int dialogue_flag = 0;
    public Sprite idle;
    public Sprite running;

    public Transform npc;

    DialogueSystem dialogueSystem;

    public float speed = 7f;

    Vector2 velocity = Vector2.zero;
    Vector2 velocity2 = Vector2.zero;
    private void Awake()
    {
        m_Animator= GetComponent<Animator>();
        //dialogueSystem = FindObjectOfType<DialogueSystem>();
        dialogueSystem = Object.FindFirstObjectByType<DialogueSystem>();

        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Start()
    {
        // Define o valor fixo do eixo Z no início
        Vector3 position = transform.position;
        position.z = fixedZ;
        transform.position = position;
    }
    void Update()
    {
            // Mantém o valor fixo de Z durante todo o jogo
            Vector3 position = transform.position;
            position.z = fixedZ;
            transform.position = position;
        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");

        if (m_Animator != null)
        {
            if (velocity != Vector2.zero)
            {
                m_Animator.SetBool("Run_Up", false);
                m_Animator.SetBool("Run_Down", false);
                m_Animator.SetBool("Run", true);
            }
            else
            {
                m_Animator.SetBool("Run", false);
            }
            if (inputx < 0)
                spriteRenderer.flipX = true;
            if (inputx > 0)
                spriteRenderer.flipX = false;
            if(velocity2.y > 0)
            {
                m_Animator.SetBool("Run_Down", false);
                m_Animator.SetBool("Run_Up", true);
            }
            else if (velocity2.y < 0)
            {
                m_Animator.SetBool("Run_Up", false);
                m_Animator.SetBool("Run_Down", true);
            }
            else
            {
                m_Animator.SetBool("Run_Up", false);
                m_Animator.SetBool("Run_Down", false);
            }

            velocity = speed * inputx * Vector2.right;
            velocity2 = speed * inputy * Vector2.up;

            if (velocity.sqrMagnitude > 0 || velocity2.sqrMagnitude > 0)
            {
                spriteRenderer.sprite = running;
            }
            else
            {
                spriteRenderer.sprite = idle;
            }

            transform.position += (Vector3)velocity * Time.deltaTime;
            transform.position += (Vector3)velocity2 * Time.deltaTime;
        }
        if ((Mathf.Abs(transform.position.x - npc.position.x) < 2.0f)&&dialogue_flag==0)
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            Invoke("Delay", 2.0f);
            
            dialogue_flag=1;
            //}
        }

    }
    public void Delay()
    {
        dialogueSystem.Next();
    }

}
