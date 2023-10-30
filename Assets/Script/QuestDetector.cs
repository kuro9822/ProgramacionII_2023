using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestDetector : MonoBehaviour
{
    public Quest questToDetect;
    public UnityEvent onQuestDetected;
    public Collider2D collectableObjectCollider; // Referencia al collider del objeto colectable

    public void Detect()
    {
        if (questToDetect.questStatus == QUEST_STATUS.ASSIGNED)
        {
            // Verifica si el jugador ha tocado el objeto colectable
            if (collectableObjectCollider != null && collectableObjectCollider.enabled)
            {
                // Marca la misión como completa
                questToDetect.questStatus = QUEST_STATUS.COMPLETE;

                // Invoca el evento de misión completada
                onQuestDetected?.Invoke();
            }
        }
    }

    public void Update()
    {
        Detect();
    }
}
