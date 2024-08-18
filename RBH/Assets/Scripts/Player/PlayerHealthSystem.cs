using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float maxHealth = 100;
    private float health = 100;
    [Header("Regeneration")]
    [SerializeField] float regenerationDelay = 5;
    [SerializeField] float regenerationRate = .1f;
    [SerializeField] float regenerationSpeed = 0.01f;
    public static Action<float> onPlayerDamaged;
    public static Action<float, float> onPlayerHealthChanged;
    public static Action onPlayerDied;

    private Coroutine regenerationCoroutine;
    void Start()
    {
        ChangeHealth(maxHealth);
    }
   
    public void TakeDamage(float damage)
    {
        health -= damage;
        onPlayerDamaged?.Invoke(health);
        onPlayerHealthChanged?.Invoke(health, maxHealth);
        if (health <= 0)
        {
            onPlayerDied?.Invoke();
        }
        else
        {
            if (regenerationCoroutine != null)
            {
                StopRegeneration();
            }
            regenerationCoroutine = StartCoroutine(StartRegenerationAfterDelay(regenerationDelay));
        }

    }

    public void ChangeHealth(float _health)
    {
        health = _health;
        onPlayerHealthChanged?.Invoke(health, maxHealth);
    }

    private IEnumerator StartRegenerationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (health > 0)
        {
            regenerationCoroutine = StartCoroutine(RegenerateHealthOverTime());
        }
    }

    private IEnumerator RegenerateHealthOverTime()
    {
        while (health < maxHealth)
        {
            if (health <= 0)
            {
                yield break;
            }
            health += regenerationRate;
            health = Mathf.Clamp(health,0,maxHealth);
            onPlayerHealthChanged?.Invoke(health, maxHealth);
            yield return new WaitForSeconds(regenerationSpeed);
        }
    }

    private void StopRegeneration()
    {
        if (regenerationCoroutine != null)
        {
            StopCoroutine(regenerationCoroutine);
            regenerationCoroutine = null;
        }
    }
}