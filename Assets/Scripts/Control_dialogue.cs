using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Control_dialogue: MonoBehaviour 
{
    public TextMeshProUGUI Name_text;
    public TextMeshProUGUI Dialogue_text;
    public Animator animatordialogue;
    public Animator animatorface;

    private Queue<string> Dialogues;

    public Queue<string> dialogues { get { return Dialogues; } private set { Dialogues = value; } }

    public AudioClip sound;
    public AudioSource audiosource;

    public GameObject DestroyDialogue;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        Dialogues = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animatordialogue.SetBool("IsOpen", true);
        animatorface.SetBool("ShowFace", true);
        
        Name_text.text = dialogue.name;

        Dialogues.Clear();

        foreach (string sentence in dialogue.Sentences)
        {
            Dialogues.Enqueue(sentence);
        }
          
    }

    public void Display_new_Sentence()
    {
        if (Dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }
        

        string sentence = Dialogues.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence (string sentence)
    {
        
        Dialogue_text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            animatorface.SetBool("Talking", true);
            audiosource.PlayOneShot(sound);
            Dialogue_text.text += letter;
            yield return null;

        }
        animatorface.SetBool("Talking", false);
    }

    public void EndDialogue()
    {
        animatorface.SetBool("ShowFace", false);
        animatorface.SetBool("Talking", false);
        animatordialogue.SetBool("IsOpen", false);
        Name_text.ClearMesh();
        Dialogue_text.ClearMesh();
        
    }





}
