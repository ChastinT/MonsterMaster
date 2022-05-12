using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacker : MonoBehaviour
{
    public HealthBar healthBar;
    public ManaBar manaBar;
    public ActionBar actionBar;
    public Attacker opponent;
    public MonsterStats currentMonster;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public float mana = 0f;
    public float action = 0f;
    public bool foresight = false;


    // Start is called before the first frame update
    void Start()
    {
        /*For each monster, generate stats
         * 0: ID
         * 1: Vigor
         * 2: Intelligence
         * 3: Agility
         * 4: Dexterity
         * 5: Current HP
         * 6: Maximum HP
        */

        /*
        for (int i = 0; i < 3; i++)
        {
            monsters[i, 0] = i;
            monsters[i, 1] = Random.Range(lower, upper);
            monsters[i, 2] = Random.Range(lower, upper);
            monsters[i, 3] = Random.Range(lower, upper);
            monsters[i, 4] = Random.Range(lower, upper);
            monsters[i, 5] = 50 + monsters[i, 1] * 10;
            monsters[i, 6] = monsters[i, 5];
        }
        */
        //Swap(0);
        //updateHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Standard battle procedures occur when both teams' total current HP is above 0
        if (currentMonster.getCurHealth() > 0 && opponent.currentMonster.getCurHealth() > 0)
        {
            //Gain mana
            if (mana < 10000)
            {
                mana += currentMonster.getBattleIntelligence() / 100;
            }
            manaBar.SetMana(mana);
            //Gain readiness and attack
            if (action < 10000)
            {
                action += currentMonster.getBattleAgility() / 10;
            }
            else
            {
                Attack();
            }
            actionBar.SetAction(action);
        }
    }
    /*
    public void updateHealth()
    {
        healthBar.SetMaxHealth(monsters[attacker, 6]);
        healthBar.SetHealth(monsters[attacker, 5]);
    }
    */
    void Attack()
    {
        if (foresight == true && mana >= 5000) {
            opponent.TakeDamage(currentMonster.getBattleVigor() * 2);
            foresight = false;
            mana -= 5000;
        }
        else if (Random.Range(0f, 100f) < opponent.currentMonster.getBattleAgility() - currentMonster.getBattleAgility())
        {
            opponent.TakeDamage(currentMonster.getBattleVigor() / 2);
        }
        else if (Random.Range(0f, 100f) < currentMonster.getBattleDexterity() - opponent.currentMonster.getBattleDexterity())
        {
            opponent.TakeDamage(currentMonster.getBattleVigor() * 2);
        }
        else
        {
            opponent.TakeDamage(currentMonster.getBattleVigor());
        }
        audioSource.PlayOneShot(audioClip);
        action = 0;
    }

    void TakeDamage(float damage)
    {
        currentMonster.currentHealth -= damage;
        if (currentMonster.getCurHealth() < 0)
        {
            currentMonster.setCurHealth(0);
        }
        healthBar.SetHealth(currentMonster.getCurHealth());
    }

    public void setMonster(MonsterStats monster)
    {
        currentMonster = monster;
        Image image = this.GetComponent<Image>();
        image.sprite = monster.GetComponent<Image>().sprite;
    }
}
