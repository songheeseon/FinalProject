using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create custom menu under Create menuitem
[CreateAssetMenu(fileName = "NewAbility", menuName = "Simple Skill System/New Ability")]
public class Ability : SkillSystemBase
{
    // input fields
    [Space(5f)]
    [Header("Ability Settings:")]
    public List<AbilityModifier> Modifiers;

    /// <summary>
    /// Returns Modifier based on the specified name
    /// </summary>
    /// <param name="modifierName">Name of the Nodifier</param>
    /// <returns>The specified Modifier on success otherwise null</returns>
    public AbilityModifier GetModifierByName(string modifierName)
    {
        // get modifier
        AbilityModifier modifier =  Modifiers.Find(x => x.Name == modifierName);
        // log error and return null if modifier cannot be found
        if (modifier == null)
        {
            Debug.LogError(string.Format("GetModifier(string modifierName): the supplied name ({0}) canot be found among the Modifiers field.", modifierName));
            return null;
        }

        // return the specified modifier
        return modifier;
    }
}
