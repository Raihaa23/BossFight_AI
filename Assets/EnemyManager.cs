using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
    public Image hpBar;
    public float maxHP;
    public float curHP;
    public ParticleSystem meleeExplode;

    public int meleeCounter;
    public int heavyCounter;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        hpBar.fillAmount = curHP / maxHP;
    }

    public void MeleeExplosion() {
        Debug.Log("Boom");
        meleeExplode.Play();
    }

    public void MeleeAttackCounter() 
    {
        meleeCounter += 1;
    }
    public void HeavyAttackDamage() {
        heavyCounter += 1;
    }
}
