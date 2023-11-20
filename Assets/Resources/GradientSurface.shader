Shader"Custom/GradientSurface"
{
    //Properties {
    //  _Color1 ("Color 1", Color) = (1, 1, 1, 1)
    //  _Color2 ("Color 2", Color) = (0, 0, 0, 1)
    //}
    //SubShader
    //{
    //    Tags   {"RenderType"="Opaque"}
    //    LOD 100

    //    Pass
    //    {
    //        CGPROGRAM
    //        #pragma vertex vert
    //        #pragma fragment frag

    //        #include "UnityCG.cginc"

    //        struct appdata
    //        {
    //            float4 vertex : POSITION;
    //            float2 uv : TEXCOORD0;
    //        };
    //        struct v2f
    //        {
    //            float2 uv : TEXCOORD0;
    //            float4 vertex : SV_POSITION;
    //        };
    //        fixed4 _Color1;
    //        fixed4 _Color2;
   
    //        v2f vert(appdata v)
    //        {
    //            v2f o;
    //            o.vertex = UnityObjectToClipPos(v.vertex);
    //            o.uv = v.uv;
    //            return o;
    //        }
    //        fixed4 frag(v2f i) : SV_Target
    //        {
    //            fixed4 col = lerp(_Color1, _Color2, i.uv.x);
    //            return col;
    //        }
    //        ENDCG
    //    }
    //}
    

     Properties
    {
        _Color1("Color 1", Color) = (1, 1, 1, 1)
        _Color2("Color 2", Color) = (0, 0, 0, 1)
        _Angle("Gradient Angle", Range(-360, 360)) = 45
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
             CGPROGRAM
             #pragma vertex vert
             #pragma fragment frag

             #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
            float4 _Color1;
            float4 _Color2;
            float _Angle;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float angle = radians(_Angle);
                float s = sin(angle);
                float c = cos(angle);
                float2 rotatedUV = float2(v.uv.x * c - v.uv.y * s, v.uv.x * s + v.uv.y * c);
                o.uv = rotatedUV;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = lerp(_Color1, _Color2, i.uv.x);
                return col;
            }
            ENDCG
        }
    }
}
