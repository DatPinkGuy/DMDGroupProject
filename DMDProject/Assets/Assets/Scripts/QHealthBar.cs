using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QHealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBarSprite;
    [SerializeField] float takenDamage;
    [SerializeField] float healthBarDamage = 10f;
    public float health = 60f;


    public void QuestionnaireBossTakeDamage()
    {
        healthBarSprite.transform.localScale -= new Vector3(takenDamage, 0f, 0f);
        health -= healthBarDamage;
    }
}
