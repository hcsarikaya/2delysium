using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogue : MonoBehaviour
{
    public PlayerSkills playerSkills;

    // Define this inside SimpleDialogue since it's dialogue-specific
    public class DialogueOption
    {
        public string skillName;
        public int requiredLevel;
        public string text;
        public bool isAvailable;
        public bool wasChosen;
    }

    void OnMouseDown()
    {
        StartConversation();
    }

    void StartConversation()
    {
        Debug.Log("NPC: What do you think about this situation?");

        List<DialogueOption> options = new List<DialogueOption>()
        {
            new DialogueOption {
                skillName = "Logic",
                requiredLevel = 2,
                text = "[Logic] The facts clearly indicate..."
            },
            new DialogueOption {
                skillName = "Empathy",
                requiredLevel = 3,
                text = "[Empathy] You must be feeling..."
            },
            new DialogueOption {
                skillName = null,
                text = "I'm not sure what to say."
            }
        };

        // Check availability
        foreach (DialogueOption option in options)
        {
            option.isAvailable = string.IsNullOrEmpty(option.skillName) ||
                               playerSkills.GetSkillLevel(option.skillName) >= option.requiredLevel;
        }

        // Display available options
        Debug.Log("Available responses:");
        int displayNumber = 1;
        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].isAvailable)
            {
                Debug.Log($"{displayNumber}. {options[i].text}");
                displayNumber++;
            }
        }

        // In a real game, you'd use UI buttons. For testing we'll auto-pick first available
        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].isAvailable)
            {
                SelectOption(options[i]);
                break;
            }
        }
    }

    void SelectOption(DialogueOption option)
    {
        option.wasChosen = true;
        Debug.Log($"You: {option.text}");

        if (!string.IsNullOrEmpty(option.skillName))
        {
            playerSkills.TriggerSkillVoice(option.skillName);
        }
    }
}