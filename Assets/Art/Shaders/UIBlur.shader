Shader "Unlit/UIBlur"
{
   Properties
    {
        _MainTex ("Background Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0.0, 1.0)) = 0.5
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "IgnoreProjector"="True"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _BlurSize;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 texColor = tex2D(_MainTex, i.uv);
                fixed4 blurColor = tex2D(_MainTex, i.uv + float2(-_BlurSize, -_BlurSize)) +
                    tex2D(_MainTex, i.uv + float2(_BlurSize, -_BlurSize)) +
                    tex2D(_MainTex, i.uv + float2(-_BlurSize, _BlurSize)) +
                    tex2D(_MainTex, i.uv + float2(_BlurSize, _BlurSize));

                return (texColor + blurColor) * 0.2;
            }
            ENDCG
        }
    }
}
