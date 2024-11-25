using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInfo", menuName = "GameSys/CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    public string characterName;
    public Sprite characterImage;
}