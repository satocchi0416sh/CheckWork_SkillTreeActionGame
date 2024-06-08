using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance { get; private set; }
    
    [SerializeField] private List<Skill> allSkills = new List<Skill>();
    public List<Skill> unlockedSkills = new List<Skill>();
    
    [SerializeField] private GameObject skillTreePanel;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockSkill(Skill skill)
    {
        unlockedSkills.Add(skill);
        CoinManager.Instance.SpendCoin(skill.skillCost);
    }

    private void Start()
    {
        skillTreePanel.SetActive(false);
        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            skillTreePanel.SetActive(!skillTreePanel.activeSelf);
        }
    }

    private void OnDestroy()
    {
        Save();
    }
    
    private void Save()
    {
        foreach (Skill skill in unlockedSkills)
        {
            PlayerPrefs.SetInt(skill.skillName, 1);
        }
    }
    
    private void Load()
    {
        foreach (Skill skill in allSkills)
        {
            if (PlayerPrefs.HasKey(skill.skillName))
            {
                skill.unlocked = true;
                skill.GetComponent<Image>().color = Color.green;
            }
        }
    }
}
