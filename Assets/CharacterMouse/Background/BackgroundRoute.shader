Shader "Unlit/BackgroundRoute"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NextTex ("Texture Next", 2D) = "white" {}
        _NextTex2 ("Texture Next 2", 2D) = "white" {}
        _Speed ("Speed", Float) = 1.0
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
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _NextTex;
            sampler2D _NextTex2;
            float _Speed;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float x = fmod(i.uv.x + _Time.y * _Speed, 3.0);
                float y = i.uv.y;
                fixed4 col;
                // map to texture
                if(x < 1.0)
                    col = tex2D(_MainTex, fixed2(x, y));
                else if (x < 2.0)
                    col = tex2D(_NextTex, fixed2(x - 1.0, y));
                else
                    col = tex2D(_NextTex2, fixed2(x - 2.0, y));
                
                return col;
            }
            ENDCG
        }
    }
}
