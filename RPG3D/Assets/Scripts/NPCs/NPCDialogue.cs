using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private string[] m_dialogues;

    private int m_dialogueIndex = 0;
    private bool m_showing = false;

    private void Update()
    {
        if (m_showing && Input.GetButtonDown("Jump"))
        {
            ShowNextDialogue();
        }
    }

    public void StartDialogue()
    {
        if (m_dialogues.Length == 0)
            return;

        m_dialogueIndex = 0;
        m_showing = true;
        print("Start dialogue");
        ShowNextDialogue();
    }

    private void ShowNextDialogue()
    {
        if (m_dialogueIndex >= m_dialogues.Length)
        {
            print("End dialogue");
            return;
        }

        print(m_dialogues[m_dialogueIndex]);
        m_dialogueIndex++;

        // TODO: Add timing to avoid 2 dialogues at the first time
    }
}
