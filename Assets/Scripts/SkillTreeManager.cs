using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance { get; private set; }
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            skillTreePanel.SetActive(!skillTreePanel.activeSelf);
        }
    }
}
