using UnityEngine;
using UnityEngine.Events;

public class DialogueStarter : MonoBehaviour
{
    [SerializeField]
    Dialogue m_Dialogue;

    public Dialogue Dialogue => m_Dialogue;

    [SerializeField]
    UnityEvent m_OnDialogueStarted;

    [SerializeField]
    UnityEvent m_OnDialogueEnded;

    public void StartDialogue()
    {
        if(DialogueReader.Instance != null) 
        { 
            DialogueReader.Instance.StartDialogue(this);

            m_OnDialogueStarted?.Invoke();
        }
    }

    public virtual void EndDialogue()
    {
        m_OnDialogueEnded?.Invoke();

        Debug.Log("Dialogue ended ");
    }
}