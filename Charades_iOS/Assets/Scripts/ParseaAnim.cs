/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using LitJson;

public class ParseaAnim : MonoBehaviour
{
    public Animator animator;
    public TextAsset animationData;

    public void Start()
    {
        //ParseAnimationData(animationData.text);
    }

    private void ParseAnimationData(string jsonData)
    {
        JsonData json = JsonMapper.ToObject(jsonData);

        //Creating new Animation Controller
        AnimatorController controller = new AnimatorController();
        controller.name = "Circle_AnimationController";

        //Adding new layer to AnimatorController
        AnimatorControllerLayer layer = new AnimatorControllerLayer();
        layer.name = "Base Layer";
        controller.AddLayer(layer);

        for(int i=0;i<json.Count;i++)
        {
            string animationName = (string)json[i]["name"];

        }
    }
}
*/