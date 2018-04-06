// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//������Ч
Shader "Custom/ParticleAdditive_BrightnessRatio" {
Properties {
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Particle Texture", 2D) = "white" {}

	//���ȱ���
	_BrightnessRatio("BrightnessRatio", Range(1, 4)) = 1
}
/************************************************************************************************************************/
/************************************************************************************************************************/
Category {
	Tags { 
		"Queue"="Transparent+5" //��Ч����Ϊ���ϲ��ʼֵΪ3005
		"IgnoreProjector"="True" 
		"RenderType"="Transparent"
	}

	Blend SrcAlpha One
	ColorMask RGB
	Cull Off 
	Lighting Off 
	ZWrite Off//����¼����ȣ�ͨ�����ڰ�͸������
	//Shader��Ĭ�������´���  1. ZWrite On 2. ZTestLEqual
	Fog { Color (0,0,0,0) }//�ر���Ч��Fog����	
	
	SubShader {
		Pass {		
CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_particles

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _TintColor;
			float _BrightnessRatio;
			
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};
			
			float4 _MainTex_ST;

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
				return 2.0f * i.color * _TintColor * tex2D(_MainTex, i.texcoord) * _BrightnessRatio;
			}
ENDCG 
		}
	}	
}
/************************************************************************************************************************/
/************************************************************************************************************************/
}