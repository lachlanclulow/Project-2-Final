/* Author: prime[31]
* Date accessed: 9/10/2016
* From Tutorial series:
* https://www.youtube.com/watch?v=hDJQXzajiPg&list=PLb8LPjN5zpx1tauZfNE1cMIIPy15UlJNZ
*
* Modified by: Lachlan Clulow
* Date: 16/10/2016
*/

Shader "_Shaders/Pixel Lit Shader Asteroid" {
	Properties{
		_Color("Diffuse Material Color", Color) = (1,1,1,1)
		_MainTex("Base RGB", 2D) = "white" {}
		_SpecColor("Specular Material Color", Color) = (1,1,1,1)
		_Shininess("Shininess", Float) = 10
		_LightPositions("Lights", Float) = 5
	}

	SubShader
	{

		Pass
	{

// Pass for ambient lighting and primary light source
Tags{ "Queue" = "Geometry" "LightMode" = "ForwardBase" }


CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#define MAX_LIGHTS 4

#include "UnityCG.cginc"
// uniforms
uniform sampler2D _MainTex;
uniform float4 _MainTex_ST;
uniform fixed4 _Color;
uniform fixed4 _LightColor0;
uniform fixed4 _SpecColor;
uniform float _Shininess;

struct vertexInput
{
	float4 vertex : POSITION;
	float3 normal : NORMAL;
	float4 texcoord : TEXCOORD;
	fixed4 color : COLOR;
};

struct fragmentInput
{
	float4 pos : SV_POSITION;
	float4 color : COLOR0;
	half2 uv : TEXCOORD0;
	float4 worldVertex : TEXCOORD1;
	float3 worldNormal : TEXCOORD2;
};

fragmentInput vert(vertexInput i)
{
	fragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.uv = TRANSFORM_TEX(i.texcoord, _MainTex);
	o.color = fixed4(_Color.rgb, i.color.a);

	float4 worldVertex = mul(_Object2World, i.vertex);
	float3 worldNormal = 
		normalize(mul(transpose((float3x3)_World2Object), i.normal.xyz));

	o.worldVertex = worldVertex;
	o.worldNormal = worldNormal;

	return o;
}

half4 frag(fragmentInput i) : COLOR
{
	float3 interpolatedNormal = normalize(i.worldNormal);

	float3 diffuse = float3(0.0, 0.0, 0.0);
	float3 specular = float3(0.0, 0.0, 0.0);

	// Calculate Diffuse Componenent
	float3 lightDirection = WorldSpaceLightDir(i.worldVertex);
	float attenuation = 1.0 / length(lightDirection);
	lightDirection = normalize(lightDirection);
	float ndotl = dot(interpolatedNormal, lightDirection);
	diffuse += attenuation * _LightColor0.rgb * _Color.rgb * max(0.0, ndotl);

	// Calculate Specular Component
	float3 viewDirection = WorldSpaceLightDir(i.worldVertex);

	if (ndotl > 0)
	{
		float3 reflection = reflect(-lightDirection, interpolatedNormal);
		float rdotv = pow(max(0.0, dot(reflection, viewDirection)), _Shininess);
		specular += attenuation * _LightColor0.rgb * _SpecColor.rgb * rdotv;
	}

	return tex2D(_MainTex, i.uv) * float4(diffuse + specular, i.color.a);
}


ENDCG
		} // end pass
		Pass
	{

// Pass for other light sources
Tags{ "LightMode" = "ForwardAdd" }
Blend One One

CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#define MAX_LIGHTS 4

#include "UnityCG.cginc"

// uniforms
uniform fixed4 _Color;
uniform fixed4 _LightColor0;
uniform fixed4 _SpecColor;
uniform float _Shininess;

struct vertexInput
{
	float4 vertex : POSITION;
	float3 normal : NORMAL;
	fixed4 color : COLOR;
};

struct fragmentInput
{
	float4 pos : SV_POSITION;
	float4 color : COLOR0;
	float4 worldVertex : TEXCOORD1;
	float3 worldNormal : TEXCOORD2;
};

fragmentInput vert(vertexInput i)
{
	fragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.color = fixed4(_Color.rgb, i.color.a);

	float4 worldVertex = mul(_Object2World, i.vertex);
	float3 worldNormal = normalize(mul(transpose((float3x3)_World2Object), i.normal.xyz));

	o.worldVertex = worldVertex;
	o.worldNormal = worldNormal;

	return o;
}

half4 frag(fragmentInput i) : COLOR
{
	float3 interpolatedNormal = normalize(i.worldNormal);

	// Calculate Diffuse Componenent
	float3 lightDirection = WorldSpaceLightDir(i.worldVertex);
	float attenuation = 1.0 / length(lightDirection);
	lightDirection = normalize(lightDirection);
	float ndotl = dot(interpolatedNormal, lightDirection);
	float3 diffuse = attenuation * _LightColor0.rgb * _Color.rgb * max(0.0, ndotl);

	// Calculate Specular Component
	float3 viewDirection = normalize(_WorldSpaceCameraPos - i.worldVertex.xyz);
	float3 specular;

	if (ndotl > 0)
	{
		float3 reflection = reflect(-lightDirection, interpolatedNormal);
		float rdotv = pow(max(0.0, dot(reflection, viewDirection)), _Shininess);
		specular = attenuation * _LightColor0.rgb * _SpecColor.rgb * rdotv;
	}

	return float4(diffuse + specular, i.color.a);
}

ENDCG
		} // end pass
	}
	FallBack "Specular"
}
