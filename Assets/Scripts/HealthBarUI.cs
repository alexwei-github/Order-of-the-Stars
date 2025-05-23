using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image healthFill;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private CombatManager character;

    void OnEnable ()
    {
        character.OnHealthChange += OnUpdateHealth;
    }
    void OnDisable ()
    {
        character.OnHealthChange -= OnUpdateHealth;
    }
    void Start ()
    {
        OnUpdateHealth();
    }
    public void OnUpdateHealth ()
    {
        healthFill.fillAmount = character.GetHealthPercentage();
        healthText.text = character.CurHp + " / " + character.MaxHp;
    }
}
