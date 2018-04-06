// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/GrayImage"
{
	Properties
	{
		_MainTex ("Base", 2D) = "white" {}
		_Intensity("Gray Intensity",range(0.0,1.0)) = 0.5
	}
	SubShader
	{
		// No culling or depth

		 // Cull Off：关闭阴影剔除 、  ZWrite ： 要将像素的深度写入深度缓存中   
        // Test Always：将当前深度值写到颜色缓冲中 
		Cull Off 
		ZWrite Off 
		ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 color:COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				fixed4 color:COLOR;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.color = v.color;
				return o;
			}
			
			sampler2D _MainTex;
			float _Intensity;

			//根据RGB和YUV颜色空间的变化关系
			//可建立亮度Y与R、G、B三个颜色分量的对应：
			//Y=0.3R+0.59G+0.11B，
			//以这个亮度值表达图像的灰度值。

			//这里取值：0.22 0.707 0.071
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv) * i.color;
				fixed r = dot(col.rgb, fixed3(1-_Intensity*0.78, _Intensity * 0.707, _Intensity * 0.071));
				fixed g = dot(col.rgb, fixed3(_Intensity*0.22, 1- _Intensity * 0.293, _Intensity * 0.071));
				fixed b = dot(col.rgb, fixed3(_Intensity*0.22, _Intensity * 0.707, 1- _Intensity * 0.929));

				col.rgb = fixed3(r,g,b);

				// just invert the colors
				return col;
			}
			ENDCG
		}
	}
}
