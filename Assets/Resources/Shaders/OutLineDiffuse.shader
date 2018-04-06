Shader "Custom/OutLineDiffuse" 
{ 
	Properties
	{
		_OutlineColor ("Outline Color", Color) = (0.1255,0.1255,0.1412,1)	//改变这个能改变轮廓边的颜色
		_Outline ("Outline width", float/*Range (.002, 0.03)*/) = .026

		_MainTex ("Base (RGB)", 2D) = "white" {}
		_light("light",Range (0,1.0)) = 0.0
		

	}
	
	SubShader 
	{
		Tags 
		{
			"IgnoreProjector" = "True"
			"RenderType" = "Opaque"
			//"CastShadows" = "True"
			"Queue" = "Geometry+1"			
		}
				LOD 200


		///设置裁切方式;
		Cull Front
		ZWrite Off
		
		CGPROGRAM
		
		#pragma surface surf BasicDiffuse  vertex:vert
		float _Outline;
		float4 _OutlineColor;

		inline float4 LightingBasicDiffuse  (SurfaceOutput s,fixed3 lightDir,fixed atten)  
        {  
			float4 col;
			col.rgb = s.Albedo;
			col.a = s.Alpha;
			return col;
        }
		
		void vert (inout appdata_full v) 
		{
			v.vertex.xyz += v.normal * _Outline;
		}
		
		struct Input 
		{
			float2 uv_tex1;
		};
		
		void surf (Input IN, inout SurfaceOutput o) 
		{
			o.Albedo = _OutlineColor.rgb;
			o.Alpha = _OutlineColor.a;

		}
		ENDCG
		
		
		Cull Back
		ZWrite On

		CGPROGRAM
		#pragma surface surf Lambert //vertex:vert
		
		sampler2D _MainTex;

		fixed _light;

		struct Input 
		{
			fixed4 color:COLOR;
			float2 uv_MainTex;
		};
		


		void surf (Input IN, inout SurfaceOutput o) 
		{
			fixed4 c;

				c = tex2D(_MainTex,IN.uv_MainTex);

			o.Emission = _light;
			o.Albedo = c;
			//o.Alpha = c.a;
		}
		ENDCG

	}
	

	Fallback "Diffuse"

}