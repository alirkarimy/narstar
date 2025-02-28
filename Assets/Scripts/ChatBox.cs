using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ChatBox : MonoBehaviour
{
    public TextTyper textTyper; // Reference to the TextTyper component
    public string[] messages = new string[]
        {
            "Hello! Welcome to the chat.",
            "How can I assist you today?",
            "Feel free to ask any questions.",
            "Have a great day!"
        };  // Array of messages to display
    private int currentMessageIndex = 0; // Index of the current message
    public UnityEvent OnChatEnd;

    private void Start()
    {
        
        // Start typing the first message
        textTyper.StartTyping(messages[currentMessageIndex]);
    }

    public void OnPointerClick()
    {
        // If there are more messages, show the next one
        if (currentMessageIndex < messages.Length - 1)
        {
            currentMessageIndex++;
            textTyper.StartTyping(messages[currentMessageIndex]);
        }
        else
        {
            OnChatEnd?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
