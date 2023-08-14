using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
}


public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameCharacter;
    public TextMeshProUGUI dialogueCharacter;
    public Image portraitCharacter;
    public int indexDialogue = 0;
    public List<Dialogue> dialogues;
    
    private void Start()
    {
      
        ShowDialogue(dialogues[0]);
    }
    public void ShowDialogue(Dialogue dialogue)
    {
        nameCharacter.text = dialogue.character.characterName;
        dialogueCharacter.text = dialogue.dialogueCharacter;
        portraitCharacter.sprite = dialogue.character.GetSprite(dialogue.expression, dialogue.headDown);
    }
    public void NextDialogue()
    {
        indexDialogue++;
        ShowDialogue(dialogues[indexDialogue]);
    }


}
