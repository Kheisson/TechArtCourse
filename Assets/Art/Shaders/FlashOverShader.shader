Shader "Experimental/FlashOverShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GlowColor ("Glow Color", Color) = (1,1,1,1)
        _GlowWidth ("Glow Width", Range(0,1)) = 0.1
        _Speed ("Speed", Range(0,10)) = 1
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
            float4 _MainTex_ST;
            float4 _GlowColor;
            float _GlowWidth;
            float _Speed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                // Create a moving white line
                float hevel = smoothstep(0.0, _GlowWidth, 1.0 - abs(1.0 - frac(uv.x + _Time.y * _Speed)));
                fixed4 tex = tex2D(_MainTex, uv);
                fixed4 glow = hevel * _GlowColor;
                // Only add the glow color where the line is
                return fixed4(lerp(tex.rgb, glow.rgb, glow.a), tex.a);
            }
            ENDCG
        }
    }
}
