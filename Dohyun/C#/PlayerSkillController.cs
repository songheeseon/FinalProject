using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    // input fields
    public List<Ability> Abilities;                     // abilities of the player character
    public List<Node> Nodes;                            // skill tree nodes attached to the player character
    public bool ResetOnApplicationQuit = true;          // flag for reset modifier values and node levels when OnApplicationQuit event fires
    public bool SendWarningIfNegativeXPAdded = false;   // flag for sending warning message to the log if negative amount of XP specified in AddXP method

    // private fields for XP handling
    private int totalXp;
    private int freeXp;

    // getters
    public int TotalXP => totalXp;
    public int FreeXP => freeXp;
    public int SpentXP => totalXp - freeXp;

    // Check periodically if a node can be unlocked
    // parent level >= parent min level
    void Update()
    {
        foreach (Node node in Nodes)
        {
            // continue if no parent node specified
            if (node.ParentNode == null) continue;
            // mark node as unlockable if criteria is met
            if (node.ParentNode.Level >= node.ParentMinLevel)
            {
                node.MarkAsUnlockable();
            }
            else
            {
                node.MarkAsNotUnlockable();
            }
        }
    }

    /// <summary>
    /// Resets Abilities, AbilityModifier values and Nodes to their initial state if function is enabled
    /// </summary>
    private void OnApplicationQuit()
    {
        // check if reset flag is set
        if (ResetOnApplicationQuit)
        {
            // loop through abilities, reset them and all of their modifiers
            foreach (Ability ability in Abilities)
            {
                foreach (AbilityModifier modifier in ability.Modifiers)
                {
                    modifier.Reset();
                }
                ability.Reset();
            }

            // loop through nodes and reset them to their initial state
            foreach (Node node in Nodes)
            {
                node.Reset();
            }
        }
    }

    /// <summary>
    /// Increments the player character's XP by the specified amount
    /// </summary>
    /// <param name="amount">amount to be added</param>
    public void AddXP(int amount)
    {
        // log warning message if amount is negative, maybe it is unintentional
        // also check if function is enabled
        if (amount < 0 && SendWarningIfNegativeXPAdded)
        {
            Debug.LogWarning(string.Format("AddXP(int amunt): the specified amount is less than zero ({0}), is it intentional?", amount));
        }

        // increment XP values
        totalXp += amount;
        freeXp += amount;
    }

    /// <summary>
    /// Gets Ability based on the specified name
    /// </summary>
    /// <param name="abilityName">Name of the Abilty</param>
    /// <returns>The specified Abilty on success otherwise null</returns>
    public Ability GetAbilityByName(string abilityName)
    {
        // get Ability
        Ability ability = Abilities.Find(x => x.Name == abilityName);
        // loag error message and return null if ability cannot be found
        if (ability == null)
        {
            Debug.LogError(string.Format("GetAbilityByName(string abilityName): the supplied name ({0}) canot be found among the Abilities field.", abilityName));
            return null;
        }

        // return Ability on success
        return ability;
    }

    /// <summary>
    /// Gets Node based on the specified name
    /// </summary>
    /// <param name="nodeName">Name of the Node</param>
    /// <returns>The specified Node on success otherwise null</returns>
    public Node GetNodeByName(string nodeName)
    {
        // get Node
        Node node = Nodes.Find(x => x.Name == nodeName);
        // log error message and return false if node cannot be found
        if (node == null)
        {
            Debug.LogError(string.Format("GetNodeByName(string nodeName): the supplied name ({0}) canot be found among the Nodes field.", nodeName));
            return null;
        }

        // return Node on success
        return node;
    }

    /// <summary>
    /// Unlocks Node based on the specified name
    /// </summary>
    /// <param name="nodeName">Name of the Node</param>
    /// <returns>true on success otherwise false</returns>
    public bool UnlockNode(string nodeName)
    {
        // get Node
        Node node = Nodes.Find(x => x.Name == nodeName);
        // log error message and return false if node cannot be found
        if (node == null)
        {
            Debug.LogError(string.Format("UnlockNode(string nodeName): the supplied name ({0}) canot be found among the Nodes field.", nodeName));
            return false;
        }
        // return if Node's XP cost is greater than the player character's free XP
        if (node.XpCost > freeXp) return false;

        // unlock the Node and decrement the player character's free XP with the Node's XP cost
        if (node.Unlock())
        {
            freeXp -= node.XpCost;
            // success, return true
            return true;
        }

        // if we got this far node.Unlock() failed, return false
        return false;
    }

        

    /// <summary>
    /// Unlocks Node base on the specified name (should only be used with UI since returns void)
    /// </summary>
    /// <param name="nodeName">Name of the Node</param>
    public void UnlockNodeUI(string nodeName)
    {
        // get Node
        Node node = Nodes.Find(x => x.Name == nodeName);
        // log error message and return false if node cannot be found
        if (node == null)
        {
            Debug.LogError(string.Format("UnlockNode(string nodeName): the supplied name ({0}) canot be found among the Nodes field.", nodeName));
            return;
        }
        // return if Node's XP cost is greater than the player character's free XP
        if (node.XpCost > freeXp) return;

        // unlock the Node and decrement the player character's free XP with the Node's XP cost
        if (node.Unlock())
        {
            freeXp -= node.XpCost;
        }
    }
}
