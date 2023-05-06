Shader "Hidden/HighlightColorShader"
{
        Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _ChosenColor ("Chosen Color", Color) = (1, 0, 0, 1)
        _Threshold ("Threshold", Range(0, 1)) = 0.5
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            sampler2D _MainTex;
            float4 _ChosenColor;
            float _Threshold;
 
            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float luminance = dot(col.rgb, float3(0.299, 0.587, 0.114));
                if (col.r >= _ChosenColor.r - _Threshold && col.r <= _ChosenColor.r + _Threshold &&
                    col.g >= _ChosenColor.g - _Threshold && col.g <= _ChosenColor.g + _Threshold &&
                    col.b >= _ChosenColor.b - _Threshold && col.b <= _ChosenColor.b + _Threshold) {
                    col = _ChosenColor;
                } else {
                    col.rgb = float3(luminance, luminance, luminance);
                }
                return col;
            }
 
            ENDCG
        }
    }
    FallBack "Diffuse"
}
