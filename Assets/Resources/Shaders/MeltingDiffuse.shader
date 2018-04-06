Shader "Custom/MeltingDiffuse" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MainLight("MainLight",float)=0					//亮度
		//_MainAlpha("MainAlpha",Range (0,0.9))=0
		//_Color ("Main Color", Color) = (1,1,0,1)
		_MaskMap ("MaskMap", 2D) = "white" {}		//溶解遮罩贴图
		_MaskRp("MaskRp",float)=1
		_Amount ("Amount", Range (0, 1)) = 0		//溶解状态
		//_Cutout ("Cutout", Range (0, 1)) = 0		//溶解状态

		_AdgeColor ("Adge Color", Color) = (1,1,0,1)	//
		_AdgePower ("Adge Power", Range (0, 0.1)) = 0

	}
	SubShader {
		//Tags {"Queue"="Transparent" "RenderType"="TransparentCutout"}
		LOD 200
		Tags 
		{
			"IgnoreProjector" = "True"
			"RenderType" = "Opaque"
			//"CastShadows" = "True"	
			"Queue"="Transparent"			
		}

		Blend SrcAlpha  OneMinusSrcAlpha  


		//ZWrite On
        //ZTest LEqual

        //AlphaTest Greater 0.4 
        //AlphaTest LEqual 0.4

		CGPROGRAM
		//half _Cutout = 0.4;
		#pragma surface surf Lambert alphatest:_Cutout


		sampler2D _MainTex;
		
		half _MainLight;
		sampler2D _MaskMap;
		//half _MainAlpha;
		//half3 _Color;
		half _Amount;
		half _MaskRp;

		half4 _AdgeColor;
		float _AdgePower;

		struct Input {
			float2 uv_MainTex;
			//float4 color:COLOR;
			float2 uv_MaskMap;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			half4 c = tex2D(_MainTex,IN.uv_MainTex);	
			
			half4 h =tex2D(_MaskMap, IN.uv_MaskMap*_MaskRp);
			float ClipAmount = h.x - _Amount;
			
			
			//else
			//o.Alpha = ClipAmount;		
			if(ClipAmount > _AdgePower)	//显示主颜色
			{
				o.Albedo = c.rgb;
				o.Alpha=1;
			}
			else if(ClipAmount>0)		//显示边缘
			{
				o.Albedo = _AdgeColor.rgb;
				o.Alpha = _AdgeColor.a;
			}
			else			//显示已经溶解;
			{
				o.Alpha=0;
			}

			o.Emission = _MainLight;//_Color.rgb*_MainAlpha;
						//o.Alpha=0;
		}
		ENDCG
	} 
	FallBack "Transparent/VertexLit"
}
