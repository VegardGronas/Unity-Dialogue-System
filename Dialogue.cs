using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "GameSys/Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<DialogueBar> dialogues;
}

[Serializable]
public class DialogueBar
{
    public CharacterInfo characterInfo;
    public string text;
}