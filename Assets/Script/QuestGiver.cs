using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest questToGive;

    public void AddQuestToQuestManager()
    {
        QuestManager.instance.quests.Add(questToGive);
    }
}
