using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Dialogue : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;
    [SerializeField]
    private Control_dialogue dialogues;

    public GameObject DestroyDialogue;
 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<Control_dialogue>().StartDialogue(dialogue);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Z) && dialogues.dialogues.Count >= 0)
            {
                FindObjectOfType<Control_dialogue>().Display_new_Sentence();
            }
            
        }

    }



}
