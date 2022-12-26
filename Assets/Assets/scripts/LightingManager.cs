using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField]
    private Light directional_light;
    [SerializeField]
    private LightingPreset preset;
    [SerializeField,Range(0,24)]
    private float time;
    private void UpdateLighting(float timepercent){
        Debug.Log("Fizan");
        RenderSettings.ambientLight=preset.ambiant_color.Evaluate(timepercent);
        RenderSettings.fogColor=preset.fog_color.Evaluate(timepercent);
        if(directional_light!=null){
            directional_light.color=preset.directtional_color.Evaluate(timepercent);
            directional_light.transform.localRotation=Quaternion.Euler(new Vector3((timepercent*360f)-90f,170,0));
        }
    }
    private void OnValidate(){
        if(directional_light!=null){
            return;
        }
        if(RenderSettings.sun!=null){
            directional_light=RenderSettings.sun;
        }
        else{
            Light[] lights=GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights){
                if(light.type==LightType.Directional){
                    directional_light=light;
                    return;
                }
            }
        }
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if(preset==null){
            return;
        }   
        if(Application.isPlaying){
            time+=Time.deltaTime;
            time%=24;
            UpdateLighting(time/24f);
        }
    }
}
