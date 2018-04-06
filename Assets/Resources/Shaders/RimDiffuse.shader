Shader "Custom/RimDiffuse" 
{ 
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_light("light",Range (0,1.0)) = 0.0
		
		_RimColor ("Rim Color", Color) = (0.93333,0.8745,0.74118,1)
		_RimPower ("Rim Power", Range(0.0,10.0)) = 5
		_AllPower ("All Power", Range(0.0, 10.0)) = 3.1


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
		
		float4 _RimColor;
		fixed _RimPower;
		fixed _AllPower;
		




		struct Input 
		{
			fixed3 color:COLOR;
			float2 uv_MainTex;
			float3 viewDir;
		};
		

		fixed OverlayBlendMode(fixed basePixel, fixed blendPixel) 
		{  
		    if (basePixel < 0.5) {  
		        return (2.0 * basePixel * blendPixel);  
		    } else {  
		        return (1.0 - 2.0 * (1.0 - basePixel) * (1.0 - blendPixel));  
		    }  
		}  

		fixed Lvse(fixed basePixel, fixed blendPixel)  
		{		
			//fixed re = ;
			//fixed re1 = ;
			return (1 - (1-basePixel)*(1-blendPixel));
		}

		void vert (inout appdata_full v) 
		{
		
			fixed3 viewDir = WorldSpaceViewDir(v.vertex); 
			viewDir = normalize(viewDir);
			fixed3 nor = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject).xyz);  
			
			fixed rim = 1.0 - saturate(dot (viewDir,nor));
			

		
			//if(rim > 0.03)
			{
				fixed3 emi_color = _RimColor.rgb * pow (rim, _RimPower)*_AllPower;
				v.color.rgb = emi_color;
			}
			/*
			else
			{
				v.color = 0;
			}
			*/
			//v.color.rgb = nor;
			//v.color.rgb = viewDir;
			//v.color.r = rim;
			//v.color.g = 0;
			//v.color.b = 0;
		}


		void surf (Input IN, inout SurfaceOutput o) 
		{
			fixed4 c;

			c = tex2D(_MainTex,IN.uv_MainTex);

			o.Albedo = c;
			//o.Albedo +=  IN.color.rgb;
/*
			o.Albedo.r = Lvse(o.Albedo.r,IN.color.r);
			o.Albedo.g = Lvse(o.Albedo.g,IN.color.g);
			o.Albedo.b = Lvse(o.Albedo.b,IN.color.b);
*/
			o.Albedo.rgb = o.Albedo.rgb + o.Albedo.rgb * IN.color.rgb;
//o.Albedo =  IN.color.rgb;
			o.Emission = _light;

			//o.Albedo = IN.color.rgb;
			//o.Albedo = o.Normal;

		}
		ENDCG
	}
		
	Fallback "Diffuse"

}