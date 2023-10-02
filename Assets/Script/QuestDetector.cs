using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestDetector : MonoBehaviour
{
    public Quest questToDetect;
    public UnityEvent onQuestDetected;

    public void Detect()
    {
        if (QuestManager.instance.GetQuestStatus(questToDetect.nameQuest)
            == QUEST_STATUS.ASSIGNED)
        {
            onQuestDetected?.Invoke();
        }
    }

    public void Update()
    {
        Detect();
    }
}
