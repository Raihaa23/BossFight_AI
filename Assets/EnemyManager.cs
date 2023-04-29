using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
    public Image hpBar;
    public float maxHP;
    public float curHP;

    [SerializeField] private float monsterHp = 100;
    
    public Animator _animator;
    public ParticleSystem meleeExplode;
    public ParticleSystem rangedBreathAttack;
    public ParticleSystem rangedSpellAttack;
    public ParticleSystem _tornado;

    public int meleeCounter;
    public int heavyCounter;
    public int rangedCounter;
    public int spellCounter;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        hpBar.fillAmount = curHP / maxHP;
    }
    
    public void MonsterOnDamage(float onDamageDealt)
    {
        monsterHp -= onDamageDealt;
        _animator = GetComponent<Animator>();
        Debug.Log($"Monster Health = {monsterHp}");
        
        if (monsterHp < 30)
        {
            if (TornadoMove)
            {
                _tornado.gameObject.SetActive(true);
                _tornado.Play();
                _tornado.transform.position =
                    new Vector3(_tornado.transform.position.x, 0, _tornado.transform.position.z);
            }
        }
        if (IsDead)
        {
               _animator.SetTrigger("isDead");
        }
    }

    private bool IsDead
    {
        get
        {
            return monsterHp == 0;
        }
    }

    private bool TornadoMove
    {
        get
        {
           return _tornado;
        }
    }
    
    
    public void MeleeExplosion() {
        meleeExplode.Play();
    }

    public void RangedAttack()
    {
        rangedBreathAttack.Play();
    }

    public void SpellAttack()
    {
        rangedSpellAttack.Play();
    }

    public void MeleeAttackCounter() 
    {
        meleeCounter += 1;
    }
    public void HeavyAttackCounter() {
        heavyCounter += 1;
    }
    
    public void RangeAttackCounter()
    {
        rangedCounter += 1;
    }

    public void SpellAttackCounter()
    {
        spellCounter += 1;
    }
}
