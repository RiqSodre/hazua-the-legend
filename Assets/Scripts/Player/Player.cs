using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Floats
    public float hazua_Speed = 10f;    //Determina o quão rápido ele pode andar no eixo X.
    public float jumpForce = 830f;     //Determinando a força do pulo.
    public float groundRadius = 0.2f;  //Cria um raio de 0.2f em volta do Hazua.

    //Booleans
    bool hazua_FacingR = true;         //Determina a direção em que Hazua está olhando.
    bool grounded = false;             //Várivael que verifica se está pisando em solo.
    public bool doubleJump = false;           //Váriavel booleana para o pulo duplo.
    
    //References
    private Animator hazua_Animator;   //Referenciando o componente de animação do Hazua.
    private Rigidbody2D hazua_Rigid;   //Referenciando o componente de Rigidbody2d.

    //Sounds
    public AudioClip jumpSound;
    public AudioClip deathSound;

    public Transform groundCheck;      //Verifica se é realmente um chão.
    public LayerMask whatIsGround;     //Cria uma camada para saber o que é chão. 
    public GameObject DeathUI;

    void Awake()
    {
        transform.tag = "Player";                  //Setando a tag Player ao iniciar.
        hazua_Animator = GetComponent<Animator>(); //Instanciando a váriavel com o componente Animator.
        hazua_Rigid = GetComponent<Rigidbody2D>(); //Instanciando a váriavel com o componente Rigidbody.

        DeathUI.SetActive(false);
    }

    void Start()
    { }

    void FixedUpdate()
    {
        if (grounded)
        {
            doubleJump = false;
        }

        hazua_Animator.SetBool("Jump", !grounded); //pulo


        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        hazua_Animator.SetBool("Ground", grounded);

        float speed = Input.GetAxis("Horizontal");
        hazua_Animator.SetFloat("Speed", Mathf.Abs(speed));
        hazua_Rigid.velocity = new Vector2(speed * hazua_Speed, hazua_Rigid.velocity.y);
        if (speed > 0 && !hazua_FacingR)
        {
            Flip();
        }
        else if (speed < 0 && hazua_FacingR)
        {
            Flip();
        }
    }

    //Função criada para virar o personagem
    void Flip()
    {
        hazua_FacingR = !hazua_FacingR;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update()
    {
        if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            hazua_Animator.SetBool("Ground", false);            //Determinando que o Hazua não está no chão.
            hazua_Rigid.AddForce(new Vector2(0, jumpForce));    //Adicionando uma força para o pulo.
            SoundManager.instance.PlaySingle(jumpSound);

            if (!doubleJump && !grounded)
            {
                SoundManager.instance.PlaySingle(jumpSound);
                doubleJump = true;
            }
        }

        if(GameControl.health <= 0)
        {
            SoundManager.instance.PlaySingle(deathSound);
            hazua_Animator.SetBool("Dead", true);
            DeathUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
