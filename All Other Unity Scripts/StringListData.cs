using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This string list data assett was created primarily for a branching dialogue system using this data, IntData, my DialogueTrigger Script and most importantly my StringListOperator script.
//this assett should be created for a single dialogue with an npc, and each unique dialogue you can have with that NPC should have it's own StringListData asset


[CreateAssetMenu]
public class StringListData : ScriptableObject
{

    public List<string> stringList;

 
}
