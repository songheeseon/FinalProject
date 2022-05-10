using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create custom menu under Create menuitem
[CreateAssetMenu(fileName = "NewNode", menuName = "Simple Skill System/New Node")]
public class Node : SkillSystemBase
{
    // input fields
    [Space(5f)]
    [Header("Node Settings:")]
    public int InitialLevel;            // initial level of Node
    public int Level;                   // actual level of Node
    public int MaxLevel;                // maximum level of Node
    public Node ParentNode;             // the Node which level is monitored to set this node to unlockable
    public int ParentMinLevel;          // minimum level of parent node at which this node becomes unlockable
    public Ability AbilityOfEffect;     // the Ability which this Node has effect on
    public string ModifierName;         // the AbilityModifier's name this Node has effect on
    public float ModifierValue;         // the value with which the modifier value will be multiplied
    public int XpCost;                  // XP cost of unlocking and levelling this node

    /// <summary>
    /// Unlocks the Node
    /// </summary>
    /// <returns>true on success otherwise false</returns>
    public override bool Unlock()
    {
        // check if base node and unlock it
        if (ParentNode == null)
        {
            base.Unlock();
            return true;
        }
        // check parent level and return if it is under min level
        if (ParentNode.Level < ParentMinLevel) return false;
        // return if Node is already unlocked but isn't stackable
        if (Unlocked && !Stackable) return false;
        // return if Node reached max level
        if (Unlocked && Stackable && Level >= MaxLevel) return false;
        // return if SkillSystemBase.Unlock fails
        if (!base.Unlock()) return false;

        // unlock ability if it isn't unlocked yet
        if (!AbilityOfEffect.Unlocked) AbilityOfEffect.Unlock();
        // increment Node level
        Level++;
        // Modify ability's modifier if modifier name is specified
        // GetModifierByName method generates error message if it can't find modifier with the specified name
        if (ModifierName != "") AbilityOfEffect.GetModifierByName(ModifierName).Modify(ModifierValue);

        return true;
    }

    /// <summary>
    /// Resets Node to initial values
    /// </summary>
    public override void Reset()
    {
        base.Reset();
        // reset level
        Level = InitialLevel;
    }
}
