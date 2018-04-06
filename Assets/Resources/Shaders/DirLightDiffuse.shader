Shader "Custom/DirLightDiffuse" 
{ 
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_light("light",Range (0,1.0)) = 0.0
		
		_DirColor ("Dir Color", Color) = (0.996078,0.94902,0.83922,1)
		_DirPower ("Dir Power", float) = 2.0

		_LightDir ("light dir", Vector) = (0,0,0,0)

	}
	
	SubShader 
	{
		LOD 200
		Tags 
		{
			"IgnoreProjector" = "True"
			"RenderType" = "Opaque"
			//"CastShadows" = "True"				
		}
		



		CGPROGRAM
		#pragma surface surf Lambert  vertex:vert
		
		sampler2D _MainTex;
		half _light;
		
		float4 _DirColor;
		fixed _DirPower;
		//fixed _AllPower;
		

		fixed4 _LightDir;



		struct Input 
		{
			fixed3 color:COLOR;
			float2 uv_MainTex;
			//float3 viewDir;
		};
		


		void vert (inout appdata_full v) 
		{		
			//fixed3 viewDir = WorldSpaceViewDir(v.vertex); 
			//viewDir = normalize(viewDir);
			fixed3 nor = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject).xyz);  
			
			v.color.rgb = _DirColor.rgb * max(dot(nor,_LightDir.xyz),0) * _DirPower;
		}


		void surf (Input IN, inout SurfaceOutput o) 
		{
			fixed4 c;
			c = tex2D(_MainTex,IN.uv_MainTex);
			o.Albedo = c.rgb + c.rgb * IN.color.rgb;
			//o.Albedo.rgb = o.Albedo.rgb + o.Albedo.rgb * IN.color.rgb;
			//o.Albedo =  IN.color.rgb;
			o.Emission = _light;
			//o.Albedo = IN.color.rgb;
			//o.Albedo = o.Normal;
		}
		ENDCG
	}
		
	Fallback "Diffuse"

}