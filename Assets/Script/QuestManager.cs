using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QUEST_STATUS
{
    UNASSIGNED, ASSIGNED, COMPLETE
}
[System.Serializable]
public class Quest
{
    public string nameQuest;
    public QUEST_STATUS questStatus;
}

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> quests;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeQuestStatus(string questName, QUEST_STATUS newStatus)
    {
        foreach (Quest q in quests)
        {
            if (q.nameQuest == questName)
            {
                q.questStatus = newStatus;
            }
        }
    }

    public QUEST_STATUS GetQuestStatus(string questName)
    {
        foreach (Quest q in quests)
        {
            if (q.nameQuest == questName)
            {
                return q.questStatus;
            }
        }
        return QUEST_STATUS.UNASSIGNED;
    }
}
