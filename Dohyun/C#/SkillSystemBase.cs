using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Timeline;

public class SkillSystemBase : ScriptableObject
{
    // input fields
    [Header("Base settings:")]
    [SerializeField]
    private bool unlockable = false;        // is the object unlockable
    [SerializeField]
    private bool unlocked = false;          // is the object unlocked
    [SerializeField]
    private bool stackable = false;         // is the object stackable (multiple levels)
    [SerializeField]
    private bool initiallyUnlocked = false; // is the object initially unlocked

    public string Name;                 // name of the object
    public string Description;          // description of the object

    // getters
    public bool Unlockable => unlockable;
    public bool Unlocked => unlocked;
    public bool Stackable => stackable;
    public bool InitiallyUnlocked => initiallyUnlocked;

    /// <summary>
    /// Marks Object as unlockable
    /// </summary>
    public virtual void MarkAsUnlockable()
    {
        unlockable = true;
    }

    /// <summary>
    /// Unmarks Object as unlockable
    /// </summary>
    public virtual void MarkAsNotUnlockable()
    {
        unlockable = false;
    }

    /// <summary>
    /// Unlocks Object
    /// </summary>
    /// <returns>true on success otherwise false</returns>
    public virtual bool Unlock()
    {
        if (!unlockable) return false;
        unlocked = true;
        return true;
    }

    /// <summary>
    /// Locks Object
    /// </summary>
    protected virtual void Lock()
    {
        unlocked = false;
    }

    /// <summary>
    /// Resets this object to its initial state
    /// </summary>
    public virtual void Reset()
    {
        // lock node if not initially unlocked
        if (!InitiallyUnlocked)
        {
            Lock();
        }
        else
        {
            Unlock();
        }
    }
}
