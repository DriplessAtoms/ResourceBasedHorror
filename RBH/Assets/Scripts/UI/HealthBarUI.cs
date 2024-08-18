using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]private Image healthBarImage;

    private void OnEnable()
    {
        PlayerHealthSystem.onPlayerHealthChanged += OnPlayerDamaged;
    }

    private void OnDisable()
    {
        PlayerHealthSystem.onPlayerHealthChanged -= OnPlayerDamaged;
    }

    private void OnPlayerDamaged(float health, float maxHealth)
    {
        healthBarImage.fillAmount =  (float)health/maxHealth;
    }
}
