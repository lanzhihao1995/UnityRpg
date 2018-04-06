// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Dissolve_TexturCoords_Add" {
Properties {
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)	
	_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}

	_DissColor ("DissColor", Color) = (1,1,1,1)
	_DissolveSrc ("DissolveSrc", 2D) = "white" {}

	_Amount ("Amount", Range (0, 1)) = 0.5
	_StartAmount("StartAmount", float) = 0.1
	_Illuminate ("Illuminate", Range (0, 1)) = 0.5
	_Tile("Tile", float) = 1	
	_ColorAnimate ("ColorAnimate", vector) = (1,1,1,1)

	//亮度倍数
	_BrightnessRatio("BrightnessRatio", Range(1, 4)) = 1
}
/************************************************************************************************************************/
/************************************************************************************************************************/
SubShader { 
	Tags { 
		"Queue"="Transparent+5" //特效设置为最上层初始值为3005
		"IgnoreProjector"="True" 
		"RenderType"="Transparent" 
	}

	Pass	{
		LOD 200
		Cull Off 
		Lighting Off 
		ZWrite Off//不记录此深度，通常用于半透明物体
	
		Blend SrcAlpha One
CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma multi_compile_particles
			
		#include "UnityCG.cginc"

		sampler2D _MainTex;
		sampler2D _DissolveSrc;
		float4 _MainTex_ST;

		fixed4 _TintColor;
		half4 _DissColor;
		half _Shininess;
		half _Amount;
		static half3 Color = float3(1,1,1);
		half4 _ColorAnimate;
		half _Illuminate;
		half _Tile;
		half _StartAmount;
		float _BrightnessRatio;

		struct appdata_t {
			float4 vertex : POSITION;
			float2 texcoord : TEXCOORD0;
			fixed4 color : COLOR;
		};

		struct v2f {
			float4 vertex : SV_POSITION;
			float2 texcoord : TEXCOORD0;
			fixed4 color : COLOR;
		};

		v2f vert (appdata_t v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
			o.color = v.color;
			return o;
		}
			
		fixed4 frag (v2f i) : SV_Target
		{		
			fixed4 result = fixed4(0, 0, 0, 0);		
			fixed4 tex = tex2D(_MainTex, i.texcoord);
			result.rgb = 2.0f * tex.rgb * _TintColor.rgb * _BrightnessRatio;
	
			float ClipTex = tex2D (_DissolveSrc, i.texcoord/_Tile).r ;
			float ClipAmount = ClipTex - _Amount;
			float Clip = 0;

			if (_Amount > 0)
			{
				if (ClipAmount <0)
				{
					Clip = 1;
				}
				else
				{	
					if (ClipAmount < _StartAmount)
					{
						if (_ColorAnimate.x == 0)
							Color.x = _DissColor.x;
						else
							Color.x = ClipAmount/_StartAmount;
          
						if (_ColorAnimate.y == 0)
							Color.y = _DissColor.y;
						else
							Color.y = ClipAmount/_StartAmount;
          
						if (_ColorAnimate.z == 0)
							Color.z = _DissColor.z;
						else
							Color.z = ClipAmount/_StartAmount;

						result.rgb  = (result.rgb *((Color.x+Color.y+Color.z))* Color*((Color.x+Color.y+Color.z)))/(1 - _Illuminate);
					}
				}
			}
 
			if (Clip == 1)
			{
				clip(-0.1);
			}   

			result.a = 2.0f * tex.a * _TintColor.a * i.color.a * _BrightnessRatio;	
			return result;
		}
ENDCG
	}
}
/************************************************************************************************************************/
/************************************************************************************************************************/
FallBack "Specular"
}
