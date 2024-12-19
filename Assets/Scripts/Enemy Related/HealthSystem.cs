using UnityEngine;
using UnityEngine.Events;
using VInspector;

public class HealthSystem : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnDamageTaken;
    public UnityEvent OnHeal;
    public UnityEvent OnDeath;

    [SerializeField] [ReadOnly] private int _currentHealth;
    private int _maxHealth;

    public int CurrentHealth => _currentHealth;

    public void Initialize(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(0, _currentHealth);

        OnDamageTaken?.Invoke();

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if(_currentHealth == _maxHealth)
            return;

        _currentHealth += amount;
        _currentHealth = Mathf.Min(_maxHealth, _currentHealth);

        OnHeal?.Invoke();
    }

    public void Die()
    {
        OnDeath?.Invoke();
    }
}