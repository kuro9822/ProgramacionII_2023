using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "DialogueSystemUniacc/Character",
    fileName = "Character", order = 0)]
public class CharacterNovel : ScriptableObject
{
    public string characterName;
    [TextArea] public string description;
    public Sprite hd_neutral, hd_blush, hd_pissed;
    public Sprite hu_neutral, hu_blush, hu_pissed;

    public Sprite GetSprite(EXPRESSION expression, bool headDown)
    {
        if (headDown)
        {
            switch (expression)
            {
                case EXPRESSION.NEUTRAL:
                    return hd_neutral;
                case EXPRESSION.BLUSH:
                     return hd_blush;
                case EXPRESSION.PISSED:
                    return hd_pissed;
            }
        }
        else
        {
            switch (expression)
            {
                case EXPRESSION.NEUTRAL:
                    return hu_neutral;
                case EXPRESSION.BLUSH:
                    return hu_blush;
                case EXPRESSION.PISSED:
                    return hu_pissed;
            }
        }

        return null;
    }
    
    
}
