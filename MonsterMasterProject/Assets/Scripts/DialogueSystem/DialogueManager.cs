using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[]audioClip;
    public TMP_Text nameBox;
    public TMP_Text dialogueBox;
    private Queue<string> speakers;
    private Queue<string> sentences;
    private string currentSpeaker;
    private string sentence;
    public GameObject dialogArea;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>(); 
        speakers = new Queue<string>();
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        speakers.Clear();
        sentences.Clear();
        foreach (string name in dialogue.names)
        {
            speakers.Enqueue(name);
        }
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            dialogArea.gameObject.SetActive(false);
            return;
        }
        currentSpeaker = speakers.Dequeue();
        nameBox.text = currentSpeaker;
        sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }

    IEnumerator TypeSentence(string sentence)
    {
        getSpeakerVoice();
        audiosource.Play();
        dialogueBox.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
      
            dialogueBox.text += letter;
            yield return null;
            
        }
        audiosource.Stop();
    }

    //Change this for characters in different games
    void getSpeakerVoice()
    {
        switch (nameBox.text)
        {
            case "Nottali":
                audiosource.clip = audioClip[0];
                break;
        }
    }

}
