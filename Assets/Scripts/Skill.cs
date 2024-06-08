using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public string skillName;
    public int skillCost = 10;
    public bool unlocked;
    public Skill requiredSkill;
    
    private Button _button;

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(Unlock);
    }

    public void Unlock()
    {
        if (CheckRequirements())
        {
            unlocked = true;
            GetComponent<Image>().color = Color.green;
            SkillTreeManager.Instance.UnlockSkill(this);
        }
    }

    private void Update()
    {
        _button.interactable = !unlocked && CheckRequirements();
    }
    
    private bool CheckRequirements()
    {
        if (CoinManager.Instance.CanSpend(skillCost))
        {
            if (requiredSkill == null)
            {
                return true;
            }

            if (requiredSkill.unlocked)
            {
                return true;
            }
        }
        
        return false;
    }
}
