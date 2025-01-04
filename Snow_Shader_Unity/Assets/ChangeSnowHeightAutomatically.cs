using UnityEngine;

public class ChangeSnowHeightAutomatically : MonoBehaviour
{
    // List of materials with the shader that we want to change
    public Material[] snowShaderMaterials;
    // Snow height properties
    public float snowStartHeight = 0f;
    public float snowEndHeight = 5f;
    public float snowSpeed = 1f;
    public float currentSnowHeight;
    
    
    void Start()
    {
        // Get the shader from the materials GetComponent<Renderer>().material
        foreach (Material material in snowShaderMaterials)
        {
            // Get the property ID of the _Snow_Height property
            int snowHeightPropertyID = Shader.PropertyToID("_Snow_Height");
            
            // Set the _Snow_Height property to 0
            material.SetFloat(snowHeightPropertyID, snowStartHeight);
        }
    }

    void Update()
    {
        // Change the snow height slowly over time
        foreach (Material material in snowShaderMaterials)
        {
            // Get the shader from the material
            Shader shader = material.shader;
            
            // Get the property ID of the _Snow_Height property
            int snowHeightPropertyID = Shader.PropertyToID("_Snow_Height");
            
            // Get the current snow height
            currentSnowHeight = material.GetFloat(snowHeightPropertyID);
            
            // Change the snow height over time
            currentSnowHeight += snowSpeed * Time.deltaTime;
            
            // Set the _Snow_Height property to the current snow height
            material.SetFloat(snowHeightPropertyID, currentSnowHeight);
        }
        
        // Reset the snow height to the start height if the snow height is at the end height
        if (currentSnowHeight >= snowEndHeight)
        {
            foreach (Material material in snowShaderMaterials)
            {
                // Get the property ID of the _Snow_Height property
                int snowHeightPropertyID = Shader.PropertyToID("_Snow_Height");
                
                // Set the _Snow_Height property to the start height
                material.SetFloat(snowHeightPropertyID, snowStartHeight);
            }
        }
        
    }
}
