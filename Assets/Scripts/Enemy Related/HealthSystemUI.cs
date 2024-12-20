using TMPro;
using UnityEngine;

public class HealthSystemUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private TMP_Text _healthText;

    private void OnEnable() 
    {
        _healthSystem.OnDamageTaken.AddListener(UpdateHealthText);
        _healthSystem.OnHeal.AddListener(UpdateHealthText);
        _healthSystem.OnHealthSystemInitialized += UpdateHealthText;
    }

    private void OnDisable() 
    {
        _healthSystem.OnDamageTaken.RemoveListener(UpdateHealthText);
        _healthSystem.OnHeal.RemoveListener(UpdateHealthText);
        _healthSystem.OnHealthSystemInitialized -= UpdateHealthText;
    }

    private void UpdateHealthText()
    {
        _healthText.text = $"{_healthSystem.CurrentHealth}";
    }
}