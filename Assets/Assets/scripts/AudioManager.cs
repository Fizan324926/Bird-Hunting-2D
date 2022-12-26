using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
   public Sound[] sounds;
    public static AudioManager instance;
    public void Awake(){
        //DontDestroyOnLoad(gameObject);
        if(instance==null){
            instance=this;
        }
        else{
            Destroy(instance);
            return;
        }
        
        foreach(var sound in sounds){
            sound.source=gameObject.AddComponent<AudioSource>();
            sound.source.clip=sound.clip;
            sound.source.volume=sound.volume;
            sound.source.pitch=sound.pitch;
        }
    }
    public void PlaySound(string name){
        foreach(var sound in sounds){
            if(sound.name==name){
                sound.source.Play();
            }
        }
    }
}
