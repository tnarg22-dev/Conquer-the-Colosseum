using UnityEngine;

public class HealthSystemForDummies : MonoBehaviour
{
    public bool IsAlive;
    public float CurrentHealth = 1000;
    public float MaximumHealth = 1000;

    public bool HasAnimationWhenHealthChanges = true;
    public float AnimationDuration = 0.1f;

    public float CurrentHealthPercentage
    {
        get
        {
            return (CurrentHealth / MaximumHealth) * 100;
        }
    }

    public OnCurrentHealthChanged OnCurrentHealthChanged;
    public OnIsAliveChanged OnIsAliveChanged;
    public OnMaximumHealthChanged OnMaximumHealthChanged;

    public GameObject HealthBarPrefabToSpawn;

    public void AddToMaximumHealth(float value)
    {
        float cachedMaximumHealth = MaximumHealth;

        MaximumHealth += value;
        OnMaximumHealthChanged.Invoke(new MaximumHealth(cachedMaximumHealth, MaximumHealth));
    }

    public void AddToCurrentHealth(float value)
    {
        if (value == 0) return;

        float cachedCurrentHealth = CurrentHealth;

        if (value > 0)
        {
            GotHealedFor(value);
        }
        else
        {
            GotHitFor(damage: value);
        }

        OnCurrentHealthChanged.Invoke(new CurrentHealth(cachedCurrentHealth, CurrentHealth, CurrentHealthPercentage));
    }

    void GotHealedFor(float value)
    {
        CurrentHealth += value;

        if (CurrentHealth > MaximumHealth)
        {
            CurrentHealth = MaximumHealth;
        }

        if (!IsAlive)
        {
            ReviveWithCustomHealth(CurrentHealth);
        }
    }

    void GotHitFor(float damage)
    {
        if (!IsAlive) { return; }

        float absoluteValue = Mathf.Abs(damage);
        DecreaseCurrentHealthBy(absoluteValue);
    }

    void DecreaseCurrentHealthBy(float value)
    {
        CurrentHealth -= value;

        if (CurrentHealth <= 0)
        {
            IsAlive = false;
            OnIsAliveChanged.Invoke(IsAlive);
        }
    }

    public void ReviveWithMaximumHealth()
    {
        Revive(MaximumHealth);
    }

    public void ReviveWithCustomHealth(float healthWhenRevived)
    {
        Revive(healthWhenRevived);
    }

    public void ReviveWithCustomHealthPercentage(float healthPercentageWhenRevived)
    {
        Revive(MaximumHealth * (healthPercentageWhenRevived / 100));
    }

    void Revive(float health)
    {
        float previousHealth = CurrentHealth;

        CurrentHealth = health;
        IsAlive = true;

        OnIsAliveChanged.Invoke(IsAlive);
        OnCurrentHealthChanged.Invoke(new CurrentHealth(previousHealth, CurrentHealth, CurrentHealthPercentage));
    }

    public void Kill()
    {
        float previousHealth = CurrentHealth;

        CurrentHealth = 0;
        IsAlive = false;

        OnIsAliveChanged.Invoke(IsAlive);
        OnCurrentHealthChanged.Invoke(new CurrentHealth(previousHealth, CurrentHealth, CurrentHealthPercentage));
    }
}