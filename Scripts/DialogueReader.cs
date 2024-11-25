using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueReader : MonoBehaviour
{
    public static DialogueReader Instance { get; private set; }

    private int m_CurrentDialogueIndex = 0;

    private DialogueStarter m_CurrentDialogue;

    [SerializeField]
    GameObject m_Canvas;

    [SerializeField]
    TextMeshProUGUI m_CharacterNameLabel;

    [SerializeField]
    TextMeshProUGUI m_DialogueLabel;

    [SerializeField]
    Image m_CharacterImage;

    private void Awake()
    {
        if(Instance != null) Destroy(Instance);
        else Instance = this;

        DisableCanvas();
    }

    public void StartDialogue(DialogueStarter dialogue)
    {
        m_CurrentDialogueIndex = 0;

        m_CurrentDialogue = dialogue;

        RunDialogue();
    }

    private void RunDialogue()
    {
        if(!m_CurrentDialogue)
        {
            Debug.Log("No dialogue assigned");

            return;
        }

        if (m_CurrentDialogue.Dialogue.dialogues.Count > 0)
        {
            if(m_CurrentDialogueIndex <= m_CurrentDialogue.Dialogue.dialogues.Count - 1)
            {
                DialogueBar bar = m_CurrentDialogue.Dialogue.dialogues[m_CurrentDialogueIndex];

                EnableCanvas(bar);

                if (bar.characterInfo == null)
                {
                    Debug.LogWarning("No characterinfo");
                }
                else
                {
                    Debug.Log("Speaker: " + bar.characterInfo.characterName);
                }

                Debug.Log(bar.text);
            }
            else
            {
                EndDialogue(m_CurrentDialogue);
            }
        }
    }

    private void EndDialogue(DialogueStarter dialogue)
    {
        dialogue.EndDialogue();

        DisableCanvas();
    }

    private void OnGUI()
    {
        if(GUI.Button( new Rect(100, 200, 100, 50), "Next dialogue bar"))
        {
            m_CurrentDialogueIndex++;
            RunDialogue();
        }
    }

    public void EnableCanvas(DialogueBar bar)
    {
        m_Canvas.SetActive(true); 
        
        m_DialogueLabel.text = bar.text;

        m_CharacterNameLabel.text = bar.characterInfo.characterName;

        if(bar.characterInfo.characterImage)
            m_CharacterImage.sprite = bar.characterInfo.characterImage;
    }

    public void DisableCanvas() 
    {
        m_Canvas.SetActive(false);
    }
}