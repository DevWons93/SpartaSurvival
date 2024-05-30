using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UIConditions uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition hunger { get { return uiCondition.hunger; } }
    Condition stamina { get { return uiCondition.stamina; } }
    //Condition mana { get { return uiCondition.mana; } }

    public float noHungerHealthDecay;
    private bool isInvincibility;

    public event Action onTakenDamage;

    // Update is called once per frame
    private void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue == 0f && !isInvincibility)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amout)
    {
        health.Add(amout);
    }

    public void Eat(float amout)
    {
        hunger.Add(amout);
    }

    public void Die()
    {
        Debug.Log("ав╬З╢ы");
    }

    public void TakePhysicalDamage(int damage)
    {
        if (isInvincibility) return;
        health.Subtract(damage);
        onTakenDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Subtract(amount);
        return true;
    }

    public void CanInvincibility(bool isActive)
    {
        isInvincibility = isActive;
    }    
}
