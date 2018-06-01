using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    //References
    private Rigidbody2D e_Rigidbody;
    private Transform e_Transform;
    //private Animator enemy_Animator;
    public Transform GroundCheck;
    public Transform WallCheck;

    //Booleans
    private bool isWall;
    private bool isGround;
    private bool facingRight;

    //Floats
    public float speed;
    public float radiusGround;
    public float radiusWall;

    public LayerMask solid;

    public int curHealth;
    public int maxHelath = 100;

	void Awake() {
        e_Rigidbody = GetComponent<Rigidbody2D>();
        e_Transform = GetComponent<Transform>();
        //enemy_Animator = GetComponent<Animator>();

        facingRight = true;
        curHealth = maxHelath;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        EnemyMovements();
	}


    void EnemyMovements()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, radiusGround, solid);
        isWall = Physics2D.OverlapCircle(WallCheck.position, radiusWall, solid);

        if((!isGround || isWall) && facingRight)
        {
            Flip();
        }
        else if((!isGround || isWall) && !facingRight)
        {
            Flip();
        }

        if (isGround)
        {
            e_Rigidbody.velocity = new Vector2(speed, e_Rigidbody.velocity.y);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        e_Transform.localScale = new Vector2(-e_Transform.localScale.x, e_Transform.localScale.y);

        speed *= -1;
    }

    public void  Damage(int damage)
    {
        curHealth -= damage;
    }

    private void Update()
    {
        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
