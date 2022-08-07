using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private PlayerHealth hp;

    private void Start()
    {
        anim = GetComponent<Animator>();
        State = States.fullhp;
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private enum States
    {
        hp_0, hp_1, hp_2, fullhp
    }
    
    private void Update()
    {
        if (hp.hp >= 3) { State = States.fullhp; }
        if (hp.hp == 2) { State = States.hp_2; }
        if (hp.hp == 1) { State = States.hp_1; }
        if (hp.hp <= 0) { State = States.hp_0; }
    }
    
}
