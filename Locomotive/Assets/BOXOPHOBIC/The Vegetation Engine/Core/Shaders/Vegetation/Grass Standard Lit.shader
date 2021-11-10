// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "BOXOPHOBIC/The Vegetation Engine/Vegetation/Grass Standard Lit"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HideInInspector]_IsVersion("_IsVersion", Float) = 460
		[StyledCategory(Render Settings, 5, 10)]_RenderingCat("[ Rendering Cat ]", Float) = 0
		[HideInInspector]_IsTVEShader("_IsTVEShader", Float) = 1
		[HideInInspector]_vertex_pivot_mode("_vertex_pivot_mode", Float) = 0
		[Enum(Opaque,0,Transparent,1)]_RenderMode("Render Mode", Float) = 0
		[Enum(Off,0,On,1)]_RenderZWrite("Render ZWrite", Float) = 1
		[IntRange]_RenderPriority("Render Priority", Range( -100 , 100)) = 0
		[Enum(Both,0,Back,1,Front,2)]_RenderCull("Render Faces", Float) = 0
		[Enum(Flip,0,Mirror,1,Same,2)]_RenderNormals("Render Normals", Float) = 0
		[StyledSpace(10)]_ReceiveSpace("# Receive Space", Float) = 0
		[Enum(Off,0,On,1)]_RenderSpecular("Receive Specular", Float) = 1
		[Enum(Off,0,On,1)]_RenderDecals("Receive Decals", Float) = 0
		[Enum(Off,0,On,1)]_RenderSSR("Receive SSR/SSGI", Float) = 0
		[Enum(Off,0,On,1)][Space(10)]_RenderClip("Alpha Clipping", Float) = 1
		_Cutoff("Alpha Treshold", Range( 0 , 1)) = 0.5
		[StyledSpace(10)]_FadeSpace("# Fade Space", Float) = 0
		[StyledCategory(Global Settings)]_GlobalCat("[ Global Cat ]", Float) = 0
		[StyledEnum(Default _Layer 1 _Layer 2 _Layer 3 _Layer 4 _Layer 5 _Layer 6 _Layer 7 _Layer 8)]_LayerColorsValue("Layer Colors", Float) = 0
		[StyledEnum(Default _Layer 1 _Layer 2 _Layer 3 _Layer 4 _Layer 5 _Layer 6 _Layer 7 _Layer 8)]_LayerExtrasValue("Layer Extras", Float) = 0
		[StyledEnum(Default _Layer 1 _Layer 2 _Layer 3 _Layer 4 _Layer 5 _Layer 6 _Layer 7 _Layer 8)]_LayerMotionValue("Layer Motion", Float) = 0
		[StyledEnum(Default _Layer 1 _Layer 2 _Layer 3 _Layer 4 _Layer 5 _Layer 6 _Layer 7 _Layer 8)]_LayerReactValue("Layer React", Float) = 0
		[StyledSpace(10)]_LayersSpace("# Layers Space", Float) = 0
		[StyledMessage(Info, Procedural Variation in use. The Variation might not work as expected when switching from one LOD to another., _VertexVariationMode, 1 , 0, 10)]_VariationGlobalsMessage("# Variation Globals Message", Float) = 0
		_GlobalColors("Global Colors", Range( 0 , 1)) = 1
		_GlobalOverlay("Global Overlay", Range( 0 , 1)) = 1
		_GlobalWetness("Global Wetness", Range( 0 , 1)) = 1
		_GlobalEmissive("Global Emissive", Range( 0 , 1)) = 1
		_GlobalAlpha("Global Alpha", Range( 0 , 1)) = 1
		_GlobalSize("Global Size", Range( 0 , 1)) = 1
		[StyledRemapSlider(_ColorsMaskMinValue, _ColorsMaskMaxValue, 0, 1, 10, 0)]_ColorsMaskRemap("Colors Mask", Vector) = (0,0,0,0)
		[HideInInspector]_ColorsMaskMinValue("Colors Mask Min Value", Range( 0 , 1)) = 0
		[HideInInspector]_ColorsMaskMaxValue("Colors Mask Max Value", Range( 0 , 1)) = 1
		_ColorsVariationValue("Colors Variation", Range( 0 , 1)) = 0
		[StyledRemapSlider(_OverlayMaskMinValue, _OverlayMaskMaxValue, 0, 1, 10, 0)]_OverlayMaskRemap("Overlay Mask", Vector) = (0,0,0,0)
		[HideInInspector]_OverlayMaskMinValue("Overlay Mask Min Value", Range( 0 , 1)) = 0.45
		[HideInInspector]_OverlayMaskMaxValue("Overlay Mask Max Value", Range( 0 , 1)) = 0.55
		_OverlayVariationValue("Overlay Variation", Range( 0 , 1)) = 0
		[Space(10)]_AlphaVariationValue("Alpha Variation", Range( 0 , 1)) = 1
		[StyledCategory(Main Settings)]_MainCat("[ Main Cat ]", Float) = 0
		[NoScaleOffset][StyledTextureSingleLine]_MainAlbedoTex("Main Albedo", 2D) = "white" {}
		[NoScaleOffset][StyledTextureSingleLine]_MainNormalTex("Main Normal", 2D) = "bump" {}
		[NoScaleOffset][StyledTextureSingleLine]_MainMaskTex("Main Mask", 2D) = "white" {}
		[Space(10)][StyledVector(9)]_MainUVs("Main UVs", Vector) = (1,1,0,0)
		[HDR]_MainColor("Main Color", Color) = (1,1,1,1)
		_MainNormalValue("Main Normal", Range( -8 , 8)) = 1
		_MainOcclusionValue("Main Occlusion", Range( 0 , 1)) = 1
		_MainSmoothnessValue("Main Smoothness", Range( 0 , 1)) = 1
		[StyledCategory(Detail Settings)]_DetailCat("[ Detail Cat ]", Float) = 0
		[Enum(Off,0,On,1)]_DetailMode("Detail Mode", Float) = 0
		[Enum(Overlay,0,Replace,1)]_DetailBlendMode("Detail Blend", Float) = 1
		[Enum(Vertex Blue,0,Projection,1)]_DetailTypeMode("Detail Type", Float) = 0
		[StyledSpace(10)]_DetailSpace("# Detail Space", Float) = 0
		[StyledRemapSlider(_DetailBlendMinValue, _DetailBlendMaxValue,0,1)]_DetailBlendRemap("Detail Blending", Vector) = (0,0,0,0)
		[StyledCategory(Occlusion Settings)]_OcclusionCat("[ Occlusion Cat ]", Float) = 0
		[HDR]_VertexOcclusionColor("Vertex Occlusion Color", Color) = (1,1,1,1)
		[StyledRemapSlider(_VertexOcclusionMinValue, _VertexOcclusionMaxValue, 0, 1)]_VertexOcclusionRemap("Vertex Occlusion Mask", Vector) = (0,0,0,0)
		[HideInInspector]_VertexOcclusionMinValue("Vertex Occlusion Min Value", Range( 0 , 1)) = 0
		[HideInInspector]_VertexOcclusionMaxValue("Vertex Occlusion Max Value", Range( 0 , 1)) = 1
		[StyledCategory(Subsurface Settings)]_SubsurfaceCat("[ Subsurface Cat ]", Float) = 0
		_SubsurfaceValue("Subsurface Intensity", Range( 0 , 1)) = 1
		[HDR]_SubsurfaceColor("Subsurface Color", Color) = (0.4,0.4,0.1,1)
		[StyledRemapSlider(_SubsurfaceMaskMinValue, _SubsurfaceMaskMaxValue,0,1)]_SubsurfaceMaskRemap("Subsurface Mask", Vector) = (0,0,0,0)
		[HideInInspector]_SubsurfaceMaskMinValue("Subsurface Mask Min Value", Range( 0 , 1)) = 0
		[HideInInspector]_SubsurfaceMaskMaxValue("Subsurface Mask Max Value", Range( 0 , 1)) = 1
		[Space(10)][DiffusionProfile]_SubsurfaceDiffusion("Subsurface Diffusion", Float) = 0
		[HideInInspector]_SubsurfaceDiffusion_Asset("Subsurface Diffusion", Vector) = (0,0,0,0)
		[HideInInspector][Space(10)][ASEDiffusionProfile(_SubsurfaceDiffusion)]_SubsurfaceDiffusion_asset("Subsurface Diffusion", Vector) = (0,0,0,0)
		[Space(10)]_MainLightScatteringValue("Subsurface Scattering Intensity", Range( 0 , 16)) = 8
		_MainLightAngleValue("Subsurface Scattering Angle", Range( 0 , 16)) = 8
		[Space(10)]_TranslucencyIntensityValue("Translucency Intensity", Range( 0 , 50)) = 1
		_TranslucencyNormalValue("Translucency Normal", Range( 0 , 1)) = 0.1
		_TranslucencyScatteringValue("Translucency Scattering", Range( 1 , 50)) = 2
		_TranslucencyDirectValue("Translucency Direct", Range( 0 , 1)) = 1
		_TranslucencyAmbientValue("Translucency Ambient", Range( 0 , 1)) = 0.2
		_TranslucencyShadowValue("Translucency Shadow", Range( 0 , 1)) = 1
		[StyledMessage(Warning,  Translucency is not supported in HDRP. Diffusion Profiles will be used instead., 10, 5)]_TranslucencyHDMessage("# Translucency HD Message", Float) = 0
		[StyledCategory(Gradient Settings)]_GradientCat("[ Gradient Cat ]", Float) = 0
		[HDR]_GradientColorOne("Gradient Color One", Color) = (1,1,1,1)
		[HDR]_GradientColorTwo("Gradient Color Two", Color) = (1,1,1,1)
		[StyledRemapSlider(_GradientMinValue, _GradientMaxValue, 0, 1)]_GradientMaskRemap("Gradient Mask", Vector) = (0,0,0,0)
		[HideInInspector]_GradientMinValue("Gradient Mask Min", Range( 0 , 1)) = 0
		[HideInInspector]_GradientMaxValue("Gradient Mask Max ", Range( 0 , 1)) = 1
		[StyledCategory(Noise Settings)]_NoiseCat("[ Noise Cat ]", Float) = 0
		[HDR]_NoiseColorOne("Noise Color One", Color) = (1,1,1,1)
		[HDR]_NoiseColorTwo("Noise Color Two", Color) = (1,1,1,1)
		[StyledRemapSlider(_NoiseMinValue, _NoiseMaxValue, 0, 1)]_NoiseMaskRemap("Noise Mask", Vector) = (0,0,0,0)
		[HideInInspector]_NoiseMinValue("Noise Mask Min", Range( 0 , 1)) = 0
		[HideInInspector]_NoiseMaxValue("Noise Mask Max ", Range( 0 , 1)) = 1
		_NoiseScaleValue("Noise Scale", Range( 0 , 1)) = 0.01
		[StyledCategory(Emissive Settings)]_EmissiveCat("[ Emissive Cat]", Float) = 0
		[NoScaleOffset][StyledTextureSingleLine]_EmissiveTex("Emissive Texture", 2D) = "white" {}
		[Space(10)][StyledVector(9)]_EmissiveUVs("Emissive UVs", Vector) = (1,1,0,0)
		[Enum(None,0,Any,10,Baked,20,Realtime,30)]_EmissiveFlagMode("Emissive Baking", Float) = 0
		[HDR]_EmissiveColor("Emissive Color", Color) = (0,0,0,0)
		[StyledEmissiveIntensity]_EmissiveIntensityParams("Emissive Intensity", Vector) = (1,1,1,0)
		[StyledCategory(Perspective Settings)]_PerspectiveCat("[ Perspective Cat ]", Float) = 0
		_PerspectivePushValue("Perspective Push", Range( 0 , 4)) = 0
		_PerspectiveNoiseValue("Perspective Noise", Range( 0 , 4)) = 0
		_PerspectiveAngleValue("Perspective Angle", Range( 0 , 8)) = 1
		[StyledCategory(Size Fade Settings)]_SizeFadeCat("[ Size Fade Cat ]", Float) = 0
		[StyledMessage(Info, The Size Fade feature is recommended to be used to fade out vegetation at a distance in combination with the LOD Groups or with a 3rd party culling system., _SizeFadeMode, 1, 0, 10)]_SizeFadeMessage("# Size Fade Message", Float) = 0
		[Enum(Off,0,On,1)]_SizeFadeMode("Size Fade Mode", Float) = 0
		_SizeFadeStartValue("Size Fade Start", Float) = 200
		_SizeFadeEndValue("Size Fade End", Float) = 300
		[StyledCategory(Motion Settings)]_MotionCat("[ Motion Cat ]", Float) = 0
		[StyledMessage(Info, Procedural variation in use. Use the Scale settings if the Variation is breaking the bending and rolling animation., _VertexVariationMode, 1 , 0, 10)]_VariationMotionMessage("# Variation Motion Message", Float) = 0
		[HDR]_MotionHighlightColor("Motion Highlight", Color) = (2,2,2,1)
		[StyledSpace(10)]_MotionSpace("# Motion Space", Float) = 0
		_MotionAmplitude_10("Bending Amplitude", Range( 0 , 2)) = 0.05
		[IntRange]_MotionSpeed_10("Bending Speed", Range( 0 , 60)) = 2
		_MotionScale_10("Bending Scale", Range( 0 , 20)) = 0
		_MotionVariation_10("Bending Variation", Range( 0 , 20)) = 0
		[Space(10)]_MotionAmplitude_32("Flutter Amplitude", Range( 0 , 2)) = 0.2
		[IntRange]_MotionSpeed_32("Flutter Speed", Range( 0 , 60)) = 20
		_MotionScale_32("Flutter Scale", Range( 0 , 20)) = 2
		_MotionVariation_32("Flutter Variation", Range( 0 , 20)) = 2
		[Space(10)]_InteractionAmplitude("Interaction Amplitude", Range( 0 , 10)) = 1
		[ASEEnd]_InteractionVariation("Interaction Variation", Range( 0 , 1)) = 0
		[HideInInspector][Enum(Single Pivot,0,Baked Pivots,1)]_VertexPivotMode("Enable Prebaked Pivots", Float) = 0
		[HideInInspector][StyledToggle]_VertexDataMode("Enable Batching Support", Float) = 0
		[HideInInspector]_Color("Legacy Color", Color) = (0,0,0,0)
		[HideInInspector]_MainTex("Legacy MainTex", 2D) = "white" {}
		[HideInInspector]_BumpMap("Legacy BumpMap", 2D) = "white" {}
		[HideInInspector]_render_normals_options("_render_normals_options", Vector) = (1,1,1,0)
		[HideInInspector]_MaxBoundsInfo("_MaxBoundsInfo", Vector) = (1,1,1,1)
		[HideInInspector]_VertexVariationMode("_VertexVariationMode", Float) = 0
		[HideInInspector]_VertexMasksMode("_VertexMasksMode", Float) = 0
		[HideInInspector]_IsGrassShader("_IsGrassShader", Float) = 1
		[HideInInspector]_IsStandardShader("_IsStandardShader", Float) = 1
		[HideInInspector]_render_cull("_render_cull", Float) = 0
		[HideInInspector]_render_src("_render_src", Float) = 1
		[HideInInspector]_render_dst("_render_dst", Float) = 0
		[HideInInspector]_render_zw("_render_zw", Float) = 1

		//_TransmissionShadow( "Transmission Shadow", Range( 0, 1 ) ) = 0.5
		//_TransStrength( "Trans Strength", Range( 0, 50 ) ) = 1
		//_TransNormal( "Trans Normal Distortion", Range( 0, 1 ) ) = 0.5
		//_TransScattering( "Trans Scattering", Range( 1, 50 ) ) = 2
		//_TransDirect( "Trans Direct", Range( 0, 1 ) ) = 0.9
		//_TransAmbient( "Trans Ambient", Range( 0, 1 ) ) = 0.1
		//_TransShadow( "Trans Shadow", Range( 0, 1 ) ) = 0.5
		//_TessPhongStrength( "Tess Phong Strength", Range( 0, 1 ) ) = 0.5
		//_TessValue( "Tess Max Tessellation", Range( 1, 32 ) ) = 16
		//_TessMin( "Tess Min Distance", Float ) = 10
		//_TessMax( "Tess Max Distance", Float ) = 25
		//_TessEdgeLength ( "Tess Edge length", Range( 2, 50 ) ) = 16
		//_TessMaxDisp( "Tess Max Displacement", Float ) = 25
	}

	SubShader
	{
		LOD 0

		

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Opaque" "Queue"="Geometry" }
		Cull [_render_cull]
		AlphaToMask Off
		HLSLINCLUDE
		#pragma target 4.0

		#ifndef ASE_TESS_FUNCS
		#define ASE_TESS_FUNCS
		float4 FixedTess( float tessValue )
		{
			return tessValue;
		}
		
		float CalcDistanceTessFactor (float4 vertex, float minDist, float maxDist, float tess, float4x4 o2w, float3 cameraPos )
		{
			float3 wpos = mul(o2w,vertex).xyz;
			float dist = distance (wpos, cameraPos);
			float f = clamp(1.0 - (dist - minDist) / (maxDist - minDist), 0.01, 1.0) * tess;
			return f;
		}

		float4 CalcTriEdgeTessFactors (float3 triVertexFactors)
		{
			float4 tess;
			tess.x = 0.5 * (triVertexFactors.y + triVertexFactors.z);
			tess.y = 0.5 * (triVertexFactors.x + triVertexFactors.z);
			tess.z = 0.5 * (triVertexFactors.x + triVertexFactors.y);
			tess.w = (triVertexFactors.x + triVertexFactors.y + triVertexFactors.z) / 3.0f;
			return tess;
		}

		float CalcEdgeTessFactor (float3 wpos0, float3 wpos1, float edgeLen, float3 cameraPos, float4 scParams )
		{
			float dist = distance (0.5 * (wpos0+wpos1), cameraPos);
			float len = distance(wpos0, wpos1);
			float f = max(len * scParams.y / (edgeLen * dist), 1.0);
			return f;
		}

		float DistanceFromPlane (float3 pos, float4 plane)
		{
			float d = dot (float4(pos,1.0f), plane);
			return d;
		}

		bool WorldViewFrustumCull (float3 wpos0, float3 wpos1, float3 wpos2, float cullEps, float4 planes[6] )
		{
			float4 planeTest;
			planeTest.x = (( DistanceFromPlane(wpos0, planes[0]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos1, planes[0]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos2, planes[0]) > -cullEps) ? 1.0f : 0.0f );
			planeTest.y = (( DistanceFromPlane(wpos0, planes[1]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos1, planes[1]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos2, planes[1]) > -cullEps) ? 1.0f : 0.0f );
			planeTest.z = (( DistanceFromPlane(wpos0, planes[2]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos1, planes[2]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos2, planes[2]) > -cullEps) ? 1.0f : 0.0f );
			planeTest.w = (( DistanceFromPlane(wpos0, planes[3]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos1, planes[3]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos2, planes[3]) > -cullEps) ? 1.0f : 0.0f );
			return !all (planeTest);
		}

		float4 DistanceBasedTess( float4 v0, float4 v1, float4 v2, float tess, float minDist, float maxDist, float4x4 o2w, float3 cameraPos )
		{
			float3 f;
			f.x = CalcDistanceTessFactor (v0,minDist,maxDist,tess,o2w,cameraPos);
			f.y = CalcDistanceTessFactor (v1,minDist,maxDist,tess,o2w,cameraPos);
			f.z = CalcDistanceTessFactor (v2,minDist,maxDist,tess,o2w,cameraPos);

			return CalcTriEdgeTessFactors (f);
		}

		float4 EdgeLengthBasedTess( float4 v0, float4 v1, float4 v2, float edgeLength, float4x4 o2w, float3 cameraPos, float4 scParams )
		{
			float3 pos0 = mul(o2w,v0).xyz;
			float3 pos1 = mul(o2w,v1).xyz;
			float3 pos2 = mul(o2w,v2).xyz;
			float4 tess;
			tess.x = CalcEdgeTessFactor (pos1, pos2, edgeLength, cameraPos, scParams);
			tess.y = CalcEdgeTessFactor (pos2, pos0, edgeLength, cameraPos, scParams);
			tess.z = CalcEdgeTessFactor (pos0, pos1, edgeLength, cameraPos, scParams);
			tess.w = (tess.x + tess.y + tess.z) / 3.0f;
			return tess;
		}

		float4 EdgeLengthBasedTessCull( float4 v0, float4 v1, float4 v2, float edgeLength, float maxDisplacement, float4x4 o2w, float3 cameraPos, float4 scParams, float4 planes[6] )
		{
			float3 pos0 = mul(o2w,v0).xyz;
			float3 pos1 = mul(o2w,v1).xyz;
			float3 pos2 = mul(o2w,v2).xyz;
			float4 tess;

			if (WorldViewFrustumCull(pos0, pos1, pos2, maxDisplacement, planes))
			{
				tess = 0.0f;
			}
			else
			{
				tess.x = CalcEdgeTessFactor (pos1, pos2, edgeLength, cameraPos, scParams);
				tess.y = CalcEdgeTessFactor (pos2, pos0, edgeLength, cameraPos, scParams);
				tess.z = CalcEdgeTessFactor (pos0, pos1, edgeLength, cameraPos, scParams);
				tess.w = (tess.x + tess.y + tess.z) / 3.0f;
			}
			return tess;
		}
		#endif //ASE_TESS_FUNCS

		ENDHLSL

		
		Pass
		{
			
			Name "Forward"
			Tags { "LightMode"="UniversalForward" }
			
			Blend [_render_src] [_render_dst], One Zero
			ZWrite [_render_zw]
			ZTest LEqual
			Offset 0,0
			ColorMask RGBA
			

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile _ DOTS_INSTANCING_ON
			#define ASE_ABSOLUTE_VERTEX_POS 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 100202
			#define ASE_USING_SAMPLING_MACROS 1

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma multi_compile _ _SCREEN_SPACE_OCCLUSION
			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS
			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
			#pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS _ADDITIONAL_OFF
			#pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
			#pragma multi_compile _ _SHADOWS_SOFT
			#pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
			
			#pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
			#pragma multi_compile _ SHADOWS_SHADOWMASK

			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_FORWARD

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			
			#if ASE_SRP_VERSION <= 70108
			#define REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR
			#endif

			#if defined(UNITY_INSTANCING_ENABLED) && defined(_TERRAIN_INSTANCED_PERPIXEL_NORMAL)
			    #define ENABLE_TERRAIN_PERPIXEL_NORMAL
			#endif

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local TVE_ALPHA_CLIP
			#pragma shader_feature_local TVE_VERTEX_DATA_BATCHED
			//TVE Shader Type Defines
			#define TVE_IS_GRASS_SHADER
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				float4 lightmapUVOrVertexSH : TEXCOORD0;
				half4 fogFactorAndVertexLight : TEXCOORD1;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
				float4 shadowCoord : TEXCOORD2;
				#endif
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
				float4 screenPos : TEXCOORD6;
				#endif
				float4 ase_texcoord7 : TEXCOORD7;
				float4 ase_texcoord8 : TEXCOORD8;
				float4 ase_texcoord9 : TEXCOORD9;
				float4 ase_texcoord10 : TEXCOORD10;
				float4 ase_texcoord11 : TEXCOORD11;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _MainUVs;
			half4 _MotionHighlightColor;
			half4 _MainColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _GradientColorOne;
			half4 _GradientColorTwo;
			half4 _SubsurfaceColor;
			float4 _SubsurfaceDiffusion_Asset;
			half4 _ColorsMaskRemap;
			float4 _MaxBoundsInfo;
			half4 _DetailBlendRemap;
			half4 _VertexOcclusionRemap;
			half4 _NoiseColorTwo;
			half4 _OverlayMaskRemap;
			float4 _NoiseMaskRemap;
			half4 _SubsurfaceMaskRemap;
			half4 _EmissiveUVs;
			half4 _VertexOcclusionColor;
			float4 _EmissiveIntensityParams;
			half4 _EmissiveColor;
			half4 _NoiseColorOne;
			float4 _Color;
			float4 _GradientMaskRemap;
			half3 _render_normals_options;
			half _VertexDataMode;
			half _GradientMaxValue;
			half _InteractionVariation;
			float _MotionScale_32;
			float _MotionSpeed_32;
			half _GradientMinValue;
			float _MotionVariation_32;
			half _PerspectiveAngleValue;
			half _PerspectiveNoiseValue;
			half _GlobalSize;
			half _PerspectivePushValue;
			half _SizeFadeStartValue;
			half _SizeFadeMode;
			half _MotionAmplitude_32;
			half _SizeFadeEndValue;
			half _render_src;
			half _NoiseMinValue;
			half _MainOcclusionValue;
			half _GlobalWetness;
			half _MainSmoothnessValue;
			half _RenderSpecular;
			half _GlobalEmissive;
			half _MainNormalValue;
			half _VertexOcclusionMaxValue;
			half _VertexOcclusionMinValue;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _ColorsMaskMaxValue;
			half _ColorsMaskMinValue;
			half _ColorsVariationValue;
			half _GlobalColors;
			half _LayerColorsValue;
			half _LayerReactValue;
			half _NoiseMaxValue;
			half _NoiseScaleValue;
			half _InteractionAmplitude;
			half _MotionAmplitude_10;
			half _MotionVariation_10;
			half _GradientCat;
			half _PerspectiveCat;
			half _TranslucencyIntensityValue;
			half _MainCat;
			half _DetailCat;
			half _RenderNormals;
			half _DetailSpace;
			half _NoiseCat;
			half _TranslucencyNormalValue;
			float _SubsurfaceDiffusion;
			half _RenderZWrite;
			half _MotionCat;
			half _VariationMotionMessage;
			half _TranslucencyAmbientValue;
			half _Cutoff;
			half _RenderCull;
			half _TranslucencyDirectValue;
			half _RenderClip;
			half _TranslucencyShadowValue;
			half _EmissiveCat;
			half _IsGrassShader;
			half _render_cull;
			half _IsStandardShader;
			half _render_dst;
			half _render_zw;
			half _RenderingCat;
			half _TranslucencyScatteringValue;
			half _DetailTypeMode;
			half _GlobalCat;
			float _MotionSpeed_10;
			half _LayerMotionValue;
			half _vertex_pivot_mode;
			half _AlphaVariationValue;
			half _VertexPivotMode;
			half _VertexMasksMode;
			half _VertexVariationMode;
			half _SizeFadeMessage;
			half _DetailMode;
			half _VariationGlobalsMessage;
			half _SubsurfaceCat;
			half _OcclusionCat;
			float _MotionScale_10;
			half _TranslucencyHDMessage;
			half _DetailBlendMode;
			half _SizeFadeCat;
			half _EmissiveFlagMode;
			half _FadeSpace;
			half _MotionSpace;
			half _IsTVEShader;
			half _ReceiveSpace;
			half _RenderDecals;
			half _IsVersion;
			half _LayersSpace;
			half _RenderSSR;
			half _RenderMode;
			half _RenderPriority;
			half _GlobalAlpha;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);
			TEXTURE2D(_BumpMap);
			SAMPLER(sampler_BumpMap);
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			TEXTURE2D(TVE_NoiseTex);
			half4 TVE_NoiseParams;
			SAMPLER(samplerTVE_NoiseTex);
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			half TVE_MotionFadeEnd;
			half TVE_MotionFadeStart;
			half TVE_DistanceFadeBias;
			TEXTURE3D(TVE_WorldTex3D);
			SAMPLER(samplerTVE_WorldTex3D);
			TEXTURE2D(_MainAlbedoTex);
			SAMPLER(sampler_MainAlbedoTex);
			half4 TVE_ColorsParams;
			TEXTURE2D_ARRAY(TVE_ColorsTex);
			half4 TVE_ColorsCoord;
			SAMPLER(samplerTVE_ColorsTex);
			float TVE_ColorsUsage[9];
			half4 TVE_MainLightParams;
			half3 TVE_MainLightDirection;
			half4 TVE_OverlayColor;
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];
			TEXTURE2D(_MainNormalTex);
			TEXTURE2D(_EmissiveTex);
			SAMPLER(sampler_EmissiveTex);
			TEXTURE2D(_MainMaskTex);
			half TVE_OverlaySmoothness;


			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 VertexPosition3588_g53707 = v.vertex.xyz;
				float3 appendResult60_g53759 = (float3(v.texcoord.z , 0.0 , v.texcoord.w));
				half3 Mesh_PivotsData2831_g53707 = ( appendResult60_g53759 * _VertexPivotMode );
				half3 Mesh_PivotsOS2291_g53707 = Mesh_PivotsData2831_g53707;
				float3 temp_output_2283_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				half3 VertexPos40_g53723 = temp_output_2283_0_g53707;
				float3 appendResult74_g53723 = (float3(VertexPos40_g53723.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53723 = appendResult74_g53723;
				float3 break84_g53723 = VertexPos40_g53723;
				float3 appendResult81_g53723 = (float3(0.0 , break84_g53723.y , break84_g53723.z));
				half3 VertexPosOtherAxis82_g53723 = appendResult81_g53723;
				half ObjectData20_g53786 = 3.14;
				float Bounds_Height374_g53707 = _MaxBoundsInfo.y;
				half WorldData19_g53786 = ( Bounds_Height374_g53707 * 3.14 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53786 = WorldData19_g53786;
				#else
				float staticSwitch14_g53786 = ObjectData20_g53786;
				#endif
				float Motion_Max_Bending1133_g53707 = staticSwitch14_g53786;
				float4x4 break19_g53751 = GetObjectToWorldMatrix();
				float3 appendResult20_g53751 = (float3(break19_g53751[ 0 ][ 3 ] , break19_g53751[ 1 ][ 3 ] , break19_g53751[ 2 ][ 3 ]));
				float3 appendResult60_g53753 = (float3(v.texcoord.z , 0.0 , v.texcoord.w));
				float3 temp_output_91_0_g53751 = ( appendResult60_g53753 * _vertex_pivot_mode );
				float3 PivotsOnly105_g53751 = (mul( GetObjectToWorldMatrix(), float4( temp_output_91_0_g53751 , 0.0 ) ).xyz).xyz;
				half3 ObjectData20_g53752 = ( appendResult20_g53751 + PivotsOnly105_g53751 );
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53752 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53752 = WorldData19_g53752;
				#else
				float3 staticSwitch14_g53752 = ObjectData20_g53752;
				#endif
				float3 temp_output_114_0_g53751 = staticSwitch14_g53752;
				float3 vertexToFrag4224_g53707 = temp_output_114_0_g53751;
				float3 ObjectPosition4223_g53707 = vertexToFrag4224_g53707;
				float3 Position83_g53758 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53758 = _LayerMotionValue;
				float4 lerpResult87_g53758 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53758).xz ) ),temp_output_84_0_g53758, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53758]);
				half4 Global_Motion_Params3909_g53707 = lerpResult87_g53758;
				float4 break322_g53745 = Global_Motion_Params3909_g53707;
				half Wind_Power369_g53745 = break322_g53745.z;
				float lerpResult376_g53745 = lerp( 0.1 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_103106_g53707 = lerpResult376_g53745;
				float3 appendResult397_g53745 = (float3(break322_g53745.x , 0.0 , break322_g53745.y));
				float3 temp_output_398_0_g53745 = (appendResult397_g53745*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53745 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53745 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53707 = (temp_output_339_0_g53745).xz;
				float2 panner73_g53743 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4223_g53707).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53743 = SAMPLE_TEXTURE2D_LOD( TVE_NoiseTex, samplerTVE_NoiseTex, panner73_g53743, 0.0 );
				float4 saferPower77_g53743 = max( abs( tex2DNode75_g53743 ) , 0.0001 );
				half Wind_Power2223_g53707 = Wind_Power369_g53745;
				float temp_output_167_0_g53743 = Wind_Power2223_g53707;
				float lerpResult168_g53743 = lerp( 1.5 , 0.25 , temp_output_167_0_g53743);
				float4 temp_cast_7 = (lerpResult168_g53743).xxxx;
				float4 break142_g53743 = pow( saferPower77_g53743 , temp_cast_7 );
				half Global_NoiseTex_R34_g53707 = break142_g53743.r;
				half Input_Speed62_g53757 = _MotionSpeed_10;
				float mulTime373_g53757 = _TimeParameters.x * Input_Speed62_g53757;
				float3 break111_g53767 = ObjectPosition4223_g53707;
				half Variation_Complex102_g53767 = frac( ( v.ase_color.r + ( break111_g53767.x + break111_g53767.z ) ) );
				half ObjectData20_g53768 = Variation_Complex102_g53767;
				half Variation_Simple105_g53767 = v.ase_color.r;
				half WorldData19_g53768 = Variation_Simple105_g53767;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53768 = WorldData19_g53768;
				#else
				float staticSwitch14_g53768 = ObjectData20_g53768;
				#endif
				half Motion_Variation3073_g53707 = staticSwitch14_g53768;
				half Motion_Variation284_g53757 = ( _MotionVariation_10 * Motion_Variation3073_g53707 );
				float2 appendResult344_g53757 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53757 = ( _MotionScale_10 * appendResult344_g53757 );
				half2 Sine_MinusOneToOne281_g53757 = sin( ( mulTime373_g53757 + Motion_Variation284_g53757 + Motion_Scale287_g53757 ) );
				float2 temp_cast_8 = (1.0).xx;
				half Input_Turbulence327_g53757 = Global_NoiseTex_R34_g53707;
				float2 lerpResult321_g53757 = lerp( Sine_MinusOneToOne281_g53757 , temp_cast_8 , Input_Turbulence327_g53757);
				half2 Motion_Bending2258_g53707 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53707 ) * Wind_Power_103106_g53707 * Wind_DirectionOS39_g53707 * Global_NoiseTex_R34_g53707 * lerpResult321_g53757 );
				half Interaction_Amplitude4137_g53707 = _InteractionAmplitude;
				float3 Position83_g53749 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53749 = _LayerReactValue;
				float4 lerpResult87_g53749 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53749).xz ) ),temp_output_84_0_g53749, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53749]);
				half4 Global_React_Params4173_g53707 = lerpResult87_g53749;
				float4 break322_g53726 = Global_React_Params4173_g53707;
				half Interaction_Mask66_g53707 = break322_g53726.z;
				float3 appendResult397_g53726 = (float3(break322_g53726.x , 0.0 , break322_g53726.y));
				float3 temp_output_398_0_g53726 = (appendResult397_g53726*2.0 + -1.0);
				float3 temp_output_339_0_g53726 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53726 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4158_g53707 = (temp_output_339_0_g53726).xz;
				float lerpResult3307_g53707 = lerp( 1.0 , Motion_Variation3073_g53707 , _InteractionVariation);
				half2 Motion_Interaction53_g53707 = ( Interaction_Amplitude4137_g53707 * Motion_Max_Bending1133_g53707 * Interaction_Mask66_g53707 * Interaction_Mask66_g53707 * Interaction_DirectionOS4158_g53707 * lerpResult3307_g53707 );
				float2 lerpResult109_g53707 = lerp( Motion_Bending2258_g53707 , Motion_Interaction53_g53707 , ( Interaction_Mask66_g53707 * saturate( Interaction_Amplitude4137_g53707 ) ));
				half Mesh_Motion_182_g53707 = v.ase_texcoord3.x;
				float2 break143_g53707 = ( lerpResult109_g53707 * Mesh_Motion_182_g53707 );
				half Motion_Z190_g53707 = break143_g53707.y;
				half Angle44_g53723 = Motion_Z190_g53707;
				half3 VertexPos40_g53733 = ( VertexPosRotationAxis50_g53723 + ( VertexPosOtherAxis82_g53723 * cos( Angle44_g53723 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53723 ) * sin( Angle44_g53723 ) ) );
				float3 appendResult74_g53733 = (float3(0.0 , 0.0 , VertexPos40_g53733.z));
				half3 VertexPosRotationAxis50_g53733 = appendResult74_g53733;
				float3 break84_g53733 = VertexPos40_g53733;
				float3 appendResult81_g53733 = (float3(break84_g53733.x , break84_g53733.y , 0.0));
				half3 VertexPosOtherAxis82_g53733 = appendResult81_g53733;
				half Motion_X216_g53707 = break143_g53707.x;
				half Angle44_g53733 = -Motion_X216_g53707;
				half Motion_Scale321_g53741 = ( _MotionScale_32 * 10.0 );
				half Input_Speed62_g53741 = _MotionSpeed_32;
				float mulTime349_g53741 = _TimeParameters.x * Input_Speed62_g53741;
				float Motion_Variation330_g53741 = ( _MotionVariation_32 * Motion_Variation3073_g53707 );
				float Bounds_Radius121_g53707 = _MaxBoundsInfo.x;
				half Input_Amplitude58_g53741 = ( _MotionAmplitude_32 * Bounds_Radius121_g53707 * 0.1 );
				float3 temp_output_299_0_g53741 = ( sin( ( ( ase_worldPos * Motion_Scale321_g53741 ) + mulTime349_g53741 + Motion_Variation330_g53741 ) ) * Input_Amplitude58_g53741 );
				half Global_NoiseTex_A139_g53707 = break142_g53743.a;
				half Mesh_Motion_3144_g53707 = v.ase_texcoord3.z;
				float lerpResult378_g53745 = lerp( 0.3 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_323115_g53707 = lerpResult378_g53745;
				float temp_output_7_0_g53789 = TVE_MotionFadeEnd;
				half Wind_FadeOut4005_g53707 = saturate( ( ( distance( ase_worldPos , _WorldSpaceCameraPos ) - temp_output_7_0_g53789 ) / ( TVE_MotionFadeStart - temp_output_7_0_g53789 ) ) );
				half3 Motion_Detail263_g53707 = ( temp_output_299_0_g53741 * ( ( Global_NoiseTex_R34_g53707 + Global_NoiseTex_A139_g53707 ) * Mesh_Motion_3144_g53707 * Wind_Power_323115_g53707 * Wind_FadeOut4005_g53707 ) );
				float3 Vertex_Motion_Object833_g53707 = ( ( VertexPosRotationAxis50_g53733 + ( VertexPosOtherAxis82_g53733 * cos( Angle44_g53733 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53733 ) * sin( Angle44_g53733 ) ) ) + Motion_Detail263_g53707 );
				float3 temp_output_3474_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				float3 appendResult2043_g53707 = (float3(Motion_X216_g53707 , 0.0 , Motion_Z190_g53707));
				float3 Vertex_Motion_World1118_g53707 = ( ( temp_output_3474_0_g53707 + appendResult2043_g53707 ) + Motion_Detail263_g53707 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch3312_g53707 = Vertex_Motion_World1118_g53707;
				#else
				float3 staticSwitch3312_g53707 = ( Vertex_Motion_Object833_g53707 + ( 0.0 * _VertexDataMode ) );
				#endif
				half Global_Vertex_Size174_g53707 = break322_g53726.w;
				float lerpResult346_g53707 = lerp( 1.0 , Global_Vertex_Size174_g53707 , _GlobalSize);
				float3 appendResult3480_g53707 = (float3(lerpResult346_g53707 , lerpResult346_g53707 , lerpResult346_g53707));
				half3 ObjectData20_g53728 = appendResult3480_g53707;
				half3 _Vector11 = half3(1,1,1);
				half3 WorldData19_g53728 = _Vector11;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53728 = WorldData19_g53728;
				#else
				float3 staticSwitch14_g53728 = ObjectData20_g53728;
				#endif
				half3 Vertex_Size1741_g53707 = staticSwitch14_g53728;
				half3 _Vector5 = half3(1,1,1);
				float temp_output_7_0_g53779 = _SizeFadeEndValue;
				float temp_output_335_0_g53707 = saturate( ( ( ( distance( _WorldSpaceCameraPos , ObjectPosition4223_g53707 ) * ( 1.0 / TVE_DistanceFadeBias ) ) - temp_output_7_0_g53779 ) / ( _SizeFadeStartValue - temp_output_7_0_g53779 ) ) );
				float3 appendResult3482_g53707 = (float3(temp_output_335_0_g53707 , temp_output_335_0_g53707 , temp_output_335_0_g53707));
				float3 lerpResult3556_g53707 = lerp( _Vector5 , appendResult3482_g53707 , _SizeFadeMode);
				half3 ObjectData20_g53738 = lerpResult3556_g53707;
				half3 WorldData19_g53738 = _Vector5;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53738 = WorldData19_g53738;
				#else
				float3 staticSwitch14_g53738 = ObjectData20_g53738;
				#endif
				float3 Vertex_SizeFade1740_g53707 = staticSwitch14_g53738;
				float3 normalizeResult2696_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 break2709_g53707 = cross( normalizeResult2696_g53707 , half3(0,1,0) );
				float3 appendResult2710_g53707 = (float3(-break2709_g53707.z , 0.0 , break2709_g53707.x));
				float3 appendResult2667_g53707 = (float3(v.ase_color.r , 0.5 , v.ase_color.r));
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult2212_g53707 = dot( ViewDir_Normalized3963_g53707 , float3(0,1,0) );
				half Mask_HView2656_g53707 = dotResult2212_g53707;
				float saferPower2652_g53707 = max( Mask_HView2656_g53707 , 0.0001 );
				half3 Grass_Coverage2661_g53707 = ( ( ( mul( GetWorldToObjectMatrix(), float4( appendResult2710_g53707 , 0.0 ) ).xyz * _PerspectivePushValue ) + ( (appendResult2667_g53707*2.0 + -1.0) * _PerspectiveNoiseValue ) ) * v.ase_color.a * pow( saferPower2652_g53707 , _PerspectiveAngleValue ) );
				float3 Final_VertexPosition890_g53707 = ( ( staticSwitch3312_g53707 * Vertex_Size1741_g53707 * Vertex_SizeFade1740_g53707 ) + Mesh_PivotsOS2291_g53707 + Grass_Coverage2661_g53707 );
				
				float temp_output_7_0_g53773 = _GradientMinValue;
				float4 lerpResult2779_g53707 = lerp( _GradientColorTwo , _GradientColorOne , saturate( ( ( v.ase_color.a - temp_output_7_0_g53773 ) / ( _GradientMaxValue - temp_output_7_0_g53773 ) ) ));
				half3 Gradient_Tint2784_g53707 = (lerpResult2779_g53707).rgb;
				float3 vertexToFrag11_g53775 = Gradient_Tint2784_g53707;
				o.ase_texcoord7.xyz = vertexToFrag11_g53775;
				float3 temp_cast_16 = (_NoiseScaleValue).xxx;
				float3 vertexToFrag3890_g53707 = ase_worldPos;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float temp_output_7_0_g53784 = _NoiseMinValue;
				half Noise_Mask3162_g53707 = saturate( ( ( SAMPLE_TEXTURE3D_LOD( TVE_WorldTex3D, samplerTVE_WorldTex3D, ( temp_cast_16 * WorldPosition3905_g53707 * 0.1 ), 0.0 ).r - temp_output_7_0_g53784 ) / ( _NoiseMaxValue - temp_output_7_0_g53784 ) ) );
				float4 lerpResult2800_g53707 = lerp( _NoiseColorTwo , _NoiseColorOne , Noise_Mask3162_g53707);
				half3 Noise_Tint2802_g53707 = (lerpResult2800_g53707).rgb;
				float3 vertexToFrag11_g53787 = Noise_Tint2802_g53707;
				o.ase_texcoord8.xyz = vertexToFrag11_g53787;
				float lerpResult169_g53743 = lerp( 4.0 , 2.0 , temp_output_167_0_g53743);
				half Global_NoiseTex_H2869_g53707 = pow( abs( tex2DNode75_g53743.a ) , lerpResult169_g53743 );
				half3 Highlight_Tint3231_g53707 = ( ( (_MotionHighlightColor).rgb * Global_NoiseTex_H2869_g53707 * Wind_Power_103106_g53707 * Wind_FadeOut4005_g53707 * v.ase_color.a ) + float3( 1,1,1 ) );
				float3 vertexToFrag11_g53766 = Highlight_Tint3231_g53707;
				o.ase_texcoord9.xyz = vertexToFrag11_g53766;
				float2 vertexToFrag11_g53744 = ( ( v.texcoord.xy * (_MainUVs).xy ) + (_MainUVs).zw );
				o.ase_texcoord10.xy = vertexToFrag11_g53744;
				float3 Position58_g53740 = WorldPosition3905_g53707;
				float temp_output_82_0_g53740 = _LayerColorsValue;
				float4 lerpResult88_g53740 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ColorsTex, samplerTVE_ColorsTex, ( (TVE_ColorsCoord).zw + ( (TVE_ColorsCoord).xy * (Position58_g53740).xz ) ),temp_output_82_0_g53740, 0.0 ) , TVE_ColorsUsage[(int)temp_output_82_0_g53740]);
				half Global_ColorsTex_A1701_g53707 = (lerpResult88_g53740).a;
				float vertexToFrag11_g53776 = Global_ColorsTex_A1701_g53707;
				o.ase_texcoord7.w = vertexToFrag11_g53776;
				o.ase_texcoord11.xyz = vertexToFrag3890_g53707;
				
				float2 vertexToFrag11_g53724 = ( ( v.texcoord.xy * (_EmissiveUVs).xy ) + (_EmissiveUVs).zw );
				o.ase_texcoord10.zw = vertexToFrag11_g53724;
				
				o.ase_color = v.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord8.w = 0;
				o.ase_texcoord9.w = 0;
				o.ase_texcoord11.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = Final_VertexPosition890_g53707;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif
				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float3 positionVS = TransformWorldToView( positionWS );
				float4 positionCS = TransformWorldToHClip( positionWS );

				VertexNormalInputs normalInput = GetVertexNormalInputs( v.ase_normal, v.ase_tangent );

				o.tSpace0 = float4( normalInput.normalWS, positionWS.x);
				o.tSpace1 = float4( normalInput.tangentWS, positionWS.y);
				o.tSpace2 = float4( normalInput.bitangentWS, positionWS.z);

				OUTPUT_LIGHTMAP_UV( v.texcoord1, unity_LightmapST, o.lightmapUVOrVertexSH.xy );
				OUTPUT_SH( normalInput.normalWS.xyz, o.lightmapUVOrVertexSH.xyz );

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					o.lightmapUVOrVertexSH.zw = v.texcoord;
					o.lightmapUVOrVertexSH.xy = v.texcoord * unity_LightmapST.xy + unity_LightmapST.zw;
				#endif

				half3 vertexLight = VertexLighting( positionWS, normalInput.normalWS );
				#ifdef ASE_FOG
					half fogFactor = ComputeFogFactor( positionCS.z );
				#else
					half fogFactor = 0;
				#endif
				o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);
				
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
				VertexPositionInputs vertexInput = (VertexPositionInputs)0;
				vertexInput.positionWS = positionWS;
				vertexInput.positionCS = positionCS;
				o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				
				o.clipPos = positionCS;
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
				o.screenPos = ComputeScreenPos(positionCS);
				#endif
				return o;
			}
			
			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_tangent = v.ase_tangent;
				o.texcoord = v.texcoord;
				o.texcoord1 = v.texcoord1;
				o.texcoord = v.texcoord;
				o.ase_color = v.ase_color;
				o.ase_texcoord3 = v.ase_texcoord3;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				o.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				o.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE)
				#define ASE_SV_DEPTH SV_DepthLessEqual  
			#else
				#define ASE_SV_DEPTH SV_Depth
			#endif

			half4 frag ( VertexOutput IN 
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						, FRONT_FACE_TYPE ase_vface : FRONT_FACE_SEMANTIC ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float2 sampleCoords = (IN.lightmapUVOrVertexSH.zw / _TerrainHeightmapRecipSize.zw + 0.5f) * _TerrainHeightmapRecipSize.xy;
					float3 WorldNormal = TransformObjectToWorldNormal(normalize(SAMPLE_TEXTURE2D(_TerrainNormalmapTexture, sampler_TerrainNormalmapTexture, sampleCoords).rgb * 2 - 1));
					float3 WorldTangent = -cross(GetObjectToWorldMatrix()._13_23_33, WorldNormal);
					float3 WorldBiTangent = cross(WorldNormal, -WorldTangent);
				#else
					float3 WorldNormal = normalize( IN.tSpace0.xyz );
					float3 WorldTangent = IN.tSpace1.xyz;
					float3 WorldBiTangent = IN.tSpace2.xyz;
				#endif
				float3 WorldPosition = float3(IN.tSpace0.w,IN.tSpace1.w,IN.tSpace2.w);
				float3 WorldViewDirection = _WorldSpaceCameraPos.xyz  - WorldPosition;
				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
				float4 ScreenPos = IN.screenPos;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					ShadowCoords = IN.shadowCoord;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
				#endif
	
				WorldViewDirection = SafeNormalize( WorldViewDirection );

				float3 vertexToFrag11_g53775 = IN.ase_texcoord7.xyz;
				float3 vertexToFrag11_g53787 = IN.ase_texcoord8.xyz;
				float3 vertexToFrag11_g53766 = IN.ase_texcoord9.xyz;
				float2 vertexToFrag11_g53744 = IN.ase_texcoord10.xy;
				half2 Main_UVs15_g53707 = vertexToFrag11_g53744;
				float4 tex2DNode29_g53707 = SAMPLE_TEXTURE2D( _MainAlbedoTex, sampler_MainAlbedoTex, Main_UVs15_g53707 );
				float3 temp_output_51_0_g53707 = ( (_MainColor).rgb * (tex2DNode29_g53707).rgb );
				half3 Main_Albedo99_g53707 = temp_output_51_0_g53707;
				half3 Blend_Albedo265_g53707 = Main_Albedo99_g53707;
				half3 Blend_AlbedoTinted2808_g53707 = ( vertexToFrag11_g53775 * vertexToFrag11_g53787 * vertexToFrag11_g53766 * Blend_Albedo265_g53707 );
				float dotResult3616_g53707 = dot( Blend_AlbedoTinted2808_g53707 , float3(0.2126,0.7152,0.0722) );
				float3 temp_cast_0 = (dotResult3616_g53707).xxx;
				float vertexToFrag11_g53776 = IN.ase_texcoord7.w;
				half Global_Colors_Influence3668_g53707 = vertexToFrag11_g53776;
				float3 lerpResult3618_g53707 = lerp( Blend_AlbedoTinted2808_g53707 , temp_cast_0 , Global_Colors_Influence3668_g53707);
				float3 vertexToFrag3890_g53707 = IN.ase_texcoord11.xyz;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float3 Position58_g53740 = WorldPosition3905_g53707;
				float temp_output_82_0_g53740 = _LayerColorsValue;
				float4 lerpResult88_g53740 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ColorsTex, samplerTVE_ColorsTex, ( (TVE_ColorsCoord).zw + ( (TVE_ColorsCoord).xy * (Position58_g53740).xz ) ),temp_output_82_0_g53740 ) , TVE_ColorsUsage[(int)temp_output_82_0_g53740]);
				half3 Global_ColorsTex_RGB1700_g53707 = (lerpResult88_g53740).rgb;
				#ifdef UNITY_COLORSPACE_GAMMA
				float staticSwitch1_g53769 = 2.0;
				#else
				float staticSwitch1_g53769 = 4.594794;
				#endif
				float3 temp_output_1953_0_g53707 = ( Global_ColorsTex_RGB1700_g53707 * staticSwitch1_g53769 );
				half3 Global_Colors1954_g53707 = temp_output_1953_0_g53707;
				float lerpResult3870_g53707 = lerp( 1.0 , IN.ase_color.r , _ColorsVariationValue);
				half Global_Colors_Value3650_g53707 = ( _GlobalColors * lerpResult3870_g53707 );
				float temp_output_7_0_g53778 = _ColorsMaskMinValue;
				half Global_Colors_Mask3692_g53707 = saturate( ( ( ( 1.0 - IN.ase_color.a ) - temp_output_7_0_g53778 ) / ( _ColorsMaskMaxValue - temp_output_7_0_g53778 ) ) );
				float3 lerpResult3628_g53707 = lerp( Blend_AlbedoTinted2808_g53707 , ( lerpResult3618_g53707 * Global_Colors1954_g53707 ) , ( Global_Colors_Value3650_g53707 * Global_Colors_Mask3692_g53707 ));
				half3 Blend_AlbedoColored863_g53707 = lerpResult3628_g53707;
				float3 temp_output_799_0_g53707 = (_SubsurfaceColor).rgb;
				float dotResult3930_g53707 = dot( temp_output_799_0_g53707 , float3(0.2126,0.7152,0.0722) );
				float3 temp_cast_3 = (dotResult3930_g53707).xxx;
				float3 lerpResult3932_g53707 = lerp( temp_output_799_0_g53707 , temp_cast_3 , Global_Colors_Influence3668_g53707);
				float3 lerpResult3942_g53707 = lerp( temp_output_799_0_g53707 , ( lerpResult3932_g53707 * Global_Colors1954_g53707 ) , ( Global_Colors_Value3650_g53707 * Global_Colors_Mask3692_g53707 ));
				half3 Subsurface_Color1722_g53707 = lerpResult3942_g53707;
				half MainLight_Subsurface4041_g53707 = TVE_MainLightParams.a;
				half Subsurface_Intensity1752_g53707 = ( _SubsurfaceValue * MainLight_Subsurface4041_g53707 );
				float temp_output_7_0_g53781 = _SubsurfaceMaskMinValue;
				half Subsurface_Mask1557_g53707 = saturate( ( ( IN.ase_color.a - temp_output_7_0_g53781 ) / ( _SubsurfaceMaskMaxValue - temp_output_7_0_g53781 ) ) );
				half3 Subsurface_Transmission884_g53707 = ( Subsurface_Color1722_g53707 * Subsurface_Intensity1752_g53707 * Subsurface_Mask1557_g53707 );
				half3 MainLight_Direction3926_g53707 = TVE_MainLightDirection;
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult785_g53707 = dot( -MainLight_Direction3926_g53707 , ViewDir_Normalized3963_g53707 );
				float saferPower1624_g53707 = max( (dotResult785_g53707*0.5 + 0.5) , 0.0001 );
				#ifdef UNITY_PASS_FORWARDADD
				float staticSwitch1602_g53707 = 0.0;
				#else
				float staticSwitch1602_g53707 = ( pow( saferPower1624_g53707 , _MainLightAngleValue ) * _MainLightScatteringValue );
				#endif
				half Mask_Subsurface_View782_g53707 = staticSwitch1602_g53707;
				half3 Subsurface_Scattering1693_g53707 = ( Subsurface_Transmission884_g53707 * Blend_AlbedoColored863_g53707 * Mask_Subsurface_View782_g53707 );
				half3 Blend_AlbedoAndSubsurface149_g53707 = ( Blend_AlbedoColored863_g53707 + Subsurface_Scattering1693_g53707 );
				half3 Global_OverlayColor1758_g53707 = (TVE_OverlayColor).rgb;
				half Main_AlbedoTex_G3526_g53707 = tex2DNode29_g53707.g;
				float3 Position82_g53742 = WorldPosition3905_g53707;
				float temp_output_84_0_g53742 = _LayerExtrasValue;
				float4 lerpResult88_g53742 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53742).xz ) ),temp_output_84_0_g53742 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53742]);
				float4 break89_g53742 = lerpResult88_g53742;
				half Global_Extras_Overlay156_g53707 = break89_g53742.b;
				float temp_output_1025_0_g53707 = ( _GlobalOverlay * Global_Extras_Overlay156_g53707 );
				float lerpResult1065_g53707 = lerp( 1.0 , IN.ase_color.r , _OverlayVariationValue);
				half Overlay_Commons1365_g53707 = ( temp_output_1025_0_g53707 * lerpResult1065_g53707 );
				float temp_output_7_0_g53770 = _OverlayMaskMinValue;
				half Overlay_Mask269_g53707 = saturate( ( ( ( ( ( IN.ase_color.a * 0.5 ) + Main_AlbedoTex_G3526_g53707 ) * Overlay_Commons1365_g53707 ) - temp_output_7_0_g53770 ) / ( _OverlayMaskMaxValue - temp_output_7_0_g53770 ) ) );
				float3 lerpResult336_g53707 = lerp( Blend_AlbedoAndSubsurface149_g53707 , Global_OverlayColor1758_g53707 , Overlay_Mask269_g53707);
				half3 Final_Albedo359_g53707 = lerpResult336_g53707;
				float3 temp_cast_6 = (1.0).xxx;
				float Mesh_Occlusion318_g53707 = IN.ase_color.g;
				float temp_output_7_0_g53782 = _VertexOcclusionMinValue;
				float3 lerpResult2945_g53707 = lerp( (_VertexOcclusionColor).rgb , temp_cast_6 , saturate( ( ( Mesh_Occlusion318_g53707 - temp_output_7_0_g53782 ) / ( _VertexOcclusionMaxValue - temp_output_7_0_g53782 ) ) ));
				float3 Vertex_Occlusion648_g53707 = lerpResult2945_g53707;
				
				float3 unpack4112_g53707 = UnpackNormalScale( SAMPLE_TEXTURE2D( _MainNormalTex, sampler_MainAlbedoTex, Main_UVs15_g53707 ), _MainNormalValue );
				unpack4112_g53707.z = lerp( 1, unpack4112_g53707.z, saturate(_MainNormalValue) );
				half3 Main_Normal137_g53707 = unpack4112_g53707;
				float3 temp_output_13_0_g53772 = Main_Normal137_g53707;
				float3 switchResult12_g53772 = (((ase_vface>0)?(temp_output_13_0_g53772):(( temp_output_13_0_g53772 * _render_normals_options ))));
				half3 Blend_Normal312_g53707 = switchResult12_g53772;
				half3 Final_Normal366_g53707 = Blend_Normal312_g53707;
				
				float4 temp_output_4214_0_g53707 = ( _EmissiveColor * _EmissiveIntensityParams.x );
				float2 vertexToFrag11_g53724 = IN.ase_texcoord10.zw;
				half2 Emissive_UVs2468_g53707 = vertexToFrag11_g53724;
				half Global_Extras_Emissive4203_g53707 = break89_g53742.r;
				float lerpResult4206_g53707 = lerp( 1.0 , Global_Extras_Emissive4203_g53707 , _GlobalEmissive);
				half3 Final_Emissive2476_g53707 = ( (( temp_output_4214_0_g53707 * SAMPLE_TEXTURE2D( _EmissiveTex, sampler_EmissiveTex, Emissive_UVs2468_g53707 ) )).rgb * lerpResult4206_g53707 );
				
				float3 temp_cast_8 = (( 0.04 * _RenderSpecular )).xxx;
				
				float4 tex2DNode35_g53707 = SAMPLE_TEXTURE2D( _MainMaskTex, sampler_MainAlbedoTex, Main_UVs15_g53707 );
				half Main_Smoothness227_g53707 = ( tex2DNode35_g53707.a * _MainSmoothnessValue );
				half Blend_Smoothness314_g53707 = Main_Smoothness227_g53707;
				half Global_OverlaySmoothness311_g53707 = TVE_OverlaySmoothness;
				float lerpResult343_g53707 = lerp( Blend_Smoothness314_g53707 , Global_OverlaySmoothness311_g53707 , Overlay_Mask269_g53707);
				half Final_Smoothness371_g53707 = lerpResult343_g53707;
				half Global_Extras_Wetness305_g53707 = break89_g53742.g;
				float lerpResult3673_g53707 = lerp( 0.0 , Global_Extras_Wetness305_g53707 , _GlobalWetness);
				half Final_SmoothnessAndWetness4130_g53707 = saturate( ( Final_Smoothness371_g53707 + lerpResult3673_g53707 ) );
				
				float lerpResult240_g53707 = lerp( 1.0 , tex2DNode35_g53707.g , _MainOcclusionValue);
				half Main_Occlusion247_g53707 = lerpResult240_g53707;
				half Blend_Occlusion323_g53707 = Main_Occlusion247_g53707;
				
				float localCustomAlphaClip3735_g53707 = ( 0.0 );
				half Final_AlphaFade3727_g53707 = 1.0;
				float Main_Alpha316_g53707 = ( _MainColor.a * tex2DNode29_g53707.a );
				float Mesh_Variation16_g53707 = IN.ase_color.r;
				float lerpResult4033_g53707 = lerp( 0.9 , (Mesh_Variation16_g53707*0.5 + 0.5) , _AlphaVariationValue);
				half Global_Extras_Alpha1033_g53707 = break89_g53742.a;
				float temp_output_4022_0_g53707 = ( lerpResult4033_g53707 - ( 1.0 - Global_Extras_Alpha1033_g53707 ) );
				half AlphaTreshold2132_g53707 = _Cutoff;
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch4017_g53707 = ( temp_output_4022_0_g53707 + AlphaTreshold2132_g53707 );
				#else
				float staticSwitch4017_g53707 = temp_output_4022_0_g53707;
				#endif
				float lerpResult4011_g53707 = lerp( 1.0 , staticSwitch4017_g53707 , _GlobalAlpha);
				half Global_Alpha315_g53707 = saturate( lerpResult4011_g53707 );
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch3792_g53707 = ( ( Main_Alpha316_g53707 * Global_Alpha315_g53707 ) - ( AlphaTreshold2132_g53707 - 0.5 ) );
				#else
				float staticSwitch3792_g53707 = ( Main_Alpha316_g53707 * Global_Alpha315_g53707 );
				#endif
				half Final_Alpha3754_g53707 = staticSwitch3792_g53707;
				float temp_output_661_0_g53707 = ( Final_AlphaFade3727_g53707 * Final_Alpha3754_g53707 );
				float Alpha3735_g53707 = temp_output_661_0_g53707;
				float Treshold3735_g53707 = 0.5;
				{
				#if TVE_ALPHA_CLIP
				clip(Alpha3735_g53707 - Treshold3735_g53707);
				#endif
				}
				half Final_Clip914_g53707 = saturate( Alpha3735_g53707 );
				
				float3 Albedo = ( Final_Albedo359_g53707 * Vertex_Occlusion648_g53707 );
				float3 Normal = Final_Normal366_g53707;
				float3 Emission = Final_Emissive2476_g53707;
				float3 Specular = temp_cast_8;
				float Metallic = 0;
				float Smoothness = Final_SmoothnessAndWetness4130_g53707;
				float Occlusion = Blend_Occlusion323_g53707;
				float Alpha = Final_Clip914_g53707;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = 1;
				#ifdef ASE_DEPTH_WRITE_ON
				float DepthValue = 0;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				InputData inputData;
				inputData.positionWS = WorldPosition;
				inputData.viewDirectionWS = WorldViewDirection;
				inputData.shadowCoord = ShadowCoords;

				#ifdef _NORMALMAP
					#if _NORMAL_DROPOFF_TS
					inputData.normalWS = TransformTangentToWorld(Normal, half3x3( WorldTangent, WorldBiTangent, WorldNormal ));
					#elif _NORMAL_DROPOFF_OS
					inputData.normalWS = TransformObjectToWorldNormal(Normal);
					#elif _NORMAL_DROPOFF_WS
					inputData.normalWS = Normal;
					#endif
					inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);
				#else
					inputData.normalWS = WorldNormal;
				#endif

				#ifdef ASE_FOG
					inputData.fogCoord = IN.fogFactorAndVertexLight.x;
				#endif

				inputData.vertexLighting = IN.fogFactorAndVertexLight.yzw;
				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float3 SH = SampleSH(inputData.normalWS.xyz);
				#else
					float3 SH = IN.lightmapUVOrVertexSH.xyz;
				#endif

				inputData.bakedGI = SAMPLE_GI( IN.lightmapUVOrVertexSH.xy, SH, inputData.normalWS );
				#ifdef _ASE_BAKEDGI
					inputData.bakedGI = BakedGI;
				#endif
				
				inputData.normalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(IN.clipPos);
				inputData.shadowMask = SAMPLE_SHADOWMASK(IN.lightmapUVOrVertexSH.xy);

				half4 color = UniversalFragmentPBR(
					inputData, 
					Albedo, 
					Metallic, 
					Specular, 
					Smoothness, 
					Occlusion, 
					Emission, 
					Alpha);

				#ifdef _TRANSMISSION_ASE
				{
					float shadow = _TransmissionShadow;

					Light mainLight = GetMainLight( inputData.shadowCoord );
					float3 mainAtten = mainLight.color * mainLight.distanceAttenuation;
					mainAtten = lerp( mainAtten, mainAtten * mainLight.shadowAttenuation, shadow );
					half3 mainTransmission = max(0 , -dot(inputData.normalWS, mainLight.direction)) * mainAtten * Transmission;
					color.rgb += Albedo * mainTransmission;

					#ifdef _ADDITIONAL_LIGHTS
						int transPixelLightCount = GetAdditionalLightsCount();
						for (int i = 0; i < transPixelLightCount; ++i)
						{
							Light light = GetAdditionalLight(i, inputData.positionWS);
							float3 atten = light.color * light.distanceAttenuation;
							atten = lerp( atten, atten * light.shadowAttenuation, shadow );

							half3 transmission = max(0 , -dot(inputData.normalWS, light.direction)) * atten * Transmission;
							color.rgb += Albedo * transmission;
						}
					#endif
				}
				#endif

				#ifdef _TRANSLUCENCY_ASE
				{
					float shadow = _TransShadow;
					float normal = _TransNormal;
					float scattering = _TransScattering;
					float direct = _TransDirect;
					float ambient = _TransAmbient;
					float strength = _TransStrength;

					Light mainLight = GetMainLight( inputData.shadowCoord );
					float3 mainAtten = mainLight.color * mainLight.distanceAttenuation;
					mainAtten = lerp( mainAtten, mainAtten * mainLight.shadowAttenuation, shadow );

					half3 mainLightDir = mainLight.direction + inputData.normalWS * normal;
					half mainVdotL = pow( saturate( dot( inputData.viewDirectionWS, -mainLightDir ) ), scattering );
					half3 mainTranslucency = mainAtten * ( mainVdotL * direct + inputData.bakedGI * ambient ) * Translucency;
					color.rgb += Albedo * mainTranslucency * strength;

					#ifdef _ADDITIONAL_LIGHTS
						int transPixelLightCount = GetAdditionalLightsCount();
						for (int i = 0; i < transPixelLightCount; ++i)
						{
							Light light = GetAdditionalLight(i, inputData.positionWS);
							float3 atten = light.color * light.distanceAttenuation;
							atten = lerp( atten, atten * light.shadowAttenuation, shadow );

							half3 lightDir = light.direction + inputData.normalWS * normal;
							half VdotL = pow( saturate( dot( inputData.viewDirectionWS, -lightDir ) ), scattering );
							half3 translucency = atten * ( VdotL * direct + inputData.bakedGI * ambient ) * Translucency;
							color.rgb += Albedo * translucency * strength;
						}
					#endif
				}
				#endif

				#ifdef _REFRACTION_ASE
					float4 projScreenPos = ScreenPos / ScreenPos.w;
					float3 refractionOffset = ( RefractionIndex - 1.0 ) * mul( UNITY_MATRIX_V, WorldNormal ).xyz * ( 1.0 - dot( WorldNormal, WorldViewDirection ) );
					projScreenPos.xy += refractionOffset.xy;
					float3 refraction = SHADERGRAPH_SAMPLE_SCENE_COLOR( projScreenPos ) * RefractionColor;
					color.rgb = lerp( refraction, color.rgb, color.a );
					color.a = 1;
				#endif

				#ifdef ASE_FINAL_COLOR_ALPHA_MULTIPLY
					color.rgb *= color.a;
				#endif

				#ifdef ASE_FOG
					#ifdef TERRAIN_SPLAT_ADDPASS
						color.rgb = MixFogColor(color.rgb, half3( 0, 0, 0 ), IN.fogFactorAndVertexLight.x );
					#else
						color.rgb = MixFog(color.rgb, IN.fogFactorAndVertexLight.x);
					#endif
				#endif

				#ifdef ASE_DEPTH_WRITE_ON
					outputDepth = DepthValue;
				#endif

				return color;
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "ShadowCaster"
			Tags { "LightMode"="ShadowCaster" }

			ZWrite On
			ZTest LEqual
			AlphaToMask Off

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile _ DOTS_INSTANCING_ON
			#define ASE_ABSOLUTE_VERTEX_POS 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 100202
			#define ASE_USING_SAMPLING_MACROS 1

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_SHADOWCASTER

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#pragma shader_feature_local TVE_ALPHA_CLIP
			#pragma shader_feature_local TVE_VERTEX_DATA_BATCHED
			//TVE Shader Type Defines
			#define TVE_IS_GRASS_SHADER
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD1;
				#endif
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _MainUVs;
			half4 _MotionHighlightColor;
			half4 _MainColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _GradientColorOne;
			half4 _GradientColorTwo;
			half4 _SubsurfaceColor;
			float4 _SubsurfaceDiffusion_Asset;
			half4 _ColorsMaskRemap;
			float4 _MaxBoundsInfo;
			half4 _DetailBlendRemap;
			half4 _VertexOcclusionRemap;
			half4 _NoiseColorTwo;
			half4 _OverlayMaskRemap;
			float4 _NoiseMaskRemap;
			half4 _SubsurfaceMaskRemap;
			half4 _EmissiveUVs;
			half4 _VertexOcclusionColor;
			float4 _EmissiveIntensityParams;
			half4 _EmissiveColor;
			half4 _NoiseColorOne;
			float4 _Color;
			float4 _GradientMaskRemap;
			half3 _render_normals_options;
			half _VertexDataMode;
			half _GradientMaxValue;
			half _InteractionVariation;
			float _MotionScale_32;
			float _MotionSpeed_32;
			half _GradientMinValue;
			float _MotionVariation_32;
			half _PerspectiveAngleValue;
			half _PerspectiveNoiseValue;
			half _GlobalSize;
			half _PerspectivePushValue;
			half _SizeFadeStartValue;
			half _SizeFadeMode;
			half _MotionAmplitude_32;
			half _SizeFadeEndValue;
			half _render_src;
			half _NoiseMinValue;
			half _MainOcclusionValue;
			half _GlobalWetness;
			half _MainSmoothnessValue;
			half _RenderSpecular;
			half _GlobalEmissive;
			half _MainNormalValue;
			half _VertexOcclusionMaxValue;
			half _VertexOcclusionMinValue;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _ColorsMaskMaxValue;
			half _ColorsMaskMinValue;
			half _ColorsVariationValue;
			half _GlobalColors;
			half _LayerColorsValue;
			half _LayerReactValue;
			half _NoiseMaxValue;
			half _NoiseScaleValue;
			half _InteractionAmplitude;
			half _MotionAmplitude_10;
			half _MotionVariation_10;
			half _GradientCat;
			half _PerspectiveCat;
			half _TranslucencyIntensityValue;
			half _MainCat;
			half _DetailCat;
			half _RenderNormals;
			half _DetailSpace;
			half _NoiseCat;
			half _TranslucencyNormalValue;
			float _SubsurfaceDiffusion;
			half _RenderZWrite;
			half _MotionCat;
			half _VariationMotionMessage;
			half _TranslucencyAmbientValue;
			half _Cutoff;
			half _RenderCull;
			half _TranslucencyDirectValue;
			half _RenderClip;
			half _TranslucencyShadowValue;
			half _EmissiveCat;
			half _IsGrassShader;
			half _render_cull;
			half _IsStandardShader;
			half _render_dst;
			half _render_zw;
			half _RenderingCat;
			half _TranslucencyScatteringValue;
			half _DetailTypeMode;
			half _GlobalCat;
			float _MotionSpeed_10;
			half _LayerMotionValue;
			half _vertex_pivot_mode;
			half _AlphaVariationValue;
			half _VertexPivotMode;
			half _VertexMasksMode;
			half _VertexVariationMode;
			half _SizeFadeMessage;
			half _DetailMode;
			half _VariationGlobalsMessage;
			half _SubsurfaceCat;
			half _OcclusionCat;
			float _MotionScale_10;
			half _TranslucencyHDMessage;
			half _DetailBlendMode;
			half _SizeFadeCat;
			half _EmissiveFlagMode;
			half _FadeSpace;
			half _MotionSpace;
			half _IsTVEShader;
			half _ReceiveSpace;
			half _RenderDecals;
			half _IsVersion;
			half _LayersSpace;
			half _RenderSSR;
			half _RenderMode;
			half _RenderPriority;
			half _GlobalAlpha;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);
			TEXTURE2D(_BumpMap);
			SAMPLER(sampler_BumpMap);
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			TEXTURE2D(TVE_NoiseTex);
			half4 TVE_NoiseParams;
			SAMPLER(samplerTVE_NoiseTex);
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			half TVE_MotionFadeEnd;
			half TVE_MotionFadeStart;
			half TVE_DistanceFadeBias;
			TEXTURE2D(_MainAlbedoTex);
			SAMPLER(sampler_MainAlbedoTex);
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];


			
			float3 _LightDirection;

			VertexOutput VertexFunction( VertexInput v )
			{
				VertexOutput o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				float3 VertexPosition3588_g53707 = v.vertex.xyz;
				float3 appendResult60_g53759 = (float3(v.ase_texcoord.z , 0.0 , v.ase_texcoord.w));
				half3 Mesh_PivotsData2831_g53707 = ( appendResult60_g53759 * _VertexPivotMode );
				half3 Mesh_PivotsOS2291_g53707 = Mesh_PivotsData2831_g53707;
				float3 temp_output_2283_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				half3 VertexPos40_g53723 = temp_output_2283_0_g53707;
				float3 appendResult74_g53723 = (float3(VertexPos40_g53723.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53723 = appendResult74_g53723;
				float3 break84_g53723 = VertexPos40_g53723;
				float3 appendResult81_g53723 = (float3(0.0 , break84_g53723.y , break84_g53723.z));
				half3 VertexPosOtherAxis82_g53723 = appendResult81_g53723;
				half ObjectData20_g53786 = 3.14;
				float Bounds_Height374_g53707 = _MaxBoundsInfo.y;
				half WorldData19_g53786 = ( Bounds_Height374_g53707 * 3.14 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53786 = WorldData19_g53786;
				#else
				float staticSwitch14_g53786 = ObjectData20_g53786;
				#endif
				float Motion_Max_Bending1133_g53707 = staticSwitch14_g53786;
				float4x4 break19_g53751 = GetObjectToWorldMatrix();
				float3 appendResult20_g53751 = (float3(break19_g53751[ 0 ][ 3 ] , break19_g53751[ 1 ][ 3 ] , break19_g53751[ 2 ][ 3 ]));
				float3 appendResult60_g53753 = (float3(v.ase_texcoord.z , 0.0 , v.ase_texcoord.w));
				float3 temp_output_91_0_g53751 = ( appendResult60_g53753 * _vertex_pivot_mode );
				float3 PivotsOnly105_g53751 = (mul( GetObjectToWorldMatrix(), float4( temp_output_91_0_g53751 , 0.0 ) ).xyz).xyz;
				half3 ObjectData20_g53752 = ( appendResult20_g53751 + PivotsOnly105_g53751 );
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53752 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53752 = WorldData19_g53752;
				#else
				float3 staticSwitch14_g53752 = ObjectData20_g53752;
				#endif
				float3 temp_output_114_0_g53751 = staticSwitch14_g53752;
				float3 vertexToFrag4224_g53707 = temp_output_114_0_g53751;
				float3 ObjectPosition4223_g53707 = vertexToFrag4224_g53707;
				float3 Position83_g53758 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53758 = _LayerMotionValue;
				float4 lerpResult87_g53758 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53758).xz ) ),temp_output_84_0_g53758, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53758]);
				half4 Global_Motion_Params3909_g53707 = lerpResult87_g53758;
				float4 break322_g53745 = Global_Motion_Params3909_g53707;
				half Wind_Power369_g53745 = break322_g53745.z;
				float lerpResult376_g53745 = lerp( 0.1 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_103106_g53707 = lerpResult376_g53745;
				float3 appendResult397_g53745 = (float3(break322_g53745.x , 0.0 , break322_g53745.y));
				float3 temp_output_398_0_g53745 = (appendResult397_g53745*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53745 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53745 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53707 = (temp_output_339_0_g53745).xz;
				float2 panner73_g53743 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4223_g53707).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53743 = SAMPLE_TEXTURE2D_LOD( TVE_NoiseTex, samplerTVE_NoiseTex, panner73_g53743, 0.0 );
				float4 saferPower77_g53743 = max( abs( tex2DNode75_g53743 ) , 0.0001 );
				half Wind_Power2223_g53707 = Wind_Power369_g53745;
				float temp_output_167_0_g53743 = Wind_Power2223_g53707;
				float lerpResult168_g53743 = lerp( 1.5 , 0.25 , temp_output_167_0_g53743);
				float4 temp_cast_7 = (lerpResult168_g53743).xxxx;
				float4 break142_g53743 = pow( saferPower77_g53743 , temp_cast_7 );
				half Global_NoiseTex_R34_g53707 = break142_g53743.r;
				half Input_Speed62_g53757 = _MotionSpeed_10;
				float mulTime373_g53757 = _TimeParameters.x * Input_Speed62_g53757;
				float3 break111_g53767 = ObjectPosition4223_g53707;
				half Variation_Complex102_g53767 = frac( ( v.ase_color.r + ( break111_g53767.x + break111_g53767.z ) ) );
				half ObjectData20_g53768 = Variation_Complex102_g53767;
				half Variation_Simple105_g53767 = v.ase_color.r;
				half WorldData19_g53768 = Variation_Simple105_g53767;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53768 = WorldData19_g53768;
				#else
				float staticSwitch14_g53768 = ObjectData20_g53768;
				#endif
				half Motion_Variation3073_g53707 = staticSwitch14_g53768;
				half Motion_Variation284_g53757 = ( _MotionVariation_10 * Motion_Variation3073_g53707 );
				float2 appendResult344_g53757 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53757 = ( _MotionScale_10 * appendResult344_g53757 );
				half2 Sine_MinusOneToOne281_g53757 = sin( ( mulTime373_g53757 + Motion_Variation284_g53757 + Motion_Scale287_g53757 ) );
				float2 temp_cast_8 = (1.0).xx;
				half Input_Turbulence327_g53757 = Global_NoiseTex_R34_g53707;
				float2 lerpResult321_g53757 = lerp( Sine_MinusOneToOne281_g53757 , temp_cast_8 , Input_Turbulence327_g53757);
				half2 Motion_Bending2258_g53707 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53707 ) * Wind_Power_103106_g53707 * Wind_DirectionOS39_g53707 * Global_NoiseTex_R34_g53707 * lerpResult321_g53757 );
				half Interaction_Amplitude4137_g53707 = _InteractionAmplitude;
				float3 Position83_g53749 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53749 = _LayerReactValue;
				float4 lerpResult87_g53749 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53749).xz ) ),temp_output_84_0_g53749, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53749]);
				half4 Global_React_Params4173_g53707 = lerpResult87_g53749;
				float4 break322_g53726 = Global_React_Params4173_g53707;
				half Interaction_Mask66_g53707 = break322_g53726.z;
				float3 appendResult397_g53726 = (float3(break322_g53726.x , 0.0 , break322_g53726.y));
				float3 temp_output_398_0_g53726 = (appendResult397_g53726*2.0 + -1.0);
				float3 temp_output_339_0_g53726 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53726 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4158_g53707 = (temp_output_339_0_g53726).xz;
				float lerpResult3307_g53707 = lerp( 1.0 , Motion_Variation3073_g53707 , _InteractionVariation);
				half2 Motion_Interaction53_g53707 = ( Interaction_Amplitude4137_g53707 * Motion_Max_Bending1133_g53707 * Interaction_Mask66_g53707 * Interaction_Mask66_g53707 * Interaction_DirectionOS4158_g53707 * lerpResult3307_g53707 );
				float2 lerpResult109_g53707 = lerp( Motion_Bending2258_g53707 , Motion_Interaction53_g53707 , ( Interaction_Mask66_g53707 * saturate( Interaction_Amplitude4137_g53707 ) ));
				half Mesh_Motion_182_g53707 = v.ase_texcoord3.x;
				float2 break143_g53707 = ( lerpResult109_g53707 * Mesh_Motion_182_g53707 );
				half Motion_Z190_g53707 = break143_g53707.y;
				half Angle44_g53723 = Motion_Z190_g53707;
				half3 VertexPos40_g53733 = ( VertexPosRotationAxis50_g53723 + ( VertexPosOtherAxis82_g53723 * cos( Angle44_g53723 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53723 ) * sin( Angle44_g53723 ) ) );
				float3 appendResult74_g53733 = (float3(0.0 , 0.0 , VertexPos40_g53733.z));
				half3 VertexPosRotationAxis50_g53733 = appendResult74_g53733;
				float3 break84_g53733 = VertexPos40_g53733;
				float3 appendResult81_g53733 = (float3(break84_g53733.x , break84_g53733.y , 0.0));
				half3 VertexPosOtherAxis82_g53733 = appendResult81_g53733;
				half Motion_X216_g53707 = break143_g53707.x;
				half Angle44_g53733 = -Motion_X216_g53707;
				half Motion_Scale321_g53741 = ( _MotionScale_32 * 10.0 );
				half Input_Speed62_g53741 = _MotionSpeed_32;
				float mulTime349_g53741 = _TimeParameters.x * Input_Speed62_g53741;
				float Motion_Variation330_g53741 = ( _MotionVariation_32 * Motion_Variation3073_g53707 );
				float Bounds_Radius121_g53707 = _MaxBoundsInfo.x;
				half Input_Amplitude58_g53741 = ( _MotionAmplitude_32 * Bounds_Radius121_g53707 * 0.1 );
				float3 temp_output_299_0_g53741 = ( sin( ( ( ase_worldPos * Motion_Scale321_g53741 ) + mulTime349_g53741 + Motion_Variation330_g53741 ) ) * Input_Amplitude58_g53741 );
				half Global_NoiseTex_A139_g53707 = break142_g53743.a;
				half Mesh_Motion_3144_g53707 = v.ase_texcoord3.z;
				float lerpResult378_g53745 = lerp( 0.3 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_323115_g53707 = lerpResult378_g53745;
				float temp_output_7_0_g53789 = TVE_MotionFadeEnd;
				half Wind_FadeOut4005_g53707 = saturate( ( ( distance( ase_worldPos , _WorldSpaceCameraPos ) - temp_output_7_0_g53789 ) / ( TVE_MotionFadeStart - temp_output_7_0_g53789 ) ) );
				half3 Motion_Detail263_g53707 = ( temp_output_299_0_g53741 * ( ( Global_NoiseTex_R34_g53707 + Global_NoiseTex_A139_g53707 ) * Mesh_Motion_3144_g53707 * Wind_Power_323115_g53707 * Wind_FadeOut4005_g53707 ) );
				float3 Vertex_Motion_Object833_g53707 = ( ( VertexPosRotationAxis50_g53733 + ( VertexPosOtherAxis82_g53733 * cos( Angle44_g53733 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53733 ) * sin( Angle44_g53733 ) ) ) + Motion_Detail263_g53707 );
				float3 temp_output_3474_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				float3 appendResult2043_g53707 = (float3(Motion_X216_g53707 , 0.0 , Motion_Z190_g53707));
				float3 Vertex_Motion_World1118_g53707 = ( ( temp_output_3474_0_g53707 + appendResult2043_g53707 ) + Motion_Detail263_g53707 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch3312_g53707 = Vertex_Motion_World1118_g53707;
				#else
				float3 staticSwitch3312_g53707 = ( Vertex_Motion_Object833_g53707 + ( 0.0 * _VertexDataMode ) );
				#endif
				half Global_Vertex_Size174_g53707 = break322_g53726.w;
				float lerpResult346_g53707 = lerp( 1.0 , Global_Vertex_Size174_g53707 , _GlobalSize);
				float3 appendResult3480_g53707 = (float3(lerpResult346_g53707 , lerpResult346_g53707 , lerpResult346_g53707));
				half3 ObjectData20_g53728 = appendResult3480_g53707;
				half3 _Vector11 = half3(1,1,1);
				half3 WorldData19_g53728 = _Vector11;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53728 = WorldData19_g53728;
				#else
				float3 staticSwitch14_g53728 = ObjectData20_g53728;
				#endif
				half3 Vertex_Size1741_g53707 = staticSwitch14_g53728;
				half3 _Vector5 = half3(1,1,1);
				float temp_output_7_0_g53779 = _SizeFadeEndValue;
				float temp_output_335_0_g53707 = saturate( ( ( ( distance( _WorldSpaceCameraPos , ObjectPosition4223_g53707 ) * ( 1.0 / TVE_DistanceFadeBias ) ) - temp_output_7_0_g53779 ) / ( _SizeFadeStartValue - temp_output_7_0_g53779 ) ) );
				float3 appendResult3482_g53707 = (float3(temp_output_335_0_g53707 , temp_output_335_0_g53707 , temp_output_335_0_g53707));
				float3 lerpResult3556_g53707 = lerp( _Vector5 , appendResult3482_g53707 , _SizeFadeMode);
				half3 ObjectData20_g53738 = lerpResult3556_g53707;
				half3 WorldData19_g53738 = _Vector5;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53738 = WorldData19_g53738;
				#else
				float3 staticSwitch14_g53738 = ObjectData20_g53738;
				#endif
				float3 Vertex_SizeFade1740_g53707 = staticSwitch14_g53738;
				float3 normalizeResult2696_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 break2709_g53707 = cross( normalizeResult2696_g53707 , half3(0,1,0) );
				float3 appendResult2710_g53707 = (float3(-break2709_g53707.z , 0.0 , break2709_g53707.x));
				float3 appendResult2667_g53707 = (float3(v.ase_color.r , 0.5 , v.ase_color.r));
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult2212_g53707 = dot( ViewDir_Normalized3963_g53707 , float3(0,1,0) );
				half Mask_HView2656_g53707 = dotResult2212_g53707;
				float saferPower2652_g53707 = max( Mask_HView2656_g53707 , 0.0001 );
				half3 Grass_Coverage2661_g53707 = ( ( ( mul( GetWorldToObjectMatrix(), float4( appendResult2710_g53707 , 0.0 ) ).xyz * _PerspectivePushValue ) + ( (appendResult2667_g53707*2.0 + -1.0) * _PerspectiveNoiseValue ) ) * v.ase_color.a * pow( saferPower2652_g53707 , _PerspectiveAngleValue ) );
				float3 Final_VertexPosition890_g53707 = ( ( staticSwitch3312_g53707 * Vertex_Size1741_g53707 * Vertex_SizeFade1740_g53707 ) + Mesh_PivotsOS2291_g53707 + Grass_Coverage2661_g53707 );
				
				float2 vertexToFrag11_g53744 = ( ( v.ase_texcoord.xy * (_MainUVs).xy ) + (_MainUVs).zw );
				o.ase_texcoord2.xy = vertexToFrag11_g53744;
				float3 vertexToFrag3890_g53707 = ase_worldPos;
				o.ase_texcoord3.xyz = vertexToFrag3890_g53707;
				
				o.ase_color = v.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord2.zw = 0;
				o.ase_texcoord3.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = Final_VertexPosition890_g53707;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				o.worldPos = positionWS;
				#endif
				float3 normalWS = TransformObjectToWorldDir(v.ase_normal);

				float4 clipPos = TransformWorldToHClip( ApplyShadowBias( positionWS, normalWS, _LightDirection ) );

				#if UNITY_REVERSED_Z
					clipPos.z = min(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
				#else
					clipPos.z = max(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = clipPos;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				o.clipPos = clipPos;
				return o;
			}

			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_color = v.ase_color;
				o.ase_texcoord3 = v.ase_texcoord3;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE)
				#define ASE_SV_DEPTH SV_DepthLessEqual  
			#else
				#define ASE_SV_DEPTH SV_Depth
			#endif

			half4 frag(	VertexOutput IN 
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );
				
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.worldPos;
				#endif
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float localCustomAlphaClip3735_g53707 = ( 0.0 );
				half Final_AlphaFade3727_g53707 = 1.0;
				float2 vertexToFrag11_g53744 = IN.ase_texcoord2.xy;
				half2 Main_UVs15_g53707 = vertexToFrag11_g53744;
				float4 tex2DNode29_g53707 = SAMPLE_TEXTURE2D( _MainAlbedoTex, sampler_MainAlbedoTex, Main_UVs15_g53707 );
				float Main_Alpha316_g53707 = ( _MainColor.a * tex2DNode29_g53707.a );
				float Mesh_Variation16_g53707 = IN.ase_color.r;
				float lerpResult4033_g53707 = lerp( 0.9 , (Mesh_Variation16_g53707*0.5 + 0.5) , _AlphaVariationValue);
				float3 vertexToFrag3890_g53707 = IN.ase_texcoord3.xyz;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float3 Position82_g53742 = WorldPosition3905_g53707;
				float temp_output_84_0_g53742 = _LayerExtrasValue;
				float4 lerpResult88_g53742 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53742).xz ) ),temp_output_84_0_g53742 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53742]);
				float4 break89_g53742 = lerpResult88_g53742;
				half Global_Extras_Alpha1033_g53707 = break89_g53742.a;
				float temp_output_4022_0_g53707 = ( lerpResult4033_g53707 - ( 1.0 - Global_Extras_Alpha1033_g53707 ) );
				half AlphaTreshold2132_g53707 = _Cutoff;
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch4017_g53707 = ( temp_output_4022_0_g53707 + AlphaTreshold2132_g53707 );
				#else
				float staticSwitch4017_g53707 = temp_output_4022_0_g53707;
				#endif
				float lerpResult4011_g53707 = lerp( 1.0 , staticSwitch4017_g53707 , _GlobalAlpha);
				half Global_Alpha315_g53707 = saturate( lerpResult4011_g53707 );
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch3792_g53707 = ( ( Main_Alpha316_g53707 * Global_Alpha315_g53707 ) - ( AlphaTreshold2132_g53707 - 0.5 ) );
				#else
				float staticSwitch3792_g53707 = ( Main_Alpha316_g53707 * Global_Alpha315_g53707 );
				#endif
				half Final_Alpha3754_g53707 = staticSwitch3792_g53707;
				float temp_output_661_0_g53707 = ( Final_AlphaFade3727_g53707 * Final_Alpha3754_g53707 );
				float Alpha3735_g53707 = temp_output_661_0_g53707;
				float Treshold3735_g53707 = 0.5;
				{
				#if TVE_ALPHA_CLIP
				clip(Alpha3735_g53707 - Treshold3735_g53707);
				#endif
				}
				half Final_Clip914_g53707 = saturate( Alpha3735_g53707 );
				
				float Alpha = Final_Clip914_g53707;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;
				#ifdef ASE_DEPTH_WRITE_ON
				float DepthValue = 0;
				#endif

				#ifdef _ALPHATEST_ON
					#ifdef _ALPHATEST_SHADOW_ON
						clip(Alpha - AlphaClipThresholdShadow);
					#else
						clip(Alpha - AlphaClipThreshold);
					#endif
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif
				#ifdef ASE_DEPTH_WRITE_ON
					outputDepth = DepthValue;
				#endif
				return 0;
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "DepthOnly"
			Tags { "LightMode"="DepthOnly" }

			ZWrite On
			ColorMask 0
			AlphaToMask Off

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile _ DOTS_INSTANCING_ON
			#define ASE_ABSOLUTE_VERTEX_POS 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 100202
			#define ASE_USING_SAMPLING_MACROS 1

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_DEPTHONLY

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#pragma shader_feature_local TVE_ALPHA_CLIP
			#pragma shader_feature_local TVE_VERTEX_DATA_BATCHED
			//TVE Shader Type Defines
			#define TVE_IS_GRASS_SHADER
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD1;
				#endif
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _MainUVs;
			half4 _MotionHighlightColor;
			half4 _MainColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _GradientColorOne;
			half4 _GradientColorTwo;
			half4 _SubsurfaceColor;
			float4 _SubsurfaceDiffusion_Asset;
			half4 _ColorsMaskRemap;
			float4 _MaxBoundsInfo;
			half4 _DetailBlendRemap;
			half4 _VertexOcclusionRemap;
			half4 _NoiseColorTwo;
			half4 _OverlayMaskRemap;
			float4 _NoiseMaskRemap;
			half4 _SubsurfaceMaskRemap;
			half4 _EmissiveUVs;
			half4 _VertexOcclusionColor;
			float4 _EmissiveIntensityParams;
			half4 _EmissiveColor;
			half4 _NoiseColorOne;
			float4 _Color;
			float4 _GradientMaskRemap;
			half3 _render_normals_options;
			half _VertexDataMode;
			half _GradientMaxValue;
			half _InteractionVariation;
			float _MotionScale_32;
			float _MotionSpeed_32;
			half _GradientMinValue;
			float _MotionVariation_32;
			half _PerspectiveAngleValue;
			half _PerspectiveNoiseValue;
			half _GlobalSize;
			half _PerspectivePushValue;
			half _SizeFadeStartValue;
			half _SizeFadeMode;
			half _MotionAmplitude_32;
			half _SizeFadeEndValue;
			half _render_src;
			half _NoiseMinValue;
			half _MainOcclusionValue;
			half _GlobalWetness;
			half _MainSmoothnessValue;
			half _RenderSpecular;
			half _GlobalEmissive;
			half _MainNormalValue;
			half _VertexOcclusionMaxValue;
			half _VertexOcclusionMinValue;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _ColorsMaskMaxValue;
			half _ColorsMaskMinValue;
			half _ColorsVariationValue;
			half _GlobalColors;
			half _LayerColorsValue;
			half _LayerReactValue;
			half _NoiseMaxValue;
			half _NoiseScaleValue;
			half _InteractionAmplitude;
			half _MotionAmplitude_10;
			half _MotionVariation_10;
			half _GradientCat;
			half _PerspectiveCat;
			half _TranslucencyIntensityValue;
			half _MainCat;
			half _DetailCat;
			half _RenderNormals;
			half _DetailSpace;
			half _NoiseCat;
			half _TranslucencyNormalValue;
			float _SubsurfaceDiffusion;
			half _RenderZWrite;
			half _MotionCat;
			half _VariationMotionMessage;
			half _TranslucencyAmbientValue;
			half _Cutoff;
			half _RenderCull;
			half _TranslucencyDirectValue;
			half _RenderClip;
			half _TranslucencyShadowValue;
			half _EmissiveCat;
			half _IsGrassShader;
			half _render_cull;
			half _IsStandardShader;
			half _render_dst;
			half _render_zw;
			half _RenderingCat;
			half _TranslucencyScatteringValue;
			half _DetailTypeMode;
			half _GlobalCat;
			float _MotionSpeed_10;
			half _LayerMotionValue;
			half _vertex_pivot_mode;
			half _AlphaVariationValue;
			half _VertexPivotMode;
			half _VertexMasksMode;
			half _VertexVariationMode;
			half _SizeFadeMessage;
			half _DetailMode;
			half _VariationGlobalsMessage;
			half _SubsurfaceCat;
			half _OcclusionCat;
			float _MotionScale_10;
			half _TranslucencyHDMessage;
			half _DetailBlendMode;
			half _SizeFadeCat;
			half _EmissiveFlagMode;
			half _FadeSpace;
			half _MotionSpace;
			half _IsTVEShader;
			half _ReceiveSpace;
			half _RenderDecals;
			half _IsVersion;
			half _LayersSpace;
			half _RenderSSR;
			half _RenderMode;
			half _RenderPriority;
			half _GlobalAlpha;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);
			TEXTURE2D(_BumpMap);
			SAMPLER(sampler_BumpMap);
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			TEXTURE2D(TVE_NoiseTex);
			half4 TVE_NoiseParams;
			SAMPLER(samplerTVE_NoiseTex);
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			half TVE_MotionFadeEnd;
			half TVE_MotionFadeStart;
			half TVE_DistanceFadeBias;
			TEXTURE2D(_MainAlbedoTex);
			SAMPLER(sampler_MainAlbedoTex);
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];


			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 VertexPosition3588_g53707 = v.vertex.xyz;
				float3 appendResult60_g53759 = (float3(v.ase_texcoord.z , 0.0 , v.ase_texcoord.w));
				half3 Mesh_PivotsData2831_g53707 = ( appendResult60_g53759 * _VertexPivotMode );
				half3 Mesh_PivotsOS2291_g53707 = Mesh_PivotsData2831_g53707;
				float3 temp_output_2283_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				half3 VertexPos40_g53723 = temp_output_2283_0_g53707;
				float3 appendResult74_g53723 = (float3(VertexPos40_g53723.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53723 = appendResult74_g53723;
				float3 break84_g53723 = VertexPos40_g53723;
				float3 appendResult81_g53723 = (float3(0.0 , break84_g53723.y , break84_g53723.z));
				half3 VertexPosOtherAxis82_g53723 = appendResult81_g53723;
				half ObjectData20_g53786 = 3.14;
				float Bounds_Height374_g53707 = _MaxBoundsInfo.y;
				half WorldData19_g53786 = ( Bounds_Height374_g53707 * 3.14 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53786 = WorldData19_g53786;
				#else
				float staticSwitch14_g53786 = ObjectData20_g53786;
				#endif
				float Motion_Max_Bending1133_g53707 = staticSwitch14_g53786;
				float4x4 break19_g53751 = GetObjectToWorldMatrix();
				float3 appendResult20_g53751 = (float3(break19_g53751[ 0 ][ 3 ] , break19_g53751[ 1 ][ 3 ] , break19_g53751[ 2 ][ 3 ]));
				float3 appendResult60_g53753 = (float3(v.ase_texcoord.z , 0.0 , v.ase_texcoord.w));
				float3 temp_output_91_0_g53751 = ( appendResult60_g53753 * _vertex_pivot_mode );
				float3 PivotsOnly105_g53751 = (mul( GetObjectToWorldMatrix(), float4( temp_output_91_0_g53751 , 0.0 ) ).xyz).xyz;
				half3 ObjectData20_g53752 = ( appendResult20_g53751 + PivotsOnly105_g53751 );
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53752 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53752 = WorldData19_g53752;
				#else
				float3 staticSwitch14_g53752 = ObjectData20_g53752;
				#endif
				float3 temp_output_114_0_g53751 = staticSwitch14_g53752;
				float3 vertexToFrag4224_g53707 = temp_output_114_0_g53751;
				float3 ObjectPosition4223_g53707 = vertexToFrag4224_g53707;
				float3 Position83_g53758 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53758 = _LayerMotionValue;
				float4 lerpResult87_g53758 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53758).xz ) ),temp_output_84_0_g53758, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53758]);
				half4 Global_Motion_Params3909_g53707 = lerpResult87_g53758;
				float4 break322_g53745 = Global_Motion_Params3909_g53707;
				half Wind_Power369_g53745 = break322_g53745.z;
				float lerpResult376_g53745 = lerp( 0.1 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_103106_g53707 = lerpResult376_g53745;
				float3 appendResult397_g53745 = (float3(break322_g53745.x , 0.0 , break322_g53745.y));
				float3 temp_output_398_0_g53745 = (appendResult397_g53745*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53745 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53745 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53707 = (temp_output_339_0_g53745).xz;
				float2 panner73_g53743 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4223_g53707).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53743 = SAMPLE_TEXTURE2D_LOD( TVE_NoiseTex, samplerTVE_NoiseTex, panner73_g53743, 0.0 );
				float4 saferPower77_g53743 = max( abs( tex2DNode75_g53743 ) , 0.0001 );
				half Wind_Power2223_g53707 = Wind_Power369_g53745;
				float temp_output_167_0_g53743 = Wind_Power2223_g53707;
				float lerpResult168_g53743 = lerp( 1.5 , 0.25 , temp_output_167_0_g53743);
				float4 temp_cast_7 = (lerpResult168_g53743).xxxx;
				float4 break142_g53743 = pow( saferPower77_g53743 , temp_cast_7 );
				half Global_NoiseTex_R34_g53707 = break142_g53743.r;
				half Input_Speed62_g53757 = _MotionSpeed_10;
				float mulTime373_g53757 = _TimeParameters.x * Input_Speed62_g53757;
				float3 break111_g53767 = ObjectPosition4223_g53707;
				half Variation_Complex102_g53767 = frac( ( v.ase_color.r + ( break111_g53767.x + break111_g53767.z ) ) );
				half ObjectData20_g53768 = Variation_Complex102_g53767;
				half Variation_Simple105_g53767 = v.ase_color.r;
				half WorldData19_g53768 = Variation_Simple105_g53767;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53768 = WorldData19_g53768;
				#else
				float staticSwitch14_g53768 = ObjectData20_g53768;
				#endif
				half Motion_Variation3073_g53707 = staticSwitch14_g53768;
				half Motion_Variation284_g53757 = ( _MotionVariation_10 * Motion_Variation3073_g53707 );
				float2 appendResult344_g53757 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53757 = ( _MotionScale_10 * appendResult344_g53757 );
				half2 Sine_MinusOneToOne281_g53757 = sin( ( mulTime373_g53757 + Motion_Variation284_g53757 + Motion_Scale287_g53757 ) );
				float2 temp_cast_8 = (1.0).xx;
				half Input_Turbulence327_g53757 = Global_NoiseTex_R34_g53707;
				float2 lerpResult321_g53757 = lerp( Sine_MinusOneToOne281_g53757 , temp_cast_8 , Input_Turbulence327_g53757);
				half2 Motion_Bending2258_g53707 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53707 ) * Wind_Power_103106_g53707 * Wind_DirectionOS39_g53707 * Global_NoiseTex_R34_g53707 * lerpResult321_g53757 );
				half Interaction_Amplitude4137_g53707 = _InteractionAmplitude;
				float3 Position83_g53749 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53749 = _LayerReactValue;
				float4 lerpResult87_g53749 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53749).xz ) ),temp_output_84_0_g53749, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53749]);
				half4 Global_React_Params4173_g53707 = lerpResult87_g53749;
				float4 break322_g53726 = Global_React_Params4173_g53707;
				half Interaction_Mask66_g53707 = break322_g53726.z;
				float3 appendResult397_g53726 = (float3(break322_g53726.x , 0.0 , break322_g53726.y));
				float3 temp_output_398_0_g53726 = (appendResult397_g53726*2.0 + -1.0);
				float3 temp_output_339_0_g53726 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53726 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4158_g53707 = (temp_output_339_0_g53726).xz;
				float lerpResult3307_g53707 = lerp( 1.0 , Motion_Variation3073_g53707 , _InteractionVariation);
				half2 Motion_Interaction53_g53707 = ( Interaction_Amplitude4137_g53707 * Motion_Max_Bending1133_g53707 * Interaction_Mask66_g53707 * Interaction_Mask66_g53707 * Interaction_DirectionOS4158_g53707 * lerpResult3307_g53707 );
				float2 lerpResult109_g53707 = lerp( Motion_Bending2258_g53707 , Motion_Interaction53_g53707 , ( Interaction_Mask66_g53707 * saturate( Interaction_Amplitude4137_g53707 ) ));
				half Mesh_Motion_182_g53707 = v.ase_texcoord3.x;
				float2 break143_g53707 = ( lerpResult109_g53707 * Mesh_Motion_182_g53707 );
				half Motion_Z190_g53707 = break143_g53707.y;
				half Angle44_g53723 = Motion_Z190_g53707;
				half3 VertexPos40_g53733 = ( VertexPosRotationAxis50_g53723 + ( VertexPosOtherAxis82_g53723 * cos( Angle44_g53723 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53723 ) * sin( Angle44_g53723 ) ) );
				float3 appendResult74_g53733 = (float3(0.0 , 0.0 , VertexPos40_g53733.z));
				half3 VertexPosRotationAxis50_g53733 = appendResult74_g53733;
				float3 break84_g53733 = VertexPos40_g53733;
				float3 appendResult81_g53733 = (float3(break84_g53733.x , break84_g53733.y , 0.0));
				half3 VertexPosOtherAxis82_g53733 = appendResult81_g53733;
				half Motion_X216_g53707 = break143_g53707.x;
				half Angle44_g53733 = -Motion_X216_g53707;
				half Motion_Scale321_g53741 = ( _MotionScale_32 * 10.0 );
				half Input_Speed62_g53741 = _MotionSpeed_32;
				float mulTime349_g53741 = _TimeParameters.x * Input_Speed62_g53741;
				float Motion_Variation330_g53741 = ( _MotionVariation_32 * Motion_Variation3073_g53707 );
				float Bounds_Radius121_g53707 = _MaxBoundsInfo.x;
				half Input_Amplitude58_g53741 = ( _MotionAmplitude_32 * Bounds_Radius121_g53707 * 0.1 );
				float3 temp_output_299_0_g53741 = ( sin( ( ( ase_worldPos * Motion_Scale321_g53741 ) + mulTime349_g53741 + Motion_Variation330_g53741 ) ) * Input_Amplitude58_g53741 );
				half Global_NoiseTex_A139_g53707 = break142_g53743.a;
				half Mesh_Motion_3144_g53707 = v.ase_texcoord3.z;
				float lerpResult378_g53745 = lerp( 0.3 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_323115_g53707 = lerpResult378_g53745;
				float temp_output_7_0_g53789 = TVE_MotionFadeEnd;
				half Wind_FadeOut4005_g53707 = saturate( ( ( distance( ase_worldPos , _WorldSpaceCameraPos ) - temp_output_7_0_g53789 ) / ( TVE_MotionFadeStart - temp_output_7_0_g53789 ) ) );
				half3 Motion_Detail263_g53707 = ( temp_output_299_0_g53741 * ( ( Global_NoiseTex_R34_g53707 + Global_NoiseTex_A139_g53707 ) * Mesh_Motion_3144_g53707 * Wind_Power_323115_g53707 * Wind_FadeOut4005_g53707 ) );
				float3 Vertex_Motion_Object833_g53707 = ( ( VertexPosRotationAxis50_g53733 + ( VertexPosOtherAxis82_g53733 * cos( Angle44_g53733 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53733 ) * sin( Angle44_g53733 ) ) ) + Motion_Detail263_g53707 );
				float3 temp_output_3474_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				float3 appendResult2043_g53707 = (float3(Motion_X216_g53707 , 0.0 , Motion_Z190_g53707));
				float3 Vertex_Motion_World1118_g53707 = ( ( temp_output_3474_0_g53707 + appendResult2043_g53707 ) + Motion_Detail263_g53707 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch3312_g53707 = Vertex_Motion_World1118_g53707;
				#else
				float3 staticSwitch3312_g53707 = ( Vertex_Motion_Object833_g53707 + ( 0.0 * _VertexDataMode ) );
				#endif
				half Global_Vertex_Size174_g53707 = break322_g53726.w;
				float lerpResult346_g53707 = lerp( 1.0 , Global_Vertex_Size174_g53707 , _GlobalSize);
				float3 appendResult3480_g53707 = (float3(lerpResult346_g53707 , lerpResult346_g53707 , lerpResult346_g53707));
				half3 ObjectData20_g53728 = appendResult3480_g53707;
				half3 _Vector11 = half3(1,1,1);
				half3 WorldData19_g53728 = _Vector11;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53728 = WorldData19_g53728;
				#else
				float3 staticSwitch14_g53728 = ObjectData20_g53728;
				#endif
				half3 Vertex_Size1741_g53707 = staticSwitch14_g53728;
				half3 _Vector5 = half3(1,1,1);
				float temp_output_7_0_g53779 = _SizeFadeEndValue;
				float temp_output_335_0_g53707 = saturate( ( ( ( distance( _WorldSpaceCameraPos , ObjectPosition4223_g53707 ) * ( 1.0 / TVE_DistanceFadeBias ) ) - temp_output_7_0_g53779 ) / ( _SizeFadeStartValue - temp_output_7_0_g53779 ) ) );
				float3 appendResult3482_g53707 = (float3(temp_output_335_0_g53707 , temp_output_335_0_g53707 , temp_output_335_0_g53707));
				float3 lerpResult3556_g53707 = lerp( _Vector5 , appendResult3482_g53707 , _SizeFadeMode);
				half3 ObjectData20_g53738 = lerpResult3556_g53707;
				half3 WorldData19_g53738 = _Vector5;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53738 = WorldData19_g53738;
				#else
				float3 staticSwitch14_g53738 = ObjectData20_g53738;
				#endif
				float3 Vertex_SizeFade1740_g53707 = staticSwitch14_g53738;
				float3 normalizeResult2696_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 break2709_g53707 = cross( normalizeResult2696_g53707 , half3(0,1,0) );
				float3 appendResult2710_g53707 = (float3(-break2709_g53707.z , 0.0 , break2709_g53707.x));
				float3 appendResult2667_g53707 = (float3(v.ase_color.r , 0.5 , v.ase_color.r));
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult2212_g53707 = dot( ViewDir_Normalized3963_g53707 , float3(0,1,0) );
				half Mask_HView2656_g53707 = dotResult2212_g53707;
				float saferPower2652_g53707 = max( Mask_HView2656_g53707 , 0.0001 );
				half3 Grass_Coverage2661_g53707 = ( ( ( mul( GetWorldToObjectMatrix(), float4( appendResult2710_g53707 , 0.0 ) ).xyz * _PerspectivePushValue ) + ( (appendResult2667_g53707*2.0 + -1.0) * _PerspectiveNoiseValue ) ) * v.ase_color.a * pow( saferPower2652_g53707 , _PerspectiveAngleValue ) );
				float3 Final_VertexPosition890_g53707 = ( ( staticSwitch3312_g53707 * Vertex_Size1741_g53707 * Vertex_SizeFade1740_g53707 ) + Mesh_PivotsOS2291_g53707 + Grass_Coverage2661_g53707 );
				
				float2 vertexToFrag11_g53744 = ( ( v.ase_texcoord.xy * (_MainUVs).xy ) + (_MainUVs).zw );
				o.ase_texcoord2.xy = vertexToFrag11_g53744;
				float3 vertexToFrag3890_g53707 = ase_worldPos;
				o.ase_texcoord3.xyz = vertexToFrag3890_g53707;
				
				o.ase_color = v.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord2.zw = 0;
				o.ase_texcoord3.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = Final_VertexPosition890_g53707;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;
				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float4 positionCS = TransformWorldToHClip( positionWS );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				o.worldPos = positionWS;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				o.clipPos = positionCS;
				return o;
			}

			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_color = v.ase_color;
				o.ase_texcoord3 = v.ase_texcoord3;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE)
				#define ASE_SV_DEPTH SV_DepthLessEqual  
			#else
				#define ASE_SV_DEPTH SV_Depth
			#endif
			half4 frag(	VertexOutput IN 
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.worldPos;
				#endif
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float localCustomAlphaClip3735_g53707 = ( 0.0 );
				half Final_AlphaFade3727_g53707 = 1.0;
				float2 vertexToFrag11_g53744 = IN.ase_texcoord2.xy;
				half2 Main_UVs15_g53707 = vertexToFrag11_g53744;
				float4 tex2DNode29_g53707 = SAMPLE_TEXTURE2D( _MainAlbedoTex, sampler_MainAlbedoTex, Main_UVs15_g53707 );
				float Main_Alpha316_g53707 = ( _MainColor.a * tex2DNode29_g53707.a );
				float Mesh_Variation16_g53707 = IN.ase_color.r;
				float lerpResult4033_g53707 = lerp( 0.9 , (Mesh_Variation16_g53707*0.5 + 0.5) , _AlphaVariationValue);
				float3 vertexToFrag3890_g53707 = IN.ase_texcoord3.xyz;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float3 Position82_g53742 = WorldPosition3905_g53707;
				float temp_output_84_0_g53742 = _LayerExtrasValue;
				float4 lerpResult88_g53742 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53742).xz ) ),temp_output_84_0_g53742 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53742]);
				float4 break89_g53742 = lerpResult88_g53742;
				half Global_Extras_Alpha1033_g53707 = break89_g53742.a;
				float temp_output_4022_0_g53707 = ( lerpResult4033_g53707 - ( 1.0 - Global_Extras_Alpha1033_g53707 ) );
				half AlphaTreshold2132_g53707 = _Cutoff;
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch4017_g53707 = ( temp_output_4022_0_g53707 + AlphaTreshold2132_g53707 );
				#else
				float staticSwitch4017_g53707 = temp_output_4022_0_g53707;
				#endif
				float lerpResult4011_g53707 = lerp( 1.0 , staticSwitch4017_g53707 , _GlobalAlpha);
				half Global_Alpha315_g53707 = saturate( lerpResult4011_g53707 );
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch3792_g53707 = ( ( Main_Alpha316_g53707 * Global_Alpha315_g53707 ) - ( AlphaTreshold2132_g53707 - 0.5 ) );
				#else
				float staticSwitch3792_g53707 = ( Main_Alpha316_g53707 * Global_Alpha315_g53707 );
				#endif
				half Final_Alpha3754_g53707 = staticSwitch3792_g53707;
				float temp_output_661_0_g53707 = ( Final_AlphaFade3727_g53707 * Final_Alpha3754_g53707 );
				float Alpha3735_g53707 = temp_output_661_0_g53707;
				float Treshold3735_g53707 = 0.5;
				{
				#if TVE_ALPHA_CLIP
				clip(Alpha3735_g53707 - Treshold3735_g53707);
				#endif
				}
				half Final_Clip914_g53707 = saturate( Alpha3735_g53707 );
				
				float Alpha = Final_Clip914_g53707;
				float AlphaClipThreshold = 0.5;
				#ifdef ASE_DEPTH_WRITE_ON
				float DepthValue = 0;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif
				#ifdef ASE_DEPTH_WRITE_ON
				outputDepth = DepthValue;
				#endif

				return 0;
			}
			ENDHLSL
		}
		
		
		Pass
		{
			
			Name "Meta"
			Tags { "LightMode"="Meta" }

			Cull Off

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile _ DOTS_INSTANCING_ON
			#define ASE_ABSOLUTE_VERTEX_POS 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 100202
			#define ASE_USING_SAMPLING_MACROS 1

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_META

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local TVE_ALPHA_CLIP
			#pragma shader_feature_local TVE_VERTEX_DATA_BATCHED
			//TVE Shader Type Defines
			#define TVE_IS_GRASS_SHADER
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END


			#pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A

			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD1;
				#endif
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_texcoord6 : TEXCOORD6;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _MainUVs;
			half4 _MotionHighlightColor;
			half4 _MainColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _GradientColorOne;
			half4 _GradientColorTwo;
			half4 _SubsurfaceColor;
			float4 _SubsurfaceDiffusion_Asset;
			half4 _ColorsMaskRemap;
			float4 _MaxBoundsInfo;
			half4 _DetailBlendRemap;
			half4 _VertexOcclusionRemap;
			half4 _NoiseColorTwo;
			half4 _OverlayMaskRemap;
			float4 _NoiseMaskRemap;
			half4 _SubsurfaceMaskRemap;
			half4 _EmissiveUVs;
			half4 _VertexOcclusionColor;
			float4 _EmissiveIntensityParams;
			half4 _EmissiveColor;
			half4 _NoiseColorOne;
			float4 _Color;
			float4 _GradientMaskRemap;
			half3 _render_normals_options;
			half _VertexDataMode;
			half _GradientMaxValue;
			half _InteractionVariation;
			float _MotionScale_32;
			float _MotionSpeed_32;
			half _GradientMinValue;
			float _MotionVariation_32;
			half _PerspectiveAngleValue;
			half _PerspectiveNoiseValue;
			half _GlobalSize;
			half _PerspectivePushValue;
			half _SizeFadeStartValue;
			half _SizeFadeMode;
			half _MotionAmplitude_32;
			half _SizeFadeEndValue;
			half _render_src;
			half _NoiseMinValue;
			half _MainOcclusionValue;
			half _GlobalWetness;
			half _MainSmoothnessValue;
			half _RenderSpecular;
			half _GlobalEmissive;
			half _MainNormalValue;
			half _VertexOcclusionMaxValue;
			half _VertexOcclusionMinValue;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _ColorsMaskMaxValue;
			half _ColorsMaskMinValue;
			half _ColorsVariationValue;
			half _GlobalColors;
			half _LayerColorsValue;
			half _LayerReactValue;
			half _NoiseMaxValue;
			half _NoiseScaleValue;
			half _InteractionAmplitude;
			half _MotionAmplitude_10;
			half _MotionVariation_10;
			half _GradientCat;
			half _PerspectiveCat;
			half _TranslucencyIntensityValue;
			half _MainCat;
			half _DetailCat;
			half _RenderNormals;
			half _DetailSpace;
			half _NoiseCat;
			half _TranslucencyNormalValue;
			float _SubsurfaceDiffusion;
			half _RenderZWrite;
			half _MotionCat;
			half _VariationMotionMessage;
			half _TranslucencyAmbientValue;
			half _Cutoff;
			half _RenderCull;
			half _TranslucencyDirectValue;
			half _RenderClip;
			half _TranslucencyShadowValue;
			half _EmissiveCat;
			half _IsGrassShader;
			half _render_cull;
			half _IsStandardShader;
			half _render_dst;
			half _render_zw;
			half _RenderingCat;
			half _TranslucencyScatteringValue;
			half _DetailTypeMode;
			half _GlobalCat;
			float _MotionSpeed_10;
			half _LayerMotionValue;
			half _vertex_pivot_mode;
			half _AlphaVariationValue;
			half _VertexPivotMode;
			half _VertexMasksMode;
			half _VertexVariationMode;
			half _SizeFadeMessage;
			half _DetailMode;
			half _VariationGlobalsMessage;
			half _SubsurfaceCat;
			half _OcclusionCat;
			float _MotionScale_10;
			half _TranslucencyHDMessage;
			half _DetailBlendMode;
			half _SizeFadeCat;
			half _EmissiveFlagMode;
			half _FadeSpace;
			half _MotionSpace;
			half _IsTVEShader;
			half _ReceiveSpace;
			half _RenderDecals;
			half _IsVersion;
			half _LayersSpace;
			half _RenderSSR;
			half _RenderMode;
			half _RenderPriority;
			half _GlobalAlpha;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);
			TEXTURE2D(_BumpMap);
			SAMPLER(sampler_BumpMap);
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			TEXTURE2D(TVE_NoiseTex);
			half4 TVE_NoiseParams;
			SAMPLER(samplerTVE_NoiseTex);
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			half TVE_MotionFadeEnd;
			half TVE_MotionFadeStart;
			half TVE_DistanceFadeBias;
			TEXTURE3D(TVE_WorldTex3D);
			SAMPLER(samplerTVE_WorldTex3D);
			TEXTURE2D(_MainAlbedoTex);
			SAMPLER(sampler_MainAlbedoTex);
			half4 TVE_ColorsParams;
			TEXTURE2D_ARRAY(TVE_ColorsTex);
			half4 TVE_ColorsCoord;
			SAMPLER(samplerTVE_ColorsTex);
			float TVE_ColorsUsage[9];
			half4 TVE_MainLightParams;
			half3 TVE_MainLightDirection;
			half4 TVE_OverlayColor;
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];
			TEXTURE2D(_EmissiveTex);
			SAMPLER(sampler_EmissiveTex);


			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 VertexPosition3588_g53707 = v.vertex.xyz;
				float3 appendResult60_g53759 = (float3(v.ase_texcoord.z , 0.0 , v.ase_texcoord.w));
				half3 Mesh_PivotsData2831_g53707 = ( appendResult60_g53759 * _VertexPivotMode );
				half3 Mesh_PivotsOS2291_g53707 = Mesh_PivotsData2831_g53707;
				float3 temp_output_2283_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				half3 VertexPos40_g53723 = temp_output_2283_0_g53707;
				float3 appendResult74_g53723 = (float3(VertexPos40_g53723.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53723 = appendResult74_g53723;
				float3 break84_g53723 = VertexPos40_g53723;
				float3 appendResult81_g53723 = (float3(0.0 , break84_g53723.y , break84_g53723.z));
				half3 VertexPosOtherAxis82_g53723 = appendResult81_g53723;
				half ObjectData20_g53786 = 3.14;
				float Bounds_Height374_g53707 = _MaxBoundsInfo.y;
				half WorldData19_g53786 = ( Bounds_Height374_g53707 * 3.14 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53786 = WorldData19_g53786;
				#else
				float staticSwitch14_g53786 = ObjectData20_g53786;
				#endif
				float Motion_Max_Bending1133_g53707 = staticSwitch14_g53786;
				float4x4 break19_g53751 = GetObjectToWorldMatrix();
				float3 appendResult20_g53751 = (float3(break19_g53751[ 0 ][ 3 ] , break19_g53751[ 1 ][ 3 ] , break19_g53751[ 2 ][ 3 ]));
				float3 appendResult60_g53753 = (float3(v.ase_texcoord.z , 0.0 , v.ase_texcoord.w));
				float3 temp_output_91_0_g53751 = ( appendResult60_g53753 * _vertex_pivot_mode );
				float3 PivotsOnly105_g53751 = (mul( GetObjectToWorldMatrix(), float4( temp_output_91_0_g53751 , 0.0 ) ).xyz).xyz;
				half3 ObjectData20_g53752 = ( appendResult20_g53751 + PivotsOnly105_g53751 );
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53752 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53752 = WorldData19_g53752;
				#else
				float3 staticSwitch14_g53752 = ObjectData20_g53752;
				#endif
				float3 temp_output_114_0_g53751 = staticSwitch14_g53752;
				float3 vertexToFrag4224_g53707 = temp_output_114_0_g53751;
				float3 ObjectPosition4223_g53707 = vertexToFrag4224_g53707;
				float3 Position83_g53758 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53758 = _LayerMotionValue;
				float4 lerpResult87_g53758 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53758).xz ) ),temp_output_84_0_g53758, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53758]);
				half4 Global_Motion_Params3909_g53707 = lerpResult87_g53758;
				float4 break322_g53745 = Global_Motion_Params3909_g53707;
				half Wind_Power369_g53745 = break322_g53745.z;
				float lerpResult376_g53745 = lerp( 0.1 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_103106_g53707 = lerpResult376_g53745;
				float3 appendResult397_g53745 = (float3(break322_g53745.x , 0.0 , break322_g53745.y));
				float3 temp_output_398_0_g53745 = (appendResult397_g53745*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53745 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53745 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53707 = (temp_output_339_0_g53745).xz;
				float2 panner73_g53743 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4223_g53707).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53743 = SAMPLE_TEXTURE2D_LOD( TVE_NoiseTex, samplerTVE_NoiseTex, panner73_g53743, 0.0 );
				float4 saferPower77_g53743 = max( abs( tex2DNode75_g53743 ) , 0.0001 );
				half Wind_Power2223_g53707 = Wind_Power369_g53745;
				float temp_output_167_0_g53743 = Wind_Power2223_g53707;
				float lerpResult168_g53743 = lerp( 1.5 , 0.25 , temp_output_167_0_g53743);
				float4 temp_cast_7 = (lerpResult168_g53743).xxxx;
				float4 break142_g53743 = pow( saferPower77_g53743 , temp_cast_7 );
				half Global_NoiseTex_R34_g53707 = break142_g53743.r;
				half Input_Speed62_g53757 = _MotionSpeed_10;
				float mulTime373_g53757 = _TimeParameters.x * Input_Speed62_g53757;
				float3 break111_g53767 = ObjectPosition4223_g53707;
				half Variation_Complex102_g53767 = frac( ( v.ase_color.r + ( break111_g53767.x + break111_g53767.z ) ) );
				half ObjectData20_g53768 = Variation_Complex102_g53767;
				half Variation_Simple105_g53767 = v.ase_color.r;
				half WorldData19_g53768 = Variation_Simple105_g53767;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53768 = WorldData19_g53768;
				#else
				float staticSwitch14_g53768 = ObjectData20_g53768;
				#endif
				half Motion_Variation3073_g53707 = staticSwitch14_g53768;
				half Motion_Variation284_g53757 = ( _MotionVariation_10 * Motion_Variation3073_g53707 );
				float2 appendResult344_g53757 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53757 = ( _MotionScale_10 * appendResult344_g53757 );
				half2 Sine_MinusOneToOne281_g53757 = sin( ( mulTime373_g53757 + Motion_Variation284_g53757 + Motion_Scale287_g53757 ) );
				float2 temp_cast_8 = (1.0).xx;
				half Input_Turbulence327_g53757 = Global_NoiseTex_R34_g53707;
				float2 lerpResult321_g53757 = lerp( Sine_MinusOneToOne281_g53757 , temp_cast_8 , Input_Turbulence327_g53757);
				half2 Motion_Bending2258_g53707 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53707 ) * Wind_Power_103106_g53707 * Wind_DirectionOS39_g53707 * Global_NoiseTex_R34_g53707 * lerpResult321_g53757 );
				half Interaction_Amplitude4137_g53707 = _InteractionAmplitude;
				float3 Position83_g53749 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53749 = _LayerReactValue;
				float4 lerpResult87_g53749 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53749).xz ) ),temp_output_84_0_g53749, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53749]);
				half4 Global_React_Params4173_g53707 = lerpResult87_g53749;
				float4 break322_g53726 = Global_React_Params4173_g53707;
				half Interaction_Mask66_g53707 = break322_g53726.z;
				float3 appendResult397_g53726 = (float3(break322_g53726.x , 0.0 , break322_g53726.y));
				float3 temp_output_398_0_g53726 = (appendResult397_g53726*2.0 + -1.0);
				float3 temp_output_339_0_g53726 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53726 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4158_g53707 = (temp_output_339_0_g53726).xz;
				float lerpResult3307_g53707 = lerp( 1.0 , Motion_Variation3073_g53707 , _InteractionVariation);
				half2 Motion_Interaction53_g53707 = ( Interaction_Amplitude4137_g53707 * Motion_Max_Bending1133_g53707 * Interaction_Mask66_g53707 * Interaction_Mask66_g53707 * Interaction_DirectionOS4158_g53707 * lerpResult3307_g53707 );
				float2 lerpResult109_g53707 = lerp( Motion_Bending2258_g53707 , Motion_Interaction53_g53707 , ( Interaction_Mask66_g53707 * saturate( Interaction_Amplitude4137_g53707 ) ));
				half Mesh_Motion_182_g53707 = v.ase_texcoord3.x;
				float2 break143_g53707 = ( lerpResult109_g53707 * Mesh_Motion_182_g53707 );
				half Motion_Z190_g53707 = break143_g53707.y;
				half Angle44_g53723 = Motion_Z190_g53707;
				half3 VertexPos40_g53733 = ( VertexPosRotationAxis50_g53723 + ( VertexPosOtherAxis82_g53723 * cos( Angle44_g53723 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53723 ) * sin( Angle44_g53723 ) ) );
				float3 appendResult74_g53733 = (float3(0.0 , 0.0 , VertexPos40_g53733.z));
				half3 VertexPosRotationAxis50_g53733 = appendResult74_g53733;
				float3 break84_g53733 = VertexPos40_g53733;
				float3 appendResult81_g53733 = (float3(break84_g53733.x , break84_g53733.y , 0.0));
				half3 VertexPosOtherAxis82_g53733 = appendResult81_g53733;
				half Motion_X216_g53707 = break143_g53707.x;
				half Angle44_g53733 = -Motion_X216_g53707;
				half Motion_Scale321_g53741 = ( _MotionScale_32 * 10.0 );
				half Input_Speed62_g53741 = _MotionSpeed_32;
				float mulTime349_g53741 = _TimeParameters.x * Input_Speed62_g53741;
				float Motion_Variation330_g53741 = ( _MotionVariation_32 * Motion_Variation3073_g53707 );
				float Bounds_Radius121_g53707 = _MaxBoundsInfo.x;
				half Input_Amplitude58_g53741 = ( _MotionAmplitude_32 * Bounds_Radius121_g53707 * 0.1 );
				float3 temp_output_299_0_g53741 = ( sin( ( ( ase_worldPos * Motion_Scale321_g53741 ) + mulTime349_g53741 + Motion_Variation330_g53741 ) ) * Input_Amplitude58_g53741 );
				half Global_NoiseTex_A139_g53707 = break142_g53743.a;
				half Mesh_Motion_3144_g53707 = v.ase_texcoord3.z;
				float lerpResult378_g53745 = lerp( 0.3 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_323115_g53707 = lerpResult378_g53745;
				float temp_output_7_0_g53789 = TVE_MotionFadeEnd;
				half Wind_FadeOut4005_g53707 = saturate( ( ( distance( ase_worldPos , _WorldSpaceCameraPos ) - temp_output_7_0_g53789 ) / ( TVE_MotionFadeStart - temp_output_7_0_g53789 ) ) );
				half3 Motion_Detail263_g53707 = ( temp_output_299_0_g53741 * ( ( Global_NoiseTex_R34_g53707 + Global_NoiseTex_A139_g53707 ) * Mesh_Motion_3144_g53707 * Wind_Power_323115_g53707 * Wind_FadeOut4005_g53707 ) );
				float3 Vertex_Motion_Object833_g53707 = ( ( VertexPosRotationAxis50_g53733 + ( VertexPosOtherAxis82_g53733 * cos( Angle44_g53733 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53733 ) * sin( Angle44_g53733 ) ) ) + Motion_Detail263_g53707 );
				float3 temp_output_3474_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				float3 appendResult2043_g53707 = (float3(Motion_X216_g53707 , 0.0 , Motion_Z190_g53707));
				float3 Vertex_Motion_World1118_g53707 = ( ( temp_output_3474_0_g53707 + appendResult2043_g53707 ) + Motion_Detail263_g53707 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch3312_g53707 = Vertex_Motion_World1118_g53707;
				#else
				float3 staticSwitch3312_g53707 = ( Vertex_Motion_Object833_g53707 + ( 0.0 * _VertexDataMode ) );
				#endif
				half Global_Vertex_Size174_g53707 = break322_g53726.w;
				float lerpResult346_g53707 = lerp( 1.0 , Global_Vertex_Size174_g53707 , _GlobalSize);
				float3 appendResult3480_g53707 = (float3(lerpResult346_g53707 , lerpResult346_g53707 , lerpResult346_g53707));
				half3 ObjectData20_g53728 = appendResult3480_g53707;
				half3 _Vector11 = half3(1,1,1);
				half3 WorldData19_g53728 = _Vector11;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53728 = WorldData19_g53728;
				#else
				float3 staticSwitch14_g53728 = ObjectData20_g53728;
				#endif
				half3 Vertex_Size1741_g53707 = staticSwitch14_g53728;
				half3 _Vector5 = half3(1,1,1);
				float temp_output_7_0_g53779 = _SizeFadeEndValue;
				float temp_output_335_0_g53707 = saturate( ( ( ( distance( _WorldSpaceCameraPos , ObjectPosition4223_g53707 ) * ( 1.0 / TVE_DistanceFadeBias ) ) - temp_output_7_0_g53779 ) / ( _SizeFadeStartValue - temp_output_7_0_g53779 ) ) );
				float3 appendResult3482_g53707 = (float3(temp_output_335_0_g53707 , temp_output_335_0_g53707 , temp_output_335_0_g53707));
				float3 lerpResult3556_g53707 = lerp( _Vector5 , appendResult3482_g53707 , _SizeFadeMode);
				half3 ObjectData20_g53738 = lerpResult3556_g53707;
				half3 WorldData19_g53738 = _Vector5;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53738 = WorldData19_g53738;
				#else
				float3 staticSwitch14_g53738 = ObjectData20_g53738;
				#endif
				float3 Vertex_SizeFade1740_g53707 = staticSwitch14_g53738;
				float3 normalizeResult2696_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 break2709_g53707 = cross( normalizeResult2696_g53707 , half3(0,1,0) );
				float3 appendResult2710_g53707 = (float3(-break2709_g53707.z , 0.0 , break2709_g53707.x));
				float3 appendResult2667_g53707 = (float3(v.ase_color.r , 0.5 , v.ase_color.r));
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult2212_g53707 = dot( ViewDir_Normalized3963_g53707 , float3(0,1,0) );
				half Mask_HView2656_g53707 = dotResult2212_g53707;
				float saferPower2652_g53707 = max( Mask_HView2656_g53707 , 0.0001 );
				half3 Grass_Coverage2661_g53707 = ( ( ( mul( GetWorldToObjectMatrix(), float4( appendResult2710_g53707 , 0.0 ) ).xyz * _PerspectivePushValue ) + ( (appendResult2667_g53707*2.0 + -1.0) * _PerspectiveNoiseValue ) ) * v.ase_color.a * pow( saferPower2652_g53707 , _PerspectiveAngleValue ) );
				float3 Final_VertexPosition890_g53707 = ( ( staticSwitch3312_g53707 * Vertex_Size1741_g53707 * Vertex_SizeFade1740_g53707 ) + Mesh_PivotsOS2291_g53707 + Grass_Coverage2661_g53707 );
				
				float temp_output_7_0_g53773 = _GradientMinValue;
				float4 lerpResult2779_g53707 = lerp( _GradientColorTwo , _GradientColorOne , saturate( ( ( v.ase_color.a - temp_output_7_0_g53773 ) / ( _GradientMaxValue - temp_output_7_0_g53773 ) ) ));
				half3 Gradient_Tint2784_g53707 = (lerpResult2779_g53707).rgb;
				float3 vertexToFrag11_g53775 = Gradient_Tint2784_g53707;
				o.ase_texcoord2.xyz = vertexToFrag11_g53775;
				float3 temp_cast_16 = (_NoiseScaleValue).xxx;
				float3 vertexToFrag3890_g53707 = ase_worldPos;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float temp_output_7_0_g53784 = _NoiseMinValue;
				half Noise_Mask3162_g53707 = saturate( ( ( SAMPLE_TEXTURE3D_LOD( TVE_WorldTex3D, samplerTVE_WorldTex3D, ( temp_cast_16 * WorldPosition3905_g53707 * 0.1 ), 0.0 ).r - temp_output_7_0_g53784 ) / ( _NoiseMaxValue - temp_output_7_0_g53784 ) ) );
				float4 lerpResult2800_g53707 = lerp( _NoiseColorTwo , _NoiseColorOne , Noise_Mask3162_g53707);
				half3 Noise_Tint2802_g53707 = (lerpResult2800_g53707).rgb;
				float3 vertexToFrag11_g53787 = Noise_Tint2802_g53707;
				o.ase_texcoord3.xyz = vertexToFrag11_g53787;
				float lerpResult169_g53743 = lerp( 4.0 , 2.0 , temp_output_167_0_g53743);
				half Global_NoiseTex_H2869_g53707 = pow( abs( tex2DNode75_g53743.a ) , lerpResult169_g53743 );
				half3 Highlight_Tint3231_g53707 = ( ( (_MotionHighlightColor).rgb * Global_NoiseTex_H2869_g53707 * Wind_Power_103106_g53707 * Wind_FadeOut4005_g53707 * v.ase_color.a ) + float3( 1,1,1 ) );
				float3 vertexToFrag11_g53766 = Highlight_Tint3231_g53707;
				o.ase_texcoord4.xyz = vertexToFrag11_g53766;
				float2 vertexToFrag11_g53744 = ( ( v.ase_texcoord.xy * (_MainUVs).xy ) + (_MainUVs).zw );
				o.ase_texcoord5.xy = vertexToFrag11_g53744;
				float3 Position58_g53740 = WorldPosition3905_g53707;
				float temp_output_82_0_g53740 = _LayerColorsValue;
				float4 lerpResult88_g53740 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ColorsTex, samplerTVE_ColorsTex, ( (TVE_ColorsCoord).zw + ( (TVE_ColorsCoord).xy * (Position58_g53740).xz ) ),temp_output_82_0_g53740, 0.0 ) , TVE_ColorsUsage[(int)temp_output_82_0_g53740]);
				half Global_ColorsTex_A1701_g53707 = (lerpResult88_g53740).a;
				float vertexToFrag11_g53776 = Global_ColorsTex_A1701_g53707;
				o.ase_texcoord2.w = vertexToFrag11_g53776;
				o.ase_texcoord6.xyz = vertexToFrag3890_g53707;
				
				float2 vertexToFrag11_g53724 = ( ( v.ase_texcoord.xy * (_EmissiveUVs).xy ) + (_EmissiveUVs).zw );
				o.ase_texcoord5.zw = vertexToFrag11_g53724;
				
				o.ase_color = v.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord3.w = 0;
				o.ase_texcoord4.w = 0;
				o.ase_texcoord6.w = 0;
				
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = Final_VertexPosition890_g53707;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				o.worldPos = positionWS;
				#endif

				o.clipPos = MetaVertexPosition( v.vertex, v.texcoord1.xy, v.texcoord1.xy, unity_LightmapST, unity_DynamicLightmapST );
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = o.clipPos;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				return o;
			}

			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.texcoord1 = v.texcoord1;
				o.texcoord2 = v.texcoord2;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_color = v.ase_color;
				o.ase_texcoord3 = v.ase_texcoord3;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				o.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag(VertexOutput IN  ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.worldPos;
				#endif
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float3 vertexToFrag11_g53775 = IN.ase_texcoord2.xyz;
				float3 vertexToFrag11_g53787 = IN.ase_texcoord3.xyz;
				float3 vertexToFrag11_g53766 = IN.ase_texcoord4.xyz;
				float2 vertexToFrag11_g53744 = IN.ase_texcoord5.xy;
				half2 Main_UVs15_g53707 = vertexToFrag11_g53744;
				float4 tex2DNode29_g53707 = SAMPLE_TEXTURE2D( _MainAlbedoTex, sampler_MainAlbedoTex, Main_UVs15_g53707 );
				float3 temp_output_51_0_g53707 = ( (_MainColor).rgb * (tex2DNode29_g53707).rgb );
				half3 Main_Albedo99_g53707 = temp_output_51_0_g53707;
				half3 Blend_Albedo265_g53707 = Main_Albedo99_g53707;
				half3 Blend_AlbedoTinted2808_g53707 = ( vertexToFrag11_g53775 * vertexToFrag11_g53787 * vertexToFrag11_g53766 * Blend_Albedo265_g53707 );
				float dotResult3616_g53707 = dot( Blend_AlbedoTinted2808_g53707 , float3(0.2126,0.7152,0.0722) );
				float3 temp_cast_0 = (dotResult3616_g53707).xxx;
				float vertexToFrag11_g53776 = IN.ase_texcoord2.w;
				half Global_Colors_Influence3668_g53707 = vertexToFrag11_g53776;
				float3 lerpResult3618_g53707 = lerp( Blend_AlbedoTinted2808_g53707 , temp_cast_0 , Global_Colors_Influence3668_g53707);
				float3 vertexToFrag3890_g53707 = IN.ase_texcoord6.xyz;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float3 Position58_g53740 = WorldPosition3905_g53707;
				float temp_output_82_0_g53740 = _LayerColorsValue;
				float4 lerpResult88_g53740 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ColorsTex, samplerTVE_ColorsTex, ( (TVE_ColorsCoord).zw + ( (TVE_ColorsCoord).xy * (Position58_g53740).xz ) ),temp_output_82_0_g53740 ) , TVE_ColorsUsage[(int)temp_output_82_0_g53740]);
				half3 Global_ColorsTex_RGB1700_g53707 = (lerpResult88_g53740).rgb;
				#ifdef UNITY_COLORSPACE_GAMMA
				float staticSwitch1_g53769 = 2.0;
				#else
				float staticSwitch1_g53769 = 4.594794;
				#endif
				float3 temp_output_1953_0_g53707 = ( Global_ColorsTex_RGB1700_g53707 * staticSwitch1_g53769 );
				half3 Global_Colors1954_g53707 = temp_output_1953_0_g53707;
				float lerpResult3870_g53707 = lerp( 1.0 , IN.ase_color.r , _ColorsVariationValue);
				half Global_Colors_Value3650_g53707 = ( _GlobalColors * lerpResult3870_g53707 );
				float temp_output_7_0_g53778 = _ColorsMaskMinValue;
				half Global_Colors_Mask3692_g53707 = saturate( ( ( ( 1.0 - IN.ase_color.a ) - temp_output_7_0_g53778 ) / ( _ColorsMaskMaxValue - temp_output_7_0_g53778 ) ) );
				float3 lerpResult3628_g53707 = lerp( Blend_AlbedoTinted2808_g53707 , ( lerpResult3618_g53707 * Global_Colors1954_g53707 ) , ( Global_Colors_Value3650_g53707 * Global_Colors_Mask3692_g53707 ));
				half3 Blend_AlbedoColored863_g53707 = lerpResult3628_g53707;
				float3 temp_output_799_0_g53707 = (_SubsurfaceColor).rgb;
				float dotResult3930_g53707 = dot( temp_output_799_0_g53707 , float3(0.2126,0.7152,0.0722) );
				float3 temp_cast_3 = (dotResult3930_g53707).xxx;
				float3 lerpResult3932_g53707 = lerp( temp_output_799_0_g53707 , temp_cast_3 , Global_Colors_Influence3668_g53707);
				float3 lerpResult3942_g53707 = lerp( temp_output_799_0_g53707 , ( lerpResult3932_g53707 * Global_Colors1954_g53707 ) , ( Global_Colors_Value3650_g53707 * Global_Colors_Mask3692_g53707 ));
				half3 Subsurface_Color1722_g53707 = lerpResult3942_g53707;
				half MainLight_Subsurface4041_g53707 = TVE_MainLightParams.a;
				half Subsurface_Intensity1752_g53707 = ( _SubsurfaceValue * MainLight_Subsurface4041_g53707 );
				float temp_output_7_0_g53781 = _SubsurfaceMaskMinValue;
				half Subsurface_Mask1557_g53707 = saturate( ( ( IN.ase_color.a - temp_output_7_0_g53781 ) / ( _SubsurfaceMaskMaxValue - temp_output_7_0_g53781 ) ) );
				half3 Subsurface_Transmission884_g53707 = ( Subsurface_Color1722_g53707 * Subsurface_Intensity1752_g53707 * Subsurface_Mask1557_g53707 );
				half3 MainLight_Direction3926_g53707 = TVE_MainLightDirection;
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult785_g53707 = dot( -MainLight_Direction3926_g53707 , ViewDir_Normalized3963_g53707 );
				float saferPower1624_g53707 = max( (dotResult785_g53707*0.5 + 0.5) , 0.0001 );
				#ifdef UNITY_PASS_FORWARDADD
				float staticSwitch1602_g53707 = 0.0;
				#else
				float staticSwitch1602_g53707 = ( pow( saferPower1624_g53707 , _MainLightAngleValue ) * _MainLightScatteringValue );
				#endif
				half Mask_Subsurface_View782_g53707 = staticSwitch1602_g53707;
				half3 Subsurface_Scattering1693_g53707 = ( Subsurface_Transmission884_g53707 * Blend_AlbedoColored863_g53707 * Mask_Subsurface_View782_g53707 );
				half3 Blend_AlbedoAndSubsurface149_g53707 = ( Blend_AlbedoColored863_g53707 + Subsurface_Scattering1693_g53707 );
				half3 Global_OverlayColor1758_g53707 = (TVE_OverlayColor).rgb;
				half Main_AlbedoTex_G3526_g53707 = tex2DNode29_g53707.g;
				float3 Position82_g53742 = WorldPosition3905_g53707;
				float temp_output_84_0_g53742 = _LayerExtrasValue;
				float4 lerpResult88_g53742 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53742).xz ) ),temp_output_84_0_g53742 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53742]);
				float4 break89_g53742 = lerpResult88_g53742;
				half Global_Extras_Overlay156_g53707 = break89_g53742.b;
				float temp_output_1025_0_g53707 = ( _GlobalOverlay * Global_Extras_Overlay156_g53707 );
				float lerpResult1065_g53707 = lerp( 1.0 , IN.ase_color.r , _OverlayVariationValue);
				half Overlay_Commons1365_g53707 = ( temp_output_1025_0_g53707 * lerpResult1065_g53707 );
				float temp_output_7_0_g53770 = _OverlayMaskMinValue;
				half Overlay_Mask269_g53707 = saturate( ( ( ( ( ( IN.ase_color.a * 0.5 ) + Main_AlbedoTex_G3526_g53707 ) * Overlay_Commons1365_g53707 ) - temp_output_7_0_g53770 ) / ( _OverlayMaskMaxValue - temp_output_7_0_g53770 ) ) );
				float3 lerpResult336_g53707 = lerp( Blend_AlbedoAndSubsurface149_g53707 , Global_OverlayColor1758_g53707 , Overlay_Mask269_g53707);
				half3 Final_Albedo359_g53707 = lerpResult336_g53707;
				float3 temp_cast_6 = (1.0).xxx;
				float Mesh_Occlusion318_g53707 = IN.ase_color.g;
				float temp_output_7_0_g53782 = _VertexOcclusionMinValue;
				float3 lerpResult2945_g53707 = lerp( (_VertexOcclusionColor).rgb , temp_cast_6 , saturate( ( ( Mesh_Occlusion318_g53707 - temp_output_7_0_g53782 ) / ( _VertexOcclusionMaxValue - temp_output_7_0_g53782 ) ) ));
				float3 Vertex_Occlusion648_g53707 = lerpResult2945_g53707;
				
				float4 temp_output_4214_0_g53707 = ( _EmissiveColor * _EmissiveIntensityParams.x );
				float2 vertexToFrag11_g53724 = IN.ase_texcoord5.zw;
				half2 Emissive_UVs2468_g53707 = vertexToFrag11_g53724;
				half Global_Extras_Emissive4203_g53707 = break89_g53742.r;
				float lerpResult4206_g53707 = lerp( 1.0 , Global_Extras_Emissive4203_g53707 , _GlobalEmissive);
				half3 Final_Emissive2476_g53707 = ( (( temp_output_4214_0_g53707 * SAMPLE_TEXTURE2D( _EmissiveTex, sampler_EmissiveTex, Emissive_UVs2468_g53707 ) )).rgb * lerpResult4206_g53707 );
				
				float localCustomAlphaClip3735_g53707 = ( 0.0 );
				half Final_AlphaFade3727_g53707 = 1.0;
				float Main_Alpha316_g53707 = ( _MainColor.a * tex2DNode29_g53707.a );
				float Mesh_Variation16_g53707 = IN.ase_color.r;
				float lerpResult4033_g53707 = lerp( 0.9 , (Mesh_Variation16_g53707*0.5 + 0.5) , _AlphaVariationValue);
				half Global_Extras_Alpha1033_g53707 = break89_g53742.a;
				float temp_output_4022_0_g53707 = ( lerpResult4033_g53707 - ( 1.0 - Global_Extras_Alpha1033_g53707 ) );
				half AlphaTreshold2132_g53707 = _Cutoff;
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch4017_g53707 = ( temp_output_4022_0_g53707 + AlphaTreshold2132_g53707 );
				#else
				float staticSwitch4017_g53707 = temp_output_4022_0_g53707;
				#endif
				float lerpResult4011_g53707 = lerp( 1.0 , staticSwitch4017_g53707 , _GlobalAlpha);
				half Global_Alpha315_g53707 = saturate( lerpResult4011_g53707 );
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch3792_g53707 = ( ( Main_Alpha316_g53707 * Global_Alpha315_g53707 ) - ( AlphaTreshold2132_g53707 - 0.5 ) );
				#else
				float staticSwitch3792_g53707 = ( Main_Alpha316_g53707 * Global_Alpha315_g53707 );
				#endif
				half Final_Alpha3754_g53707 = staticSwitch3792_g53707;
				float temp_output_661_0_g53707 = ( Final_AlphaFade3727_g53707 * Final_Alpha3754_g53707 );
				float Alpha3735_g53707 = temp_output_661_0_g53707;
				float Treshold3735_g53707 = 0.5;
				{
				#if TVE_ALPHA_CLIP
				clip(Alpha3735_g53707 - Treshold3735_g53707);
				#endif
				}
				half Final_Clip914_g53707 = saturate( Alpha3735_g53707 );
				
				
				float3 Albedo = ( Final_Albedo359_g53707 * Vertex_Occlusion648_g53707 );
				float3 Emission = Final_Emissive2476_g53707;
				float Alpha = Final_Clip914_g53707;
				float AlphaClipThreshold = 0.5;

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				MetaInput metaInput = (MetaInput)0;
				metaInput.Albedo = Albedo;
				metaInput.Emission = Emission;
				
				return MetaFragment(metaInput);
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "Universal2D"
			Tags { "LightMode"="Universal2D" }

			Blend [_render_src] [_render_dst], One Zero
			ZWrite [_render_zw]
			ZTest LEqual
			Offset 0,0
			ColorMask RGBA

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile _ DOTS_INSTANCING_ON
			#define ASE_ABSOLUTE_VERTEX_POS 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 100202
			#define ASE_USING_SAMPLING_MACROS 1

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_2D

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			
			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local TVE_ALPHA_CLIP
			#pragma shader_feature_local TVE_VERTEX_DATA_BATCHED
			//TVE Shader Type Defines
			#define TVE_IS_GRASS_SHADER
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END


			#pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A

			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD1;
				#endif
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_texcoord6 : TEXCOORD6;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _MainUVs;
			half4 _MotionHighlightColor;
			half4 _MainColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _GradientColorOne;
			half4 _GradientColorTwo;
			half4 _SubsurfaceColor;
			float4 _SubsurfaceDiffusion_Asset;
			half4 _ColorsMaskRemap;
			float4 _MaxBoundsInfo;
			half4 _DetailBlendRemap;
			half4 _VertexOcclusionRemap;
			half4 _NoiseColorTwo;
			half4 _OverlayMaskRemap;
			float4 _NoiseMaskRemap;
			half4 _SubsurfaceMaskRemap;
			half4 _EmissiveUVs;
			half4 _VertexOcclusionColor;
			float4 _EmissiveIntensityParams;
			half4 _EmissiveColor;
			half4 _NoiseColorOne;
			float4 _Color;
			float4 _GradientMaskRemap;
			half3 _render_normals_options;
			half _VertexDataMode;
			half _GradientMaxValue;
			half _InteractionVariation;
			float _MotionScale_32;
			float _MotionSpeed_32;
			half _GradientMinValue;
			float _MotionVariation_32;
			half _PerspectiveAngleValue;
			half _PerspectiveNoiseValue;
			half _GlobalSize;
			half _PerspectivePushValue;
			half _SizeFadeStartValue;
			half _SizeFadeMode;
			half _MotionAmplitude_32;
			half _SizeFadeEndValue;
			half _render_src;
			half _NoiseMinValue;
			half _MainOcclusionValue;
			half _GlobalWetness;
			half _MainSmoothnessValue;
			half _RenderSpecular;
			half _GlobalEmissive;
			half _MainNormalValue;
			half _VertexOcclusionMaxValue;
			half _VertexOcclusionMinValue;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _ColorsMaskMaxValue;
			half _ColorsMaskMinValue;
			half _ColorsVariationValue;
			half _GlobalColors;
			half _LayerColorsValue;
			half _LayerReactValue;
			half _NoiseMaxValue;
			half _NoiseScaleValue;
			half _InteractionAmplitude;
			half _MotionAmplitude_10;
			half _MotionVariation_10;
			half _GradientCat;
			half _PerspectiveCat;
			half _TranslucencyIntensityValue;
			half _MainCat;
			half _DetailCat;
			half _RenderNormals;
			half _DetailSpace;
			half _NoiseCat;
			half _TranslucencyNormalValue;
			float _SubsurfaceDiffusion;
			half _RenderZWrite;
			half _MotionCat;
			half _VariationMotionMessage;
			half _TranslucencyAmbientValue;
			half _Cutoff;
			half _RenderCull;
			half _TranslucencyDirectValue;
			half _RenderClip;
			half _TranslucencyShadowValue;
			half _EmissiveCat;
			half _IsGrassShader;
			half _render_cull;
			half _IsStandardShader;
			half _render_dst;
			half _render_zw;
			half _RenderingCat;
			half _TranslucencyScatteringValue;
			half _DetailTypeMode;
			half _GlobalCat;
			float _MotionSpeed_10;
			half _LayerMotionValue;
			half _vertex_pivot_mode;
			half _AlphaVariationValue;
			half _VertexPivotMode;
			half _VertexMasksMode;
			half _VertexVariationMode;
			half _SizeFadeMessage;
			half _DetailMode;
			half _VariationGlobalsMessage;
			half _SubsurfaceCat;
			half _OcclusionCat;
			float _MotionScale_10;
			half _TranslucencyHDMessage;
			half _DetailBlendMode;
			half _SizeFadeCat;
			half _EmissiveFlagMode;
			half _FadeSpace;
			half _MotionSpace;
			half _IsTVEShader;
			half _ReceiveSpace;
			half _RenderDecals;
			half _IsVersion;
			half _LayersSpace;
			half _RenderSSR;
			half _RenderMode;
			half _RenderPriority;
			half _GlobalAlpha;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);
			TEXTURE2D(_BumpMap);
			SAMPLER(sampler_BumpMap);
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			TEXTURE2D(TVE_NoiseTex);
			half4 TVE_NoiseParams;
			SAMPLER(samplerTVE_NoiseTex);
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			half TVE_MotionFadeEnd;
			half TVE_MotionFadeStart;
			half TVE_DistanceFadeBias;
			TEXTURE3D(TVE_WorldTex3D);
			SAMPLER(samplerTVE_WorldTex3D);
			TEXTURE2D(_MainAlbedoTex);
			SAMPLER(sampler_MainAlbedoTex);
			half4 TVE_ColorsParams;
			TEXTURE2D_ARRAY(TVE_ColorsTex);
			half4 TVE_ColorsCoord;
			SAMPLER(samplerTVE_ColorsTex);
			float TVE_ColorsUsage[9];
			half4 TVE_MainLightParams;
			half3 TVE_MainLightDirection;
			half4 TVE_OverlayColor;
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];


			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				float3 VertexPosition3588_g53707 = v.vertex.xyz;
				float3 appendResult60_g53759 = (float3(v.ase_texcoord.z , 0.0 , v.ase_texcoord.w));
				half3 Mesh_PivotsData2831_g53707 = ( appendResult60_g53759 * _VertexPivotMode );
				half3 Mesh_PivotsOS2291_g53707 = Mesh_PivotsData2831_g53707;
				float3 temp_output_2283_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				half3 VertexPos40_g53723 = temp_output_2283_0_g53707;
				float3 appendResult74_g53723 = (float3(VertexPos40_g53723.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53723 = appendResult74_g53723;
				float3 break84_g53723 = VertexPos40_g53723;
				float3 appendResult81_g53723 = (float3(0.0 , break84_g53723.y , break84_g53723.z));
				half3 VertexPosOtherAxis82_g53723 = appendResult81_g53723;
				half ObjectData20_g53786 = 3.14;
				float Bounds_Height374_g53707 = _MaxBoundsInfo.y;
				half WorldData19_g53786 = ( Bounds_Height374_g53707 * 3.14 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53786 = WorldData19_g53786;
				#else
				float staticSwitch14_g53786 = ObjectData20_g53786;
				#endif
				float Motion_Max_Bending1133_g53707 = staticSwitch14_g53786;
				float4x4 break19_g53751 = GetObjectToWorldMatrix();
				float3 appendResult20_g53751 = (float3(break19_g53751[ 0 ][ 3 ] , break19_g53751[ 1 ][ 3 ] , break19_g53751[ 2 ][ 3 ]));
				float3 appendResult60_g53753 = (float3(v.ase_texcoord.z , 0.0 , v.ase_texcoord.w));
				float3 temp_output_91_0_g53751 = ( appendResult60_g53753 * _vertex_pivot_mode );
				float3 PivotsOnly105_g53751 = (mul( GetObjectToWorldMatrix(), float4( temp_output_91_0_g53751 , 0.0 ) ).xyz).xyz;
				half3 ObjectData20_g53752 = ( appendResult20_g53751 + PivotsOnly105_g53751 );
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53752 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53752 = WorldData19_g53752;
				#else
				float3 staticSwitch14_g53752 = ObjectData20_g53752;
				#endif
				float3 temp_output_114_0_g53751 = staticSwitch14_g53752;
				float3 vertexToFrag4224_g53707 = temp_output_114_0_g53751;
				float3 ObjectPosition4223_g53707 = vertexToFrag4224_g53707;
				float3 Position83_g53758 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53758 = _LayerMotionValue;
				float4 lerpResult87_g53758 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53758).xz ) ),temp_output_84_0_g53758, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53758]);
				half4 Global_Motion_Params3909_g53707 = lerpResult87_g53758;
				float4 break322_g53745 = Global_Motion_Params3909_g53707;
				half Wind_Power369_g53745 = break322_g53745.z;
				float lerpResult376_g53745 = lerp( 0.1 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_103106_g53707 = lerpResult376_g53745;
				float3 appendResult397_g53745 = (float3(break322_g53745.x , 0.0 , break322_g53745.y));
				float3 temp_output_398_0_g53745 = (appendResult397_g53745*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53745 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53745 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53707 = (temp_output_339_0_g53745).xz;
				float2 panner73_g53743 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4223_g53707).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53743 = SAMPLE_TEXTURE2D_LOD( TVE_NoiseTex, samplerTVE_NoiseTex, panner73_g53743, 0.0 );
				float4 saferPower77_g53743 = max( abs( tex2DNode75_g53743 ) , 0.0001 );
				half Wind_Power2223_g53707 = Wind_Power369_g53745;
				float temp_output_167_0_g53743 = Wind_Power2223_g53707;
				float lerpResult168_g53743 = lerp( 1.5 , 0.25 , temp_output_167_0_g53743);
				float4 temp_cast_7 = (lerpResult168_g53743).xxxx;
				float4 break142_g53743 = pow( saferPower77_g53743 , temp_cast_7 );
				half Global_NoiseTex_R34_g53707 = break142_g53743.r;
				half Input_Speed62_g53757 = _MotionSpeed_10;
				float mulTime373_g53757 = _TimeParameters.x * Input_Speed62_g53757;
				float3 break111_g53767 = ObjectPosition4223_g53707;
				half Variation_Complex102_g53767 = frac( ( v.ase_color.r + ( break111_g53767.x + break111_g53767.z ) ) );
				half ObjectData20_g53768 = Variation_Complex102_g53767;
				half Variation_Simple105_g53767 = v.ase_color.r;
				half WorldData19_g53768 = Variation_Simple105_g53767;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53768 = WorldData19_g53768;
				#else
				float staticSwitch14_g53768 = ObjectData20_g53768;
				#endif
				half Motion_Variation3073_g53707 = staticSwitch14_g53768;
				half Motion_Variation284_g53757 = ( _MotionVariation_10 * Motion_Variation3073_g53707 );
				float2 appendResult344_g53757 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53757 = ( _MotionScale_10 * appendResult344_g53757 );
				half2 Sine_MinusOneToOne281_g53757 = sin( ( mulTime373_g53757 + Motion_Variation284_g53757 + Motion_Scale287_g53757 ) );
				float2 temp_cast_8 = (1.0).xx;
				half Input_Turbulence327_g53757 = Global_NoiseTex_R34_g53707;
				float2 lerpResult321_g53757 = lerp( Sine_MinusOneToOne281_g53757 , temp_cast_8 , Input_Turbulence327_g53757);
				half2 Motion_Bending2258_g53707 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53707 ) * Wind_Power_103106_g53707 * Wind_DirectionOS39_g53707 * Global_NoiseTex_R34_g53707 * lerpResult321_g53757 );
				half Interaction_Amplitude4137_g53707 = _InteractionAmplitude;
				float3 Position83_g53749 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53749 = _LayerReactValue;
				float4 lerpResult87_g53749 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53749).xz ) ),temp_output_84_0_g53749, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53749]);
				half4 Global_React_Params4173_g53707 = lerpResult87_g53749;
				float4 break322_g53726 = Global_React_Params4173_g53707;
				half Interaction_Mask66_g53707 = break322_g53726.z;
				float3 appendResult397_g53726 = (float3(break322_g53726.x , 0.0 , break322_g53726.y));
				float3 temp_output_398_0_g53726 = (appendResult397_g53726*2.0 + -1.0);
				float3 temp_output_339_0_g53726 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53726 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4158_g53707 = (temp_output_339_0_g53726).xz;
				float lerpResult3307_g53707 = lerp( 1.0 , Motion_Variation3073_g53707 , _InteractionVariation);
				half2 Motion_Interaction53_g53707 = ( Interaction_Amplitude4137_g53707 * Motion_Max_Bending1133_g53707 * Interaction_Mask66_g53707 * Interaction_Mask66_g53707 * Interaction_DirectionOS4158_g53707 * lerpResult3307_g53707 );
				float2 lerpResult109_g53707 = lerp( Motion_Bending2258_g53707 , Motion_Interaction53_g53707 , ( Interaction_Mask66_g53707 * saturate( Interaction_Amplitude4137_g53707 ) ));
				half Mesh_Motion_182_g53707 = v.ase_texcoord3.x;
				float2 break143_g53707 = ( lerpResult109_g53707 * Mesh_Motion_182_g53707 );
				half Motion_Z190_g53707 = break143_g53707.y;
				half Angle44_g53723 = Motion_Z190_g53707;
				half3 VertexPos40_g53733 = ( VertexPosRotationAxis50_g53723 + ( VertexPosOtherAxis82_g53723 * cos( Angle44_g53723 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53723 ) * sin( Angle44_g53723 ) ) );
				float3 appendResult74_g53733 = (float3(0.0 , 0.0 , VertexPos40_g53733.z));
				half3 VertexPosRotationAxis50_g53733 = appendResult74_g53733;
				float3 break84_g53733 = VertexPos40_g53733;
				float3 appendResult81_g53733 = (float3(break84_g53733.x , break84_g53733.y , 0.0));
				half3 VertexPosOtherAxis82_g53733 = appendResult81_g53733;
				half Motion_X216_g53707 = break143_g53707.x;
				half Angle44_g53733 = -Motion_X216_g53707;
				half Motion_Scale321_g53741 = ( _MotionScale_32 * 10.0 );
				half Input_Speed62_g53741 = _MotionSpeed_32;
				float mulTime349_g53741 = _TimeParameters.x * Input_Speed62_g53741;
				float Motion_Variation330_g53741 = ( _MotionVariation_32 * Motion_Variation3073_g53707 );
				float Bounds_Radius121_g53707 = _MaxBoundsInfo.x;
				half Input_Amplitude58_g53741 = ( _MotionAmplitude_32 * Bounds_Radius121_g53707 * 0.1 );
				float3 temp_output_299_0_g53741 = ( sin( ( ( ase_worldPos * Motion_Scale321_g53741 ) + mulTime349_g53741 + Motion_Variation330_g53741 ) ) * Input_Amplitude58_g53741 );
				half Global_NoiseTex_A139_g53707 = break142_g53743.a;
				half Mesh_Motion_3144_g53707 = v.ase_texcoord3.z;
				float lerpResult378_g53745 = lerp( 0.3 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_323115_g53707 = lerpResult378_g53745;
				float temp_output_7_0_g53789 = TVE_MotionFadeEnd;
				half Wind_FadeOut4005_g53707 = saturate( ( ( distance( ase_worldPos , _WorldSpaceCameraPos ) - temp_output_7_0_g53789 ) / ( TVE_MotionFadeStart - temp_output_7_0_g53789 ) ) );
				half3 Motion_Detail263_g53707 = ( temp_output_299_0_g53741 * ( ( Global_NoiseTex_R34_g53707 + Global_NoiseTex_A139_g53707 ) * Mesh_Motion_3144_g53707 * Wind_Power_323115_g53707 * Wind_FadeOut4005_g53707 ) );
				float3 Vertex_Motion_Object833_g53707 = ( ( VertexPosRotationAxis50_g53733 + ( VertexPosOtherAxis82_g53733 * cos( Angle44_g53733 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53733 ) * sin( Angle44_g53733 ) ) ) + Motion_Detail263_g53707 );
				float3 temp_output_3474_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				float3 appendResult2043_g53707 = (float3(Motion_X216_g53707 , 0.0 , Motion_Z190_g53707));
				float3 Vertex_Motion_World1118_g53707 = ( ( temp_output_3474_0_g53707 + appendResult2043_g53707 ) + Motion_Detail263_g53707 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch3312_g53707 = Vertex_Motion_World1118_g53707;
				#else
				float3 staticSwitch3312_g53707 = ( Vertex_Motion_Object833_g53707 + ( 0.0 * _VertexDataMode ) );
				#endif
				half Global_Vertex_Size174_g53707 = break322_g53726.w;
				float lerpResult346_g53707 = lerp( 1.0 , Global_Vertex_Size174_g53707 , _GlobalSize);
				float3 appendResult3480_g53707 = (float3(lerpResult346_g53707 , lerpResult346_g53707 , lerpResult346_g53707));
				half3 ObjectData20_g53728 = appendResult3480_g53707;
				half3 _Vector11 = half3(1,1,1);
				half3 WorldData19_g53728 = _Vector11;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53728 = WorldData19_g53728;
				#else
				float3 staticSwitch14_g53728 = ObjectData20_g53728;
				#endif
				half3 Vertex_Size1741_g53707 = staticSwitch14_g53728;
				half3 _Vector5 = half3(1,1,1);
				float temp_output_7_0_g53779 = _SizeFadeEndValue;
				float temp_output_335_0_g53707 = saturate( ( ( ( distance( _WorldSpaceCameraPos , ObjectPosition4223_g53707 ) * ( 1.0 / TVE_DistanceFadeBias ) ) - temp_output_7_0_g53779 ) / ( _SizeFadeStartValue - temp_output_7_0_g53779 ) ) );
				float3 appendResult3482_g53707 = (float3(temp_output_335_0_g53707 , temp_output_335_0_g53707 , temp_output_335_0_g53707));
				float3 lerpResult3556_g53707 = lerp( _Vector5 , appendResult3482_g53707 , _SizeFadeMode);
				half3 ObjectData20_g53738 = lerpResult3556_g53707;
				half3 WorldData19_g53738 = _Vector5;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53738 = WorldData19_g53738;
				#else
				float3 staticSwitch14_g53738 = ObjectData20_g53738;
				#endif
				float3 Vertex_SizeFade1740_g53707 = staticSwitch14_g53738;
				float3 normalizeResult2696_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 break2709_g53707 = cross( normalizeResult2696_g53707 , half3(0,1,0) );
				float3 appendResult2710_g53707 = (float3(-break2709_g53707.z , 0.0 , break2709_g53707.x));
				float3 appendResult2667_g53707 = (float3(v.ase_color.r , 0.5 , v.ase_color.r));
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult2212_g53707 = dot( ViewDir_Normalized3963_g53707 , float3(0,1,0) );
				half Mask_HView2656_g53707 = dotResult2212_g53707;
				float saferPower2652_g53707 = max( Mask_HView2656_g53707 , 0.0001 );
				half3 Grass_Coverage2661_g53707 = ( ( ( mul( GetWorldToObjectMatrix(), float4( appendResult2710_g53707 , 0.0 ) ).xyz * _PerspectivePushValue ) + ( (appendResult2667_g53707*2.0 + -1.0) * _PerspectiveNoiseValue ) ) * v.ase_color.a * pow( saferPower2652_g53707 , _PerspectiveAngleValue ) );
				float3 Final_VertexPosition890_g53707 = ( ( staticSwitch3312_g53707 * Vertex_Size1741_g53707 * Vertex_SizeFade1740_g53707 ) + Mesh_PivotsOS2291_g53707 + Grass_Coverage2661_g53707 );
				
				float temp_output_7_0_g53773 = _GradientMinValue;
				float4 lerpResult2779_g53707 = lerp( _GradientColorTwo , _GradientColorOne , saturate( ( ( v.ase_color.a - temp_output_7_0_g53773 ) / ( _GradientMaxValue - temp_output_7_0_g53773 ) ) ));
				half3 Gradient_Tint2784_g53707 = (lerpResult2779_g53707).rgb;
				float3 vertexToFrag11_g53775 = Gradient_Tint2784_g53707;
				o.ase_texcoord2.xyz = vertexToFrag11_g53775;
				float3 temp_cast_16 = (_NoiseScaleValue).xxx;
				float3 vertexToFrag3890_g53707 = ase_worldPos;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float temp_output_7_0_g53784 = _NoiseMinValue;
				half Noise_Mask3162_g53707 = saturate( ( ( SAMPLE_TEXTURE3D_LOD( TVE_WorldTex3D, samplerTVE_WorldTex3D, ( temp_cast_16 * WorldPosition3905_g53707 * 0.1 ), 0.0 ).r - temp_output_7_0_g53784 ) / ( _NoiseMaxValue - temp_output_7_0_g53784 ) ) );
				float4 lerpResult2800_g53707 = lerp( _NoiseColorTwo , _NoiseColorOne , Noise_Mask3162_g53707);
				half3 Noise_Tint2802_g53707 = (lerpResult2800_g53707).rgb;
				float3 vertexToFrag11_g53787 = Noise_Tint2802_g53707;
				o.ase_texcoord3.xyz = vertexToFrag11_g53787;
				float lerpResult169_g53743 = lerp( 4.0 , 2.0 , temp_output_167_0_g53743);
				half Global_NoiseTex_H2869_g53707 = pow( abs( tex2DNode75_g53743.a ) , lerpResult169_g53743 );
				half3 Highlight_Tint3231_g53707 = ( ( (_MotionHighlightColor).rgb * Global_NoiseTex_H2869_g53707 * Wind_Power_103106_g53707 * Wind_FadeOut4005_g53707 * v.ase_color.a ) + float3( 1,1,1 ) );
				float3 vertexToFrag11_g53766 = Highlight_Tint3231_g53707;
				o.ase_texcoord4.xyz = vertexToFrag11_g53766;
				float2 vertexToFrag11_g53744 = ( ( v.ase_texcoord.xy * (_MainUVs).xy ) + (_MainUVs).zw );
				o.ase_texcoord5.xy = vertexToFrag11_g53744;
				float3 Position58_g53740 = WorldPosition3905_g53707;
				float temp_output_82_0_g53740 = _LayerColorsValue;
				float4 lerpResult88_g53740 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ColorsTex, samplerTVE_ColorsTex, ( (TVE_ColorsCoord).zw + ( (TVE_ColorsCoord).xy * (Position58_g53740).xz ) ),temp_output_82_0_g53740, 0.0 ) , TVE_ColorsUsage[(int)temp_output_82_0_g53740]);
				half Global_ColorsTex_A1701_g53707 = (lerpResult88_g53740).a;
				float vertexToFrag11_g53776 = Global_ColorsTex_A1701_g53707;
				o.ase_texcoord2.w = vertexToFrag11_g53776;
				o.ase_texcoord6.xyz = vertexToFrag3890_g53707;
				
				o.ase_color = v.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord3.w = 0;
				o.ase_texcoord4.w = 0;
				o.ase_texcoord5.zw = 0;
				o.ase_texcoord6.w = 0;
				
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = Final_VertexPosition890_g53707;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float4 positionCS = TransformWorldToHClip( positionWS );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				o.worldPos = positionWS;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.clipPos = positionCS;
				return o;
			}

			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_color = v.ase_color;
				o.ase_texcoord3 = v.ase_texcoord3;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag(VertexOutput IN  ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.worldPos;
				#endif
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float3 vertexToFrag11_g53775 = IN.ase_texcoord2.xyz;
				float3 vertexToFrag11_g53787 = IN.ase_texcoord3.xyz;
				float3 vertexToFrag11_g53766 = IN.ase_texcoord4.xyz;
				float2 vertexToFrag11_g53744 = IN.ase_texcoord5.xy;
				half2 Main_UVs15_g53707 = vertexToFrag11_g53744;
				float4 tex2DNode29_g53707 = SAMPLE_TEXTURE2D( _MainAlbedoTex, sampler_MainAlbedoTex, Main_UVs15_g53707 );
				float3 temp_output_51_0_g53707 = ( (_MainColor).rgb * (tex2DNode29_g53707).rgb );
				half3 Main_Albedo99_g53707 = temp_output_51_0_g53707;
				half3 Blend_Albedo265_g53707 = Main_Albedo99_g53707;
				half3 Blend_AlbedoTinted2808_g53707 = ( vertexToFrag11_g53775 * vertexToFrag11_g53787 * vertexToFrag11_g53766 * Blend_Albedo265_g53707 );
				float dotResult3616_g53707 = dot( Blend_AlbedoTinted2808_g53707 , float3(0.2126,0.7152,0.0722) );
				float3 temp_cast_0 = (dotResult3616_g53707).xxx;
				float vertexToFrag11_g53776 = IN.ase_texcoord2.w;
				half Global_Colors_Influence3668_g53707 = vertexToFrag11_g53776;
				float3 lerpResult3618_g53707 = lerp( Blend_AlbedoTinted2808_g53707 , temp_cast_0 , Global_Colors_Influence3668_g53707);
				float3 vertexToFrag3890_g53707 = IN.ase_texcoord6.xyz;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float3 Position58_g53740 = WorldPosition3905_g53707;
				float temp_output_82_0_g53740 = _LayerColorsValue;
				float4 lerpResult88_g53740 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ColorsTex, samplerTVE_ColorsTex, ( (TVE_ColorsCoord).zw + ( (TVE_ColorsCoord).xy * (Position58_g53740).xz ) ),temp_output_82_0_g53740 ) , TVE_ColorsUsage[(int)temp_output_82_0_g53740]);
				half3 Global_ColorsTex_RGB1700_g53707 = (lerpResult88_g53740).rgb;
				#ifdef UNITY_COLORSPACE_GAMMA
				float staticSwitch1_g53769 = 2.0;
				#else
				float staticSwitch1_g53769 = 4.594794;
				#endif
				float3 temp_output_1953_0_g53707 = ( Global_ColorsTex_RGB1700_g53707 * staticSwitch1_g53769 );
				half3 Global_Colors1954_g53707 = temp_output_1953_0_g53707;
				float lerpResult3870_g53707 = lerp( 1.0 , IN.ase_color.r , _ColorsVariationValue);
				half Global_Colors_Value3650_g53707 = ( _GlobalColors * lerpResult3870_g53707 );
				float temp_output_7_0_g53778 = _ColorsMaskMinValue;
				half Global_Colors_Mask3692_g53707 = saturate( ( ( ( 1.0 - IN.ase_color.a ) - temp_output_7_0_g53778 ) / ( _ColorsMaskMaxValue - temp_output_7_0_g53778 ) ) );
				float3 lerpResult3628_g53707 = lerp( Blend_AlbedoTinted2808_g53707 , ( lerpResult3618_g53707 * Global_Colors1954_g53707 ) , ( Global_Colors_Value3650_g53707 * Global_Colors_Mask3692_g53707 ));
				half3 Blend_AlbedoColored863_g53707 = lerpResult3628_g53707;
				float3 temp_output_799_0_g53707 = (_SubsurfaceColor).rgb;
				float dotResult3930_g53707 = dot( temp_output_799_0_g53707 , float3(0.2126,0.7152,0.0722) );
				float3 temp_cast_3 = (dotResult3930_g53707).xxx;
				float3 lerpResult3932_g53707 = lerp( temp_output_799_0_g53707 , temp_cast_3 , Global_Colors_Influence3668_g53707);
				float3 lerpResult3942_g53707 = lerp( temp_output_799_0_g53707 , ( lerpResult3932_g53707 * Global_Colors1954_g53707 ) , ( Global_Colors_Value3650_g53707 * Global_Colors_Mask3692_g53707 ));
				half3 Subsurface_Color1722_g53707 = lerpResult3942_g53707;
				half MainLight_Subsurface4041_g53707 = TVE_MainLightParams.a;
				half Subsurface_Intensity1752_g53707 = ( _SubsurfaceValue * MainLight_Subsurface4041_g53707 );
				float temp_output_7_0_g53781 = _SubsurfaceMaskMinValue;
				half Subsurface_Mask1557_g53707 = saturate( ( ( IN.ase_color.a - temp_output_7_0_g53781 ) / ( _SubsurfaceMaskMaxValue - temp_output_7_0_g53781 ) ) );
				half3 Subsurface_Transmission884_g53707 = ( Subsurface_Color1722_g53707 * Subsurface_Intensity1752_g53707 * Subsurface_Mask1557_g53707 );
				half3 MainLight_Direction3926_g53707 = TVE_MainLightDirection;
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult785_g53707 = dot( -MainLight_Direction3926_g53707 , ViewDir_Normalized3963_g53707 );
				float saferPower1624_g53707 = max( (dotResult785_g53707*0.5 + 0.5) , 0.0001 );
				#ifdef UNITY_PASS_FORWARDADD
				float staticSwitch1602_g53707 = 0.0;
				#else
				float staticSwitch1602_g53707 = ( pow( saferPower1624_g53707 , _MainLightAngleValue ) * _MainLightScatteringValue );
				#endif
				half Mask_Subsurface_View782_g53707 = staticSwitch1602_g53707;
				half3 Subsurface_Scattering1693_g53707 = ( Subsurface_Transmission884_g53707 * Blend_AlbedoColored863_g53707 * Mask_Subsurface_View782_g53707 );
				half3 Blend_AlbedoAndSubsurface149_g53707 = ( Blend_AlbedoColored863_g53707 + Subsurface_Scattering1693_g53707 );
				half3 Global_OverlayColor1758_g53707 = (TVE_OverlayColor).rgb;
				half Main_AlbedoTex_G3526_g53707 = tex2DNode29_g53707.g;
				float3 Position82_g53742 = WorldPosition3905_g53707;
				float temp_output_84_0_g53742 = _LayerExtrasValue;
				float4 lerpResult88_g53742 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53742).xz ) ),temp_output_84_0_g53742 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53742]);
				float4 break89_g53742 = lerpResult88_g53742;
				half Global_Extras_Overlay156_g53707 = break89_g53742.b;
				float temp_output_1025_0_g53707 = ( _GlobalOverlay * Global_Extras_Overlay156_g53707 );
				float lerpResult1065_g53707 = lerp( 1.0 , IN.ase_color.r , _OverlayVariationValue);
				half Overlay_Commons1365_g53707 = ( temp_output_1025_0_g53707 * lerpResult1065_g53707 );
				float temp_output_7_0_g53770 = _OverlayMaskMinValue;
				half Overlay_Mask269_g53707 = saturate( ( ( ( ( ( IN.ase_color.a * 0.5 ) + Main_AlbedoTex_G3526_g53707 ) * Overlay_Commons1365_g53707 ) - temp_output_7_0_g53770 ) / ( _OverlayMaskMaxValue - temp_output_7_0_g53770 ) ) );
				float3 lerpResult336_g53707 = lerp( Blend_AlbedoAndSubsurface149_g53707 , Global_OverlayColor1758_g53707 , Overlay_Mask269_g53707);
				half3 Final_Albedo359_g53707 = lerpResult336_g53707;
				float3 temp_cast_6 = (1.0).xxx;
				float Mesh_Occlusion318_g53707 = IN.ase_color.g;
				float temp_output_7_0_g53782 = _VertexOcclusionMinValue;
				float3 lerpResult2945_g53707 = lerp( (_VertexOcclusionColor).rgb , temp_cast_6 , saturate( ( ( Mesh_Occlusion318_g53707 - temp_output_7_0_g53782 ) / ( _VertexOcclusionMaxValue - temp_output_7_0_g53782 ) ) ));
				float3 Vertex_Occlusion648_g53707 = lerpResult2945_g53707;
				
				float localCustomAlphaClip3735_g53707 = ( 0.0 );
				half Final_AlphaFade3727_g53707 = 1.0;
				float Main_Alpha316_g53707 = ( _MainColor.a * tex2DNode29_g53707.a );
				float Mesh_Variation16_g53707 = IN.ase_color.r;
				float lerpResult4033_g53707 = lerp( 0.9 , (Mesh_Variation16_g53707*0.5 + 0.5) , _AlphaVariationValue);
				half Global_Extras_Alpha1033_g53707 = break89_g53742.a;
				float temp_output_4022_0_g53707 = ( lerpResult4033_g53707 - ( 1.0 - Global_Extras_Alpha1033_g53707 ) );
				half AlphaTreshold2132_g53707 = _Cutoff;
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch4017_g53707 = ( temp_output_4022_0_g53707 + AlphaTreshold2132_g53707 );
				#else
				float staticSwitch4017_g53707 = temp_output_4022_0_g53707;
				#endif
				float lerpResult4011_g53707 = lerp( 1.0 , staticSwitch4017_g53707 , _GlobalAlpha);
				half Global_Alpha315_g53707 = saturate( lerpResult4011_g53707 );
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch3792_g53707 = ( ( Main_Alpha316_g53707 * Global_Alpha315_g53707 ) - ( AlphaTreshold2132_g53707 - 0.5 ) );
				#else
				float staticSwitch3792_g53707 = ( Main_Alpha316_g53707 * Global_Alpha315_g53707 );
				#endif
				half Final_Alpha3754_g53707 = staticSwitch3792_g53707;
				float temp_output_661_0_g53707 = ( Final_AlphaFade3727_g53707 * Final_Alpha3754_g53707 );
				float Alpha3735_g53707 = temp_output_661_0_g53707;
				float Treshold3735_g53707 = 0.5;
				{
				#if TVE_ALPHA_CLIP
				clip(Alpha3735_g53707 - Treshold3735_g53707);
				#endif
				}
				half Final_Clip914_g53707 = saturate( Alpha3735_g53707 );
				
				
				float3 Albedo = ( Final_Albedo359_g53707 * Vertex_Occlusion648_g53707 );
				float Alpha = Final_Clip914_g53707;
				float AlphaClipThreshold = 0.5;

				half4 color = half4( Albedo, Alpha );

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				return color;
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "DepthNormals"
			Tags { "LightMode"="DepthNormals" }

			ZWrite On
			Blend One Zero
            ZTest LEqual
            ZWrite On

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile _ DOTS_INSTANCING_ON
			#define ASE_ABSOLUTE_VERTEX_POS 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 100202
			#define ASE_USING_SAMPLING_MACROS 1

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_DEPTHNORMALSONLY

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ASE_NEEDS_VERT_POSITION
			#pragma shader_feature_local TVE_ALPHA_CLIP
			#pragma shader_feature_local TVE_VERTEX_DATA_BATCHED
			//TVE Shader Type Defines
			#define TVE_IS_GRASS_SHADER
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD1;
				#endif
				float3 worldNormal : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_color : COLOR;
				float4 ase_texcoord4 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _MainUVs;
			half4 _MotionHighlightColor;
			half4 _MainColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _GradientColorOne;
			half4 _GradientColorTwo;
			half4 _SubsurfaceColor;
			float4 _SubsurfaceDiffusion_Asset;
			half4 _ColorsMaskRemap;
			float4 _MaxBoundsInfo;
			half4 _DetailBlendRemap;
			half4 _VertexOcclusionRemap;
			half4 _NoiseColorTwo;
			half4 _OverlayMaskRemap;
			float4 _NoiseMaskRemap;
			half4 _SubsurfaceMaskRemap;
			half4 _EmissiveUVs;
			half4 _VertexOcclusionColor;
			float4 _EmissiveIntensityParams;
			half4 _EmissiveColor;
			half4 _NoiseColorOne;
			float4 _Color;
			float4 _GradientMaskRemap;
			half3 _render_normals_options;
			half _VertexDataMode;
			half _GradientMaxValue;
			half _InteractionVariation;
			float _MotionScale_32;
			float _MotionSpeed_32;
			half _GradientMinValue;
			float _MotionVariation_32;
			half _PerspectiveAngleValue;
			half _PerspectiveNoiseValue;
			half _GlobalSize;
			half _PerspectivePushValue;
			half _SizeFadeStartValue;
			half _SizeFadeMode;
			half _MotionAmplitude_32;
			half _SizeFadeEndValue;
			half _render_src;
			half _NoiseMinValue;
			half _MainOcclusionValue;
			half _GlobalWetness;
			half _MainSmoothnessValue;
			half _RenderSpecular;
			half _GlobalEmissive;
			half _MainNormalValue;
			half _VertexOcclusionMaxValue;
			half _VertexOcclusionMinValue;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _ColorsMaskMaxValue;
			half _ColorsMaskMinValue;
			half _ColorsVariationValue;
			half _GlobalColors;
			half _LayerColorsValue;
			half _LayerReactValue;
			half _NoiseMaxValue;
			half _NoiseScaleValue;
			half _InteractionAmplitude;
			half _MotionAmplitude_10;
			half _MotionVariation_10;
			half _GradientCat;
			half _PerspectiveCat;
			half _TranslucencyIntensityValue;
			half _MainCat;
			half _DetailCat;
			half _RenderNormals;
			half _DetailSpace;
			half _NoiseCat;
			half _TranslucencyNormalValue;
			float _SubsurfaceDiffusion;
			half _RenderZWrite;
			half _MotionCat;
			half _VariationMotionMessage;
			half _TranslucencyAmbientValue;
			half _Cutoff;
			half _RenderCull;
			half _TranslucencyDirectValue;
			half _RenderClip;
			half _TranslucencyShadowValue;
			half _EmissiveCat;
			half _IsGrassShader;
			half _render_cull;
			half _IsStandardShader;
			half _render_dst;
			half _render_zw;
			half _RenderingCat;
			half _TranslucencyScatteringValue;
			half _DetailTypeMode;
			half _GlobalCat;
			float _MotionSpeed_10;
			half _LayerMotionValue;
			half _vertex_pivot_mode;
			half _AlphaVariationValue;
			half _VertexPivotMode;
			half _VertexMasksMode;
			half _VertexVariationMode;
			half _SizeFadeMessage;
			half _DetailMode;
			half _VariationGlobalsMessage;
			half _SubsurfaceCat;
			half _OcclusionCat;
			float _MotionScale_10;
			half _TranslucencyHDMessage;
			half _DetailBlendMode;
			half _SizeFadeCat;
			half _EmissiveFlagMode;
			half _FadeSpace;
			half _MotionSpace;
			half _IsTVEShader;
			half _ReceiveSpace;
			half _RenderDecals;
			half _IsVersion;
			half _LayersSpace;
			half _RenderSSR;
			half _RenderMode;
			half _RenderPriority;
			half _GlobalAlpha;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);
			TEXTURE2D(_BumpMap);
			SAMPLER(sampler_BumpMap);
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			TEXTURE2D(TVE_NoiseTex);
			half4 TVE_NoiseParams;
			SAMPLER(samplerTVE_NoiseTex);
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			half TVE_MotionFadeEnd;
			half TVE_MotionFadeStart;
			half TVE_DistanceFadeBias;
			TEXTURE2D(_MainAlbedoTex);
			SAMPLER(sampler_MainAlbedoTex);
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];


			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 VertexPosition3588_g53707 = v.vertex.xyz;
				float3 appendResult60_g53759 = (float3(v.ase_texcoord.z , 0.0 , v.ase_texcoord.w));
				half3 Mesh_PivotsData2831_g53707 = ( appendResult60_g53759 * _VertexPivotMode );
				half3 Mesh_PivotsOS2291_g53707 = Mesh_PivotsData2831_g53707;
				float3 temp_output_2283_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				half3 VertexPos40_g53723 = temp_output_2283_0_g53707;
				float3 appendResult74_g53723 = (float3(VertexPos40_g53723.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53723 = appendResult74_g53723;
				float3 break84_g53723 = VertexPos40_g53723;
				float3 appendResult81_g53723 = (float3(0.0 , break84_g53723.y , break84_g53723.z));
				half3 VertexPosOtherAxis82_g53723 = appendResult81_g53723;
				half ObjectData20_g53786 = 3.14;
				float Bounds_Height374_g53707 = _MaxBoundsInfo.y;
				half WorldData19_g53786 = ( Bounds_Height374_g53707 * 3.14 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53786 = WorldData19_g53786;
				#else
				float staticSwitch14_g53786 = ObjectData20_g53786;
				#endif
				float Motion_Max_Bending1133_g53707 = staticSwitch14_g53786;
				float4x4 break19_g53751 = GetObjectToWorldMatrix();
				float3 appendResult20_g53751 = (float3(break19_g53751[ 0 ][ 3 ] , break19_g53751[ 1 ][ 3 ] , break19_g53751[ 2 ][ 3 ]));
				float3 appendResult60_g53753 = (float3(v.ase_texcoord.z , 0.0 , v.ase_texcoord.w));
				float3 temp_output_91_0_g53751 = ( appendResult60_g53753 * _vertex_pivot_mode );
				float3 PivotsOnly105_g53751 = (mul( GetObjectToWorldMatrix(), float4( temp_output_91_0_g53751 , 0.0 ) ).xyz).xyz;
				half3 ObjectData20_g53752 = ( appendResult20_g53751 + PivotsOnly105_g53751 );
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53752 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53752 = WorldData19_g53752;
				#else
				float3 staticSwitch14_g53752 = ObjectData20_g53752;
				#endif
				float3 temp_output_114_0_g53751 = staticSwitch14_g53752;
				float3 vertexToFrag4224_g53707 = temp_output_114_0_g53751;
				float3 ObjectPosition4223_g53707 = vertexToFrag4224_g53707;
				float3 Position83_g53758 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53758 = _LayerMotionValue;
				float4 lerpResult87_g53758 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53758).xz ) ),temp_output_84_0_g53758, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53758]);
				half4 Global_Motion_Params3909_g53707 = lerpResult87_g53758;
				float4 break322_g53745 = Global_Motion_Params3909_g53707;
				half Wind_Power369_g53745 = break322_g53745.z;
				float lerpResult376_g53745 = lerp( 0.1 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_103106_g53707 = lerpResult376_g53745;
				float3 appendResult397_g53745 = (float3(break322_g53745.x , 0.0 , break322_g53745.y));
				float3 temp_output_398_0_g53745 = (appendResult397_g53745*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53745 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53745 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53707 = (temp_output_339_0_g53745).xz;
				float2 panner73_g53743 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4223_g53707).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53743 = SAMPLE_TEXTURE2D_LOD( TVE_NoiseTex, samplerTVE_NoiseTex, panner73_g53743, 0.0 );
				float4 saferPower77_g53743 = max( abs( tex2DNode75_g53743 ) , 0.0001 );
				half Wind_Power2223_g53707 = Wind_Power369_g53745;
				float temp_output_167_0_g53743 = Wind_Power2223_g53707;
				float lerpResult168_g53743 = lerp( 1.5 , 0.25 , temp_output_167_0_g53743);
				float4 temp_cast_7 = (lerpResult168_g53743).xxxx;
				float4 break142_g53743 = pow( saferPower77_g53743 , temp_cast_7 );
				half Global_NoiseTex_R34_g53707 = break142_g53743.r;
				half Input_Speed62_g53757 = _MotionSpeed_10;
				float mulTime373_g53757 = _TimeParameters.x * Input_Speed62_g53757;
				float3 break111_g53767 = ObjectPosition4223_g53707;
				half Variation_Complex102_g53767 = frac( ( v.ase_color.r + ( break111_g53767.x + break111_g53767.z ) ) );
				half ObjectData20_g53768 = Variation_Complex102_g53767;
				half Variation_Simple105_g53767 = v.ase_color.r;
				half WorldData19_g53768 = Variation_Simple105_g53767;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53768 = WorldData19_g53768;
				#else
				float staticSwitch14_g53768 = ObjectData20_g53768;
				#endif
				half Motion_Variation3073_g53707 = staticSwitch14_g53768;
				half Motion_Variation284_g53757 = ( _MotionVariation_10 * Motion_Variation3073_g53707 );
				float2 appendResult344_g53757 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53757 = ( _MotionScale_10 * appendResult344_g53757 );
				half2 Sine_MinusOneToOne281_g53757 = sin( ( mulTime373_g53757 + Motion_Variation284_g53757 + Motion_Scale287_g53757 ) );
				float2 temp_cast_8 = (1.0).xx;
				half Input_Turbulence327_g53757 = Global_NoiseTex_R34_g53707;
				float2 lerpResult321_g53757 = lerp( Sine_MinusOneToOne281_g53757 , temp_cast_8 , Input_Turbulence327_g53757);
				half2 Motion_Bending2258_g53707 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53707 ) * Wind_Power_103106_g53707 * Wind_DirectionOS39_g53707 * Global_NoiseTex_R34_g53707 * lerpResult321_g53757 );
				half Interaction_Amplitude4137_g53707 = _InteractionAmplitude;
				float3 Position83_g53749 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53749 = _LayerReactValue;
				float4 lerpResult87_g53749 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53749).xz ) ),temp_output_84_0_g53749, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53749]);
				half4 Global_React_Params4173_g53707 = lerpResult87_g53749;
				float4 break322_g53726 = Global_React_Params4173_g53707;
				half Interaction_Mask66_g53707 = break322_g53726.z;
				float3 appendResult397_g53726 = (float3(break322_g53726.x , 0.0 , break322_g53726.y));
				float3 temp_output_398_0_g53726 = (appendResult397_g53726*2.0 + -1.0);
				float3 temp_output_339_0_g53726 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53726 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4158_g53707 = (temp_output_339_0_g53726).xz;
				float lerpResult3307_g53707 = lerp( 1.0 , Motion_Variation3073_g53707 , _InteractionVariation);
				half2 Motion_Interaction53_g53707 = ( Interaction_Amplitude4137_g53707 * Motion_Max_Bending1133_g53707 * Interaction_Mask66_g53707 * Interaction_Mask66_g53707 * Interaction_DirectionOS4158_g53707 * lerpResult3307_g53707 );
				float2 lerpResult109_g53707 = lerp( Motion_Bending2258_g53707 , Motion_Interaction53_g53707 , ( Interaction_Mask66_g53707 * saturate( Interaction_Amplitude4137_g53707 ) ));
				half Mesh_Motion_182_g53707 = v.ase_texcoord3.x;
				float2 break143_g53707 = ( lerpResult109_g53707 * Mesh_Motion_182_g53707 );
				half Motion_Z190_g53707 = break143_g53707.y;
				half Angle44_g53723 = Motion_Z190_g53707;
				half3 VertexPos40_g53733 = ( VertexPosRotationAxis50_g53723 + ( VertexPosOtherAxis82_g53723 * cos( Angle44_g53723 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53723 ) * sin( Angle44_g53723 ) ) );
				float3 appendResult74_g53733 = (float3(0.0 , 0.0 , VertexPos40_g53733.z));
				half3 VertexPosRotationAxis50_g53733 = appendResult74_g53733;
				float3 break84_g53733 = VertexPos40_g53733;
				float3 appendResult81_g53733 = (float3(break84_g53733.x , break84_g53733.y , 0.0));
				half3 VertexPosOtherAxis82_g53733 = appendResult81_g53733;
				half Motion_X216_g53707 = break143_g53707.x;
				half Angle44_g53733 = -Motion_X216_g53707;
				half Motion_Scale321_g53741 = ( _MotionScale_32 * 10.0 );
				half Input_Speed62_g53741 = _MotionSpeed_32;
				float mulTime349_g53741 = _TimeParameters.x * Input_Speed62_g53741;
				float Motion_Variation330_g53741 = ( _MotionVariation_32 * Motion_Variation3073_g53707 );
				float Bounds_Radius121_g53707 = _MaxBoundsInfo.x;
				half Input_Amplitude58_g53741 = ( _MotionAmplitude_32 * Bounds_Radius121_g53707 * 0.1 );
				float3 temp_output_299_0_g53741 = ( sin( ( ( ase_worldPos * Motion_Scale321_g53741 ) + mulTime349_g53741 + Motion_Variation330_g53741 ) ) * Input_Amplitude58_g53741 );
				half Global_NoiseTex_A139_g53707 = break142_g53743.a;
				half Mesh_Motion_3144_g53707 = v.ase_texcoord3.z;
				float lerpResult378_g53745 = lerp( 0.3 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_323115_g53707 = lerpResult378_g53745;
				float temp_output_7_0_g53789 = TVE_MotionFadeEnd;
				half Wind_FadeOut4005_g53707 = saturate( ( ( distance( ase_worldPos , _WorldSpaceCameraPos ) - temp_output_7_0_g53789 ) / ( TVE_MotionFadeStart - temp_output_7_0_g53789 ) ) );
				half3 Motion_Detail263_g53707 = ( temp_output_299_0_g53741 * ( ( Global_NoiseTex_R34_g53707 + Global_NoiseTex_A139_g53707 ) * Mesh_Motion_3144_g53707 * Wind_Power_323115_g53707 * Wind_FadeOut4005_g53707 ) );
				float3 Vertex_Motion_Object833_g53707 = ( ( VertexPosRotationAxis50_g53733 + ( VertexPosOtherAxis82_g53733 * cos( Angle44_g53733 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53733 ) * sin( Angle44_g53733 ) ) ) + Motion_Detail263_g53707 );
				float3 temp_output_3474_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				float3 appendResult2043_g53707 = (float3(Motion_X216_g53707 , 0.0 , Motion_Z190_g53707));
				float3 Vertex_Motion_World1118_g53707 = ( ( temp_output_3474_0_g53707 + appendResult2043_g53707 ) + Motion_Detail263_g53707 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch3312_g53707 = Vertex_Motion_World1118_g53707;
				#else
				float3 staticSwitch3312_g53707 = ( Vertex_Motion_Object833_g53707 + ( 0.0 * _VertexDataMode ) );
				#endif
				half Global_Vertex_Size174_g53707 = break322_g53726.w;
				float lerpResult346_g53707 = lerp( 1.0 , Global_Vertex_Size174_g53707 , _GlobalSize);
				float3 appendResult3480_g53707 = (float3(lerpResult346_g53707 , lerpResult346_g53707 , lerpResult346_g53707));
				half3 ObjectData20_g53728 = appendResult3480_g53707;
				half3 _Vector11 = half3(1,1,1);
				half3 WorldData19_g53728 = _Vector11;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53728 = WorldData19_g53728;
				#else
				float3 staticSwitch14_g53728 = ObjectData20_g53728;
				#endif
				half3 Vertex_Size1741_g53707 = staticSwitch14_g53728;
				half3 _Vector5 = half3(1,1,1);
				float temp_output_7_0_g53779 = _SizeFadeEndValue;
				float temp_output_335_0_g53707 = saturate( ( ( ( distance( _WorldSpaceCameraPos , ObjectPosition4223_g53707 ) * ( 1.0 / TVE_DistanceFadeBias ) ) - temp_output_7_0_g53779 ) / ( _SizeFadeStartValue - temp_output_7_0_g53779 ) ) );
				float3 appendResult3482_g53707 = (float3(temp_output_335_0_g53707 , temp_output_335_0_g53707 , temp_output_335_0_g53707));
				float3 lerpResult3556_g53707 = lerp( _Vector5 , appendResult3482_g53707 , _SizeFadeMode);
				half3 ObjectData20_g53738 = lerpResult3556_g53707;
				half3 WorldData19_g53738 = _Vector5;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53738 = WorldData19_g53738;
				#else
				float3 staticSwitch14_g53738 = ObjectData20_g53738;
				#endif
				float3 Vertex_SizeFade1740_g53707 = staticSwitch14_g53738;
				float3 normalizeResult2696_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 break2709_g53707 = cross( normalizeResult2696_g53707 , half3(0,1,0) );
				float3 appendResult2710_g53707 = (float3(-break2709_g53707.z , 0.0 , break2709_g53707.x));
				float3 appendResult2667_g53707 = (float3(v.ase_color.r , 0.5 , v.ase_color.r));
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult2212_g53707 = dot( ViewDir_Normalized3963_g53707 , float3(0,1,0) );
				half Mask_HView2656_g53707 = dotResult2212_g53707;
				float saferPower2652_g53707 = max( Mask_HView2656_g53707 , 0.0001 );
				half3 Grass_Coverage2661_g53707 = ( ( ( mul( GetWorldToObjectMatrix(), float4( appendResult2710_g53707 , 0.0 ) ).xyz * _PerspectivePushValue ) + ( (appendResult2667_g53707*2.0 + -1.0) * _PerspectiveNoiseValue ) ) * v.ase_color.a * pow( saferPower2652_g53707 , _PerspectiveAngleValue ) );
				float3 Final_VertexPosition890_g53707 = ( ( staticSwitch3312_g53707 * Vertex_Size1741_g53707 * Vertex_SizeFade1740_g53707 ) + Mesh_PivotsOS2291_g53707 + Grass_Coverage2661_g53707 );
				
				float2 vertexToFrag11_g53744 = ( ( v.ase_texcoord.xy * (_MainUVs).xy ) + (_MainUVs).zw );
				o.ase_texcoord3.xy = vertexToFrag11_g53744;
				float3 vertexToFrag3890_g53707 = ase_worldPos;
				o.ase_texcoord4.xyz = vertexToFrag3890_g53707;
				
				o.ase_color = v.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord3.zw = 0;
				o.ase_texcoord4.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = Final_VertexPosition890_g53707;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;
				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float3 normalWS = TransformObjectToWorldNormal( v.ase_normal );
				float4 positionCS = TransformWorldToHClip( positionWS );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				o.worldPos = positionWS;
				#endif

				o.worldNormal = normalWS;

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				o.clipPos = positionCS;
				return o;
			}

			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_color = v.ase_color;
				o.ase_texcoord3 = v.ase_texcoord3;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE)
				#define ASE_SV_DEPTH SV_DepthLessEqual  
			#else
				#define ASE_SV_DEPTH SV_Depth
			#endif
			half4 frag(	VertexOutput IN 
						#ifdef ASE_DEPTH_WRITE_ON
						,out float outputDepth : ASE_SV_DEPTH
						#endif
						 ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.worldPos;
				#endif
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float localCustomAlphaClip3735_g53707 = ( 0.0 );
				half Final_AlphaFade3727_g53707 = 1.0;
				float2 vertexToFrag11_g53744 = IN.ase_texcoord3.xy;
				half2 Main_UVs15_g53707 = vertexToFrag11_g53744;
				float4 tex2DNode29_g53707 = SAMPLE_TEXTURE2D( _MainAlbedoTex, sampler_MainAlbedoTex, Main_UVs15_g53707 );
				float Main_Alpha316_g53707 = ( _MainColor.a * tex2DNode29_g53707.a );
				float Mesh_Variation16_g53707 = IN.ase_color.r;
				float lerpResult4033_g53707 = lerp( 0.9 , (Mesh_Variation16_g53707*0.5 + 0.5) , _AlphaVariationValue);
				float3 vertexToFrag3890_g53707 = IN.ase_texcoord4.xyz;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float3 Position82_g53742 = WorldPosition3905_g53707;
				float temp_output_84_0_g53742 = _LayerExtrasValue;
				float4 lerpResult88_g53742 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53742).xz ) ),temp_output_84_0_g53742 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53742]);
				float4 break89_g53742 = lerpResult88_g53742;
				half Global_Extras_Alpha1033_g53707 = break89_g53742.a;
				float temp_output_4022_0_g53707 = ( lerpResult4033_g53707 - ( 1.0 - Global_Extras_Alpha1033_g53707 ) );
				half AlphaTreshold2132_g53707 = _Cutoff;
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch4017_g53707 = ( temp_output_4022_0_g53707 + AlphaTreshold2132_g53707 );
				#else
				float staticSwitch4017_g53707 = temp_output_4022_0_g53707;
				#endif
				float lerpResult4011_g53707 = lerp( 1.0 , staticSwitch4017_g53707 , _GlobalAlpha);
				half Global_Alpha315_g53707 = saturate( lerpResult4011_g53707 );
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch3792_g53707 = ( ( Main_Alpha316_g53707 * Global_Alpha315_g53707 ) - ( AlphaTreshold2132_g53707 - 0.5 ) );
				#else
				float staticSwitch3792_g53707 = ( Main_Alpha316_g53707 * Global_Alpha315_g53707 );
				#endif
				half Final_Alpha3754_g53707 = staticSwitch3792_g53707;
				float temp_output_661_0_g53707 = ( Final_AlphaFade3727_g53707 * Final_Alpha3754_g53707 );
				float Alpha3735_g53707 = temp_output_661_0_g53707;
				float Treshold3735_g53707 = 0.5;
				{
				#if TVE_ALPHA_CLIP
				clip(Alpha3735_g53707 - Treshold3735_g53707);
				#endif
				}
				half Final_Clip914_g53707 = saturate( Alpha3735_g53707 );
				
				float Alpha = Final_Clip914_g53707;
				float AlphaClipThreshold = 0.5;
				#ifdef ASE_DEPTH_WRITE_ON
				float DepthValue = 0;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif
				
				#ifdef ASE_DEPTH_WRITE_ON
				outputDepth = DepthValue;
				#endif
				
				return float4(PackNormalOctRectEncode(TransformWorldToViewDir(IN.worldNormal, true)), 0.0, 0.0);
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "GBuffer"
			Tags { "LightMode"="UniversalGBuffer" }
			
			Blend [_render_src] [_render_dst], One Zero
			ZWrite [_render_zw]
			ZTest LEqual
			Offset 0,0
			ColorMask RGBA
			

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#pragma multi_compile _ DOTS_INSTANCING_ON
			#define ASE_ABSOLUTE_VERTEX_POS 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 100202
			#define ASE_USING_SAMPLING_MACROS 1

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS
			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
			#pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
			#pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
			#pragma multi_compile _ _SHADOWS_SOFT
			#pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
			#pragma multi_compile _ _GBUFFER_NORMALS_OCT
			
			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS SHADERPASS_GBUFFER

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityGBuffer.hlsl"

			#if ASE_SRP_VERSION <= 70108
			#define REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR
			#endif

			#if defined(UNITY_INSTANCING_ENABLED) && defined(_TERRAIN_INSTANCED_PERPIXEL_NORMAL)
			    #define ENABLE_TERRAIN_PERPIXEL_NORMAL
			#endif

			#define ASE_NEEDS_VERT_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local TVE_ALPHA_CLIP
			#pragma shader_feature_local TVE_VERTEX_DATA_BATCHED
			//TVE Shader Type Defines
			#define TVE_IS_GRASS_SHADER
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord : TEXCOORD0;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				float4 lightmapUVOrVertexSH : TEXCOORD0;
				half4 fogFactorAndVertexLight : TEXCOORD1;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
				float4 shadowCoord : TEXCOORD2;
				#endif
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
				float4 screenPos : TEXCOORD6;
				#endif
				float4 ase_texcoord7 : TEXCOORD7;
				float4 ase_texcoord8 : TEXCOORD8;
				float4 ase_texcoord9 : TEXCOORD9;
				float4 ase_texcoord10 : TEXCOORD10;
				float4 ase_texcoord11 : TEXCOORD11;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _MainUVs;
			half4 _MotionHighlightColor;
			half4 _MainColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _GradientColorOne;
			half4 _GradientColorTwo;
			half4 _SubsurfaceColor;
			float4 _SubsurfaceDiffusion_Asset;
			half4 _ColorsMaskRemap;
			float4 _MaxBoundsInfo;
			half4 _DetailBlendRemap;
			half4 _VertexOcclusionRemap;
			half4 _NoiseColorTwo;
			half4 _OverlayMaskRemap;
			float4 _NoiseMaskRemap;
			half4 _SubsurfaceMaskRemap;
			half4 _EmissiveUVs;
			half4 _VertexOcclusionColor;
			float4 _EmissiveIntensityParams;
			half4 _EmissiveColor;
			half4 _NoiseColorOne;
			float4 _Color;
			float4 _GradientMaskRemap;
			half3 _render_normals_options;
			half _VertexDataMode;
			half _GradientMaxValue;
			half _InteractionVariation;
			float _MotionScale_32;
			float _MotionSpeed_32;
			half _GradientMinValue;
			float _MotionVariation_32;
			half _PerspectiveAngleValue;
			half _PerspectiveNoiseValue;
			half _GlobalSize;
			half _PerspectivePushValue;
			half _SizeFadeStartValue;
			half _SizeFadeMode;
			half _MotionAmplitude_32;
			half _SizeFadeEndValue;
			half _render_src;
			half _NoiseMinValue;
			half _MainOcclusionValue;
			half _GlobalWetness;
			half _MainSmoothnessValue;
			half _RenderSpecular;
			half _GlobalEmissive;
			half _MainNormalValue;
			half _VertexOcclusionMaxValue;
			half _VertexOcclusionMinValue;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _ColorsMaskMaxValue;
			half _ColorsMaskMinValue;
			half _ColorsVariationValue;
			half _GlobalColors;
			half _LayerColorsValue;
			half _LayerReactValue;
			half _NoiseMaxValue;
			half _NoiseScaleValue;
			half _InteractionAmplitude;
			half _MotionAmplitude_10;
			half _MotionVariation_10;
			half _GradientCat;
			half _PerspectiveCat;
			half _TranslucencyIntensityValue;
			half _MainCat;
			half _DetailCat;
			half _RenderNormals;
			half _DetailSpace;
			half _NoiseCat;
			half _TranslucencyNormalValue;
			float _SubsurfaceDiffusion;
			half _RenderZWrite;
			half _MotionCat;
			half _VariationMotionMessage;
			half _TranslucencyAmbientValue;
			half _Cutoff;
			half _RenderCull;
			half _TranslucencyDirectValue;
			half _RenderClip;
			half _TranslucencyShadowValue;
			half _EmissiveCat;
			half _IsGrassShader;
			half _render_cull;
			half _IsStandardShader;
			half _render_dst;
			half _render_zw;
			half _RenderingCat;
			half _TranslucencyScatteringValue;
			half _DetailTypeMode;
			half _GlobalCat;
			float _MotionSpeed_10;
			half _LayerMotionValue;
			half _vertex_pivot_mode;
			half _AlphaVariationValue;
			half _VertexPivotMode;
			half _VertexMasksMode;
			half _VertexVariationMode;
			half _SizeFadeMessage;
			half _DetailMode;
			half _VariationGlobalsMessage;
			half _SubsurfaceCat;
			half _OcclusionCat;
			float _MotionScale_10;
			half _TranslucencyHDMessage;
			half _DetailBlendMode;
			half _SizeFadeCat;
			half _EmissiveFlagMode;
			half _FadeSpace;
			half _MotionSpace;
			half _IsTVEShader;
			half _ReceiveSpace;
			half _RenderDecals;
			half _IsVersion;
			half _LayersSpace;
			half _RenderSSR;
			half _RenderMode;
			half _RenderPriority;
			half _GlobalAlpha;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);
			TEXTURE2D(_BumpMap);
			SAMPLER(sampler_BumpMap);
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			TEXTURE2D(TVE_NoiseTex);
			half4 TVE_NoiseParams;
			SAMPLER(samplerTVE_NoiseTex);
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			half TVE_MotionFadeEnd;
			half TVE_MotionFadeStart;
			half TVE_DistanceFadeBias;
			TEXTURE3D(TVE_WorldTex3D);
			SAMPLER(samplerTVE_WorldTex3D);
			TEXTURE2D(_MainAlbedoTex);
			SAMPLER(sampler_MainAlbedoTex);
			half4 TVE_ColorsParams;
			TEXTURE2D_ARRAY(TVE_ColorsTex);
			half4 TVE_ColorsCoord;
			SAMPLER(samplerTVE_ColorsTex);
			float TVE_ColorsUsage[9];
			half4 TVE_MainLightParams;
			half3 TVE_MainLightDirection;
			half4 TVE_OverlayColor;
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];
			TEXTURE2D(_EmissiveTex);
			SAMPLER(sampler_EmissiveTex);
			TEXTURE2D(_MainMaskTex);
			half TVE_OverlaySmoothness;


			
			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 VertexPosition3588_g53707 = v.vertex.xyz;
				float3 appendResult60_g53759 = (float3(v.texcoord.z , 0.0 , v.texcoord.w));
				half3 Mesh_PivotsData2831_g53707 = ( appendResult60_g53759 * _VertexPivotMode );
				half3 Mesh_PivotsOS2291_g53707 = Mesh_PivotsData2831_g53707;
				float3 temp_output_2283_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				half3 VertexPos40_g53723 = temp_output_2283_0_g53707;
				float3 appendResult74_g53723 = (float3(VertexPos40_g53723.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53723 = appendResult74_g53723;
				float3 break84_g53723 = VertexPos40_g53723;
				float3 appendResult81_g53723 = (float3(0.0 , break84_g53723.y , break84_g53723.z));
				half3 VertexPosOtherAxis82_g53723 = appendResult81_g53723;
				half ObjectData20_g53786 = 3.14;
				float Bounds_Height374_g53707 = _MaxBoundsInfo.y;
				half WorldData19_g53786 = ( Bounds_Height374_g53707 * 3.14 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53786 = WorldData19_g53786;
				#else
				float staticSwitch14_g53786 = ObjectData20_g53786;
				#endif
				float Motion_Max_Bending1133_g53707 = staticSwitch14_g53786;
				float4x4 break19_g53751 = GetObjectToWorldMatrix();
				float3 appendResult20_g53751 = (float3(break19_g53751[ 0 ][ 3 ] , break19_g53751[ 1 ][ 3 ] , break19_g53751[ 2 ][ 3 ]));
				float3 appendResult60_g53753 = (float3(v.texcoord.z , 0.0 , v.texcoord.w));
				float3 temp_output_91_0_g53751 = ( appendResult60_g53753 * _vertex_pivot_mode );
				float3 PivotsOnly105_g53751 = (mul( GetObjectToWorldMatrix(), float4( temp_output_91_0_g53751 , 0.0 ) ).xyz).xyz;
				half3 ObjectData20_g53752 = ( appendResult20_g53751 + PivotsOnly105_g53751 );
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53752 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53752 = WorldData19_g53752;
				#else
				float3 staticSwitch14_g53752 = ObjectData20_g53752;
				#endif
				float3 temp_output_114_0_g53751 = staticSwitch14_g53752;
				float3 vertexToFrag4224_g53707 = temp_output_114_0_g53751;
				float3 ObjectPosition4223_g53707 = vertexToFrag4224_g53707;
				float3 Position83_g53758 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53758 = _LayerMotionValue;
				float4 lerpResult87_g53758 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53758).xz ) ),temp_output_84_0_g53758, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53758]);
				half4 Global_Motion_Params3909_g53707 = lerpResult87_g53758;
				float4 break322_g53745 = Global_Motion_Params3909_g53707;
				half Wind_Power369_g53745 = break322_g53745.z;
				float lerpResult376_g53745 = lerp( 0.1 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_103106_g53707 = lerpResult376_g53745;
				float3 appendResult397_g53745 = (float3(break322_g53745.x , 0.0 , break322_g53745.y));
				float3 temp_output_398_0_g53745 = (appendResult397_g53745*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53745 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53745 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53707 = (temp_output_339_0_g53745).xz;
				float2 panner73_g53743 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4223_g53707).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53743 = SAMPLE_TEXTURE2D_LOD( TVE_NoiseTex, samplerTVE_NoiseTex, panner73_g53743, 0.0 );
				float4 saferPower77_g53743 = max( abs( tex2DNode75_g53743 ) , 0.0001 );
				half Wind_Power2223_g53707 = Wind_Power369_g53745;
				float temp_output_167_0_g53743 = Wind_Power2223_g53707;
				float lerpResult168_g53743 = lerp( 1.5 , 0.25 , temp_output_167_0_g53743);
				float4 temp_cast_7 = (lerpResult168_g53743).xxxx;
				float4 break142_g53743 = pow( saferPower77_g53743 , temp_cast_7 );
				half Global_NoiseTex_R34_g53707 = break142_g53743.r;
				half Input_Speed62_g53757 = _MotionSpeed_10;
				float mulTime373_g53757 = _TimeParameters.x * Input_Speed62_g53757;
				float3 break111_g53767 = ObjectPosition4223_g53707;
				half Variation_Complex102_g53767 = frac( ( v.ase_color.r + ( break111_g53767.x + break111_g53767.z ) ) );
				half ObjectData20_g53768 = Variation_Complex102_g53767;
				half Variation_Simple105_g53767 = v.ase_color.r;
				half WorldData19_g53768 = Variation_Simple105_g53767;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float staticSwitch14_g53768 = WorldData19_g53768;
				#else
				float staticSwitch14_g53768 = ObjectData20_g53768;
				#endif
				half Motion_Variation3073_g53707 = staticSwitch14_g53768;
				half Motion_Variation284_g53757 = ( _MotionVariation_10 * Motion_Variation3073_g53707 );
				float2 appendResult344_g53757 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53757 = ( _MotionScale_10 * appendResult344_g53757 );
				half2 Sine_MinusOneToOne281_g53757 = sin( ( mulTime373_g53757 + Motion_Variation284_g53757 + Motion_Scale287_g53757 ) );
				float2 temp_cast_8 = (1.0).xx;
				half Input_Turbulence327_g53757 = Global_NoiseTex_R34_g53707;
				float2 lerpResult321_g53757 = lerp( Sine_MinusOneToOne281_g53757 , temp_cast_8 , Input_Turbulence327_g53757);
				half2 Motion_Bending2258_g53707 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53707 ) * Wind_Power_103106_g53707 * Wind_DirectionOS39_g53707 * Global_NoiseTex_R34_g53707 * lerpResult321_g53757 );
				half Interaction_Amplitude4137_g53707 = _InteractionAmplitude;
				float3 Position83_g53749 = ObjectPosition4223_g53707;
				float temp_output_84_0_g53749 = _LayerReactValue;
				float4 lerpResult87_g53749 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53749).xz ) ),temp_output_84_0_g53749, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53749]);
				half4 Global_React_Params4173_g53707 = lerpResult87_g53749;
				float4 break322_g53726 = Global_React_Params4173_g53707;
				half Interaction_Mask66_g53707 = break322_g53726.z;
				float3 appendResult397_g53726 = (float3(break322_g53726.x , 0.0 , break322_g53726.y));
				float3 temp_output_398_0_g53726 = (appendResult397_g53726*2.0 + -1.0);
				float3 temp_output_339_0_g53726 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53726 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4158_g53707 = (temp_output_339_0_g53726).xz;
				float lerpResult3307_g53707 = lerp( 1.0 , Motion_Variation3073_g53707 , _InteractionVariation);
				half2 Motion_Interaction53_g53707 = ( Interaction_Amplitude4137_g53707 * Motion_Max_Bending1133_g53707 * Interaction_Mask66_g53707 * Interaction_Mask66_g53707 * Interaction_DirectionOS4158_g53707 * lerpResult3307_g53707 );
				float2 lerpResult109_g53707 = lerp( Motion_Bending2258_g53707 , Motion_Interaction53_g53707 , ( Interaction_Mask66_g53707 * saturate( Interaction_Amplitude4137_g53707 ) ));
				half Mesh_Motion_182_g53707 = v.ase_texcoord3.x;
				float2 break143_g53707 = ( lerpResult109_g53707 * Mesh_Motion_182_g53707 );
				half Motion_Z190_g53707 = break143_g53707.y;
				half Angle44_g53723 = Motion_Z190_g53707;
				half3 VertexPos40_g53733 = ( VertexPosRotationAxis50_g53723 + ( VertexPosOtherAxis82_g53723 * cos( Angle44_g53723 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53723 ) * sin( Angle44_g53723 ) ) );
				float3 appendResult74_g53733 = (float3(0.0 , 0.0 , VertexPos40_g53733.z));
				half3 VertexPosRotationAxis50_g53733 = appendResult74_g53733;
				float3 break84_g53733 = VertexPos40_g53733;
				float3 appendResult81_g53733 = (float3(break84_g53733.x , break84_g53733.y , 0.0));
				half3 VertexPosOtherAxis82_g53733 = appendResult81_g53733;
				half Motion_X216_g53707 = break143_g53707.x;
				half Angle44_g53733 = -Motion_X216_g53707;
				half Motion_Scale321_g53741 = ( _MotionScale_32 * 10.0 );
				half Input_Speed62_g53741 = _MotionSpeed_32;
				float mulTime349_g53741 = _TimeParameters.x * Input_Speed62_g53741;
				float Motion_Variation330_g53741 = ( _MotionVariation_32 * Motion_Variation3073_g53707 );
				float Bounds_Radius121_g53707 = _MaxBoundsInfo.x;
				half Input_Amplitude58_g53741 = ( _MotionAmplitude_32 * Bounds_Radius121_g53707 * 0.1 );
				float3 temp_output_299_0_g53741 = ( sin( ( ( ase_worldPos * Motion_Scale321_g53741 ) + mulTime349_g53741 + Motion_Variation330_g53741 ) ) * Input_Amplitude58_g53741 );
				half Global_NoiseTex_A139_g53707 = break142_g53743.a;
				half Mesh_Motion_3144_g53707 = v.ase_texcoord3.z;
				float lerpResult378_g53745 = lerp( 0.3 , 1.0 , Wind_Power369_g53745);
				half Wind_Power_323115_g53707 = lerpResult378_g53745;
				float temp_output_7_0_g53789 = TVE_MotionFadeEnd;
				half Wind_FadeOut4005_g53707 = saturate( ( ( distance( ase_worldPos , _WorldSpaceCameraPos ) - temp_output_7_0_g53789 ) / ( TVE_MotionFadeStart - temp_output_7_0_g53789 ) ) );
				half3 Motion_Detail263_g53707 = ( temp_output_299_0_g53741 * ( ( Global_NoiseTex_R34_g53707 + Global_NoiseTex_A139_g53707 ) * Mesh_Motion_3144_g53707 * Wind_Power_323115_g53707 * Wind_FadeOut4005_g53707 ) );
				float3 Vertex_Motion_Object833_g53707 = ( ( VertexPosRotationAxis50_g53733 + ( VertexPosOtherAxis82_g53733 * cos( Angle44_g53733 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53733 ) * sin( Angle44_g53733 ) ) ) + Motion_Detail263_g53707 );
				float3 temp_output_3474_0_g53707 = ( VertexPosition3588_g53707 - Mesh_PivotsOS2291_g53707 );
				float3 appendResult2043_g53707 = (float3(Motion_X216_g53707 , 0.0 , Motion_Z190_g53707));
				float3 Vertex_Motion_World1118_g53707 = ( ( temp_output_3474_0_g53707 + appendResult2043_g53707 ) + Motion_Detail263_g53707 );
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch3312_g53707 = Vertex_Motion_World1118_g53707;
				#else
				float3 staticSwitch3312_g53707 = ( Vertex_Motion_Object833_g53707 + ( 0.0 * _VertexDataMode ) );
				#endif
				half Global_Vertex_Size174_g53707 = break322_g53726.w;
				float lerpResult346_g53707 = lerp( 1.0 , Global_Vertex_Size174_g53707 , _GlobalSize);
				float3 appendResult3480_g53707 = (float3(lerpResult346_g53707 , lerpResult346_g53707 , lerpResult346_g53707));
				half3 ObjectData20_g53728 = appendResult3480_g53707;
				half3 _Vector11 = half3(1,1,1);
				half3 WorldData19_g53728 = _Vector11;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53728 = WorldData19_g53728;
				#else
				float3 staticSwitch14_g53728 = ObjectData20_g53728;
				#endif
				half3 Vertex_Size1741_g53707 = staticSwitch14_g53728;
				half3 _Vector5 = half3(1,1,1);
				float temp_output_7_0_g53779 = _SizeFadeEndValue;
				float temp_output_335_0_g53707 = saturate( ( ( ( distance( _WorldSpaceCameraPos , ObjectPosition4223_g53707 ) * ( 1.0 / TVE_DistanceFadeBias ) ) - temp_output_7_0_g53779 ) / ( _SizeFadeStartValue - temp_output_7_0_g53779 ) ) );
				float3 appendResult3482_g53707 = (float3(temp_output_335_0_g53707 , temp_output_335_0_g53707 , temp_output_335_0_g53707));
				float3 lerpResult3556_g53707 = lerp( _Vector5 , appendResult3482_g53707 , _SizeFadeMode);
				half3 ObjectData20_g53738 = lerpResult3556_g53707;
				half3 WorldData19_g53738 = _Vector5;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53738 = WorldData19_g53738;
				#else
				float3 staticSwitch14_g53738 = ObjectData20_g53738;
				#endif
				float3 Vertex_SizeFade1740_g53707 = staticSwitch14_g53738;
				float3 normalizeResult2696_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 break2709_g53707 = cross( normalizeResult2696_g53707 , half3(0,1,0) );
				float3 appendResult2710_g53707 = (float3(-break2709_g53707.z , 0.0 , break2709_g53707.x));
				float3 appendResult2667_g53707 = (float3(v.ase_color.r , 0.5 , v.ase_color.r));
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult2212_g53707 = dot( ViewDir_Normalized3963_g53707 , float3(0,1,0) );
				half Mask_HView2656_g53707 = dotResult2212_g53707;
				float saferPower2652_g53707 = max( Mask_HView2656_g53707 , 0.0001 );
				half3 Grass_Coverage2661_g53707 = ( ( ( mul( GetWorldToObjectMatrix(), float4( appendResult2710_g53707 , 0.0 ) ).xyz * _PerspectivePushValue ) + ( (appendResult2667_g53707*2.0 + -1.0) * _PerspectiveNoiseValue ) ) * v.ase_color.a * pow( saferPower2652_g53707 , _PerspectiveAngleValue ) );
				float3 Final_VertexPosition890_g53707 = ( ( staticSwitch3312_g53707 * Vertex_Size1741_g53707 * Vertex_SizeFade1740_g53707 ) + Mesh_PivotsOS2291_g53707 + Grass_Coverage2661_g53707 );
				
				float temp_output_7_0_g53773 = _GradientMinValue;
				float4 lerpResult2779_g53707 = lerp( _GradientColorTwo , _GradientColorOne , saturate( ( ( v.ase_color.a - temp_output_7_0_g53773 ) / ( _GradientMaxValue - temp_output_7_0_g53773 ) ) ));
				half3 Gradient_Tint2784_g53707 = (lerpResult2779_g53707).rgb;
				float3 vertexToFrag11_g53775 = Gradient_Tint2784_g53707;
				o.ase_texcoord7.xyz = vertexToFrag11_g53775;
				float3 temp_cast_16 = (_NoiseScaleValue).xxx;
				float3 vertexToFrag3890_g53707 = ase_worldPos;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float temp_output_7_0_g53784 = _NoiseMinValue;
				half Noise_Mask3162_g53707 = saturate( ( ( SAMPLE_TEXTURE3D_LOD( TVE_WorldTex3D, samplerTVE_WorldTex3D, ( temp_cast_16 * WorldPosition3905_g53707 * 0.1 ), 0.0 ).r - temp_output_7_0_g53784 ) / ( _NoiseMaxValue - temp_output_7_0_g53784 ) ) );
				float4 lerpResult2800_g53707 = lerp( _NoiseColorTwo , _NoiseColorOne , Noise_Mask3162_g53707);
				half3 Noise_Tint2802_g53707 = (lerpResult2800_g53707).rgb;
				float3 vertexToFrag11_g53787 = Noise_Tint2802_g53707;
				o.ase_texcoord8.xyz = vertexToFrag11_g53787;
				float lerpResult169_g53743 = lerp( 4.0 , 2.0 , temp_output_167_0_g53743);
				half Global_NoiseTex_H2869_g53707 = pow( abs( tex2DNode75_g53743.a ) , lerpResult169_g53743 );
				half3 Highlight_Tint3231_g53707 = ( ( (_MotionHighlightColor).rgb * Global_NoiseTex_H2869_g53707 * Wind_Power_103106_g53707 * Wind_FadeOut4005_g53707 * v.ase_color.a ) + float3( 1,1,1 ) );
				float3 vertexToFrag11_g53766 = Highlight_Tint3231_g53707;
				o.ase_texcoord9.xyz = vertexToFrag11_g53766;
				float2 vertexToFrag11_g53744 = ( ( v.texcoord.xy * (_MainUVs).xy ) + (_MainUVs).zw );
				o.ase_texcoord10.xy = vertexToFrag11_g53744;
				float3 Position58_g53740 = WorldPosition3905_g53707;
				float temp_output_82_0_g53740 = _LayerColorsValue;
				float4 lerpResult88_g53740 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ColorsTex, samplerTVE_ColorsTex, ( (TVE_ColorsCoord).zw + ( (TVE_ColorsCoord).xy * (Position58_g53740).xz ) ),temp_output_82_0_g53740, 0.0 ) , TVE_ColorsUsage[(int)temp_output_82_0_g53740]);
				half Global_ColorsTex_A1701_g53707 = (lerpResult88_g53740).a;
				float vertexToFrag11_g53776 = Global_ColorsTex_A1701_g53707;
				o.ase_texcoord7.w = vertexToFrag11_g53776;
				o.ase_texcoord11.xyz = vertexToFrag3890_g53707;
				
				float2 vertexToFrag11_g53724 = ( ( v.texcoord.xy * (_EmissiveUVs).xy ) + (_EmissiveUVs).zw );
				o.ase_texcoord10.zw = vertexToFrag11_g53724;
				
				o.ase_color = v.ase_color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord8.w = 0;
				o.ase_texcoord9.w = 0;
				o.ase_texcoord11.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = Final_VertexPosition890_g53707;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif
				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float3 positionVS = TransformWorldToView( positionWS );
				float4 positionCS = TransformWorldToHClip( positionWS );

				VertexNormalInputs normalInput = GetVertexNormalInputs( v.ase_normal, v.ase_tangent );

				o.tSpace0 = float4( normalInput.normalWS, positionWS.x);
				o.tSpace1 = float4( normalInput.tangentWS, positionWS.y);
				o.tSpace2 = float4( normalInput.bitangentWS, positionWS.z);

				OUTPUT_LIGHTMAP_UV( v.texcoord1, unity_LightmapST, o.lightmapUVOrVertexSH.xy );
				OUTPUT_SH( normalInput.normalWS.xyz, o.lightmapUVOrVertexSH.xyz );

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					o.lightmapUVOrVertexSH.zw = v.texcoord;
					o.lightmapUVOrVertexSH.xy = v.texcoord * unity_LightmapST.xy + unity_LightmapST.zw;
				#endif

				half3 vertexLight = VertexLighting( positionWS, normalInput.normalWS );
				#ifdef ASE_FOG
					half fogFactor = ComputeFogFactor( positionCS.z );
				#else
					half fogFactor = 0;
				#endif
				o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);
				
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
				VertexPositionInputs vertexInput = (VertexPositionInputs)0;
				vertexInput.positionWS = positionWS;
				vertexInput.positionCS = positionCS;
				o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				
				o.clipPos = positionCS;
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
				o.screenPos = ComputeScreenPos(positionCS);
				#endif
				return o;
			}
			
			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 ase_color : COLOR;
				float4 ase_texcoord3 : TEXCOORD3;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_tangent = v.ase_tangent;
				o.texcoord = v.texcoord;
				o.texcoord1 = v.texcoord1;
				o.texcoord = v.texcoord;
				o.ase_color = v.ase_color;
				o.ase_texcoord3 = v.ase_texcoord3;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				o.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				o.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				o.ase_color = patch[0].ase_color * bary.x + patch[1].ase_color * bary.y + patch[2].ase_color * bary.z;
				o.ase_texcoord3 = patch[0].ase_texcoord3 * bary.x + patch[1].ase_texcoord3 * bary.y + patch[2].ase_texcoord3 * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			#if defined(ASE_EARLY_Z_DEPTH_OPTIMIZE)
				#define ASE_SV_DEPTH SV_DepthLessEqual  
			#else
				#define ASE_SV_DEPTH SV_Depth
			#endif
			FragmentOutput frag ( VertexOutput IN 
								#ifdef ASE_DEPTH_WRITE_ON
								,out float outputDepth : ASE_SV_DEPTH
								#endif
								 )
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float2 sampleCoords = (IN.lightmapUVOrVertexSH.zw / _TerrainHeightmapRecipSize.zw + 0.5f) * _TerrainHeightmapRecipSize.xy;
					float3 WorldNormal = TransformObjectToWorldNormal(normalize(SAMPLE_TEXTURE2D(_TerrainNormalmapTexture, sampler_TerrainNormalmapTexture, sampleCoords).rgb * 2 - 1));
					float3 WorldTangent = -cross(GetObjectToWorldMatrix()._13_23_33, WorldNormal);
					float3 WorldBiTangent = cross(WorldNormal, -WorldTangent);
				#else
					float3 WorldNormal = normalize( IN.tSpace0.xyz );
					float3 WorldTangent = IN.tSpace1.xyz;
					float3 WorldBiTangent = IN.tSpace2.xyz;
				#endif
				float3 WorldPosition = float3(IN.tSpace0.w,IN.tSpace1.w,IN.tSpace2.w);
				float3 WorldViewDirection = _WorldSpaceCameraPos.xyz  - WorldPosition;
				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
				float4 ScreenPos = IN.screenPos;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					ShadowCoords = IN.shadowCoord;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
				#endif
	
				WorldViewDirection = SafeNormalize( WorldViewDirection );

				float3 vertexToFrag11_g53775 = IN.ase_texcoord7.xyz;
				float3 vertexToFrag11_g53787 = IN.ase_texcoord8.xyz;
				float3 vertexToFrag11_g53766 = IN.ase_texcoord9.xyz;
				float2 vertexToFrag11_g53744 = IN.ase_texcoord10.xy;
				half2 Main_UVs15_g53707 = vertexToFrag11_g53744;
				float4 tex2DNode29_g53707 = SAMPLE_TEXTURE2D( _MainAlbedoTex, sampler_MainAlbedoTex, Main_UVs15_g53707 );
				float3 temp_output_51_0_g53707 = ( (_MainColor).rgb * (tex2DNode29_g53707).rgb );
				half3 Main_Albedo99_g53707 = temp_output_51_0_g53707;
				half3 Blend_Albedo265_g53707 = Main_Albedo99_g53707;
				half3 Blend_AlbedoTinted2808_g53707 = ( vertexToFrag11_g53775 * vertexToFrag11_g53787 * vertexToFrag11_g53766 * Blend_Albedo265_g53707 );
				float dotResult3616_g53707 = dot( Blend_AlbedoTinted2808_g53707 , float3(0.2126,0.7152,0.0722) );
				float3 temp_cast_0 = (dotResult3616_g53707).xxx;
				float vertexToFrag11_g53776 = IN.ase_texcoord7.w;
				half Global_Colors_Influence3668_g53707 = vertexToFrag11_g53776;
				float3 lerpResult3618_g53707 = lerp( Blend_AlbedoTinted2808_g53707 , temp_cast_0 , Global_Colors_Influence3668_g53707);
				float3 vertexToFrag3890_g53707 = IN.ase_texcoord11.xyz;
				float3 WorldPosition3905_g53707 = vertexToFrag3890_g53707;
				float3 Position58_g53740 = WorldPosition3905_g53707;
				float temp_output_82_0_g53740 = _LayerColorsValue;
				float4 lerpResult88_g53740 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ColorsTex, samplerTVE_ColorsTex, ( (TVE_ColorsCoord).zw + ( (TVE_ColorsCoord).xy * (Position58_g53740).xz ) ),temp_output_82_0_g53740 ) , TVE_ColorsUsage[(int)temp_output_82_0_g53740]);
				half3 Global_ColorsTex_RGB1700_g53707 = (lerpResult88_g53740).rgb;
				#ifdef UNITY_COLORSPACE_GAMMA
				float staticSwitch1_g53769 = 2.0;
				#else
				float staticSwitch1_g53769 = 4.594794;
				#endif
				float3 temp_output_1953_0_g53707 = ( Global_ColorsTex_RGB1700_g53707 * staticSwitch1_g53769 );
				half3 Global_Colors1954_g53707 = temp_output_1953_0_g53707;
				float lerpResult3870_g53707 = lerp( 1.0 , IN.ase_color.r , _ColorsVariationValue);
				half Global_Colors_Value3650_g53707 = ( _GlobalColors * lerpResult3870_g53707 );
				float temp_output_7_0_g53778 = _ColorsMaskMinValue;
				half Global_Colors_Mask3692_g53707 = saturate( ( ( ( 1.0 - IN.ase_color.a ) - temp_output_7_0_g53778 ) / ( _ColorsMaskMaxValue - temp_output_7_0_g53778 ) ) );
				float3 lerpResult3628_g53707 = lerp( Blend_AlbedoTinted2808_g53707 , ( lerpResult3618_g53707 * Global_Colors1954_g53707 ) , ( Global_Colors_Value3650_g53707 * Global_Colors_Mask3692_g53707 ));
				half3 Blend_AlbedoColored863_g53707 = lerpResult3628_g53707;
				float3 temp_output_799_0_g53707 = (_SubsurfaceColor).rgb;
				float dotResult3930_g53707 = dot( temp_output_799_0_g53707 , float3(0.2126,0.7152,0.0722) );
				float3 temp_cast_3 = (dotResult3930_g53707).xxx;
				float3 lerpResult3932_g53707 = lerp( temp_output_799_0_g53707 , temp_cast_3 , Global_Colors_Influence3668_g53707);
				float3 lerpResult3942_g53707 = lerp( temp_output_799_0_g53707 , ( lerpResult3932_g53707 * Global_Colors1954_g53707 ) , ( Global_Colors_Value3650_g53707 * Global_Colors_Mask3692_g53707 ));
				half3 Subsurface_Color1722_g53707 = lerpResult3942_g53707;
				half MainLight_Subsurface4041_g53707 = TVE_MainLightParams.a;
				half Subsurface_Intensity1752_g53707 = ( _SubsurfaceValue * MainLight_Subsurface4041_g53707 );
				float temp_output_7_0_g53781 = _SubsurfaceMaskMinValue;
				half Subsurface_Mask1557_g53707 = saturate( ( ( IN.ase_color.a - temp_output_7_0_g53781 ) / ( _SubsurfaceMaskMaxValue - temp_output_7_0_g53781 ) ) );
				half3 Subsurface_Transmission884_g53707 = ( Subsurface_Color1722_g53707 * Subsurface_Intensity1752_g53707 * Subsurface_Mask1557_g53707 );
				half3 MainLight_Direction3926_g53707 = TVE_MainLightDirection;
				float3 normalizeResult2169_g53707 = normalize( ( _WorldSpaceCameraPos - WorldPosition ) );
				float3 ViewDir_Normalized3963_g53707 = normalizeResult2169_g53707;
				float dotResult785_g53707 = dot( -MainLight_Direction3926_g53707 , ViewDir_Normalized3963_g53707 );
				float saferPower1624_g53707 = max( (dotResult785_g53707*0.5 + 0.5) , 0.0001 );
				#ifdef UNITY_PASS_FORWARDADD
				float staticSwitch1602_g53707 = 0.0;
				#else
				float staticSwitch1602_g53707 = ( pow( saferPower1624_g53707 , _MainLightAngleValue ) * _MainLightScatteringValue );
				#endif
				half Mask_Subsurface_View782_g53707 = staticSwitch1602_g53707;
				half3 Subsurface_Scattering1693_g53707 = ( Subsurface_Transmission884_g53707 * Blend_AlbedoColored863_g53707 * Mask_Subsurface_View782_g53707 );
				half3 Blend_AlbedoAndSubsurface149_g53707 = ( Blend_AlbedoColored863_g53707 + Subsurface_Scattering1693_g53707 );
				half3 Global_OverlayColor1758_g53707 = (TVE_OverlayColor).rgb;
				half Main_AlbedoTex_G3526_g53707 = tex2DNode29_g53707.g;
				float3 Position82_g53742 = WorldPosition3905_g53707;
				float temp_output_84_0_g53742 = _LayerExtrasValue;
				float4 lerpResult88_g53742 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53742).xz ) ),temp_output_84_0_g53742 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53742]);
				float4 break89_g53742 = lerpResult88_g53742;
				half Global_Extras_Overlay156_g53707 = break89_g53742.b;
				float temp_output_1025_0_g53707 = ( _GlobalOverlay * Global_Extras_Overlay156_g53707 );
				float lerpResult1065_g53707 = lerp( 1.0 , IN.ase_color.r , _OverlayVariationValue);
				half Overlay_Commons1365_g53707 = ( temp_output_1025_0_g53707 * lerpResult1065_g53707 );
				float temp_output_7_0_g53770 = _OverlayMaskMinValue;
				half Overlay_Mask269_g53707 = saturate( ( ( ( ( ( IN.ase_color.a * 0.5 ) + Main_AlbedoTex_G3526_g53707 ) * Overlay_Commons1365_g53707 ) - temp_output_7_0_g53770 ) / ( _OverlayMaskMaxValue - temp_output_7_0_g53770 ) ) );
				float3 lerpResult336_g53707 = lerp( Blend_AlbedoAndSubsurface149_g53707 , Global_OverlayColor1758_g53707 , Overlay_Mask269_g53707);
				half3 Final_Albedo359_g53707 = lerpResult336_g53707;
				float3 temp_cast_6 = (1.0).xxx;
				float Mesh_Occlusion318_g53707 = IN.ase_color.g;
				float temp_output_7_0_g53782 = _VertexOcclusionMinValue;
				float3 lerpResult2945_g53707 = lerp( (_VertexOcclusionColor).rgb , temp_cast_6 , saturate( ( ( Mesh_Occlusion318_g53707 - temp_output_7_0_g53782 ) / ( _VertexOcclusionMaxValue - temp_output_7_0_g53782 ) ) ));
				float3 Vertex_Occlusion648_g53707 = lerpResult2945_g53707;
				
				float4 temp_output_4214_0_g53707 = ( _EmissiveColor * _EmissiveIntensityParams.x );
				float2 vertexToFrag11_g53724 = IN.ase_texcoord10.zw;
				half2 Emissive_UVs2468_g53707 = vertexToFrag11_g53724;
				half Global_Extras_Emissive4203_g53707 = break89_g53742.r;
				float lerpResult4206_g53707 = lerp( 1.0 , Global_Extras_Emissive4203_g53707 , _GlobalEmissive);
				half3 Final_Emissive2476_g53707 = ( (( temp_output_4214_0_g53707 * SAMPLE_TEXTURE2D( _EmissiveTex, sampler_EmissiveTex, Emissive_UVs2468_g53707 ) )).rgb * lerpResult4206_g53707 );
				
				float3 temp_cast_7 = (( 0.04 * _RenderSpecular )).xxx;
				
				float4 tex2DNode35_g53707 = SAMPLE_TEXTURE2D( _MainMaskTex, sampler_MainAlbedoTex, Main_UVs15_g53707 );
				half Main_Smoothness227_g53707 = ( tex2DNode35_g53707.a * _MainSmoothnessValue );
				half Blend_Smoothness314_g53707 = Main_Smoothness227_g53707;
				half Global_OverlaySmoothness311_g53707 = TVE_OverlaySmoothness;
				float lerpResult343_g53707 = lerp( Blend_Smoothness314_g53707 , Global_OverlaySmoothness311_g53707 , Overlay_Mask269_g53707);
				half Final_Smoothness371_g53707 = lerpResult343_g53707;
				half Global_Extras_Wetness305_g53707 = break89_g53742.g;
				float lerpResult3673_g53707 = lerp( 0.0 , Global_Extras_Wetness305_g53707 , _GlobalWetness);
				half Final_SmoothnessAndWetness4130_g53707 = saturate( ( Final_Smoothness371_g53707 + lerpResult3673_g53707 ) );
				
				float lerpResult240_g53707 = lerp( 1.0 , tex2DNode35_g53707.g , _MainOcclusionValue);
				half Main_Occlusion247_g53707 = lerpResult240_g53707;
				half Blend_Occlusion323_g53707 = Main_Occlusion247_g53707;
				
				float localCustomAlphaClip3735_g53707 = ( 0.0 );
				half Final_AlphaFade3727_g53707 = 1.0;
				float Main_Alpha316_g53707 = ( _MainColor.a * tex2DNode29_g53707.a );
				float Mesh_Variation16_g53707 = IN.ase_color.r;
				float lerpResult4033_g53707 = lerp( 0.9 , (Mesh_Variation16_g53707*0.5 + 0.5) , _AlphaVariationValue);
				half Global_Extras_Alpha1033_g53707 = break89_g53742.a;
				float temp_output_4022_0_g53707 = ( lerpResult4033_g53707 - ( 1.0 - Global_Extras_Alpha1033_g53707 ) );
				half AlphaTreshold2132_g53707 = _Cutoff;
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch4017_g53707 = ( temp_output_4022_0_g53707 + AlphaTreshold2132_g53707 );
				#else
				float staticSwitch4017_g53707 = temp_output_4022_0_g53707;
				#endif
				float lerpResult4011_g53707 = lerp( 1.0 , staticSwitch4017_g53707 , _GlobalAlpha);
				half Global_Alpha315_g53707 = saturate( lerpResult4011_g53707 );
				#ifdef TVE_ALPHA_CLIP
				float staticSwitch3792_g53707 = ( ( Main_Alpha316_g53707 * Global_Alpha315_g53707 ) - ( AlphaTreshold2132_g53707 - 0.5 ) );
				#else
				float staticSwitch3792_g53707 = ( Main_Alpha316_g53707 * Global_Alpha315_g53707 );
				#endif
				half Final_Alpha3754_g53707 = staticSwitch3792_g53707;
				float temp_output_661_0_g53707 = ( Final_AlphaFade3727_g53707 * Final_Alpha3754_g53707 );
				float Alpha3735_g53707 = temp_output_661_0_g53707;
				float Treshold3735_g53707 = 0.5;
				{
				#if TVE_ALPHA_CLIP
				clip(Alpha3735_g53707 - Treshold3735_g53707);
				#endif
				}
				half Final_Clip914_g53707 = saturate( Alpha3735_g53707 );
				
				float3 Albedo = ( Final_Albedo359_g53707 * Vertex_Occlusion648_g53707 );
				float3 Normal = float3(0, 0, 1);
				float3 Emission = Final_Emissive2476_g53707;
				float3 Specular = temp_cast_7;
				float Metallic = 0;
				float Smoothness = Final_SmoothnessAndWetness4130_g53707;
				float Occlusion = Blend_Occlusion323_g53707;
				float Alpha = Final_Clip914_g53707;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = 1;
				#ifdef ASE_DEPTH_WRITE_ON
				float DepthValue = 0;
				#endif

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				InputData inputData;
				inputData.positionWS = WorldPosition;
				inputData.viewDirectionWS = WorldViewDirection;
				inputData.shadowCoord = ShadowCoords;

				#ifdef _NORMALMAP
					#if _NORMAL_DROPOFF_TS
					inputData.normalWS = TransformTangentToWorld(Normal, half3x3( WorldTangent, WorldBiTangent, WorldNormal ));
					#elif _NORMAL_DROPOFF_OS
					inputData.normalWS = TransformObjectToWorldNormal(Normal);
					#elif _NORMAL_DROPOFF_WS
					inputData.normalWS = Normal;
					#endif
					inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);
				#else
					inputData.normalWS = WorldNormal;
				#endif

				#ifdef ASE_FOG
					inputData.fogCoord = IN.fogFactorAndVertexLight.x;
				#endif

				inputData.vertexLighting = IN.fogFactorAndVertexLight.yzw;
				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float3 SH = SampleSH(inputData.normalWS.xyz);
				#else
					float3 SH = IN.lightmapUVOrVertexSH.xyz;
				#endif

				inputData.bakedGI = SAMPLE_GI( IN.lightmapUVOrVertexSH.xy, SH, inputData.normalWS );
				#ifdef _ASE_BAKEDGI
					inputData.bakedGI = BakedGI;
				#endif

				BRDFData brdfData;
				InitializeBRDFData( Albedo, Metallic, Specular, Smoothness, Alpha, brdfData);
				half4 color;
				color.rgb = GlobalIllumination( brdfData, inputData.bakedGI, Occlusion, inputData.normalWS, inputData.viewDirectionWS);
				color.a = Alpha;
			
				#ifdef ASE_FINAL_COLOR_ALPHA_MULTIPLY
					color.rgb *= color.a;
				#endif
				
				#ifdef ASE_FOG
					#ifdef TERRAIN_SPLAT_ADDPASS
						color.rgb = MixFogColor(color.rgb, half3( 0, 0, 0 ), IN.fogFactorAndVertexLight.x );
					#else
						color.rgb = MixFog(color.rgb, IN.fogFactorAndVertexLight.x);
					#endif
				#endif
				
				#ifdef ASE_DEPTH_WRITE_ON
					outputDepth = DepthValue;
				#endif
				
				return BRDFDataToGbuffer(brdfData, inputData, Smoothness, Emission + color.rgb);
			}

			ENDHLSL
		}
		
	}
	/*ase_lod*/
	CustomEditor "TVEShaderCoreGUI"
	Fallback "Hidden/BOXOPHOBIC/The Vegetation Engine/Fallback"
	
}
/*ASEBEGIN
Version=18910
1920;6;1920;1023;2739.485;585.84;1;True;False
Node;AmplifyShaderEditor.FunctionNode;596;-1344,-896;Inherit;False;Compile All Shaders;-1;;52312;e67c8238031dbf04ab79a5d4d63d1b4f;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;168;-2176,-896;Half;False;Property;_IsGrassShader;_IsGrassShader;194;1;[HideInInspector];Create;True;0;0;0;True;0;False;1;0;1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;10;-2176,-768;Half;False;Property;_render_cull;_render_cull;196;1;[HideInInspector];Create;True;0;3;Both;0;Back;1;Front;2;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;81;-1968,-896;Half;False;Property;_IsStandardShader;_IsStandardShader;195;1;[HideInInspector];Create;True;0;0;0;True;0;False;1;0;1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-1792,-768;Half;False;Property;_render_dst;_render_dst;198;1;[HideInInspector];Create;True;0;2;Opaque;0;Transparent;1;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;569;-2176,-384;Inherit;False;Base Shader;0;;53707;856f7164d1c579d43a5cf4968a75ca43;80,3882,1,3880,1,3957,0,4028,1,4029,1,4204,1,3903,1,3904,1,3900,1,3908,1,4172,1,1300,1,1298,1,4179,1,3586,0,3658,1,1708,1,3509,1,1712,0,3873,1,1714,1,1718,1,1717,1,1715,1,916,0,1763,0,1762,0,3568,1,1949,1,1776,1,3475,1,4210,1,893,1,1745,1,3479,0,3501,1,3221,1,1646,1,1757,0,1271,1,3889,1,2807,1,3886,0,2953,1,3887,0,3243,1,3888,0,3728,0,3949,0,2172,0,3883,0,2658,1,1742,1,3484,0,1734,0,1737,0,3575,0,1735,0,1736,0,1733,0,1550,0,878,0,4067,0,4068,0,4072,0,4069,0,4070,0,860,1,3544,1,2260,1,2261,1,2032,0,2054,0,2039,1,2062,1,3592,1,4177,1,4217,1,4242,1,2750,1;0;19;FLOAT3;0;FLOAT3;528;FLOAT3;2489;FLOAT;531;FLOAT;4135;FLOAT;529;FLOAT;3678;FLOAT;530;FLOAT;4127;FLOAT;4122;FLOAT;4134;FLOAT;1235;FLOAT3;1230;FLOAT;1461;FLOAT;1290;FLOAT;721;FLOAT;532;FLOAT;629;FLOAT3;534
Node;AmplifyShaderEditor.FunctionNode;595;-1920,384;Inherit;False;Define FEATURES UNIVERSAL;-1;;53706;71dc7add32e5f6247b1fb74ecceddd3e;0;0;1;FLOAT;529
Node;AmplifyShaderEditor.RangedFloatNode;20;-1984,-768;Half;False;Property;_render_src;_render_src;197;1;[HideInInspector];Create;True;0;0;0;True;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;597;-1536,-896;Inherit;False;Compile Core;-1;;53705;634b02fd1f32e6a4c875d8fc2c450956;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;535;-2176,384;Inherit;False;Define SHADER GRASS;-1;;53704;921559c53826c0142ba6e27dd03eaef2;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;17;-1600,-768;Half;False;Property;_render_zw;_render_zw;199;1;[HideInInspector];Create;True;0;2;Opaque;0;Transparent;1;0;True;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;587;-1376,-384;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;1;New Amplify Shader;28cd5599e02859647ae1798e4fcaef6c;True;ExtraPrePass;0;0;ExtraPrePass;5;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;0;False;True;1;1;False;-1;0;False;-1;0;1;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;0;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;589;-1376,-384;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;1;New Amplify Shader;28cd5599e02859647ae1798e4fcaef6c;True;ShadowCaster;0;2;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;-1;True;3;False;-1;False;True;1;LightMode=ShadowCaster;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;588;-1376,-384;Float;False;True;-1;2;TVEShaderCoreGUI;0;18;BOXOPHOBIC/The Vegetation Engine/Vegetation/Grass Standard Lit;28cd5599e02859647ae1798e4fcaef6c;True;Forward;0;1;Forward;18;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;True;True;2;True;10;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;4;0;True;True;1;1;True;20;0;True;7;1;1;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;True;True;1;True;17;True;0;False;-1;True;False;0;False;-1;0;False;-1;True;1;LightMode=UniversalForward;False;0;Hidden/BOXOPHOBIC/The Vegetation Engine/Fallback;0;0;Standard;38;Workflow;0;Surface;0;  Refraction Model;0;  Blend;0;Two Sided;0;Fragment Normal Space,InvertActionOnDeselection;0;Transmission;0;  Transmission Shadow;0.5,True,1013;Translucency;0;  Translucency Strength;1,False,-1;  Normal Distortion;0.5,False,-1;  Scattering;2,False,-1;  Direct;0.9,False,-1;  Ambient;0.1,False,-1;  Shadow;0.5,False,-1;Cast Shadows;1;  Use Shadow Threshold;0;Receive Shadows;1;GPU Instancing;1;LOD CrossFade;1;Built-in Fog;1;_FinalColorxAlpha;0;Meta Pass;1;Override Baked GI;0;Extra Pre Pass;0;DOTS Instancing;1;Tessellation;0;  Phong;0;  Strength;0.5,False,-1;  Type;0;  Tess;16,False,-1;  Min;10,False,-1;  Max;25,False,-1;  Edge Length;16,False,-1;  Max Displacement;25,False,-1;Write Depth;0;  Early Z;0;Vertex Position,InvertActionOnDeselection;0;0;8;False;True;True;True;True;True;True;True;False;;True;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;591;-1376,-384;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;1;New Amplify Shader;28cd5599e02859647ae1798e4fcaef6c;True;Meta;0;4;Meta;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;590;-1376,-384;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;1;New Amplify Shader;28cd5599e02859647ae1798e4fcaef6c;True;DepthOnly;0;3;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;False;False;True;False;False;False;False;0;False;-1;False;False;False;False;False;False;False;False;False;True;1;False;-1;False;False;True;1;LightMode=DepthOnly;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;599;-1376,-384;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;1;New Amplify Shader;28cd5599e02859647ae1798e4fcaef6c;True;GBuffer;0;7;GBuffer;1;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;0;False;True;1;1;True;20;0;True;7;1;1;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;1;True;17;True;0;False;-1;True;False;0;False;-1;0;False;-1;True;1;LightMode=UniversalGBuffer;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;592;-1376,-384;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;1;New Amplify Shader;28cd5599e02859647ae1798e4fcaef6c;True;Universal2D;0;5;Universal2D;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;0;False;True;1;1;True;20;0;True;7;1;1;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;False;False;True;1;True;17;True;0;False;-1;True;False;0;False;-1;0;False;-1;True;1;LightMode=Universal2D;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;598;-1376,-47;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;1;New Amplify Shader;28cd5599e02859647ae1798e4fcaef6c;True;DepthNormals;0;6;DepthNormals;0;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;0;0;False;True;1;1;False;-1;0;False;-1;0;1;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;-1;True;3;False;-1;False;True;1;LightMode=DepthNormals;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.CommentaryNode;408;-2176,256;Inherit;False;1026.438;100;Features;0;;0,1,0.5,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;37;-2176,-1024;Inherit;False;1023.392;100;Internal;0;;1,0.252,0,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;33;-2176,-512;Inherit;False;1024.392;100;Final;0;;0,1,0.5,1;0;0
WireConnection;588;0;569;0
WireConnection;588;1;569;528
WireConnection;588;2;569;2489
WireConnection;588;9;569;3678
WireConnection;588;4;569;530
WireConnection;588;5;569;531
WireConnection;588;6;569;532
WireConnection;588;8;569;534
ASEEND*/
//CHKSM=5795EEBB13EF2B0F5257FAF5C45363F8A6E6BCC8
