using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public int maxMessages = 25;

    public GameObject dialogueContainer, playerMessageObject, infoMessageObject, combatMessageObject, lootMessageObject;
    public InputField chatInput;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    void Start()
    {
        GenerateInfoMessage();
    }

    void Update()
    {
        // Check if chat contains text, if enter is pressed then send to window.
        if (chatInput.text != "")
        {
            if (chatInput.text.Length <= 255)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    GeneratePlayerMessage("<b><i><color=#DEDEDE><size=22>Me:</size></color></i></b> " + "(" + GenerateTimestamp() + ")\n" +
                                          "<color=#00C7FF><size=21>" + chatInput.text + "</size></color>");
                    chatInput.text = "";
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {

                    GeneratePlayerMessage("<b><i><color=#DEDEDE><size=22>\nMe:</size></color></i></b> " + "(" + GenerateTimestamp() + ")" +
                                          "<color=#00C7FF><size=21>   " + chatInput.text + "</size></color>");
                    chatInput.text = "";
                }
            }
        }
        else
        {
            if (!chatInput.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatInput.ActivateInputField();
            }
        }
    }

    public void GeneratePlayerMessage(string text)
    {
        // Garbage collection for message cap.
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        // Create new message object, assign input text, instantiate as child of dialogue.
        Message playerMessage = new Message();

        playerMessage.text = text;

        GameObject newText = Instantiate(playerMessageObject, dialogueContainer.transform);

        playerMessage.textObject = newText.GetComponent<Text>();

        playerMessage.textObject.text = playerMessage.text;

        messageList.Add(playerMessage);

    }

    public void GenerateCombatMessage()
    {
        Message combatMessage = new Message();

        combatMessage.text = "";

        GameObject newChatPrompt = Instantiate(combatMessageObject, dialogueContainer.transform);

        combatMessage.textObject = newChatPrompt.GetComponent<Text>();

        combatMessage.textObject.text = combatMessage.text;

        messageList.Add(combatMessage);
    }

    public void GenerateLootMessage()
    {
        Message lootMessage = new Message();

        lootMessage.text = "";

        GameObject newChatPrompt = Instantiate(lootMessageObject, dialogueContainer.transform);

        lootMessage.textObject = newChatPrompt.GetComponent<Text>();

        lootMessage.textObject.text = lootMessage.text;

        messageList.Add(lootMessage);
    }

    public void GenerateInfoMessage()
    {
        Message infoMessage = new Message();

        infoMessage.text = "<b><size=23>----------------------------------------</size></b>\n" +
                           "<size=23>Welcome to the game!</size>\n" +
                           "<size=23>" + System.DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt") + "</size>\n" +
                           "<size=23>Version: Developer Test Build</size>\n" +
                           "<b><size=23>----------------------------------------</size></b>";

        GameObject newChatPrompt = Instantiate(infoMessageObject, dialogueContainer.transform);

        infoMessage.textObject = newChatPrompt.GetComponent<Text>();

        infoMessage.textObject.text = infoMessage.text;

        messageList.Add(infoMessage);
    }

    public string GenerateTimestamp()
    {
        string timestamp;
        timestamp = System.DateTime.Now.ToString("HH:mm:ss");
        return timestamp;
    }
}

public class Message
{
    public string text;
    public Text textObject;
}

