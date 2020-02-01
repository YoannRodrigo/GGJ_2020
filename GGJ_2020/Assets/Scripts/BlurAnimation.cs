using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BlurAnimation : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public float apertureParameter;
    private readonly FloatParameter newAperture = new FloatParameter();
    private DepthOfField depthOfField;

    private void Update()
    {
        print(postProcessVolume.sharedProfile.settings.Count);
        
        postProcessVolume.sharedProfile.settings.Remove(depthOfField);
        depthOfField = ScriptableObject.CreateInstance<DepthOfField>();
        depthOfField.focusDistance.value = 0.9f;
        depthOfField.focusDistance.overrideState = true;
        depthOfField.aperture.value = apertureParameter;
        depthOfField.aperture.overrideState = true;
        postProcessVolume.sharedProfile.settings.Add(depthOfField);
    }
}
