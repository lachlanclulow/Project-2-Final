/* Author: prime[31]
* Date accessed: 9/10/2016
* From Tutorial series:
* https://www.youtube.com/watch?v=hDJQXzajiPg&list=PLb8LPjN5zpx1tauZfNE1cMIIPy15UlJNZ
*
* Modified by: Lachlan Clulow
* Date: 16/10/2016
*/

Shader "_Shaders/SimpleTexture" 
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white" {}
	}

	SubShader
	{
		Tags {"Queue" = "Transparent"}
		ZWrite off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

//uniforms
uniform sampler2D _MainTex;
uniform float4 _MainTex_ST;


struct vertexInput
{
	float4 vertex : POSITION;
	float4 texcoord : TEXCOORD0;
};

struct fragmentInput
{
	float4 pos : SV_POSITION;
	half2 uv : TEXCOORD0;
};

fragmentInput vert(vertexInput i)
{
	fragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.uv = TRANSFORM_TEX(i.texcoord, _MainTex);

	return o;
}

half4 frag(fragmentInput i) : COLOR
{
	return tex2D( _MainTex, i.uv );
}

ENDCG
		}
	}
	FallBack "Diffuse"
}
