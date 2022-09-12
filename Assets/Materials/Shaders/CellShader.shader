Shader "Unlit/CellShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Albedo Color",  Color) = (.0, .0, .0, 1)
        _ShadowColor("Shadow Color",  Color) = (.0, .0, .0, 1)
    }
    SubShader
    {
        Tags { "LightMode" = "ForwardBase"  "SHADOWSUPPORT" = "true" "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma /*multi_compile_fog*/ multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                //UNITY_FOG_COORDS(1)
                SHADOW_COORDS(1)
                float3 normal : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float4 _ShadowColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                //UNITY_TRANSFER_FOG(o,o.vertex);
                TRANSFER_SHADOW(o);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                half NdotL = max(dot(i.normal, normalize(_WorldSpaceLightPos0)),0.0f);
                half diff = saturate(NdotL);
                fixed shadow = SHADOW_ATTENUATION(i);
                fixed3 lighting = diff * shadow;

                fixed3 col = _Color * lighting + (1 - lighting) * _ShadowColor;
                col *= tex2D(_MainTex, i.uv);

                //UNITY_APPLY_FOG(i.fogCoord, col);
                return fixed4(col, 1.0f);
            }
            ENDCG
        }
        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}
