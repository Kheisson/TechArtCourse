Shader "Experimental/StainOverShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _StainTex ("Stain Texture", 2D) = "white" {}
        _StainSize ("Stain Size", Range(0.0, 1.0)) = 0.1
        _StainIntensity ("Stain Intensity", Range(0.0, 1.0)) = 0.5
        _RandomSeed ("Random Seed", Range(0.0, 1.0)) = 0.0
        _Speed ("Movement Speed", Range(0.0, 10.0)) = 1.0
    }

    SubShader
    {
        Tags { "Queue"="Overlay" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off

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
            sampler2D _StainTex;
            float _StainSize;
            float _StainIntensity;
            float _RandomSeed;
            float _Speed;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 mainColor = tex2D(_MainTex, i.uv);
                float2 randomOffset = float2(
                    frac(sin(dot(i.uv.xy, float2(12.9898, 78.233))) * 43758.5453 + _RandomSeed),
                    frac(cos(dot(i.uv.xy, float2(23.5674, 89.012))) * 23421.6312 + _RandomSeed)
                );

                float2 movementOffset = float2(
                    sin(_Time.y * _Speed),
                    cos(_Time.y * _Speed)
                );

                float2 stainUV = i.uv + (randomOffset + movementOffset) * _StainSize;
                fixed4 stainColor = tex2D(_StainTex, stainUV);

                return mainColor * (1 - _StainIntensity) + stainColor * _StainIntensity;
            }
            ENDCG
        }
    }
}
