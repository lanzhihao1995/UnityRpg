// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Transparent/Diffuse Clip" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	_Clip ("Clip Rect", Vector) = (-1,-1,1,1)
}

Category {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	Blend SrcAlpha  OneMinusSrcAlpha
	LOD 200

	SubShader {
		Pass {
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _Color;
			
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float4 pos : TEXCOORD2;
			};
			
			float4 _MainTex_ST;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				o.color = v.color;
				o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);

				o.pos = o.vertex;

				return o;
			}

			sampler2D_float _CameraDepthTexture;
			float _InvFade;
			float4 _Clip;
			
			fixed4 frag (v2f i) : SV_Target
			{

				fixed4 c = i.color * _Color * tex2D(_MainTex, i.texcoord);

				if(i.pos.y > _Clip.w || i.pos.y < _Clip.y || i.pos.x > _Clip.z || i.pos.x < _Clip.x)
				{
					c.a = 0;
				}

				return c;
			}
			ENDCG 
		}
		}
}

Fallback "Transparent/VertexLit"
}
