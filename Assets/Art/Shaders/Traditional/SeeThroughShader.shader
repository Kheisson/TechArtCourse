Shader "Experimental/SeeThroughShader"
{
    Properties {
        // Define shader properties that can be customized in the inspector
        _MainTex ("Texture", 2D) = "white" {} // Main texture property
        [Space(10)][Header(Custom Properties)][Space(10)]
        _MousePos ("Mouse Position", Vector) = (0,0,0,0) // Mouse position property
        _Radius ("Radius", Range(0, 1)) = 0.1 // Radius property
    }
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" } // Rendering tags for transparency
        
        Pass {
            CGPROGRAM
            #pragma vertex vert // Vertex shader function
            #pragma fragment frag // Fragment shader function
            #include "UnityCG.cginc" // Include UnityCG.cginc for helper functions

            struct appdata {
                float4 vertex : POSITION; // Vertex position
                float2 uv : TEXCOORD0; // Texture coordinate
            };

            struct v2f {
                float2 uv : TEXCOORD0; // Texture coordinate
                float4 vertex : SV_POSITION; // Vertex position
                float2 screenPos : TEXCOORD1; // Screen position
            };

            sampler2D _MainTex; // Main texture
            float4 _MainTex_ST; // Tiling and offset for main texture
            float4 _MousePos; // Mouse position
            float _Radius; // Radius

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // Transform vertex position to clip space
                o.uv = TRANSFORM_TEX(v.uv, _MainTex); // Transform texture coordinate
                o.screenPos = o.vertex.xy / o.vertex.w; // Calculate screen position
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                float dist = distance(i.screenPos, _MousePos.xy); // Calculate distance to mouse position
                fixed4 col = tex2D(_MainTex, i.uv); // Sample color from main texture
                if (dist < _Radius) discard; // Discard fragment if distance is within radius
                return col; // Return color
            }
            ENDCG
        }
    }
}
