using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public List<Dialogue> dialogues;

    public bool isPlayerInZone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
            DialogueManager.instance.AddDialogues(dialogues);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
        }
    }

    private void Update()
    {
        if (isPlayerInZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!DialogueManager.instance.isTalking)
                {
                    DialogueManager.instance.ShowDialogue(DialogueManager.instance.dialogues[0]);
                    DialogueManager.instance.isTalking = true;
                }
                else
                {
                    DialogueManager.instance.NextDialogue();
                }
            }
        }
    }
}
