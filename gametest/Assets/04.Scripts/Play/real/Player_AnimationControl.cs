using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AnimationControl : MonoBehaviour {

    void Awake()
    {
        destroy();
    }
    void destroy()
    {
        var final_animation = GameObject.FindGameObjectsWithTag("FinalAttackAnimation");
        var short_animation = GameObject.FindGameObjectsWithTag("ShortAttackAnimation");
        var explosion_animation = GameObject.FindGameObjectsWithTag("ExplosionAnimation");
        var short_missile = GameObject.FindGameObjectsWithTag("PlayerShortMissile");
        var Pattern_Mark = GameObject.FindGameObjectsWithTag("Pattern_Mark");
        foreach (var finalani in final_animation)
        {
            Destroy(finalani, 1.5f);
        }
        foreach (var shortani in short_animation)
        {
            Destroy(shortani, 0.5f);
        }
        foreach (var exploani in explosion_animation)
        {
            Destroy(exploani, 0.85f);
        }
        foreach (var shortmissile in short_missile)
        {
            Destroy(shortmissile, 0.5f);
        }
        foreach(var PatternMark in Pattern_Mark)
        {
            Destroy(PatternMark, 0.5f);
        }
        
    }
}
