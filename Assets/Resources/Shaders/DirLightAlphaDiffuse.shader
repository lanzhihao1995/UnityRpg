// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DirLightAlphaDiffuse" 
{ 
    Properties
    {

        // Basic colors.
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}

        _light("light",Range (0,1.0)) = 0.0

        _DirColor ("Dir Color", Color) = (0.996078,0.94902,0.83922,1)
        _DirPower ("Dir Power", float) = 2.0

        _LightDir ("light dir", Vector) = (0,0,0,0)

    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Transparent"
        }

        Pass
        {
            Name "ShadowCaster"
            Tags
            {
                "LightMode" = "ShadowCaster"
            }

            CGPROGRAM
            #pragma vertex vert   
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "ShaderRequirement.cginc"

		    sampler2D _MainTex;
		    half4 _MainTex_ST;

            #pragma multi_compile_shadowcaster
            #pragma fragmentoption ARB_precision_hint_fastest
            //#pragma skip_variants LIGHTMAP_ON DIRLIGHTMAP_SEPARATE DIRLIGHTMAP_COMBINED DYNAMICLIGHTMAP_ON VERTEXLIGHT_ON

            struct appdata
            {
                float4 vertex : POSITION;
                half3 normal : NORMAL;
                half2 uv : TEXCOORD0;
            };

            struct v2f
            {
                V2F_SHADOW_CASTER;
                //SHADER_COLOR_COORDS(1)
                half2 uv : TEXCOORD1;
            };

            v2f vert(appdata v)
            {
                v2f o;

                CALCULATE_REQUIREMENT
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)

                //SHADER_TRANSFER_UV(o, v)
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv.xy);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }

        Pass
        {
            Name "Main"
            Tags
            {
                "LightMode" = "ForwardBase"
            }




            Blend One OneMinusSrcAlpha
            ZWrite On

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            //#include "UnityPBSLighting.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"


            #ifndef REQUIRE_VS_WORLD_POSITION
            #define REQUIRE_VS_WORLD_POSITION
            #endif

            #ifndef REQUIRE_VS_WORLD_NORMAL
            #define REQUIRE_VS_WORLD_NORMAL
            #endif

            // Require the necessary resource.
            #include "ShaderRequirement.cginc"

            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma fragmentoption ARB_precision_hint_fastest

            #pragma skip_variants DIRLIGHTMAP_SEPARATE DIRLIGHTMAP_COMBINED DYNAMICLIGHTMAP_ON VERTEXLIGHT_ON



		    sampler2D _MainTex;
		    half4 _MainTex_ST;
		    half _light;
		    float4 _DirColor;
		    fixed _DirPower;
		    fixed4 _LightDir;

            struct appdata
            {
                float4 vertex : POSITION;
                half3 normal : NORMAL;
                half2 uv : TEXCOORD0;

            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                //SHADER_COLOR_COORDS(0)
                half2 uv : TEXCOORD0;

                //SHADER_LIGHTING_COORDS(1, 2, 3, 4)
                fixed4 ambience : TEXCOORD1;
                half3 worldNormal : TEXCOORD2;
                half3 viewDir :  TEXCOORD3;
                //half3 viewRefDir : TEXCOORD4

                SHADER_REQUIREMENT_COORDS(5)
                LIGHTING_COORDS(6, 7)
                UNITY_FOG_COORDS(8)

                fixed3 color : COLOR;
              };



            v2f vert(appdata v)
            {
                v2f o;

                CALCULATE_REQUIREMENT

                // Position, normal and UV.
                o.pos = UnityObjectToClipPos(v.vertex);

                //SHADER_TRANSFER_UV(o, v)
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                //SHADER_TRANSFER_LIGHTING(o, v);
                o.worldNormal = worldNormal; 
                //shaderTransferLighting(v.vertex, v.normal, worldPosition, worldNormal, o.ambience, o.viewDir)
                half3 lightDirection = normalize(half3(_WorldSpaceLightPos0.xyz));
                o.ambience.rgb = ShadeSH9(half4(worldNormal.xyz, 1.0));
                o.ambience.a = max(dot(worldNormal, lightDirection), 0.0);
                o.viewDir = normalize(WorldSpaceViewDir(v.vertex));


                SHADER_TRANSFER_REQUIREMENT(o);
                TRANSFER_VERTEX_TO_FRAGMENT(o);
                UNITY_TRANSFER_FOG(o, o.pos);

                o.color.rgb = _DirColor.rgb * max(dot(v.normal,_LightDir.xyz),0) * _DirPower;


                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv.xy);
                col.rgb *= col.a;



                fixed atten = LIGHT_ATTENUATION(i);

                //col = SHADER_APPLY_LIGHTING(col, mask, atten, i);
                       
                fixed3 lights = fixed3(0.0, 0.0, 0.0);

                // Diffuse
                fixed NdotL = i.ambience.a;
                lights = _LightColor0.rgb * NdotL;

                lights *= atten;
                lights += i.ambience.rgb;

                col.rgb *= lights; 


                col.rgb = col.rgb + col.rgb * i.color.rgb;

                //fixed3 emission = fixed3(1, 1, 1, 1) * ;
                col *= (1+_light);

                UNITY_APPLY_FOG(i.fogCoord, col);

                return col;
            }
            ENDCG
        }
    }

    CustomEditor "Legacy Shaders/Transparent/Cutout/Diffuse"
}