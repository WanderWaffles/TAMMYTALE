using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar_Movement : MonoBehaviour
{
    [SerializeField]
    private BasicMoves Moves;

    [SerializeField]
    private Collider2D[] waypoints;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private bool[] Limits;

    float horizontal1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col == waypoints[0])
        {
            Limits[0] = true;
        }
        else if (col == waypoints[1])
        {
            Limits[1] = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {

        if (Moves.Horizontal1 > 0 && Moves.Wallstop == false && col.gameObject.CompareTag("Player")  && Limits[0] == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[0].transform.position, Speed * Time.deltaTime);

        }

        else if (Moves.Horizontal1 < 0 && Moves.Wallstop == false && col.gameObject.CompareTag("Player") && Limits[1] == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position, Speed * Time.deltaTime);
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col == waypoints[0])
        {
            Limits[0] = false;
        }
        else if (col == waypoints[1])
        {
            Limits[1] = false;
        }
    }

}
