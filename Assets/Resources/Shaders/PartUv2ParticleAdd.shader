// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

///使用模型顶点的UV2，主要用于流光特效，将UV2  K成0或者更小，则那个顶点相关的面不进行渲染
Shader "Custom/PartUv2ParticleAdd" {
Properties {
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTexPartUv2 ("Particle Texture", 2D) = "white" {}
}

	Category 
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		Blend SrcAlpha One
		//AlphaTest Greater .01
		ColorMask RGB
		Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }
	
		// ---- Fragment program cards
		SubShader
		{
			Pass {
			
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest
				#pragma multi_compile_particles

				#include "UnityCG.cginc"

				sampler2D _MainTexPartUv2;
				fixed4 _TintColor;
				
				struct appdata_t {
					float4 vertex : POSITION;
					float2 texcoord : TEXCOORD0;
					float2 texcoord1 : TEXCOORD1;
				};

				struct v2f {
					float4 vertex : POSITION;
					float2 texcoord : TEXCOORD0;
				};
				
				float4 _MainTexPartUv2_ST;

				v2f vert (appdata_t v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					
					
					if(v.texcoord1.x >= 0.0001 && v.texcoord1.y >= 0.0001)	///UV2是正常值，需要做流光动画渲染
					{
						o.texcoord = TRANSFORM_TEX(v.texcoord1,_MainTexPartUv2);
					}
					else				///UV2为0，不应用动画变换，并将UV设置为负的，用于在像素函数里做判断
					{
						o.texcoord.x = -100000;
						o.texcoord.y = -100000;
					}
					return o;
				}

				
				fixed4 frag (v2f i) : COLOR
				{	
					if(i.texcoord.x >= 0 && i.texcoord.y >= 0)
					{
						return 2.0f * _TintColor * tex2D(_MainTexPartUv2, i.texcoord);
					}
					else
					{
						fixed4 co;
						co.rgb = 0;
						co.a = 0;
						return co;
					}
				}
				ENDCG 
			}
		} 	
	
	}
}
