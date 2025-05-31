using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [System.Serializable]
    public class Skill
    {
        public string name;
        public int level;
    }

    public List<Skill> skills = new List<Skill>()
    {
        new Skill { name = "Logic", level = 1 },
        new Skill { name = "Empathy", level = 1 },
        new Skill { name = "Drama", level = 1 }
    };

    public int GetSkillLevel(string skillName)
    {
        Skill skill = skills.Find(s => s.name == skillName);
        return skill?.level ?? 0;
    }
    // Simple method to increase a skill
    public void ImproveSkill(string skillName, int amount)
    {
        Skill skill = skills.Find(s => s.name == skillName);
        if (skill != null)
        {
            skill.level += amount;
            Debug.Log(skillName + " improved to level " + skill.level);
        }
    }

    public bool AttemptSkillCheck(string skillName, int difficulty)
    {
        Skill skill = skills.Find(s => s.name == skillName);
        if (skill == null) return false;

        // Simple check: if skill level >= difficulty, you pass
        bool success = skill.level >= difficulty;
        Debug.Log(skillName + " check (" + skill.level + " vs " + difficulty + "): " + (success ? "SUCCESS" : "FAIL"));

        if (success)
        {
            TriggerSkillVoice(skillName);
        }
        
        return success;
    }

    [System.Serializable]
    public class SkillVoiceLine
    {
        public string skillName;
        [TextArea] public string message;
    }

    public List<SkillVoiceLine> voiceLines = new List<SkillVoiceLine>()
{
    new SkillVoiceLine { skillName = "Logic", message = "This doesn't add up. There's a contradiction here." },
    new SkillVoiceLine { skillName = "Empathy", message = "You can tell they're hurting behind that smile." }
};

    public void TriggerSkillVoice(string skillName)
    {
        SkillVoiceLine line = voiceLines.Find(v => v.skillName == skillName);
        if (line != null)
        {
            Debug.Log("<color=cyan>" + skillName + ":</color> " + line.message);
        }
    }
}