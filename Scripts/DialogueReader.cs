using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    public static DialogueReader Instance { get; private set; }

    private int m_CurrentDialogueIndex = 0;

    private DialogueStarter m_CurrentDialogue;

    private void Awake()
    {
        if(Instance != null) Destroy(Instance);
        else Instance = this;
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
    }

    private void OnGUI()
    {
        if(GUI.Button( new Rect(100, 200, 100, 50), "Next dialogue bar"))
        {
            m_CurrentDialogueIndex++;
            RunDialogue();
        }
    }
}