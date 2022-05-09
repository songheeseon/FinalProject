using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create custom menu under Create menuitem
[CreateAssetMenu(fileName = "NewAbilityModifier", menuName = "Simple Skill System/New Ability Modifier")]
public class AbilityModifier : ScriptableObject
{
    private float baseValue = 1f;
    private float modifier = 1f;

    // input fields
    public string Name;

    // getters
    public float Value => baseValue * modifier;

    /// <summary>
    /// Modifies the modifier value
    /// </summary>
    /// <param name="value">value to multipy with</param>
    public void Modify(float value)
    {
        modifier *= value;
    }

    /// <summary>
    /// Resets the modifier value
    /// </summary>
    public void Reset()
    {
        modifier = 1f;
    }
}
