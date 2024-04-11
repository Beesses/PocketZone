using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView
{
    private Health _health;
    private float maxHealth;
    private Image _healthImage;

    public HealthView(Health health,Image healthImage, float MaxHealth)
    {
        _health = health;
        maxHealth = MaxHealth;
        _healthImage = healthImage;
        _health.Changed += ChangeHealth;
        _health.Died += Died;
    }

    private void ChangeHealth(float health)
    {
        _healthImage.rectTransform.sizeDelta = new Vector2(1.5f * (health / maxHealth), 0.3f);
    }

    private void Died()
    {
        _health.Changed -= ChangeHealth;
        _health.Died -= Died;
    }
}
