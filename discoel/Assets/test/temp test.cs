using UnityEngine;

public class temptest : MonoBehaviour
{
    public PlayerSkills playerSkills;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerSkills.ImproveSkill("Logic", 1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            bool passed = playerSkills.AttemptSkillCheck("Logic", 3);
            // You can use this result to trigger different events
        }
    }

}
