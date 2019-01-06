Shader "Custom/Appearance" {
	Properties{
		_MainTexture("Main Texture", 2D) = "white" {}
		_DissolveTexture("Dissolve (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1)
		[NoScaleOffset] _EmissionMap("Emission Map", 2D) = "black" {}
		[HDR] _Emission("Emission", Color) = (0,0,0)
		 _DissolveScale("Dissolve", Range(-0.5,2.5)) = 0
		_DissolveStart("Starting Point", Vector) = (0,1,0)
		 _DissolveEnd("End Point", Vector) = (0,0,0)
		_DissolveWidth("Width", Range(0,1)) = 1
		_GlowIntensity("Glow Intensity", Range(0.0, 5.0)) = 0.05
		_GlowScale("Glow Size", Range(0.0, 5.0)) = 1.0
		[HDR] _Glow("Glow Color", Color) = (1, 1, 1, 1)
		[HDR] _GlowEnd("Glow End Color", Color) = (1, 1, 1, 1)
		_GlowColFac("Glow Colorshift", Range(0.01, 2.0)) = 0.75
		_NoiseResolution("Noise Resolution", Vector) = (0,0,0)
	}
		SubShader{
			Tags { "Queue" = "Opaque " "RenderType" = "Transparent" }

			CGPROGRAM
				#include "UnityCG.cginc"
				#pragma surface surf Standard alpha:fade vertex:vert
				#pragma target 3.0


				sampler2D _MainTexture;
				sampler2D _DissolveTexture;
				sampler2D _EmissionMap;
				float3 _Emission;
				float _DissolveScale;
				float3 _DissolveStart;
				float3 _DissolveEnd;
				float3 _Color;
				float _DissolveWidth;
				float _GlowScale;
				float _GlowIntensity;
				float4 _Glow;
				float4 _GlowEnd;
				float _GlowColFac;
				float2 _NoiseResolution;

				float4 _MainTex_ST;
				struct Input {
					float2 uv_MainTexture;
					float3 dGeometry;
				};


				static float3 dDir = normalize(_DissolveEnd - _DissolveStart);
				static float3 dissolveStartConverted = _DissolveStart - _DissolveWidth * dDir;
				static float dBandFactor = 1.0f / _DissolveWidth;

				float3 mod289(float3 x)
				{
					return x - floor(x * (1.0 / 289.0)) * 289.0;
				}

				float2 mod289(float2 x)
				{
					return x - floor(x * (1.0 / 289.0)) * 289.0;
				}

				float3 permute(float3 x) {
					return mod289(((x*34.0) + 1.0)*x);
				}

				float3 fract(float3 st) {
					return st - floor(st);
				}

				float2 fract(float2 st) {
					return st - floor(st);
				}

				float fract(float st) {
					return st - floor(st);
				}

				float2 random2(float2 p) {
					return fract(sin(float2(dot(p,float2(127.1,311.7)),dot(p,float2(269.5,183.3))))*43758.5453);
				}

				float snoise(float2 v) {
					const float4 c = float4(0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439);
					float2 i = floor(v + dot(v, c.yy));
					float2 x0 = v - i + dot(i,c.xx);
					float2 i1;
					i1 = (x0.x > x0.y) ? float2(1.0, 0.0) : float2(0.0, 1.0);
					float4 x12 = x0.xyxy + c.xxzz;
					x12.xy -= i1;
					i = mod289(i);
					float3 p = permute(permute(i.y + float3(0.0, i1.y, 1.0))
						+ i.x + float3(0.0, i1.x, 1.0));

					float3 m = max(0.5 - float3(dot(x0,x0), dot(x12.xy,x12.xy), dot(x12.zw,x12.zw)), 0.0);
					m = m * m;
					m = m * m;
					float3 x = 2.0 * fract(p * c.www) - 1.0;
					float3 h = abs(x) - 0.5;
					float3 ox = floor(x + 0.5);
					float3 a0 = x - ox;
					m *= 1.79284291400159 - 0.85373472095314 * (a0*a0 + h * h);
					float3 g;
					g.x = a0.x  * x0.x + h.x  * x0.y;
					g.yz = a0.yz * x12.xz + h.yz * x12.yw;
					return 130.0 * dot(m, g);
				}

				/*float3 smoothstep(edge0, edge1, x) {
					t = clamp(float3((x - edge0) / (edge1 - edge0), 0.0, 1.0));
					return t * t * (3.0 - 2.0 * t);
				}*/

				float2 skew(float2 st) {
					float2 r = float2(0,0);
					r.x = 1.1547 * st.x;
					r.y = st.y + 0.5 * r.x;
					return r;
				}

				float3 simplexGrid(float2 st) {
					float3 xyz = float3(0,0,0);

					float2 p = fract(skew(st));
					if (p.x > p.y) {
						xyz.xy = 1.0 - float2(p.x, p.y - p.x);
						xyz.z = p.y;
					}
	 else {
	  xyz.yz = 1.0 - float2(p.x - p.y, p.y);
	  xyz.x = p.x;
  }

  return fract(xyz);
}

float3 CellularNoise(float2 st) {
	float3 color = float3(0,0,0);
	st *= 2.0;

	float2 i_st = floor(st);
	float2 f_st = fract(st);
	float m_dist = 1.0;

	for (int i = -1; i <= 1; i++) {
		for (int j = -1; j <= 1; j++) {
			float2 neighbour = float2(i, j);
			float2 p = random2(i_st + neighbour);
			p = 0.5 + 0.5*sin(_Time.y *0.2 + 6.2831*p);

			float2 diff = neighbour + p - f_st;
			float dist = length(diff) * 1.7;

			m_dist = min(m_dist, dist);
		}
	}

	color += m_dist;

	return color;
}

float3 GetEmission(Input i) {
	float3 color = (.0, .0, .0);
	/*float2 st = i.uv_MainTexture / _NoiseResolution;
	st.x *= _NoiseResolution.x / _NoiseResolution.y;


	float t = fract(1 - _Time.y * 0.5) * 5;

	if (i.uv_MainTexture.y > t && i.uv_MainTexture.y <= t + 0.15)
		color = float3(1.,1.,1.);*/

	return tex2D(_EmissionMap, i.uv_MainTexture) * _Emission;
}

void vert(inout appdata_full v, out Input o) {
	UNITY_INITIALIZE_OUTPUT(Input,o);

	o.uv_MainTexture = TRANSFORM_TEX(o.uv_MainTexture, _MainTex);
	float3 dPoint = lerp(dissolveStartConverted, _DissolveEnd, _DissolveScale);
	o.dGeometry = dot(v.vertex - dPoint, dDir) * dBandFactor;
}

void surf(Input IN, inout SurfaceOutputStandard o) {
	half dBase = -2.0f * _DissolveScale + 1.0f;

	fixed4 mTex = tex2D(_MainTexture, IN.uv_MainTexture);
	fixed4 dTex = tex2D(_DissolveTexture, IN.uv_MainTexture);

	half dTexRead = dTex.r + dBase;
	half dFinal = dTexRead + IN.dGeometry;

	half dPredict = (_GlowScale - dFinal) * _GlowIntensity;
	half dPredictCol = (_GlowScale * _GlowColFac - dFinal) * _GlowIntensity;

	fixed3 glowCol = dPredict * lerp(_Glow, _GlowEnd, clamp(dPredictCol, 0.0f, 1.0f));
	glowCol = clamp(glowCol, 0.0f, 1.0f);

	half alpha = clamp(dFinal, 0.0f, 1.0f);

	o.Emission = glowCol + GetEmission(IN);
	o.Albedo = mTex.rgb * _Color.rgb;
	o.Alpha = alpha;
}
ENDCG
		}
			FallBack "Diffuse"
}