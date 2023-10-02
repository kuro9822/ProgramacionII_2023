using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest questToGive;

    public void AddQuestToQuestManager()
    {
        if (QuestManager.instance.GetQuestStatus(questToGive.nameQuest) != 
            QUEST_STATUS.ASSIGNED)
        {
            QuestManager.instance.quests.Add(questToGive);
        }
    }
}
