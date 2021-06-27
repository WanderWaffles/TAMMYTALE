using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene_Controller : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            animator.SetBool("StartScene1", true);
        }
        

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            animator.SetBool("StartScene1", false);
        }
    }

}
