Shader"Custom/MaskedGradientShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _MaskTex ("Mask Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
#include "UnityCG.cginc"

struct appdata_t
{
    float4 vertex : POSITION;
    float2 uv : TEXCOORD0;
};

struct v2f
{
    float2 uv : TEXCOORD0;
    float4 vertex : SV_POSITION;
};

sampler2D _MainTex;
sampler2D _MaskTex;

v2f vert(appdata_t v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = v.uv;
    return o;
}

fixed4 frag(v2f i) : SV_Target
{
                // Sample the main texture
    fixed4 col = tex2D(_MainTex, i.uv);
                
                // Sample the mask texture
    fixed4 mask = tex2D(_MaskTex, i.uv);
                
                // Use the mask's alpha channel to control the final color
    col.a = mask.a;
                
    return col;
}
            ENDCG
        }
    }
}
