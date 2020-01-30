using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QHealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBarSprite;
    [SerializeField] float takenDamage;


    public void QuestionnaireBossTakeDamage()
    {
        healthBarSprite.transform.localScale -= new Vector3(takenDamage, 0f, 0f);
    }
}
