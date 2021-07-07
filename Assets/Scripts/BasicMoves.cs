using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicMoves : MonoBehaviour
{
    Rigidbody2D Player;
    Animator Animator;
    private float horizontal1;
    private float vertical1;
    public float Horizontal1 { get { return horizontal1; } private set { horizontal1 = value; } }

    private float Velocity = 300;

    public float velocity { get{return Velocity;} set{ Velocity = value; }}
    public LayerMask PlayerCollisionWith =8;

    public bool Wallstop;


    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moves();
        MovesStop();

    }

    void Moves()
    {
        if (Velocity == 500)
        {
            horizontal1 = Input.GetAxis("Horizontal");
            vertical1 = Input.GetAxis("Vertical");
        }
            

        if (horizontal1 != 0 || vertical1 != 0)
        {
            Animator.SetBool("Walking" , true);
            Animator.SetFloat("AxisX", horizontal1);
            Animator.SetFloat("AxisY", vertical1);
            Animator.SetFloat("Velocity", Velocity);
        }
        else{
            Animator.SetFloat("Velocity", 0);
            Animator.SetBool("Walking", false);

        }


        Player.velocity = new Vector2(horizontal1 * Velocity * Time.fixedDeltaTime, vertical1 * Velocity * Time.fixedDeltaTime);

    }

   void MovesStop()
    {

        Debug.DrawRay(Player.transform.position - new Vector3(0, 0.5f, 0), new Vector3(Mathf.Round(horizontal1), Mathf.Round(vertical1)) * .6f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(Player.transform.position - new Vector3(0, 0.5f, 0), new Vector2(Mathf.Round(horizontal1), Mathf.Round(vertical1)), 0.6f, 1 << 8);


        if (hit)
        {
            Animator.SetFloat("Velocity", 0);
            Animator.SetBool("Walking", false);
        }
        else if (!hit && Player.tag != "Dialogue")
        {
            Velocity = 500;
        }

    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Wallstop = true;
        }
      
    }


    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Wallstop = false;
            Velocity = 500;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Dialogue"))
        {
            horizontal1 = 0;
            vertical1 = 0;
            Velocity = 0;
            Animator.SetFloat("Velocity", 0);
            Animator.SetBool("Walking", false);

        }
    }





}
