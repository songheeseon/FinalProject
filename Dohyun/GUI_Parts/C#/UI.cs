using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject playerCharacter;
    private PlayerSkillController skillController;

    private Text totalXp;
    private Text freeXp;
    private Text damage;

    //공격 버튼
    private Button baseNode;
    private Button aUP1Node;
    private Button aUP2Node;
    private Button aUP3Node;
    private Button aUP4Node;
    private Button aUP5Node;


    //버튼 텍스트
    private Text baseNodeLevel;
    private Text aUP1NodeLevel;
    private Text aUP2NodeLevel;
    private Text aUP3NodeLevel;
    private Text aUP4NodeLevel;
    private Text aUP5NodeLevel;

    //버튼 경험치
    private Text baseNodeXP;
    private Text aUP1NodeXP;
    private Text aUP2NodeXP;
    private Text aUP3NodeXP;
    private Text aUP4NodeXP;
    private Text aUP5NodeXP;
  

    void Start()
    {
        skillController = playerCharacter.GetComponent<PlayerSkillController>();

        // UI
        totalXp = GameObject.Find("TotalXP").GetComponent<Text>();
        freeXp = GameObject.Find("FreeXP").GetComponent<Text>();
        damage = GameObject.Find("Damage").GetComponent<Text>();

        baseNode = GameObject.Find("BaseNode").GetComponent<Button>();
        aUP1Node = GameObject.Find("AUP1Node").GetComponent<Button>();
        aUP2Node = GameObject.Find("AUP2Node").GetComponent<Button>();
        aUP3Node = GameObject.Find("AUP3Node").GetComponent<Button>();
        aUP4Node = GameObject.Find("AUP4Node").GetComponent<Button>();
        aUP5Node = GameObject.Find("AUP5Node").GetComponent<Button>();

        //Lv UI
        baseNodeLevel = GameObject.Find("BaseNodeLevel").GetComponent<Text>();
        aUP1NodeLevel = GameObject.Find("AUP1NodeLevel").GetComponent<Text>();
        aUP2NodeLevel = GameObject.Find("AUP2NodeLevel").GetComponent<Text>();
        aUP3NodeLevel = GameObject.Find("AUP3NodeLevel").GetComponent<Text>();
        aUP4NodeLevel = GameObject.Find("AUP4NodeLevel").GetComponent<Text>();
        aUP5NodeLevel = GameObject.Find("AUP5NodeLevel").GetComponent<Text>();

        //XP = Money로 바꿀 예정.

        baseNodeXP = GameObject.Find("BaseNodeXP").GetComponent<Text>();
        aUP1NodeXP = GameObject.Find("AUP1NodeXP").GetComponent<Text>();
        aUP2NodeXP = GameObject.Find("AUP2NodeXP").GetComponent<Text>();
        aUP3NodeXP = GameObject.Find("AUP3NodeXP").GetComponent<Text>();
        aUP4NodeXP = GameObject.Find("AUP4NodeXP").GetComponent<Text>();
        aUP5NodeXP = GameObject.Find("AUP5NodeXP").GetComponent<Text>();


    }

    void Update()
    {
        // update XP text
        totalXp.text = skillController.TotalXP.ToString();
        freeXp.text = skillController.FreeXP.ToString();

        damage.text = skillController.GetAbilityByName("Attack").GetModifierByName("").Value.ToString();

        // update baseNode back color, level and XP cost on UI
        if (skillController.GetNodeByName("BaseNode").Unlockable) baseNode.image.color = Color.white;
        if (skillController.GetNodeByName("BaseNode").Unlocked) baseNode.image.color = Color.green;
        baseNodeLevel.text = skillController.GetNodeByName("BaseNode").Level.ToString();
        baseNodeXP.text = string.Format("{0} XP",skillController.GetNodeByName("BaseNode").XpCost.ToString());

        // update attackDamageNode back color, level and XP cost on UI
        if (skillController.GetNodeByName("AUP1Node").Unlockable) aUP1Node.image.color = Color.white;
        if (skillController.GetNodeByName("AUP1Node").Unlocked) aUP1Node.image.color = Color.green;
        aUP1NodeLevel.text = skillController.GetNodeByName("AUP1Node").Level.ToString();
        aUP1NodeXP.text = string.Format("{0} XP", skillController.GetNodeByName("AUP1Node").XpCost.ToString());


    }
}
