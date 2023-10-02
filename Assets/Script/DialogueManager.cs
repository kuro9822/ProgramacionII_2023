using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public enum EXPRESSION
{
    NEUTRAL, BLUSH, PISSED
}

[System.Serializable]
public class Dialogue
{
    public CharacterNovel character;
    public bool headDown;
    public EXPRESSION expression;
    [TextArea] public string dialogueCharacter;
    public UnityEvent onDialogue;
}


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TextMeshProUGUI nameCharacter;
    public TextMeshProUGUI dialogueCharacter;
    public Image portraitCharacter;
    public int indexDialogue = 0;
    public List<Dialogue> dialogues;
    public CanvasGroup cg;
    public bool isTalking;
    public PlayerController player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
    public void ShowDialogue(Dialogue dialogue)
    {
        isTalking = true;
        player.canMove = false;
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
        nameCharacter.text = dialogue.character.characterName;
        dialogueCharacter.text = dialogue.dialogueCharacter;
        portraitCharacter.sprite = dialogue.character.GetSprite(dialogue.expression, dialogue.headDown);
        dialogue.onDialogue?.Invoke();
    }
    public void NextDialogue()
    {
        indexDialogue++;
        if (indexDialogue >= dialogues.Count)
        {
            cg.alpha = 0;
            cg.interactable = false;
            cg.blocksRaycasts = false;
            indexDialogue = 0;
            isTalking = false;
            player.canMove = true;
        }
        else
        {
            ShowDialogue(dialogues[indexDialogue]);
        }
       
    }

    public void AddDialogues(List<Dialogue> dialoguesToAdd)
    {
        dialogues.Clear();
        dialogues.AddRange(dialoguesToAdd);
    }


}
