using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public Slider slider;
    public static AudioClip die_sound,hit_sound,point_sound,wing_sound,swooshing_sound;
    static AudioSource audioSrc;
	// Use this for initialization
	void Start () {
        die_sound = Resources.Load<AudioClip>("sfx_die");
        hit_sound = Resources.Load<AudioClip>("sfx_hit");
        point_sound = Resources.Load<AudioClip>("sfx_point");
        wing_sound = Resources.Load<AudioClip>("sfx_wing");
        swooshing_sound = Resources.Load<AudioClip>("sfx_swooshing");
    
        audioSrc = GetComponent<AudioSource>();
    }
    //To control the volume through slider
    public void OnValueChanged() {
        audioSrc.volume = slider.value;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound(string clip) {
        switch (clip) {
            case "die":
                audioSrc.PlayOneShot(die_sound);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit_sound);
                break;
            case "point":
                audioSrc.PlayOneShot(point_sound);
                break;
            case "wing":
                audioSrc.PlayOneShot(wing_sound);
                break;
            case "swooshing":
                audioSrc.PlayOneShot(swooshing_sound);
                break;
        }
    }
}
