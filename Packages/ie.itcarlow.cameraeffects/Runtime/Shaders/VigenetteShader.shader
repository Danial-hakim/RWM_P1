Shader "Hidden/VigenetteShader"
{
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _VignetteColor ("Vignette Color", Color) = (1, 1, 1, 1)
        _VignetteSize ("Vignette Size", Range(0, 1)) = 0.5
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _VignetteColor;
            float _VignetteSize;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                float2 center = float2(0.5, 0.5);
                float vignette = smoothstep(_VignetteSize, 1, distance(i.uv, center));
                return tex2D(_MainTex, i.uv) * lerp(fixed4(1, 1, 1, 1), _VignetteColor, vignette);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
