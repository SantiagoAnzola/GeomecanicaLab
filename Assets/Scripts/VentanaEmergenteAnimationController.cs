using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentanaEmergenteAnimationController : MonoBehaviour
{
    public RawImage rawImageComponent; // Arrastra el componente Raw Image al Inspector
    public List<RenderTexture> renderTextures; // Arrastra el Render Texture al Inspector
    public VentanaEmergenteAnimationController(RawImage rawImage, List<RenderTexture> textures)
    {
        rawImageComponent = rawImage;
        renderTextures = textures;
    }
    public void AsignarTextura(string modelo)
    {
        for (int i = 0; i < renderTextures.Count; i++)
        {
            Debug.Log($"nombre del archivo {i}: {renderTextures[i].name}");
            if (renderTextures[i].name == modelo) {
                rawImageComponent.texture = renderTextures[i];
            }
            
        }
    }
}
