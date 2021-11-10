// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "BOXOPHOBIC/The Vegetation Engine/Impostors/Vegetation Subsurface Lit (Octahedorn)"
{
    Properties
    {
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[StyledCategory(Impostor Settings, 5, 10)]_ImpostorCat("[ Impostor Cat ]", Float) = 0
		_Albedo("Impostor Albedo & Alpha", 2D) = "white" {}
		_Normals("Impostor Normal & Depth", 2D) = "white" {}
		[NoScaleOffset]_Mask("Impostor Baked Masks", 2D) = "white" {}
		[NoScaleOffset]_Emissive("Impostor Emissive Map", 2D) = "white" {}
		_AI_Parallax("Impostor Parallax", Range( 0 , 1)) = 1
		_AI_ShadowView("Impostor Shadow View", Range( 0 , 1)) = 1
		_AI_ShadowBias("Impostor Shadow Bias", Range( 0 , 2)) = 0.25
		_AI_TextureBias("Impostor Texture Bias", Float) = -1
		_AI_Clip("Impostor Clip", Range( 0 , 1)) = 0.5
		[HideInInspector]_AI_DepthSize("Impostor Depth Size", Float) = 0
		[HideInInspector]_AI_SizeOffset("Impostor Size Offset", Vector) = (0,0,0,0)
		[HideInInspector]_AI_Frames("Impostor Frames", Float) = 0
		[HideInInspector]_AI_Offset("Impostor Offset", Vector) = (0,0,0,0)
		[HideInInspector]_AI_ImpostorSize("Impostor Size", Float) = 0
		[HideInInspector]_AI_FramesY("Impostor Frames Y", Float) = 0
		[HideInInspector]_AI_FramesX("Impostor Frames X", Float) = 0
		[HideInInspector]_IsVersion("_IsVersion", Float) = 210
		[StyledMessage(Error, Baked Pivots are not supported with Impostors and the Size features and Motion will not work with large Grass meshes., _MaterialType, 20, 10, 0)]_PivotsMessage("# Pivots Message", Float) = 0
		[Enum(Vegetation,10,Grass,20)][Space(10)]_MaterialType("Impostor Type", Float) = 10
		[HDR][Space(10)]_ImpostorBarkColor("Impostor Bark Color", Color) = (1,1,1,1)
		[HDR]_ImpostorLeafColor("Impostor Leaf Color", Color) = (1,1,1,1)
		_ImpostorBarkSaturationValue("Impostor Bark Saturation", Range( 0 , 1)) = 1
		_ImpostorLeafSaturationValue("Impostor Leaf Saturation", Range( 0 , 1)) = 1
		[HDR][Space(10)]_ImpostorGrassColor("Impostor Grass Color", Color) = (1,1,1,1)
		_ImpostorGrassSaturationValue("Impostor Grass Saturation", Range( 0 , 1)) = 1
		_ImpostorSmoothnessValue("Impostor Smoothness", Range( 0 , 1)) = 1
		[Enum(Off,0,On,1)][Space(10)]_RenderSpecular("Receive Specular", Float) = 1
		[StyledCategory(Global Settings)]_GlobalCat("[ Global Cat ]", Float) = 0
		[StyledEnum(Default _Layer 1 _Layer 2 _Layer 3 _Layer 4 _Layer 5 _Layer 6 _Layer 7 _Layer 8)]_LayerColorsValue("Layer Colors", Float) = 0
		[StyledEnum(Default _Layer 1 _Layer 2 _Layer 3 _Layer 4 _Layer 5 _Layer 6 _Layer 7 _Layer 8)]_LayerExtrasValue("Layer Extras", Float) = 0
		[StyledEnum(Default _Layer 1 _Layer 2 _Layer 3 _Layer 4 _Layer 5 _Layer 6 _Layer 7 _Layer 8)]_LayerReactValue("Layer React", Float) = 0
		[StyledEnum(Default _Layer 1 _Layer 2 _Layer 3 _Layer 4 _Layer 5 _Layer 6 _Layer 7 _Layer 8)]_LayerMotionValue("Layer Motion", Float) = 0
		[StyledSpace(10)]_LayersSpace("# Layers Space", Float) = 0
		_GlobalColors("Global Colors", Range( 0 , 1)) = 0
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
		_OverlayVariationValue("Overlay Variation", Range( 0 , 1)) = 0.5
		[Space(10)]_AlphaVariationValue("Alpha Variation", Range( 0 , 1)) = 1
		[StyledCategory(Detail Settings)]_DetailCat("[ Detail Cat ]", Float) = 0
		[Enum(Baked,0,Projection,1)]_DetailMode("Detail Mode", Float) = 0
		[Enum(Overlay,0,Replace,1)]_DetailBlendMode("Detail Blend", Float) = 1
		[StyledRemapSlider(_DetailBlendMinValue, _DetailBlendMaxValue,0,1)]_DetailBlendRemap("Detail Blending", Vector) = (0,0,0,0)
		[StyledCategory(Subsurface Settings)]_SubsurfaceCat("[ Subsurface Cat ]", Float) = 0
		_SubsurfaceValue("Subsurface Intensity", Range( 0 , 1)) = 1
		[HDR]_SubsurfaceColor("Subsurface Color", Color) = (0.4,0.4,0.1,1)
		[StyledRemapSlider(_SubsurfaceMaskMinValue, _SubsurfaceMaskMaxValue,0,1)]_SubsurfaceMaskRemap("Subsurface Mask", Vector) = (0,0,0,0)
		[HideInInspector]_SubsurfaceMaskMinValue("Subsurface Mask Min Value", Range( 0 , 1)) = 0
		[HideInInspector]_SubsurfaceMaskMaxValue("Subsurface Mask Max Value", Range( 0 , 1)) = 1
		[Space(10)][DiffusionProfile]_SubsurfaceDiffusion("Subsurface Diffusion", Float) = 0
		[HideInInspector][Space(10)][ASEDiffusionProfile(_SubsurfaceDiffusion)]_SubsurfaceDiffusion_asset("Subsurface Diffusion", Vector) = (0,0,0,0)
		[HideInInspector]_SubsurfaceDiffusion_Asset("Subsurface Diffusion", Vector) = (0,0,0,0)
		[Space(10)]_MainLightScatteringValue("Subsurface Scattering Intensity", Range( 0 , 16)) = 8
		_MainLightNormalValue("Subsurface Scattering Normal", Range( 0 , 1)) = 0.5
		_MainLightAngleValue("Subsurface Scattering Angle", Range( 0 , 16)) = 8
		[Space(10)]_TranslucencyIntensityValue("Translucency Intensity", Range( 0 , 50)) = 1
		_TranslucencyNormalValue("Translucency Normal", Range( 0 , 1)) = 0.1
		_TranslucencyScatteringValue("Translucency Scattering", Range( 1 , 50)) = 2
		_TranslucencyDirectValue("Translucency Direct", Range( 0 , 1)) = 1
		_TranslucencyAmbientValue("Translucency Ambient", Range( 0 , 1)) = 0.2
		_TranslucencyShadowValue("Translucency Shadow", Range( 0 , 1)) = 1
		[StyledMessage(Warning,  Translucency is not supported in HDRP. Diffusion Profiles will be used instead., 10, 5)]_TranslucencyHDMessage("# Translucency HD Message", Float) = 0
		[StyledRemapSlider(_GradientMinValue, _GradientMaxValue, 0, 1)]_GradientMaskRemap("Gradient Mask", Vector) = (0,0,0,0)
		[StyledCategory(Noise Settings)]_NoiseCat("[ Noise Cat ]", Float) = 0
		[HDR]_NoiseColorOne("Noise Color One", Color) = (1,1,1,1)
		[HDR]_NoiseColorTwo("Noise Color Two", Color) = (1,1,1,1)
		[StyledRemapSlider(_NoiseMinValue, _NoiseMaxValue, 0, 1)]_NoiseMaskRemap("Noise Mask", Vector) = (0,0,0,0)
		[HideInInspector]_NoiseMinValue("Noise Mask Min", Range( 0 , 1)) = 0
		[HideInInspector]_NoiseMaxValue("Noise Mask Max ", Range( 0 , 1)) = 1
		_NoiseScaleValue("Noise Scale", Range( 0 , 1)) = 0.01
		[StyledCategory(Emissive Settings)]_EmissiveCat("[ Emissive Cat]", Float) = 0
		[Enum(None,0,Any,10,Baked,20,Realtime,30)]_EmissiveFlagMode("Emissive Baking", Float) = 0
		[HDR]_EmissiveColor("Emissive Color", Color) = (0,0,0,0)
		[StyledEmissiveIntensity]_EmissiveIntensityParams("Emissive Intensity", Vector) = (1,1,1,0)
		[StyledCategory(Fade Settings)]_SizeFadeCat("[ Size Fade Cat ]", Float) = 0
		[StyledMessage(Info, The Size Fade feature is recommended to be used to fade out vegetation at a distance in combination with the LOD Groups or with a 3rd party culling system., _SizeFadeMode, 1, 0, 10)]_SizeFadeMessage("# Size Fade Message", Float) = 0
		[StyledCategory(Motion Settings)]_MotionCat("[ Motion Cat ]", Float) = 0
		[HDR]_MotionHighlightColor("Motion Highlight", Color) = (2,2,2,1)
		[StyledSpace(10)]_MotionSpace("# Motion Space", Float) = 1
		_MotionAmplitude_10("Bending Amplitude", Range( 0 , 2)) = 2
		[IntRange]_MotionSpeed_10("Bending Speed", Range( 0 , 60)) = 6
		_MotionScale_10("Bending Elasticity", Range( 0 , 20)) = 1
		[ASEEnd][Space(10)]_InteractionAmplitude("Interaction Amplitude", Range( 0 , 10)) = 0
		[HideInInspector]_IsTVEAIShader("_IsTVEAIShader", Float) = 1
		[HideInInspector]_IsInitialized("_IsInitialized", Float) = 0
		[HideInInspector]_subsurface_shadow("_subsurface_shadow", Float) = 1
		[HideInInspector]_IsVegetationShader("_IsVegetationShader", Float) = 1

		//_TransmissionShadow( "Transmission Shadow", Range( 0, 1 ) ) = 0.5
		//_TransStrength( "Trans Strength", Range( 0, 50 ) ) = 1
		//_TransNormal( "Trans Normal Distortion", Range( 0, 1 ) ) = 0.5
		//_TransScattering( "Trans Scattering", Range( 1, 50 ) ) = 2
		//_TransDirect( "Trans Direct", Range( 0, 1 ) ) = 0.9
		//_TransAmbient( "Trans Ambient", Range( 0, 1 ) ) = 0.1
		//_TransShadow( "Trans Shadow", Range( 0, 1 ) ) = 0.5
    }

    SubShader
    {
		LOD 0

		
        Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Opaque" "Queue"="Geometry" "ImpostorType"="Octahedron" }

		Cull Back
		HLSLINCLUDE
		#pragma target 4.0

		struct SurfaceOutput
		{
			half3 Albedo;
			half3 Specular;
			half Metallic;
			float3 Normal;
			half3 Emission;
			half Smoothness;
			half Occlusion;
			half Alpha;
		};

		#define AI_RENDERPIPELINE
		ENDHLSL
		
        Pass
        {
			
			Name "Base"
        	Tags { "LightMode"="UniversalForward" }

			Blend One Zero
			ZWrite On
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA
            
        	HLSLPROGRAM
            
            #define _TRANSMISSION_ASE 1
            #define ASE_SRP_VERSION 100202
            #ifdef UNITY_COLORSPACE_GAMMA//AI_SRP
            #define unity_ColorSpaceDielectricSpec half4(0.220916301, 0.220916301, 0.220916301, 1.0 - 0.220916301)//AI_SRP
            #else//AI_SRP
            #define unity_ColorSpaceDielectricSpec half4(0.04, 0.04, 0.04, 1.0 - 0.04) //AI_SRP
            #endif//AI_SRP

            
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x

        	// -------------------------------------
            // Lightweight Pipeline keywords
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile _ _SHADOWS_SOFT
            #pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
            
        	// -------------------------------------
            // Unity defined keywords
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile_fog

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma vertex vert
        	#pragma fragment frag        	

        	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        	#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        	#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
        	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			#define ai_ObjectToWorld GetObjectToWorldMatrix()
			#define ai_WorldToObject GetWorldToObjectMatrix()
			#define AI_INV_TWO_PI  INV_TWO_PI
			#define AI_PI          PI
			#define AI_INV_PI      INV_PI
			#pragma multi_compile __ LOD_FADE_CROSSFADE
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			#pragma shader_feature_local TVE_IS_VEGETATION_SHADER TVE_IS_GRASS_SHADER


            struct GraphVertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 ase_tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

        	struct GraphVertexOutput
            {
                float4 clipPos                : SV_POSITION;
                float4 lightmapUVOrVertexSH	  : TEXCOORD0;
        		half4 fogFactorAndVertexLight : TEXCOORD1; // x: fogFactor, yzw: vertex light
				//#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
            	//float4 shadowCoord            : TEXCOORD2;
				//#endif
				float4 UVsFrame199 : TEXCOORD3;
				float4 UVsFrame299 : TEXCOORD4;
				float4 UVsFrame399 : TEXCOORD5;
				float4 octaframe99 : TEXCOORD6;
				float4 viewPos99 : TEXCOORD7;
				float4 ase_texcoord8 : TEXCOORD8;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            	UNITY_VERTEX_OUTPUT_STEREO
            };

			CBUFFER_START(UnityPerMaterial)
			half4 _SubsurfaceColor;
			half4 _MotionHighlightColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _NoiseColorOne;
			half4 _NoiseColorTwo;
			float4 _SubsurfaceDiffusion_Asset;
			float4 _ImpostorGrassColor;
			float4 _ImpostorLeafColor;
			float4 _ImpostorBarkColor;
			half4 _ColorsMaskRemap;
			half4 _EmissiveColor;
			float4 _AI_SizeOffset;
			half4 _OverlayMaskRemap;
			half4 _DetailBlendRemap;
			float4 _NoiseMaskRemap;
			float4 _EmissiveIntensityParams;
			float4 _GradientMaskRemap;
			half4 _SubsurfaceMaskRemap;
			float3 _AI_Offset;
			half _ImpostorGrassSaturationValue;
			half _LayerColorsValue;
			half _ImpostorLeafSaturationValue;
			half _ImpostorBarkSaturationValue;
			half _GlobalSize;
			half _NoiseScaleValue;
			half _NoiseMinValue;
			half _NoiseMaxValue;
			half _LayerReactValue;
			half _InteractionAmplitude;
			half _GlobalColors;
			half _IsTVEAIShader;
			half _ColorsMaskMinValue;
			half _GlobalWetness;
			half _ImpostorSmoothnessValue;
			float _RenderSpecular;
			half _GlobalEmissive;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightNormalValue;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _MotionScale_10;
			half _ColorsMaskMaxValue;
			half _ColorsVariationValue;
			half _MotionSpeed_10;
			float _AI_ShadowBias;
			half _MotionAmplitude_10;
			half _SizeFadeCat;
			half _LayersSpace;
			half _NoiseCat;
			float _MaterialType;
			half _MotionCat;
			half _EmissiveFlagMode;
			half _TranslucencyScatteringValue;
			half _SubsurfaceCat;
			half _DetailMode;
			half _GlobalCat;
			half _TranslucencyIntensityValue;
			half _DetailBlendMode;
			half _IsInitialized;
			half _SizeFadeMessage;
			half _TranslucencyShadowValue;
			half _TranslucencyAmbientValue;
			half _MotionSpace;
			half _TranslucencyHDMessage;
			half _LayerMotionValue;
			half _DetailCat;
			float _SubsurfaceDiffusion;
			float _AI_Clip;
			float _AI_ShadowView;
			half _AlphaVariationValue;
			float _AI_DepthSize;
			float _AI_TextureBias;
			float _AI_Parallax;
			float _AI_ImpostorSize;
			float _AI_FramesY;
			float _AI_FramesX;
			float _AI_Frames;
			half _ImpostorCat;
			half _subsurface_shadow;
			half _IsVegetationShader;
			half _TranslucencyDirectValue;
			float _IsVersion;
			half _EmissiveCat;
			half _PivotsMessage;
			half _TranslucencyNormalValue;
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
			CBUFFER_END
			sampler2D _Albedo;
			sampler2D _Normals;
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			sampler2D TVE_NoiseTex;
			half4 TVE_NoiseParams;
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			sampler2D _Mask;
			sampler2D _Emissive;
			SAMPLER(sampler_Mask);
			SAMPLER(sampler_Emissive);
			sampler3D TVE_WorldTex3D;
			half4 TVE_ColorsParams;
			TEXTURE2D_ARRAY(TVE_ColorsTex);
			half4 TVE_ColorsCoord;
			SAMPLER(samplerTVE_ColorsTex);
			float TVE_ColorsUsage[9];
			float4 TVE_MainLightParams;
			half3 TVE_MainLightDirection;
			half4 TVE_OverlayColor;
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];

			
			float2 VectortoOctahedron( float3 N )
			{
				N /= dot( 1.0, abs( N ) );
				if( N.z <= 0 )
				{
				N.xy = ( 1 - abs( N.yx ) ) * ( N.xy >= 0 ? 1.0 : -1.0 );
				}
				return N.xy;
			}
			
			float3 OctahedronToVector( float2 Oct )
			{
				float3 N = float3( Oct, 1.0 - dot( 1.0, abs( Oct ) ) );
				if(N.z< 0 )
				{
				N.xy = ( 1 - abs( N.yx) ) * (N.xy >= 0 ? 1.0 : -1.0 );
				}
				return normalize( N);
			}
			
			inline void RayPlaneIntersectionUV( float3 normal, float3 rayPosition, float3 rayDirection, inout float2 uvs, inout float3 localNormal )
			{
				float lDotN = dot( rayDirection, normal ); 
				float p0l0DotN = dot( -rayPosition, normal );
				float t = p0l0DotN / lDotN;
				float3 p = rayDirection * t + rayPosition;
				float3 upVector = float3( 0, 1, 0 );
				float3 tangent = normalize( cross( upVector, normal ) + float3( -0.001, 0, 0 ) );
				float3 bitangent = cross( tangent, normal );
				float frameX = dot( p, tangent );
				float frameZ = dot( p, bitangent );
				uvs = -float2( frameX, frameZ );
				if( t <= 0.0 )
				uvs = 0;
				float3x3 worldToLocal = float3x3( tangent, bitangent, normal );
				localNormal = normalize( mul( worldToLocal, rayDirection ) );
			}
			
			inline void OctaImpostorVertex( inout float4 vertex, inout float3 normal, inout float4 uvsFrame1, inout float4 uvsFrame2, inout float4 uvsFrame3, inout float4 octaFrame, inout float4 viewPos )
			{
				float2 uvOffset = _AI_SizeOffset.zw;
				float parallax = -_AI_Parallax; 
				float UVscale = _AI_ImpostorSize;
				float framesXY = _AI_Frames;
				float prevFrame = framesXY - 1;
				float3 fractions = 1.0 / float3( framesXY, prevFrame, UVscale );
				float fractionsFrame = fractions.x;
				float fractionsPrevFrame = fractions.y;
				float fractionsUVscale = fractions.z;
				float3 worldOrigin = 0;
				float4 perspective = float4( 0, 0, 0, 1 );
				if( UNITY_MATRIX_P[ 3 ][ 3 ] == 1 ) 
				{
				perspective = float4( 0, 0, 5000, 0 );
				worldOrigin = ai_ObjectToWorld._m03_m13_m23;
				}
				float3 worldCameraPos = worldOrigin + mul( UNITY_MATRIX_I_V, perspective ).xyz;
				float3 objectCameraPosition = mul( ai_WorldToObject, float4( worldCameraPos, 1 ) ).xyz - _AI_Offset.xyz; 
				float3 objectCameraDirection = normalize( objectCameraPosition );
				float3 upVector = float3( 0,1,0 );
				float3 objectHorizontalVector = normalize( cross( objectCameraDirection, upVector ) );
				float3 objectVerticalVector = cross( objectHorizontalVector, objectCameraDirection );
				float2 uvExpansion = vertex.xy;
				float3 billboard = objectHorizontalVector * uvExpansion.x + objectVerticalVector * uvExpansion.y;
				float3 localDir = billboard - objectCameraPosition; 
				float2 frameOcta = VectortoOctahedron( objectCameraDirection.xzy ) * 0.5 + 0.5;
				float2 prevOctaFrame = frameOcta * prevFrame;
				float2 baseOctaFrame = floor( prevOctaFrame );
				float2 fractionOctaFrame = ( baseOctaFrame * fractionsFrame );
				float2 octaFrame1 = ( baseOctaFrame * fractionsPrevFrame ) * 2.0 - 1.0;
				float3 octa1WorldY = OctahedronToVector( octaFrame1 ).xzy;
				float3 octa1LocalY;
				float2 uvFrame1;
				RayPlaneIntersectionUV( octa1WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame1, /*inout*/ octa1LocalY );
				float2 uvParallax1 = octa1LocalY.xy * fractionsFrame * parallax;
				uvFrame1 = ( uvFrame1 * fractionsUVscale + 0.5 ) * fractionsFrame + fractionOctaFrame;
				uvsFrame1 = float4( uvParallax1, uvFrame1) - float4( 0, 0, uvOffset );
				float2 fractPrevOctaFrame = frac( prevOctaFrame );
				float2 cornerDifference = lerp( float2( 0,1 ) , float2( 1,0 ) , saturate( ceil( ( fractPrevOctaFrame.x - fractPrevOctaFrame.y ) ) ));
				float2 octaFrame2 = ( ( baseOctaFrame + cornerDifference ) * fractionsPrevFrame ) * 2.0 - 1.0;
				float3 octa2WorldY = OctahedronToVector( octaFrame2 ).xzy;
				float3 octa2LocalY;
				float2 uvFrame2;
				RayPlaneIntersectionUV( octa2WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame2, /*inout*/ octa2LocalY );
				float2 uvParallax2 = octa2LocalY.xy * fractionsFrame * parallax;
				uvFrame2 = ( uvFrame2 * fractionsUVscale + 0.5 ) * fractionsFrame + ( ( cornerDifference * fractionsFrame ) + fractionOctaFrame );
				uvsFrame2 = float4( uvParallax2, uvFrame2) - float4( 0, 0, uvOffset );
				float2 octaFrame3 = ( ( baseOctaFrame + 1 ) * fractionsPrevFrame  ) * 2.0 - 1.0;
				float3 octa3WorldY = OctahedronToVector( octaFrame3 ).xzy;
				float3 octa3LocalY;
				float2 uvFrame3;
				RayPlaneIntersectionUV( octa3WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame3, /*inout*/ octa3LocalY );
				float2 uvParallax3 = octa3LocalY.xy * fractionsFrame * parallax;
				uvFrame3 = ( uvFrame3 * fractionsUVscale + 0.5 ) * fractionsFrame + ( fractionOctaFrame + fractionsFrame );
				uvsFrame3 = float4( uvParallax3, uvFrame3) - float4( 0, 0, uvOffset );
				octaFrame = 0;
				octaFrame.xy = prevOctaFrame;
				octaFrame.zw = fractionOctaFrame;
				vertex.xyz = billboard + _AI_Offset.xyz;
				normal.xyz = objectCameraDirection;
				viewPos = 0;
				viewPos.xyz = TransformWorldToView( TransformObjectToWorld( vertex.xyz ) );
			}
			
			inline void OctaImpostorFragment( inout SurfaceOutput o, out float4 clipPos, out float3 worldPos, float4 uvsFrame1, float4 uvsFrame2, float4 uvsFrame3, float4 octaFrame, float4 interpViewPos, out float4 output0, out float4 output1 )
			{
				float depthBias = -1.0;
				float textureBias = _AI_TextureBias;
				float2 fraction = frac( octaFrame.xy );
				float2 invFraction = 1 - fraction;
				float3 weights;
				weights.x = min( invFraction.x, invFraction.y );
				weights.y = abs( fraction.x - fraction.y );
				weights.z = min( fraction.x, fraction.y );
				float4 parallaxSample1 = tex2Dbias( _Normals, float4(uvsFrame1.zw, 0, depthBias) );
				float2 parallax1 = ( ( 0.5 - parallaxSample1.a ) * uvsFrame1.xy ) + uvsFrame1.zw;
				float4 parallaxSample2 = tex2Dbias( _Normals, float4(uvsFrame2.zw, 0, depthBias) );
				float2 parallax2 = ( ( 0.5 - parallaxSample2.a ) * uvsFrame2.xy ) + uvsFrame2.zw;
				float4 parallaxSample3 = tex2Dbias( _Normals, float4(uvsFrame3.zw, 0, depthBias) );
				float2 parallax3 = ( ( 0.5 - parallaxSample3.a ) * uvsFrame3.xy ) + uvsFrame3.zw;
				float4 albedo1 = tex2Dbias( _Albedo, float4(parallax1, 0, textureBias) );
				float4 albedo2 = tex2Dbias( _Albedo, float4(parallax2, 0, textureBias) );
				float4 albedo3 = tex2Dbias( _Albedo, float4(parallax3, 0, textureBias) );
				float4 blendedAlbedo = albedo1 * weights.x + albedo2 * weights.y + albedo3 * weights.z;
				o.Alpha = ( blendedAlbedo.a - _AI_Clip );
				clip( o.Alpha );
				float t = ceil( fraction.x - fraction.y );
				float4 cornerDifference = float4( t, 1 - t, 1, 1 );
				float2 step_1 = ( parallax1 - octaFrame.zw ) * _AI_Frames;
				float4 step23 = ( float4( parallax2, parallax3 ) -  octaFrame.zwzw ) * _AI_Frames - cornerDifference;
				step_1 = step_1 * (1-step_1);
				step23 = step23 * (1-step23);
				float3 steps;
				steps.x = step_1.x * step_1.y;
				steps.y = step23.x * step23.y;
				steps.z = step23.z * step23.w;
				steps = step(-steps, 0);
				float final = dot( steps, weights );
				clip( final - 0.5 );
				o.Albedo = blendedAlbedo.rgb;
				#if defined(AI_HD_RENDERPIPELINE) && ( AI_HDRP_VERSION >= 50702 )
				float4 feat1 = _Features.SampleLevel( SamplerState_Point_Repeat, parallax1, 0);
				o.Diffusion = feat1.rgb;
				o.Features = feat1.a;
				float4 test1 = _Specular.SampleLevel( SamplerState_Point_Repeat, parallax1, 0);
				o.MetalTangent = test1.b;
				#endif
				float4 normals1 = tex2Dbias( _Normals, float4(parallax1, 0, textureBias) );
				float4 normals2 = tex2Dbias( _Normals, float4(parallax2, 0, textureBias) );
				float4 normals3 = tex2Dbias( _Normals, float4(parallax3, 0, textureBias) );
				float4 blendedNormal = normals1 * weights.x  + normals2 * weights.y + normals3 * weights.z;
				float4 output0a = tex2Dbias( _Mask, float4(parallax1, 0, textureBias) );
				float4 output0b = tex2Dbias( _Mask, float4(parallax2, 0, textureBias) );
				float4 output0c = tex2Dbias( _Mask, float4(parallax3, 0, textureBias) );
				output0 = output0a * weights.x  + output0b * weights.y + output0c * weights.z; 
				float4 output1a = tex2Dbias( _Emissive, float4(parallax1, 0, textureBias) );
				float4 output1b = tex2Dbias( _Emissive, float4(parallax2, 0, textureBias) );
				float4 output1c = tex2Dbias( _Emissive, float4(parallax3, 0, textureBias) );
				output1 = output1a * weights.x  + output1b * weights.y + output1c * weights.z; 
				float3 localNormal = blendedNormal.rgb * 2.0 - 1.0;
				float3 worldNormal = normalize( mul( (float3x3)ai_ObjectToWorld, localNormal ) );
				o.Normal = worldNormal;
				float3 viewPos = interpViewPos.xyz;
				#if defined(UNITY_PASS_SHADOWCASTER) // Standard RP fix for deferred path
				float depthOffset = ( ( parallaxSample1.a * weights.x + parallaxSample2.a * weights.y + parallaxSample3.a * weights.z ) - 0.5001 /** 2.0 - 1.0*/ ) /** 0.5*/ * _AI_DepthSize * length( ai_ObjectToWorld[ 2 ].xyz );
				#else
				float depthOffset = ( ( parallaxSample1.a * weights.x + parallaxSample2.a * weights.y + parallaxSample3.a * weights.z ) - 0.5 /** 2.0 - 1.0*/ ) /** 0.5*/ * _AI_DepthSize * length( ai_ObjectToWorld[ 2 ].xyz );
				#endif
				#if ( defined(SHADERPASS) && (SHADERPASS == SHADERPASS_SHADOWS) ) || defined(UNITY_PASS_SHADOWCASTER)
				viewPos.z += depthOffset * _AI_ShadowView;
				viewPos.z += -_AI_ShadowBias;
				#else 
				viewPos.z += depthOffset;
				#endif
				worldPos = mul( UNITY_MATRIX_I_V, float4( viewPos.xyz, 1 ) ).xyz;
				clipPos = mul( UNITY_MATRIX_P, float4( viewPos, 1 ) );
				#if defined(UNITY_PASS_SHADOWCASTER) && !defined(SHADERPASS)
				#if UNITY_REVERSED_Z
				clipPos.z = min( clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE );
				#else
				clipPos.z = max( clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE );
				#endif
				#endif
				clipPos.xyz /= clipPos.w;
				if( UNITY_NEAR_CLIP_VALUE < 0 )
				clipPos = clipPos * 0.5 + 0.5;
			}
			

            GraphVertexOutput vert (GraphVertexInput v)
        	{
        		GraphVertexOutput o = (GraphVertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
            	UNITY_TRANSFER_INSTANCE_ID(v, o);
        		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				OctaImpostorVertex( v.vertex, v.normal, o.UVsFrame199, o.UVsFrame299, o.UVsFrame399, o.octaframe99, o.viewPos99 );
				float3 worldPosOut99 = mul( UNITY_MATRIX_I_V, float4( o.viewPos99.xyz, 1.0 ) ).xyz;
				float3 temp_output_3563_0_g53398 = worldPosOut99;
				float3 worldToObj3565_g53398 = mul( GetWorldToObjectMatrix(), float4( temp_output_3563_0_g53398, 1 ) ).xyz;
				float3 VertexPosition3564_g53398 = worldToObj3565_g53398;
				half3 VertexPos40_g53462 = VertexPosition3564_g53398;
				float3 appendResult74_g53462 = (float3(VertexPos40_g53462.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53462 = appendResult74_g53462;
				float3 break84_g53462 = VertexPos40_g53462;
				float3 appendResult81_g53462 = (float3(0.0 , break84_g53462.y , break84_g53462.z));
				half3 VertexPosOtherAxis82_g53462 = appendResult81_g53462;
				float Motion_Max_Bending1133_g53398 = 3.14;
				float4x4 break19_g53480 = GetObjectToWorldMatrix();
				float3 appendResult20_g53480 = (float3(break19_g53480[ 0 ][ 3 ] , break19_g53480[ 1 ][ 3 ] , break19_g53480[ 2 ][ 3 ]));
				half3 ObjectData20_g53481 = appendResult20_g53480;
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53481 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53481 = WorldData19_g53481;
				#else
				float3 staticSwitch14_g53481 = ObjectData20_g53481;
				#endif
				float3 temp_output_114_0_g53480 = staticSwitch14_g53481;
				float3 ObjectPosition4422_g53398 = temp_output_114_0_g53480;
				float3 Position83_g53471 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53471 = _LayerMotionValue;
				float4 lerpResult87_g53471 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53471).xz ) ),temp_output_84_0_g53471, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53471]);
				half4 Global_Motion_Params4344_g53398 = lerpResult87_g53471;
				float4 break322_g53478 = Global_Motion_Params4344_g53398;
				half Wind_Power369_g53478 = break322_g53478.z;
				float lerpResult376_g53478 = lerp( 0.1 , 1.0 , Wind_Power369_g53478);
				half Wind_Power_103106_g53398 = lerpResult376_g53478;
				float3 appendResult397_g53478 = (float3(break322_g53478.x , 0.0 , break322_g53478.y));
				float3 temp_output_398_0_g53478 = (appendResult397_g53478*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53478 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53478 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53398 = (temp_output_339_0_g53478).xz;
				float2 panner73_g53468 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4422_g53398).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53468 = tex2Dlod( TVE_NoiseTex, float4( panner73_g53468, 0, 0.0) );
				float4 saferPower77_g53468 = max( abs( tex2DNode75_g53468 ) , 0.0001 );
				half Wind_Power2223_g53398 = Wind_Power369_g53478;
				float temp_output_167_0_g53468 = Wind_Power2223_g53398;
				float lerpResult168_g53468 = lerp( 1.5 , 0.25 , temp_output_167_0_g53468);
				float4 temp_cast_5 = (lerpResult168_g53468).xxxx;
				float4 break142_g53468 = pow( saferPower77_g53468 , temp_cast_5 );
				half Global_NoiseTex_R34_g53398 = break142_g53468.r;
				half Input_Speed62_g53399 = _MotionSpeed_10;
				float mulTime373_g53399 = _TimeParameters.x * Input_Speed62_g53399;
				half Motion_Variation284_g53399 = 0.0;
				float2 appendResult344_g53399 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53399 = ( _MotionScale_10 * appendResult344_g53399 );
				half2 Sine_MinusOneToOne281_g53399 = sin( ( mulTime373_g53399 + Motion_Variation284_g53399 + Motion_Scale287_g53399 ) );
				float2 temp_cast_6 = (1.0).xx;
				half Input_Turbulence327_g53399 = Global_NoiseTex_R34_g53398;
				float2 lerpResult321_g53399 = lerp( Sine_MinusOneToOne281_g53399 , temp_cast_6 , Input_Turbulence327_g53399);
				half2 Motion_Bending2258_g53398 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53398 ) * Wind_Power_103106_g53398 * Wind_DirectionOS39_g53398 * Global_NoiseTex_R34_g53398 * lerpResult321_g53399 );
				half Interaction_Amplitude4351_g53398 = _InteractionAmplitude;
				float3 Position83_g53477 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53477 = _LayerReactValue;
				float4 lerpResult87_g53477 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53477).xz ) ),temp_output_84_0_g53477, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53477]);
				half4 Global_React_Params4413_g53398 = lerpResult87_g53477;
				float4 break322_g53460 = Global_React_Params4413_g53398;
				half Interaction_Mask66_g53398 = break322_g53460.z;
				float3 appendResult397_g53460 = (float3(break322_g53460.x , 0.0 , break322_g53460.y));
				float3 temp_output_398_0_g53460 = (appendResult397_g53460*2.0 + -1.0);
				float3 temp_output_339_0_g53460 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53460 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4349_g53398 = (temp_output_339_0_g53460).xz;
				half2 Motion_Interaction53_g53398 = ( Interaction_Amplitude4351_g53398 * Motion_Max_Bending1133_g53398 * Interaction_Mask66_g53398 * Interaction_Mask66_g53398 * Interaction_DirectionOS4349_g53398 );
				float2 lerpResult109_g53398 = lerp( Motion_Bending2258_g53398 , Motion_Interaction53_g53398 , ( Interaction_Mask66_g53398 * saturate( Interaction_Amplitude4351_g53398 ) ));
				float temp_output_3572_0_g53398 = saturate( VertexPosition3564_g53398.y );
				half Mesh_Motion_182_g53398 = temp_output_3572_0_g53398;
				float2 break143_g53398 = ( lerpResult109_g53398 * Mesh_Motion_182_g53398 );
				half Motion_Z190_g53398 = break143_g53398.y;
				half Angle44_g53462 = Motion_Z190_g53398;
				half3 VertexPos40_g53465 = ( VertexPosRotationAxis50_g53462 + ( VertexPosOtherAxis82_g53462 * cos( Angle44_g53462 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53462 ) * sin( Angle44_g53462 ) ) );
				float3 appendResult74_g53465 = (float3(0.0 , 0.0 , VertexPos40_g53465.z));
				half3 VertexPosRotationAxis50_g53465 = appendResult74_g53465;
				float3 break84_g53465 = VertexPos40_g53465;
				float3 appendResult81_g53465 = (float3(break84_g53465.x , break84_g53465.y , 0.0));
				half3 VertexPosOtherAxis82_g53465 = appendResult81_g53465;
				half Motion_X216_g53398 = break143_g53398.x;
				half Angle44_g53465 = -Motion_X216_g53398;
				float3 Vertex_Motion_Object833_g53398 = ( VertexPosRotationAxis50_g53465 + ( VertexPosOtherAxis82_g53465 * cos( Angle44_g53465 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53465 ) * sin( Angle44_g53465 ) ) );
				half Global_VertexTex_Size174_g53398 = break322_g53460.w;
				float lerpResult346_g53398 = lerp( 1.0 , Global_VertexTex_Size174_g53398 , _GlobalSize);
				float3 appendResult3480_g53398 = (float3(lerpResult346_g53398 , lerpResult346_g53398 , lerpResult346_g53398));
				half3 Vertex_Size1741_g53398 = appendResult3480_g53398;
				half3 _Vector5 = half3(1,1,1);
				float3 Vertex_SizeFade1740_g53398 = _Vector5;
				half IsInitialized3811_g53398 = _IsInitialized;
				float3 Final_VertexPosition890_g53398 = ( ( ( Vertex_Motion_Object833_g53398 * Vertex_Size1741_g53398 * Vertex_SizeFade1740_g53398 ) - VertexPosition3564_g53398 ) * IsInitialized3811_g53398 );
				
				o.ase_texcoord8.xyz = ase_worldPos;
				
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord8.w = 0;
				v.vertex.xyz += Final_VertexPosition890_g53398;

        		// Vertex shader outputs defined by graph
                float3 lwWNormal = TransformObjectToWorldNormal(v.normal );

                VertexPositionInputs vertexInput = GetVertexPositionInputs(v.vertex.xyz);
                
         		// We either sample GI from lightmap or SH.
        	    // Lightmap UV and vertex SH coefficients use the same interpolator ("float2 lightmapUV" for lightmap or "half3 vertexSH" for SH)
                // see DECLARE_LIGHTMAP_OR_SH macro.
        	    // The following funcions initialize the correct variable with correct data
        	    OUTPUT_LIGHTMAP_UV(v.texcoord1, unity_LightmapST, o.lightmapUVOrVertexSH.xy);
        	    OUTPUT_SH(lwWNormal, o.lightmapUVOrVertexSH.xyz);

        	    half3 vertexLight = VertexLighting(vertexInput.positionWS, lwWNormal);
        	    half fogFactor = ComputeFogFactor(vertexInput.positionCS.z);
        	    o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);
        	    o.clipPos = vertexInput.positionCS;

				//#if defined( REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR )
				//	o.shadowCoord = GetShadowCoord(vertexInput);
				//#endif
        		return o;
        	}

        	half4 frag (GraphVertexOutput IN, out float outDepth : SV_Depth ) : SV_Target
            {
            	UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);
				
				SurfaceOutput o = (SurfaceOutput)0;
				float4 clipPos = 0;
				float3 worldPos = 0;

				float4 output0 = 0;
				float4 output1 = 0;
				OctaImpostorFragment( o, clipPos, worldPos, IN.UVsFrame199, IN.UVsFrame299, IN.UVsFrame399, IN.octaframe99, IN.viewPos99, output0, output1 );
				half3 Main_Albedo_Raw4295_g53398 = o.Albedo;
				float dotResult4302_g53398 = dot( float3(0.2126,0.7152,0.0722) , Main_Albedo_Raw4295_g53398 );
				float3 temp_cast_0 = (dotResult4302_g53398).xxx;
				float4 break3589_g53398 = output0;
				half Main_Mask_Leaves3712_g53398 = ceil( break3589_g53398.g );
				float lerpResult4305_g53398 = lerp( _ImpostorBarkSaturationValue , _ImpostorLeafSaturationValue , Main_Mask_Leaves3712_g53398);
				float3 lerpResult4303_g53398 = lerp( temp_cast_0 , Main_Albedo_Raw4295_g53398 , lerpResult4305_g53398);
				float4 lerpResult4310_g53398 = lerp( _ImpostorBarkColor , _ImpostorLeafColor , Main_Mask_Leaves3712_g53398);
				float dotResult4323_g53398 = dot( float3(0.2126,0.7152,0.0722) , Main_Albedo_Raw4295_g53398 );
				float3 temp_cast_2 = (dotResult4323_g53398).xxx;
				float3 lerpResult4317_g53398 = lerp( temp_cast_2 , Main_Albedo_Raw4295_g53398 , _ImpostorGrassSaturationValue);
				#ifdef TVE_IS_GRASS_SHADER
				float3 staticSwitch4322_g53398 = ( lerpResult4317_g53398 * (_ImpostorGrassColor).rgb );
				#else
				float3 staticSwitch4322_g53398 = ( lerpResult4303_g53398 * (lerpResult4310_g53398).rgb );
				#endif
				half3 Main_Albedo3817_g53398 = staticSwitch4322_g53398;
				half3 Blend_Albedo4137_g53398 = Main_Albedo3817_g53398;
				float3 temp_cast_3 = (_NoiseScaleValue).xxx;
				float3 temp_output_3563_0_g53398 = worldPos;
				float3 World_Pos4027_g53398 = temp_output_3563_0_g53398;
				float temp_output_7_0_g53452 = _NoiseMinValue;
				half Noise_Mask4030_g53398 = saturate( ( ( tex3D( TVE_WorldTex3D, ( temp_cast_3 * World_Pos4027_g53398 * 0.1 ) ).r - temp_output_7_0_g53452 ) / ( _NoiseMaxValue - temp_output_7_0_g53452 ) ) );
				float4 lerpResult4044_g53398 = lerp( _NoiseColorTwo , _NoiseColorOne , Noise_Mask4030_g53398);
				half3 Noise_Tint4031_g53398 = (lerpResult4044_g53398).rgb;
				float3 _Vector10 = float3(1,1,1);
				float4x4 break19_g53480 = GetObjectToWorldMatrix();
				float3 appendResult20_g53480 = (float3(break19_g53480[ 0 ][ 3 ] , break19_g53480[ 1 ][ 3 ] , break19_g53480[ 2 ][ 3 ]));
				half3 ObjectData20_g53481 = appendResult20_g53480;
				float3 ase_worldPos = IN.ase_texcoord8.xyz;
				half3 WorldData19_g53481 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53481 = WorldData19_g53481;
				#else
				float3 staticSwitch14_g53481 = ObjectData20_g53481;
				#endif
				float3 temp_output_114_0_g53480 = staticSwitch14_g53481;
				float3 ObjectPosition4422_g53398 = temp_output_114_0_g53480;
				float2 panner73_g53468 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4422_g53398).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53468 = tex2D( TVE_NoiseTex, panner73_g53468 );
				float3 Position83_g53471 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53471 = _LayerMotionValue;
				float4 lerpResult87_g53471 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53471).xz ) ),temp_output_84_0_g53471 ) , TVE_MotionUsage[(int)temp_output_84_0_g53471]);
				half4 Global_Motion_Params4344_g53398 = lerpResult87_g53471;
				float4 break322_g53478 = Global_Motion_Params4344_g53398;
				half Wind_Power369_g53478 = break322_g53478.z;
				half Wind_Power2223_g53398 = Wind_Power369_g53478;
				float temp_output_167_0_g53468 = Wind_Power2223_g53398;
				float lerpResult169_g53468 = lerp( 4.0 , 2.0 , temp_output_167_0_g53468);
				half Global_NoiseTex_H2869_g53398 = pow( abs( tex2DNode75_g53468.a ) , lerpResult169_g53468 );
				float lerpResult376_g53478 = lerp( 0.1 , 1.0 , Wind_Power369_g53478);
				half Wind_Power_103106_g53398 = lerpResult376_g53478;
				float3 worldToObj3565_g53398 = mul( GetWorldToObjectMatrix(), float4( temp_output_3563_0_g53398, 1 ) ).xyz;
				float3 VertexPosition3564_g53398 = worldToObj3565_g53398;
				float temp_output_3572_0_g53398 = saturate( VertexPosition3564_g53398.y );
				half Mesh_Height1524_g53398 = temp_output_3572_0_g53398;
				half Main_Mask_Variation_Or_Metallic3607_g53398 = break3589_g53398.r;
				half3 Highlight_Tint3904_g53398 = ( ( (_MotionHighlightColor).rgb * Global_NoiseTex_H2869_g53398 * Wind_Power_103106_g53398 * Mesh_Height1524_g53398 * Main_Mask_Variation_Or_Metallic3607_g53398 ) + float3( 1,1,1 ) );
				#ifdef TVE_IS_GRASS_SHADER
				float3 staticSwitch4284_g53398 = Highlight_Tint3904_g53398;
				#else
				float3 staticSwitch4284_g53398 = _Vector10;
				#endif
				half3 Blend_AlbedoTinted3958_g53398 = ( Blend_Albedo4137_g53398 * Noise_Tint4031_g53398 * staticSwitch4284_g53398 );
				float dotResult4002_g53398 = dot( Blend_AlbedoTinted3958_g53398 , float3(0.2126,0.7152,0.0722) );
				float3 temp_cast_7 = (dotResult4002_g53398).xxx;
				float3 Position58_g53463 = World_Pos4027_g53398;
				float temp_output_82_0_g53463 = _LayerColorsValue;
				float4 lerpResult88_g53463 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ColorsTex, samplerTVE_ColorsTex, ( (TVE_ColorsCoord).zw + ( (TVE_ColorsCoord).xy * (Position58_g53463).xz ) ),temp_output_82_0_g53463 ) , TVE_ColorsUsage[(int)temp_output_82_0_g53463]);
				half Global_ColorsTex_A1701_g53398 = (lerpResult88_g53463).a;
				half Global_Colors_Influence3998_g53398 = Global_ColorsTex_A1701_g53398;
				float3 lerpResult4004_g53398 = lerp( Blend_AlbedoTinted3958_g53398 , temp_cast_7 , Global_Colors_Influence3998_g53398);
				half3 Global_ColorsTex_RGB1700_g53398 = (lerpResult88_g53463).rgb;
				#ifdef UNITY_COLORSPACE_GAMMA
				float staticSwitch1_g53450 = 2.0;
				#else
				float staticSwitch1_g53450 = 4.594794;
				#endif
				half3 Global_Colors3856_g53398 = ( Global_ColorsTex_RGB1700_g53398 * staticSwitch1_g53450 );
				float lerpResult4092_g53398 = lerp( 1.0 , Main_Mask_Variation_Or_Metallic3607_g53398 , _ColorsVariationValue);
				half Global_Colors_Value3999_g53398 = ( _GlobalColors * lerpResult4092_g53398 );
				half Main_Mask_Subsurface_Or_Blend3609_g53398 = break3589_g53398.b;
				#ifdef TVE_IS_GRASS_SHADER
				float staticSwitch4275_g53398 = ( 1.0 - Main_Mask_Subsurface_Or_Blend3609_g53398 );
				#else
				float staticSwitch4275_g53398 = Main_Mask_Subsurface_Or_Blend3609_g53398;
				#endif
				float temp_output_7_0_g53455 = _ColorsMaskMinValue;
				half Global_Colors_Mask4022_g53398 = ( saturate( ( ( staticSwitch4275_g53398 - temp_output_7_0_g53455 ) / ( _ColorsMaskMaxValue - temp_output_7_0_g53455 ) ) ) * Main_Mask_Leaves3712_g53398 );
				float3 lerpResult4007_g53398 = lerp( Blend_AlbedoTinted3958_g53398 , ( lerpResult4004_g53398 * Global_Colors3856_g53398 ) , ( Global_Colors_Value3999_g53398 * Global_Colors_Mask4022_g53398 ));
				float3 lerpResult4086_g53398 = lerp( Blend_Albedo4137_g53398 , lerpResult4007_g53398 , Main_Mask_Leaves3712_g53398);
				half3 Blend_AlbedoColored3711_g53398 = lerpResult4086_g53398;
				float3 temp_output_3681_0_g53398 = (_SubsurfaceColor).rgb;
				float dotResult4019_g53398 = dot( temp_output_3681_0_g53398 , float3(0.2126,0.7152,0.0722) );
				float3 temp_cast_10 = (dotResult4019_g53398).xxx;
				float3 lerpResult4018_g53398 = lerp( temp_output_3681_0_g53398 , temp_cast_10 , Global_Colors_Influence3998_g53398);
				float3 lerpResult4017_g53398 = lerp( temp_output_3681_0_g53398 , ( lerpResult4018_g53398 * Global_Colors3856_g53398 ) , ( Global_Colors_Value3999_g53398 * Global_Colors_Mask4022_g53398 ));
				half3 Subsurface_Color3656_g53398 = lerpResult4017_g53398;
				half MainLight_Subsurface4111_g53398 = TVE_MainLightParams.a;
				half Subsurface_Intensity3684_g53398 = ( _SubsurfaceValue * MainLight_Subsurface4111_g53398 );
				float temp_output_7_0_g53467 = _SubsurfaceMaskMinValue;
				half Subsurface_Mask3666_g53398 = ( saturate( ( ( Main_Mask_Subsurface_Or_Blend3609_g53398 - temp_output_7_0_g53467 ) / ( _SubsurfaceMaskMaxValue - temp_output_7_0_g53467 ) ) ) * Main_Mask_Leaves3712_g53398 );
				half3 Subsurface_Transmission3659_g53398 = ( Subsurface_Color3656_g53398 * Subsurface_Intensity3684_g53398 * Subsurface_Mask3666_g53398 );
				half3 MainLight_Direction4110_g53398 = TVE_MainLightDirection;
				float3 normalizeResult3635_g53398 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
				float dotResult3631_g53398 = dot( -MainLight_Direction4110_g53398 , normalizeResult3635_g53398 );
				float saferPower3620_g53398 = max( (dotResult3631_g53398*0.5 + 0.5) , 0.0001 );
				#ifdef UNITY_PASS_FORWARDADD
				float staticSwitch3636_g53398 = 0.0;
				#else
				float staticSwitch3636_g53398 = ( pow( saferPower3620_g53398 , _MainLightAngleValue ) * _MainLightScatteringValue );
				#endif
				half Mask_Subsurface_View3614_g53398 = staticSwitch3636_g53398;
				half3 World_Normal3638_g53398 = o.Normal;
				float dotResult3625_g53398 = dot( MainLight_Direction4110_g53398 , World_Normal3638_g53398 );
				float lerpResult4385_g53398 = lerp( 1.0 , saturate( dotResult3625_g53398 ) , _MainLightNormalValue);
				#ifdef TVE_IS_GRASS_SHADER
				float staticSwitch4387_g53398 = 1.0;
				#else
				float staticSwitch4387_g53398 = lerpResult4385_g53398;
				#endif
				#ifdef UNITY_PASS_FORWARDADD
				float staticSwitch3618_g53398 = 0.0;
				#else
				float staticSwitch3618_g53398 = staticSwitch4387_g53398;
				#endif
				half Mask_Subsurface_Normal3637_g53398 = staticSwitch3618_g53398;
				half3 Subsurface_Scattering3702_g53398 = ( Subsurface_Transmission3659_g53398 * Blend_AlbedoColored3711_g53398 * Mask_Subsurface_View3614_g53398 * Mask_Subsurface_Normal3637_g53398 );
				half3 Albedo_Subsurface3874_g53398 = ( Blend_AlbedoColored3711_g53398 + Subsurface_Scattering3702_g53398 );
				half3 Global_OverlayColor1758_g53398 = (TVE_OverlayColor).rgb;
				half Main_AlbedoTex_G3807_g53398 = Main_Albedo_Raw4295_g53398.y;
				float3 Position82_g53466 = World_Pos4027_g53398;
				float temp_output_84_0_g53466 = _LayerExtrasValue;
				float4 lerpResult88_g53466 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53466).xz ) ),temp_output_84_0_g53466 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53466]);
				float4 break89_g53466 = lerpResult88_g53466;
				half Global_ExtrasTex_Overlay156_g53398 = break89_g53466.b;
				float temp_output_3774_0_g53398 = ( _GlobalOverlay * Global_ExtrasTex_Overlay156_g53398 );
				float lerpResult3746_g53398 = lerp( 1.0 , Main_Mask_Variation_Or_Metallic3607_g53398 , _OverlayVariationValue);
				half Overlay_Commons3739_g53398 = ( temp_output_3774_0_g53398 * lerpResult3746_g53398 );
				#ifdef TVE_IS_GRASS_SHADER
				float staticSwitch4267_g53398 = ( ( ( Main_Mask_Subsurface_Or_Blend3609_g53398 * 0.5 ) + Main_AlbedoTex_G3807_g53398 ) * Overlay_Commons3739_g53398 );
				#else
				float staticSwitch4267_g53398 = ( ( ( World_Normal3638_g53398.y * 0.5 ) + Main_AlbedoTex_G3807_g53398 ) * Overlay_Commons3739_g53398 );
				#endif
				float temp_output_7_0_g53457 = _OverlayMaskMinValue;
				half Overlay_Mask3762_g53398 = saturate( ( ( staticSwitch4267_g53398 - temp_output_7_0_g53457 ) / ( _OverlayMaskMaxValue - temp_output_7_0_g53457 ) ) );
				float3 lerpResult3875_g53398 = lerp( Albedo_Subsurface3874_g53398 , Global_OverlayColor1758_g53398 , Overlay_Mask3762_g53398);
				half3 Final_Albedo4100_g53398 = lerpResult3875_g53398;
				half IsInitialized3811_g53398 = _IsInitialized;
				float3 lerpResult3815_g53398 = lerp( float3( 1,0,0 ) , Final_Albedo4100_g53398 , IsInitialized3811_g53398);
				float3 localLODFadeCustom3987_g53398 = ( lerpResult3815_g53398 );
				{
				// TVE Temporary fix for Dither in URP
				#ifdef LOD_FADE_CROSSFADE
				LODDitheringTransition(IN.clipPos.xyz, unity_LODFade.x);
				#endif
				}
				#ifdef LOD_FADE_CROSSFADE
				float3 staticSwitch3989_g53398 = localLODFadeCustom3987_g53398;
				#else
				float3 staticSwitch3989_g53398 = lerpResult3815_g53398;
				#endif
				
				float4 temp_output_4421_0_g53398 = ( _EmissiveColor * _EmissiveIntensityParams.x );
				half Global_ExtrasTex_Emissive4408_g53398 = break89_g53466.r;
				float lerpResult4417_g53398 = lerp( 1.0 , Global_ExtrasTex_Emissive4408_g53398 , _GlobalEmissive);
				half3 Final_Emissive4365_g53398 = ( (( temp_output_4421_0_g53398 * output1 )).rgb * lerpResult4417_g53398 );
				
				float3 temp_cast_14 = (( 0.04 * _RenderSpecular )).xxx;
				
				half Main_Mask_Smoothness3820_g53398 = break3589_g53398.a;
				half Main_Smoothness3838_g53398 = ( Main_Mask_Smoothness3820_g53398 * _ImpostorSmoothnessValue );
				half Global_ExtrasTex_Wetness305_g53398 = break89_g53466.g;
				float lerpResult3892_g53398 = lerp( Main_Smoothness3838_g53398 , saturate( ( Main_Smoothness3838_g53398 + Global_ExtrasTex_Wetness305_g53398 ) ) , _GlobalWetness);
				half Final_Smoothness3898_g53398 = lerpResult3892_g53398;
				
				float temp_output_3577_0_g53398 = o.Alpha;
				float localCustomAlphaClipAlways4430_g53398 = ( temp_output_3577_0_g53398 );
				float lerpResult4049_g53398 = lerp( 0.9 , (Main_Mask_Variation_Or_Metallic3607_g53398*0.5 + 0.5) , _AlphaVariationValue);
				half Global_ExtrasTex_Alpha1033_g53398 = break89_g53466.a;
				float lerpResult4053_g53398 = lerp( 1.0 , ( ( lerpResult4049_g53398 - ( 1.0 - Global_ExtrasTex_Alpha1033_g53398 ) ) + 0.1 ) , _GlobalAlpha);
				float lerpResult4075_g53398 = lerp( 1.0 , saturate( lerpResult4053_g53398 ) , Main_Mask_Leaves3712_g53398);
				half Final_Alpha4102_g53398 = lerpResult4075_g53398;
				float Alpha4430_g53398 = Final_Alpha4102_g53398;
				{
				clip(Alpha4430_g53398 - 0.1);
				}
				
				
		        float3 Albedo = staticSwitch3989_g53398;
				float3 Normal = World_Normal3638_g53398;
				float3 Emission = Final_Emissive4365_g53398;
				float3 Specular = temp_cast_14;
				float Metallic = 0;
				float Smoothness = Final_Smoothness3898_g53398;
				float Occlusion = 1;
				float3 Transmission = Subsurface_Transmission3659_g53398;
				float3 Translucency = 1;
				float Alpha = localCustomAlphaClipAlways4430_g53398;
				float AlphaClipThreshold = 0;
				float4 bakedGI = float4(0,0,0,0);

				IN.clipPos.zw = clipPos.zw;

				float3 WorldSpaceViewDirection = SafeNormalize( _WorldSpaceCameraPos.xyz - worldPos );

        		InputData inputData;
        		inputData.positionWS = worldPos;

				inputData.normalWS = Normal;

				#if !SHADER_HINT_NICE_QUALITY
					// viewDirection should be normalized here, but we avoid doing it as it's close enough and we save some ALU.
					inputData.viewDirectionWS = WorldSpaceViewDirection;
				#else
					inputData.viewDirectionWS = normalize(WorldSpaceViewDirection);
				#endif

				float4 shadowCoord = 0;
				//#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
				//	shadowCoord = IN.shadowCoord;
				//#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
				#if defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					shadowCoord = TransformWorldToShadowCoord( worldPos );
				#endif

        	    inputData.shadowCoord = shadowCoord;

        	    inputData.fogCoord = IN.fogFactorAndVertexLight.x;
        	    inputData.vertexLighting = IN.fogFactorAndVertexLight.yzw;

				#if defined(CUSTOM_BAKED_GI)
					half4 decodeInstructions = half4( LIGHTMAP_HDR_MULTIPLIER, LIGHTMAP_HDR_EXPONENT, 0.0h, 0.0h );
					inputData.bakedGI = UnpackLightmapRGBM( bakedGI, decodeInstructions ) * EMISSIVE_RGBM_SCALE;
				#else
                    OUTPUT_SH(inputData.normalWS, IN.lightmapUVOrVertexSH.xyz);
					inputData.bakedGI = SAMPLE_GI(IN.lightmapUVOrVertexSH.xy, IN.lightmapUVOrVertexSH.xyz, inputData.normalWS);
				#endif

        		half4 color = UniversalFragmentPBR(
        			inputData, 
        			Albedo, 
        			Metallic, 
        			Specular, 
        			Smoothness, 
        			Occlusion, 
        			Emission, 
        			Alpha);

				// BOXOPHOBIC: Added Transmission and Translucency
				#ifdef _TRANSMISSION_ASE
				{
					float shadow = _subsurface_shadow;

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

				#ifdef TERRAIN_SPLAT_ADDPASS
					color.rgb = MixFogColor(color.rgb, half3( 0, 0, 0 ), IN.fogFactorAndVertexLight.x );
				#else
					color.rgb = MixFog(color.rgb, IN.fogFactorAndVertexLight.x);
				#endif

				#if _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#if ASE_LW_FINAL_COLOR_ALPHA_MULTIPLY
					color.rgb *= color.a;
				#endif
				outDepth = IN.clipPos.z;
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

            HLSLPROGRAM
            #define _TRANSMISSION_ASE 1
            #define ASE_SRP_VERSION 100202
            #ifdef UNITY_COLORSPACE_GAMMA//AI_SRP
            #define unity_ColorSpaceDielectricSpec half4(0.220916301, 0.220916301, 0.220916301, 1.0 - 0.220916301)//AI_SRP
            #else//AI_SRP
            #define unity_ColorSpaceDielectricSpec half4(0.04, 0.04, 0.04, 1.0 - 0.04) //AI_SRP
            #endif//AI_SRP

            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            
			#ifndef UNITY_PASS_SHADOWCASTER
			#define UNITY_PASS_SHADOWCASTER
			#endif

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma vertex ShadowPassVertex
            #pragma fragment ShadowPassFragment

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ai_ObjectToWorld GetObjectToWorldMatrix()
			#define ai_WorldToObject GetWorldToObjectMatrix()
			#define AI_INV_TWO_PI  INV_TWO_PI
			#define AI_PI          PI
			#define AI_INV_PI      INV_PI
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			#pragma shader_feature_local TVE_IS_VEGETATION_SHADER TVE_IS_GRASS_SHADER


            struct GraphVertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

        	struct VertexOutput
        	{
        	    float4 clipPos : SV_POSITION;
                float4 UVsFrame199 : TEXCOORD7;
                float4 UVsFrame299 : TEXCOORD8;
                float4 UVsFrame399 : TEXCOORD9;
                float4 octaframe99 : TEXCOORD10;
                float4 viewPos99 : TEXCOORD11;
                UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
        	};

            float3 _LightDirection;
			CBUFFER_START(UnityPerMaterial)
			half4 _SubsurfaceColor;
			half4 _MotionHighlightColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _NoiseColorOne;
			half4 _NoiseColorTwo;
			float4 _SubsurfaceDiffusion_Asset;
			float4 _ImpostorGrassColor;
			float4 _ImpostorLeafColor;
			float4 _ImpostorBarkColor;
			half4 _ColorsMaskRemap;
			half4 _EmissiveColor;
			float4 _AI_SizeOffset;
			half4 _OverlayMaskRemap;
			half4 _DetailBlendRemap;
			float4 _NoiseMaskRemap;
			float4 _EmissiveIntensityParams;
			float4 _GradientMaskRemap;
			half4 _SubsurfaceMaskRemap;
			float3 _AI_Offset;
			half _ImpostorGrassSaturationValue;
			half _LayerColorsValue;
			half _ImpostorLeafSaturationValue;
			half _ImpostorBarkSaturationValue;
			half _GlobalSize;
			half _NoiseScaleValue;
			half _NoiseMinValue;
			half _NoiseMaxValue;
			half _LayerReactValue;
			half _InteractionAmplitude;
			half _GlobalColors;
			half _IsTVEAIShader;
			half _ColorsMaskMinValue;
			half _GlobalWetness;
			half _ImpostorSmoothnessValue;
			float _RenderSpecular;
			half _GlobalEmissive;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightNormalValue;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _MotionScale_10;
			half _ColorsMaskMaxValue;
			half _ColorsVariationValue;
			half _MotionSpeed_10;
			float _AI_ShadowBias;
			half _MotionAmplitude_10;
			half _SizeFadeCat;
			half _LayersSpace;
			half _NoiseCat;
			float _MaterialType;
			half _MotionCat;
			half _EmissiveFlagMode;
			half _TranslucencyScatteringValue;
			half _SubsurfaceCat;
			half _DetailMode;
			half _GlobalCat;
			half _TranslucencyIntensityValue;
			half _DetailBlendMode;
			half _IsInitialized;
			half _SizeFadeMessage;
			half _TranslucencyShadowValue;
			half _TranslucencyAmbientValue;
			half _MotionSpace;
			half _TranslucencyHDMessage;
			half _LayerMotionValue;
			half _DetailCat;
			float _SubsurfaceDiffusion;
			float _AI_Clip;
			float _AI_ShadowView;
			half _AlphaVariationValue;
			float _AI_DepthSize;
			float _AI_TextureBias;
			float _AI_Parallax;
			float _AI_ImpostorSize;
			float _AI_FramesY;
			float _AI_FramesX;
			float _AI_Frames;
			half _ImpostorCat;
			half _subsurface_shadow;
			half _IsVegetationShader;
			half _TranslucencyDirectValue;
			float _IsVersion;
			half _EmissiveCat;
			half _PivotsMessage;
			half _TranslucencyNormalValue;
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
			CBUFFER_END
			sampler2D _Albedo;
			sampler2D _Normals;
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			sampler2D TVE_NoiseTex;
			half4 TVE_NoiseParams;
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			sampler2D _Mask;
			sampler2D _Emissive;
			SAMPLER(sampler_Mask);
			SAMPLER(sampler_Emissive);
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];

			
			float2 VectortoOctahedron( float3 N )
			{
				N /= dot( 1.0, abs( N ) );
				if( N.z <= 0 )
				{
				N.xy = ( 1 - abs( N.yx ) ) * ( N.xy >= 0 ? 1.0 : -1.0 );
				}
				return N.xy;
			}
			
			float3 OctahedronToVector( float2 Oct )
			{
				float3 N = float3( Oct, 1.0 - dot( 1.0, abs( Oct ) ) );
				if(N.z< 0 )
				{
				N.xy = ( 1 - abs( N.yx) ) * (N.xy >= 0 ? 1.0 : -1.0 );
				}
				return normalize( N);
			}
			
			inline void RayPlaneIntersectionUV( float3 normal, float3 rayPosition, float3 rayDirection, inout float2 uvs, inout float3 localNormal )
			{
				float lDotN = dot( rayDirection, normal ); 
				float p0l0DotN = dot( -rayPosition, normal );
				float t = p0l0DotN / lDotN;
				float3 p = rayDirection * t + rayPosition;
				float3 upVector = float3( 0, 1, 0 );
				float3 tangent = normalize( cross( upVector, normal ) + float3( -0.001, 0, 0 ) );
				float3 bitangent = cross( tangent, normal );
				float frameX = dot( p, tangent );
				float frameZ = dot( p, bitangent );
				uvs = -float2( frameX, frameZ );
				if( t <= 0.0 )
				uvs = 0;
				float3x3 worldToLocal = float3x3( tangent, bitangent, normal );
				localNormal = normalize( mul( worldToLocal, rayDirection ) );
			}
			
			inline void OctaImpostorVertex( inout float4 vertex, inout float3 normal, inout float4 uvsFrame1, inout float4 uvsFrame2, inout float4 uvsFrame3, inout float4 octaFrame, inout float4 viewPos )
			{
				float2 uvOffset = _AI_SizeOffset.zw;
				float parallax = -_AI_Parallax; 
				float UVscale = _AI_ImpostorSize;
				float framesXY = _AI_Frames;
				float prevFrame = framesXY - 1;
				float3 fractions = 1.0 / float3( framesXY, prevFrame, UVscale );
				float fractionsFrame = fractions.x;
				float fractionsPrevFrame = fractions.y;
				float fractionsUVscale = fractions.z;
				float3 worldOrigin = 0;
				float4 perspective = float4( 0, 0, 0, 1 );
				if( UNITY_MATRIX_P[ 3 ][ 3 ] == 1 ) 
				{
				perspective = float4( 0, 0, 5000, 0 );
				worldOrigin = ai_ObjectToWorld._m03_m13_m23;
				}
				float3 worldCameraPos = worldOrigin + mul( UNITY_MATRIX_I_V, perspective ).xyz;
				float3 objectCameraPosition = mul( ai_WorldToObject, float4( worldCameraPos, 1 ) ).xyz - _AI_Offset.xyz; 
				float3 objectCameraDirection = normalize( objectCameraPosition );
				float3 upVector = float3( 0,1,0 );
				float3 objectHorizontalVector = normalize( cross( objectCameraDirection, upVector ) );
				float3 objectVerticalVector = cross( objectHorizontalVector, objectCameraDirection );
				float2 uvExpansion = vertex.xy;
				float3 billboard = objectHorizontalVector * uvExpansion.x + objectVerticalVector * uvExpansion.y;
				float3 localDir = billboard - objectCameraPosition; 
				float2 frameOcta = VectortoOctahedron( objectCameraDirection.xzy ) * 0.5 + 0.5;
				float2 prevOctaFrame = frameOcta * prevFrame;
				float2 baseOctaFrame = floor( prevOctaFrame );
				float2 fractionOctaFrame = ( baseOctaFrame * fractionsFrame );
				float2 octaFrame1 = ( baseOctaFrame * fractionsPrevFrame ) * 2.0 - 1.0;
				float3 octa1WorldY = OctahedronToVector( octaFrame1 ).xzy;
				float3 octa1LocalY;
				float2 uvFrame1;
				RayPlaneIntersectionUV( octa1WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame1, /*inout*/ octa1LocalY );
				float2 uvParallax1 = octa1LocalY.xy * fractionsFrame * parallax;
				uvFrame1 = ( uvFrame1 * fractionsUVscale + 0.5 ) * fractionsFrame + fractionOctaFrame;
				uvsFrame1 = float4( uvParallax1, uvFrame1) - float4( 0, 0, uvOffset );
				float2 fractPrevOctaFrame = frac( prevOctaFrame );
				float2 cornerDifference = lerp( float2( 0,1 ) , float2( 1,0 ) , saturate( ceil( ( fractPrevOctaFrame.x - fractPrevOctaFrame.y ) ) ));
				float2 octaFrame2 = ( ( baseOctaFrame + cornerDifference ) * fractionsPrevFrame ) * 2.0 - 1.0;
				float3 octa2WorldY = OctahedronToVector( octaFrame2 ).xzy;
				float3 octa2LocalY;
				float2 uvFrame2;
				RayPlaneIntersectionUV( octa2WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame2, /*inout*/ octa2LocalY );
				float2 uvParallax2 = octa2LocalY.xy * fractionsFrame * parallax;
				uvFrame2 = ( uvFrame2 * fractionsUVscale + 0.5 ) * fractionsFrame + ( ( cornerDifference * fractionsFrame ) + fractionOctaFrame );
				uvsFrame2 = float4( uvParallax2, uvFrame2) - float4( 0, 0, uvOffset );
				float2 octaFrame3 = ( ( baseOctaFrame + 1 ) * fractionsPrevFrame  ) * 2.0 - 1.0;
				float3 octa3WorldY = OctahedronToVector( octaFrame3 ).xzy;
				float3 octa3LocalY;
				float2 uvFrame3;
				RayPlaneIntersectionUV( octa3WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame3, /*inout*/ octa3LocalY );
				float2 uvParallax3 = octa3LocalY.xy * fractionsFrame * parallax;
				uvFrame3 = ( uvFrame3 * fractionsUVscale + 0.5 ) * fractionsFrame + ( fractionOctaFrame + fractionsFrame );
				uvsFrame3 = float4( uvParallax3, uvFrame3) - float4( 0, 0, uvOffset );
				octaFrame = 0;
				octaFrame.xy = prevOctaFrame;
				octaFrame.zw = fractionOctaFrame;
				vertex.xyz = billboard + _AI_Offset.xyz;
				normal.xyz = objectCameraDirection;
				viewPos = 0;
				viewPos.xyz = TransformWorldToView( TransformObjectToWorld( vertex.xyz ) );
			}
			
			inline void OctaImpostorFragment( inout SurfaceOutput o, out float4 clipPos, out float3 worldPos, float4 uvsFrame1, float4 uvsFrame2, float4 uvsFrame3, float4 octaFrame, float4 interpViewPos, out float4 output0, out float4 output1 )
			{
				float depthBias = -1.0;
				float textureBias = _AI_TextureBias;
				float2 fraction = frac( octaFrame.xy );
				float2 invFraction = 1 - fraction;
				float3 weights;
				weights.x = min( invFraction.x, invFraction.y );
				weights.y = abs( fraction.x - fraction.y );
				weights.z = min( fraction.x, fraction.y );
				float4 parallaxSample1 = tex2Dbias( _Normals, float4(uvsFrame1.zw, 0, depthBias) );
				float2 parallax1 = ( ( 0.5 - parallaxSample1.a ) * uvsFrame1.xy ) + uvsFrame1.zw;
				float4 parallaxSample2 = tex2Dbias( _Normals, float4(uvsFrame2.zw, 0, depthBias) );
				float2 parallax2 = ( ( 0.5 - parallaxSample2.a ) * uvsFrame2.xy ) + uvsFrame2.zw;
				float4 parallaxSample3 = tex2Dbias( _Normals, float4(uvsFrame3.zw, 0, depthBias) );
				float2 parallax3 = ( ( 0.5 - parallaxSample3.a ) * uvsFrame3.xy ) + uvsFrame3.zw;
				float4 albedo1 = tex2Dbias( _Albedo, float4(parallax1, 0, textureBias) );
				float4 albedo2 = tex2Dbias( _Albedo, float4(parallax2, 0, textureBias) );
				float4 albedo3 = tex2Dbias( _Albedo, float4(parallax3, 0, textureBias) );
				float4 blendedAlbedo = albedo1 * weights.x + albedo2 * weights.y + albedo3 * weights.z;
				o.Alpha = ( blendedAlbedo.a - _AI_Clip );
				clip( o.Alpha );
				float t = ceil( fraction.x - fraction.y );
				float4 cornerDifference = float4( t, 1 - t, 1, 1 );
				float2 step_1 = ( parallax1 - octaFrame.zw ) * _AI_Frames;
				float4 step23 = ( float4( parallax2, parallax3 ) -  octaFrame.zwzw ) * _AI_Frames - cornerDifference;
				step_1 = step_1 * (1-step_1);
				step23 = step23 * (1-step23);
				float3 steps;
				steps.x = step_1.x * step_1.y;
				steps.y = step23.x * step23.y;
				steps.z = step23.z * step23.w;
				steps = step(-steps, 0);
				float final = dot( steps, weights );
				clip( final - 0.5 );
				o.Albedo = blendedAlbedo.rgb;
				#if defined(AI_HD_RENDERPIPELINE) && ( AI_HDRP_VERSION >= 50702 )
				float4 feat1 = _Features.SampleLevel( SamplerState_Point_Repeat, parallax1, 0);
				o.Diffusion = feat1.rgb;
				o.Features = feat1.a;
				float4 test1 = _Specular.SampleLevel( SamplerState_Point_Repeat, parallax1, 0);
				o.MetalTangent = test1.b;
				#endif
				float4 normals1 = tex2Dbias( _Normals, float4(parallax1, 0, textureBias) );
				float4 normals2 = tex2Dbias( _Normals, float4(parallax2, 0, textureBias) );
				float4 normals3 = tex2Dbias( _Normals, float4(parallax3, 0, textureBias) );
				float4 blendedNormal = normals1 * weights.x  + normals2 * weights.y + normals3 * weights.z;
				float4 output0a = tex2Dbias( _Mask, float4(parallax1, 0, textureBias) );
				float4 output0b = tex2Dbias( _Mask, float4(parallax2, 0, textureBias) );
				float4 output0c = tex2Dbias( _Mask, float4(parallax3, 0, textureBias) );
				output0 = output0a * weights.x  + output0b * weights.y + output0c * weights.z; 
				float4 output1a = tex2Dbias( _Emissive, float4(parallax1, 0, textureBias) );
				float4 output1b = tex2Dbias( _Emissive, float4(parallax2, 0, textureBias) );
				float4 output1c = tex2Dbias( _Emissive, float4(parallax3, 0, textureBias) );
				output1 = output1a * weights.x  + output1b * weights.y + output1c * weights.z; 
				float3 localNormal = blendedNormal.rgb * 2.0 - 1.0;
				float3 worldNormal = normalize( mul( (float3x3)ai_ObjectToWorld, localNormal ) );
				o.Normal = worldNormal;
				float3 viewPos = interpViewPos.xyz;
				#if defined(UNITY_PASS_SHADOWCASTER) // Standard RP fix for deferred path
				float depthOffset = ( ( parallaxSample1.a * weights.x + parallaxSample2.a * weights.y + parallaxSample3.a * weights.z ) - 0.5001 /** 2.0 - 1.0*/ ) /** 0.5*/ * _AI_DepthSize * length( ai_ObjectToWorld[ 2 ].xyz );
				#else
				float depthOffset = ( ( parallaxSample1.a * weights.x + parallaxSample2.a * weights.y + parallaxSample3.a * weights.z ) - 0.5 /** 2.0 - 1.0*/ ) /** 0.5*/ * _AI_DepthSize * length( ai_ObjectToWorld[ 2 ].xyz );
				#endif
				#if ( defined(SHADERPASS) && (SHADERPASS == SHADERPASS_SHADOWS) ) || defined(UNITY_PASS_SHADOWCASTER)
				viewPos.z += depthOffset * _AI_ShadowView;
				viewPos.z += -_AI_ShadowBias;
				#else 
				viewPos.z += depthOffset;
				#endif
				worldPos = mul( UNITY_MATRIX_I_V, float4( viewPos.xyz, 1 ) ).xyz;
				clipPos = mul( UNITY_MATRIX_P, float4( viewPos, 1 ) );
				#if defined(UNITY_PASS_SHADOWCASTER) && !defined(SHADERPASS)
				#if UNITY_REVERSED_Z
				clipPos.z = min( clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE );
				#else
				clipPos.z = max( clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE );
				#endif
				#endif
				clipPos.xyz /= clipPos.w;
				if( UNITY_NEAR_CLIP_VALUE < 0 )
				clipPos = clipPos * 0.5 + 0.5;
			}
			

            VertexOutput ShadowPassVertex(GraphVertexInput v)
        	{
        	    VertexOutput o;
        	    UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				OctaImpostorVertex( v.vertex, v.normal, o.UVsFrame199, o.UVsFrame299, o.UVsFrame399, o.octaframe99, o.viewPos99 );
				float3 worldPosOut99 = mul( UNITY_MATRIX_I_V, float4( o.viewPos99.xyz, 1.0 ) ).xyz;
				float3 temp_output_3563_0_g53398 = worldPosOut99;
				float3 worldToObj3565_g53398 = mul( GetWorldToObjectMatrix(), float4( temp_output_3563_0_g53398, 1 ) ).xyz;
				float3 VertexPosition3564_g53398 = worldToObj3565_g53398;
				half3 VertexPos40_g53462 = VertexPosition3564_g53398;
				float3 appendResult74_g53462 = (float3(VertexPos40_g53462.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53462 = appendResult74_g53462;
				float3 break84_g53462 = VertexPos40_g53462;
				float3 appendResult81_g53462 = (float3(0.0 , break84_g53462.y , break84_g53462.z));
				half3 VertexPosOtherAxis82_g53462 = appendResult81_g53462;
				float Motion_Max_Bending1133_g53398 = 3.14;
				float4x4 break19_g53480 = GetObjectToWorldMatrix();
				float3 appendResult20_g53480 = (float3(break19_g53480[ 0 ][ 3 ] , break19_g53480[ 1 ][ 3 ] , break19_g53480[ 2 ][ 3 ]));
				half3 ObjectData20_g53481 = appendResult20_g53480;
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53481 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53481 = WorldData19_g53481;
				#else
				float3 staticSwitch14_g53481 = ObjectData20_g53481;
				#endif
				float3 temp_output_114_0_g53480 = staticSwitch14_g53481;
				float3 ObjectPosition4422_g53398 = temp_output_114_0_g53480;
				float3 Position83_g53471 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53471 = _LayerMotionValue;
				float4 lerpResult87_g53471 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53471).xz ) ),temp_output_84_0_g53471, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53471]);
				half4 Global_Motion_Params4344_g53398 = lerpResult87_g53471;
				float4 break322_g53478 = Global_Motion_Params4344_g53398;
				half Wind_Power369_g53478 = break322_g53478.z;
				float lerpResult376_g53478 = lerp( 0.1 , 1.0 , Wind_Power369_g53478);
				half Wind_Power_103106_g53398 = lerpResult376_g53478;
				float3 appendResult397_g53478 = (float3(break322_g53478.x , 0.0 , break322_g53478.y));
				float3 temp_output_398_0_g53478 = (appendResult397_g53478*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53478 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53478 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53398 = (temp_output_339_0_g53478).xz;
				float2 panner73_g53468 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4422_g53398).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53468 = tex2Dlod( TVE_NoiseTex, float4( panner73_g53468, 0, 0.0) );
				float4 saferPower77_g53468 = max( abs( tex2DNode75_g53468 ) , 0.0001 );
				half Wind_Power2223_g53398 = Wind_Power369_g53478;
				float temp_output_167_0_g53468 = Wind_Power2223_g53398;
				float lerpResult168_g53468 = lerp( 1.5 , 0.25 , temp_output_167_0_g53468);
				float4 temp_cast_5 = (lerpResult168_g53468).xxxx;
				float4 break142_g53468 = pow( saferPower77_g53468 , temp_cast_5 );
				half Global_NoiseTex_R34_g53398 = break142_g53468.r;
				half Input_Speed62_g53399 = _MotionSpeed_10;
				float mulTime373_g53399 = _TimeParameters.x * Input_Speed62_g53399;
				half Motion_Variation284_g53399 = 0.0;
				float2 appendResult344_g53399 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53399 = ( _MotionScale_10 * appendResult344_g53399 );
				half2 Sine_MinusOneToOne281_g53399 = sin( ( mulTime373_g53399 + Motion_Variation284_g53399 + Motion_Scale287_g53399 ) );
				float2 temp_cast_6 = (1.0).xx;
				half Input_Turbulence327_g53399 = Global_NoiseTex_R34_g53398;
				float2 lerpResult321_g53399 = lerp( Sine_MinusOneToOne281_g53399 , temp_cast_6 , Input_Turbulence327_g53399);
				half2 Motion_Bending2258_g53398 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53398 ) * Wind_Power_103106_g53398 * Wind_DirectionOS39_g53398 * Global_NoiseTex_R34_g53398 * lerpResult321_g53399 );
				half Interaction_Amplitude4351_g53398 = _InteractionAmplitude;
				float3 Position83_g53477 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53477 = _LayerReactValue;
				float4 lerpResult87_g53477 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53477).xz ) ),temp_output_84_0_g53477, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53477]);
				half4 Global_React_Params4413_g53398 = lerpResult87_g53477;
				float4 break322_g53460 = Global_React_Params4413_g53398;
				half Interaction_Mask66_g53398 = break322_g53460.z;
				float3 appendResult397_g53460 = (float3(break322_g53460.x , 0.0 , break322_g53460.y));
				float3 temp_output_398_0_g53460 = (appendResult397_g53460*2.0 + -1.0);
				float3 temp_output_339_0_g53460 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53460 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4349_g53398 = (temp_output_339_0_g53460).xz;
				half2 Motion_Interaction53_g53398 = ( Interaction_Amplitude4351_g53398 * Motion_Max_Bending1133_g53398 * Interaction_Mask66_g53398 * Interaction_Mask66_g53398 * Interaction_DirectionOS4349_g53398 );
				float2 lerpResult109_g53398 = lerp( Motion_Bending2258_g53398 , Motion_Interaction53_g53398 , ( Interaction_Mask66_g53398 * saturate( Interaction_Amplitude4351_g53398 ) ));
				float temp_output_3572_0_g53398 = saturate( VertexPosition3564_g53398.y );
				half Mesh_Motion_182_g53398 = temp_output_3572_0_g53398;
				float2 break143_g53398 = ( lerpResult109_g53398 * Mesh_Motion_182_g53398 );
				half Motion_Z190_g53398 = break143_g53398.y;
				half Angle44_g53462 = Motion_Z190_g53398;
				half3 VertexPos40_g53465 = ( VertexPosRotationAxis50_g53462 + ( VertexPosOtherAxis82_g53462 * cos( Angle44_g53462 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53462 ) * sin( Angle44_g53462 ) ) );
				float3 appendResult74_g53465 = (float3(0.0 , 0.0 , VertexPos40_g53465.z));
				half3 VertexPosRotationAxis50_g53465 = appendResult74_g53465;
				float3 break84_g53465 = VertexPos40_g53465;
				float3 appendResult81_g53465 = (float3(break84_g53465.x , break84_g53465.y , 0.0));
				half3 VertexPosOtherAxis82_g53465 = appendResult81_g53465;
				half Motion_X216_g53398 = break143_g53398.x;
				half Angle44_g53465 = -Motion_X216_g53398;
				float3 Vertex_Motion_Object833_g53398 = ( VertexPosRotationAxis50_g53465 + ( VertexPosOtherAxis82_g53465 * cos( Angle44_g53465 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53465 ) * sin( Angle44_g53465 ) ) );
				half Global_VertexTex_Size174_g53398 = break322_g53460.w;
				float lerpResult346_g53398 = lerp( 1.0 , Global_VertexTex_Size174_g53398 , _GlobalSize);
				float3 appendResult3480_g53398 = (float3(lerpResult346_g53398 , lerpResult346_g53398 , lerpResult346_g53398));
				half3 Vertex_Size1741_g53398 = appendResult3480_g53398;
				half3 _Vector5 = half3(1,1,1);
				float3 Vertex_SizeFade1740_g53398 = _Vector5;
				half IsInitialized3811_g53398 = _IsInitialized;
				float3 Final_VertexPosition890_g53398 = ( ( ( Vertex_Motion_Object833_g53398 * Vertex_Size1741_g53398 * Vertex_SizeFade1740_g53398 ) - VertexPosition3564_g53398 ) * IsInitialized3811_g53398 );
				
				v.vertex.xyz += Final_VertexPosition890_g53398;

        	    float3 positionWS = TransformObjectToWorld(v.vertex.xyz);
                float3 normalWS = TransformObjectToWorldDir(v.normal );

                float invNdotL = 1.0 - saturate(dot(_LightDirection, normalWS));
                float scale = invNdotL * _ShadowBias.y;

                // normal bias is negative since we want to apply an inset normal offset
				positionWS = _LightDirection * _ShadowBias.xxx + positionWS;
				positionWS = normalWS * scale.xxx + positionWS;
				float4 clipPos = TransformWorldToHClip( positionWS );

				// no need for shadow bias alteration since we do it in fragment anyway
				o.clipPos = clipPos;

        	    return o;
        	}

            half4 ShadowPassFragment(VertexOutput IN, out float outDepth : SV_Depth ) : SV_TARGET
            {
                UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);

				SurfaceOutput o = (SurfaceOutput)0;
				float4 clipPos = 0;
				float3 worldPos = 0;
				float4 output0 = 0;
				float4 output1 = 0;
				OctaImpostorFragment( o, clipPos, worldPos, IN.UVsFrame199, IN.UVsFrame299, IN.UVsFrame399, IN.octaframe99, IN.viewPos99, output0, output1 );
				float temp_output_3577_0_g53398 = o.Alpha;
				float localCustomAlphaClipAlways4430_g53398 = ( temp_output_3577_0_g53398 );
				float4 break3589_g53398 = output0;
				half Main_Mask_Variation_Or_Metallic3607_g53398 = break3589_g53398.r;
				float lerpResult4049_g53398 = lerp( 0.9 , (Main_Mask_Variation_Or_Metallic3607_g53398*0.5 + 0.5) , _AlphaVariationValue);
				float3 temp_output_3563_0_g53398 = worldPos;
				float3 World_Pos4027_g53398 = temp_output_3563_0_g53398;
				float3 Position82_g53466 = World_Pos4027_g53398;
				float temp_output_84_0_g53466 = _LayerExtrasValue;
				float4 lerpResult88_g53466 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53466).xz ) ),temp_output_84_0_g53466 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53466]);
				float4 break89_g53466 = lerpResult88_g53466;
				half Global_ExtrasTex_Alpha1033_g53398 = break89_g53466.a;
				float lerpResult4053_g53398 = lerp( 1.0 , ( ( lerpResult4049_g53398 - ( 1.0 - Global_ExtrasTex_Alpha1033_g53398 ) ) + 0.1 ) , _GlobalAlpha);
				half Main_Mask_Leaves3712_g53398 = ceil( break3589_g53398.g );
				float lerpResult4075_g53398 = lerp( 1.0 , saturate( lerpResult4053_g53398 ) , Main_Mask_Leaves3712_g53398);
				half Final_Alpha4102_g53398 = lerpResult4075_g53398;
				float Alpha4430_g53398 = Final_Alpha4102_g53398;
				{
				clip(Alpha4430_g53398 - 0.1);
				}
				
				IN.clipPos.zw = clipPos.zw;

				float Alpha = localCustomAlphaClipAlways4430_g53398;
				float AlphaClipThreshold = AlphaClipThreshold;

				#if _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif
				outDepth = IN.clipPos.z;
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

            HLSLPROGRAM
            #define _TRANSMISSION_ASE 1
            #define ASE_SRP_VERSION 100202
            #ifdef UNITY_COLORSPACE_GAMMA//AI_SRP
            #define unity_ColorSpaceDielectricSpec half4(0.220916301, 0.220916301, 0.220916301, 1.0 - 0.220916301)//AI_SRP
            #else//AI_SRP
            #define unity_ColorSpaceDielectricSpec half4(0.04, 0.04, 0.04, 1.0 - 0.04) //AI_SRP
            #endif//AI_SRP

            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma vertex vert
            #pragma fragment frag			          

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
           
			#define ai_ObjectToWorld GetObjectToWorldMatrix()
			#define ai_WorldToObject GetWorldToObjectMatrix()
			#define AI_INV_TWO_PI  INV_TWO_PI
			#define AI_PI          PI
			#define AI_INV_PI      INV_PI
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			#pragma shader_feature_local TVE_IS_VEGETATION_SHADER TVE_IS_GRASS_SHADER


            struct GraphVertexInput
            {
                float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };


        	struct VertexOutput
        	{
        	    float4 clipPos      : SV_POSITION;
                float4 UVsFrame199 : TEXCOORD0;
                float4 UVsFrame299 : TEXCOORD1;
                float4 UVsFrame399 : TEXCOORD2;
                float4 octaframe99 : TEXCOORD3;
                float4 viewPos99 : TEXCOORD4;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
        	};

			CBUFFER_START(UnityPerMaterial)
			half4 _SubsurfaceColor;
			half4 _MotionHighlightColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _NoiseColorOne;
			half4 _NoiseColorTwo;
			float4 _SubsurfaceDiffusion_Asset;
			float4 _ImpostorGrassColor;
			float4 _ImpostorLeafColor;
			float4 _ImpostorBarkColor;
			half4 _ColorsMaskRemap;
			half4 _EmissiveColor;
			float4 _AI_SizeOffset;
			half4 _OverlayMaskRemap;
			half4 _DetailBlendRemap;
			float4 _NoiseMaskRemap;
			float4 _EmissiveIntensityParams;
			float4 _GradientMaskRemap;
			half4 _SubsurfaceMaskRemap;
			float3 _AI_Offset;
			half _ImpostorGrassSaturationValue;
			half _LayerColorsValue;
			half _ImpostorLeafSaturationValue;
			half _ImpostorBarkSaturationValue;
			half _GlobalSize;
			half _NoiseScaleValue;
			half _NoiseMinValue;
			half _NoiseMaxValue;
			half _LayerReactValue;
			half _InteractionAmplitude;
			half _GlobalColors;
			half _IsTVEAIShader;
			half _ColorsMaskMinValue;
			half _GlobalWetness;
			half _ImpostorSmoothnessValue;
			float _RenderSpecular;
			half _GlobalEmissive;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightNormalValue;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _MotionScale_10;
			half _ColorsMaskMaxValue;
			half _ColorsVariationValue;
			half _MotionSpeed_10;
			float _AI_ShadowBias;
			half _MotionAmplitude_10;
			half _SizeFadeCat;
			half _LayersSpace;
			half _NoiseCat;
			float _MaterialType;
			half _MotionCat;
			half _EmissiveFlagMode;
			half _TranslucencyScatteringValue;
			half _SubsurfaceCat;
			half _DetailMode;
			half _GlobalCat;
			half _TranslucencyIntensityValue;
			half _DetailBlendMode;
			half _IsInitialized;
			half _SizeFadeMessage;
			half _TranslucencyShadowValue;
			half _TranslucencyAmbientValue;
			half _MotionSpace;
			half _TranslucencyHDMessage;
			half _LayerMotionValue;
			half _DetailCat;
			float _SubsurfaceDiffusion;
			float _AI_Clip;
			float _AI_ShadowView;
			half _AlphaVariationValue;
			float _AI_DepthSize;
			float _AI_TextureBias;
			float _AI_Parallax;
			float _AI_ImpostorSize;
			float _AI_FramesY;
			float _AI_FramesX;
			float _AI_Frames;
			half _ImpostorCat;
			half _subsurface_shadow;
			half _IsVegetationShader;
			half _TranslucencyDirectValue;
			float _IsVersion;
			half _EmissiveCat;
			half _PivotsMessage;
			half _TranslucencyNormalValue;
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
			CBUFFER_END
			sampler2D _Albedo;
			sampler2D _Normals;
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			sampler2D TVE_NoiseTex;
			half4 TVE_NoiseParams;
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			sampler2D _Mask;
			sampler2D _Emissive;
			SAMPLER(sampler_Mask);
			SAMPLER(sampler_Emissive);
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];

			
			float2 VectortoOctahedron( float3 N )
			{
				N /= dot( 1.0, abs( N ) );
				if( N.z <= 0 )
				{
				N.xy = ( 1 - abs( N.yx ) ) * ( N.xy >= 0 ? 1.0 : -1.0 );
				}
				return N.xy;
			}
			
			float3 OctahedronToVector( float2 Oct )
			{
				float3 N = float3( Oct, 1.0 - dot( 1.0, abs( Oct ) ) );
				if(N.z< 0 )
				{
				N.xy = ( 1 - abs( N.yx) ) * (N.xy >= 0 ? 1.0 : -1.0 );
				}
				return normalize( N);
			}
			
			inline void RayPlaneIntersectionUV( float3 normal, float3 rayPosition, float3 rayDirection, inout float2 uvs, inout float3 localNormal )
			{
				float lDotN = dot( rayDirection, normal ); 
				float p0l0DotN = dot( -rayPosition, normal );
				float t = p0l0DotN / lDotN;
				float3 p = rayDirection * t + rayPosition;
				float3 upVector = float3( 0, 1, 0 );
				float3 tangent = normalize( cross( upVector, normal ) + float3( -0.001, 0, 0 ) );
				float3 bitangent = cross( tangent, normal );
				float frameX = dot( p, tangent );
				float frameZ = dot( p, bitangent );
				uvs = -float2( frameX, frameZ );
				if( t <= 0.0 )
				uvs = 0;
				float3x3 worldToLocal = float3x3( tangent, bitangent, normal );
				localNormal = normalize( mul( worldToLocal, rayDirection ) );
			}
			
			inline void OctaImpostorVertex( inout float4 vertex, inout float3 normal, inout float4 uvsFrame1, inout float4 uvsFrame2, inout float4 uvsFrame3, inout float4 octaFrame, inout float4 viewPos )
			{
				float2 uvOffset = _AI_SizeOffset.zw;
				float parallax = -_AI_Parallax; 
				float UVscale = _AI_ImpostorSize;
				float framesXY = _AI_Frames;
				float prevFrame = framesXY - 1;
				float3 fractions = 1.0 / float3( framesXY, prevFrame, UVscale );
				float fractionsFrame = fractions.x;
				float fractionsPrevFrame = fractions.y;
				float fractionsUVscale = fractions.z;
				float3 worldOrigin = 0;
				float4 perspective = float4( 0, 0, 0, 1 );
				if( UNITY_MATRIX_P[ 3 ][ 3 ] == 1 ) 
				{
				perspective = float4( 0, 0, 5000, 0 );
				worldOrigin = ai_ObjectToWorld._m03_m13_m23;
				}
				float3 worldCameraPos = worldOrigin + mul( UNITY_MATRIX_I_V, perspective ).xyz;
				float3 objectCameraPosition = mul( ai_WorldToObject, float4( worldCameraPos, 1 ) ).xyz - _AI_Offset.xyz; 
				float3 objectCameraDirection = normalize( objectCameraPosition );
				float3 upVector = float3( 0,1,0 );
				float3 objectHorizontalVector = normalize( cross( objectCameraDirection, upVector ) );
				float3 objectVerticalVector = cross( objectHorizontalVector, objectCameraDirection );
				float2 uvExpansion = vertex.xy;
				float3 billboard = objectHorizontalVector * uvExpansion.x + objectVerticalVector * uvExpansion.y;
				float3 localDir = billboard - objectCameraPosition; 
				float2 frameOcta = VectortoOctahedron( objectCameraDirection.xzy ) * 0.5 + 0.5;
				float2 prevOctaFrame = frameOcta * prevFrame;
				float2 baseOctaFrame = floor( prevOctaFrame );
				float2 fractionOctaFrame = ( baseOctaFrame * fractionsFrame );
				float2 octaFrame1 = ( baseOctaFrame * fractionsPrevFrame ) * 2.0 - 1.0;
				float3 octa1WorldY = OctahedronToVector( octaFrame1 ).xzy;
				float3 octa1LocalY;
				float2 uvFrame1;
				RayPlaneIntersectionUV( octa1WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame1, /*inout*/ octa1LocalY );
				float2 uvParallax1 = octa1LocalY.xy * fractionsFrame * parallax;
				uvFrame1 = ( uvFrame1 * fractionsUVscale + 0.5 ) * fractionsFrame + fractionOctaFrame;
				uvsFrame1 = float4( uvParallax1, uvFrame1) - float4( 0, 0, uvOffset );
				float2 fractPrevOctaFrame = frac( prevOctaFrame );
				float2 cornerDifference = lerp( float2( 0,1 ) , float2( 1,0 ) , saturate( ceil( ( fractPrevOctaFrame.x - fractPrevOctaFrame.y ) ) ));
				float2 octaFrame2 = ( ( baseOctaFrame + cornerDifference ) * fractionsPrevFrame ) * 2.0 - 1.0;
				float3 octa2WorldY = OctahedronToVector( octaFrame2 ).xzy;
				float3 octa2LocalY;
				float2 uvFrame2;
				RayPlaneIntersectionUV( octa2WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame2, /*inout*/ octa2LocalY );
				float2 uvParallax2 = octa2LocalY.xy * fractionsFrame * parallax;
				uvFrame2 = ( uvFrame2 * fractionsUVscale + 0.5 ) * fractionsFrame + ( ( cornerDifference * fractionsFrame ) + fractionOctaFrame );
				uvsFrame2 = float4( uvParallax2, uvFrame2) - float4( 0, 0, uvOffset );
				float2 octaFrame3 = ( ( baseOctaFrame + 1 ) * fractionsPrevFrame  ) * 2.0 - 1.0;
				float3 octa3WorldY = OctahedronToVector( octaFrame3 ).xzy;
				float3 octa3LocalY;
				float2 uvFrame3;
				RayPlaneIntersectionUV( octa3WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame3, /*inout*/ octa3LocalY );
				float2 uvParallax3 = octa3LocalY.xy * fractionsFrame * parallax;
				uvFrame3 = ( uvFrame3 * fractionsUVscale + 0.5 ) * fractionsFrame + ( fractionOctaFrame + fractionsFrame );
				uvsFrame3 = float4( uvParallax3, uvFrame3) - float4( 0, 0, uvOffset );
				octaFrame = 0;
				octaFrame.xy = prevOctaFrame;
				octaFrame.zw = fractionOctaFrame;
				vertex.xyz = billboard + _AI_Offset.xyz;
				normal.xyz = objectCameraDirection;
				viewPos = 0;
				viewPos.xyz = TransformWorldToView( TransformObjectToWorld( vertex.xyz ) );
			}
			
			inline void OctaImpostorFragment( inout SurfaceOutput o, out float4 clipPos, out float3 worldPos, float4 uvsFrame1, float4 uvsFrame2, float4 uvsFrame3, float4 octaFrame, float4 interpViewPos, out float4 output0, out float4 output1 )
			{
				float depthBias = -1.0;
				float textureBias = _AI_TextureBias;
				float2 fraction = frac( octaFrame.xy );
				float2 invFraction = 1 - fraction;
				float3 weights;
				weights.x = min( invFraction.x, invFraction.y );
				weights.y = abs( fraction.x - fraction.y );
				weights.z = min( fraction.x, fraction.y );
				float4 parallaxSample1 = tex2Dbias( _Normals, float4(uvsFrame1.zw, 0, depthBias) );
				float2 parallax1 = ( ( 0.5 - parallaxSample1.a ) * uvsFrame1.xy ) + uvsFrame1.zw;
				float4 parallaxSample2 = tex2Dbias( _Normals, float4(uvsFrame2.zw, 0, depthBias) );
				float2 parallax2 = ( ( 0.5 - parallaxSample2.a ) * uvsFrame2.xy ) + uvsFrame2.zw;
				float4 parallaxSample3 = tex2Dbias( _Normals, float4(uvsFrame3.zw, 0, depthBias) );
				float2 parallax3 = ( ( 0.5 - parallaxSample3.a ) * uvsFrame3.xy ) + uvsFrame3.zw;
				float4 albedo1 = tex2Dbias( _Albedo, float4(parallax1, 0, textureBias) );
				float4 albedo2 = tex2Dbias( _Albedo, float4(parallax2, 0, textureBias) );
				float4 albedo3 = tex2Dbias( _Albedo, float4(parallax3, 0, textureBias) );
				float4 blendedAlbedo = albedo1 * weights.x + albedo2 * weights.y + albedo3 * weights.z;
				o.Alpha = ( blendedAlbedo.a - _AI_Clip );
				clip( o.Alpha );
				float t = ceil( fraction.x - fraction.y );
				float4 cornerDifference = float4( t, 1 - t, 1, 1 );
				float2 step_1 = ( parallax1 - octaFrame.zw ) * _AI_Frames;
				float4 step23 = ( float4( parallax2, parallax3 ) -  octaFrame.zwzw ) * _AI_Frames - cornerDifference;
				step_1 = step_1 * (1-step_1);
				step23 = step23 * (1-step23);
				float3 steps;
				steps.x = step_1.x * step_1.y;
				steps.y = step23.x * step23.y;
				steps.z = step23.z * step23.w;
				steps = step(-steps, 0);
				float final = dot( steps, weights );
				clip( final - 0.5 );
				o.Albedo = blendedAlbedo.rgb;
				#if defined(AI_HD_RENDERPIPELINE) && ( AI_HDRP_VERSION >= 50702 )
				float4 feat1 = _Features.SampleLevel( SamplerState_Point_Repeat, parallax1, 0);
				o.Diffusion = feat1.rgb;
				o.Features = feat1.a;
				float4 test1 = _Specular.SampleLevel( SamplerState_Point_Repeat, parallax1, 0);
				o.MetalTangent = test1.b;
				#endif
				float4 normals1 = tex2Dbias( _Normals, float4(parallax1, 0, textureBias) );
				float4 normals2 = tex2Dbias( _Normals, float4(parallax2, 0, textureBias) );
				float4 normals3 = tex2Dbias( _Normals, float4(parallax3, 0, textureBias) );
				float4 blendedNormal = normals1 * weights.x  + normals2 * weights.y + normals3 * weights.z;
				float4 output0a = tex2Dbias( _Mask, float4(parallax1, 0, textureBias) );
				float4 output0b = tex2Dbias( _Mask, float4(parallax2, 0, textureBias) );
				float4 output0c = tex2Dbias( _Mask, float4(parallax3, 0, textureBias) );
				output0 = output0a * weights.x  + output0b * weights.y + output0c * weights.z; 
				float4 output1a = tex2Dbias( _Emissive, float4(parallax1, 0, textureBias) );
				float4 output1b = tex2Dbias( _Emissive, float4(parallax2, 0, textureBias) );
				float4 output1c = tex2Dbias( _Emissive, float4(parallax3, 0, textureBias) );
				output1 = output1a * weights.x  + output1b * weights.y + output1c * weights.z; 
				float3 localNormal = blendedNormal.rgb * 2.0 - 1.0;
				float3 worldNormal = normalize( mul( (float3x3)ai_ObjectToWorld, localNormal ) );
				o.Normal = worldNormal;
				float3 viewPos = interpViewPos.xyz;
				#if defined(UNITY_PASS_SHADOWCASTER) // Standard RP fix for deferred path
				float depthOffset = ( ( parallaxSample1.a * weights.x + parallaxSample2.a * weights.y + parallaxSample3.a * weights.z ) - 0.5001 /** 2.0 - 1.0*/ ) /** 0.5*/ * _AI_DepthSize * length( ai_ObjectToWorld[ 2 ].xyz );
				#else
				float depthOffset = ( ( parallaxSample1.a * weights.x + parallaxSample2.a * weights.y + parallaxSample3.a * weights.z ) - 0.5 /** 2.0 - 1.0*/ ) /** 0.5*/ * _AI_DepthSize * length( ai_ObjectToWorld[ 2 ].xyz );
				#endif
				#if ( defined(SHADERPASS) && (SHADERPASS == SHADERPASS_SHADOWS) ) || defined(UNITY_PASS_SHADOWCASTER)
				viewPos.z += depthOffset * _AI_ShadowView;
				viewPos.z += -_AI_ShadowBias;
				#else 
				viewPos.z += depthOffset;
				#endif
				worldPos = mul( UNITY_MATRIX_I_V, float4( viewPos.xyz, 1 ) ).xyz;
				clipPos = mul( UNITY_MATRIX_P, float4( viewPos, 1 ) );
				#if defined(UNITY_PASS_SHADOWCASTER) && !defined(SHADERPASS)
				#if UNITY_REVERSED_Z
				clipPos.z = min( clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE );
				#else
				clipPos.z = max( clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE );
				#endif
				#endif
				clipPos.xyz /= clipPos.w;
				if( UNITY_NEAR_CLIP_VALUE < 0 )
				clipPos = clipPos * 0.5 + 0.5;
			}
			

            VertexOutput vert(GraphVertexInput v)
            {
                VertexOutput o = (VertexOutput)0;
        	    UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				OctaImpostorVertex( v.vertex, v.normal, o.UVsFrame199, o.UVsFrame299, o.UVsFrame399, o.octaframe99, o.viewPos99 );
				float3 worldPosOut99 = mul( UNITY_MATRIX_I_V, float4( o.viewPos99.xyz, 1.0 ) ).xyz;
				float3 temp_output_3563_0_g53398 = worldPosOut99;
				float3 worldToObj3565_g53398 = mul( GetWorldToObjectMatrix(), float4( temp_output_3563_0_g53398, 1 ) ).xyz;
				float3 VertexPosition3564_g53398 = worldToObj3565_g53398;
				half3 VertexPos40_g53462 = VertexPosition3564_g53398;
				float3 appendResult74_g53462 = (float3(VertexPos40_g53462.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53462 = appendResult74_g53462;
				float3 break84_g53462 = VertexPos40_g53462;
				float3 appendResult81_g53462 = (float3(0.0 , break84_g53462.y , break84_g53462.z));
				half3 VertexPosOtherAxis82_g53462 = appendResult81_g53462;
				float Motion_Max_Bending1133_g53398 = 3.14;
				float4x4 break19_g53480 = GetObjectToWorldMatrix();
				float3 appendResult20_g53480 = (float3(break19_g53480[ 0 ][ 3 ] , break19_g53480[ 1 ][ 3 ] , break19_g53480[ 2 ][ 3 ]));
				half3 ObjectData20_g53481 = appendResult20_g53480;
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53481 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53481 = WorldData19_g53481;
				#else
				float3 staticSwitch14_g53481 = ObjectData20_g53481;
				#endif
				float3 temp_output_114_0_g53480 = staticSwitch14_g53481;
				float3 ObjectPosition4422_g53398 = temp_output_114_0_g53480;
				float3 Position83_g53471 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53471 = _LayerMotionValue;
				float4 lerpResult87_g53471 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53471).xz ) ),temp_output_84_0_g53471, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53471]);
				half4 Global_Motion_Params4344_g53398 = lerpResult87_g53471;
				float4 break322_g53478 = Global_Motion_Params4344_g53398;
				half Wind_Power369_g53478 = break322_g53478.z;
				float lerpResult376_g53478 = lerp( 0.1 , 1.0 , Wind_Power369_g53478);
				half Wind_Power_103106_g53398 = lerpResult376_g53478;
				float3 appendResult397_g53478 = (float3(break322_g53478.x , 0.0 , break322_g53478.y));
				float3 temp_output_398_0_g53478 = (appendResult397_g53478*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53478 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53478 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53398 = (temp_output_339_0_g53478).xz;
				float2 panner73_g53468 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4422_g53398).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53468 = tex2Dlod( TVE_NoiseTex, float4( panner73_g53468, 0, 0.0) );
				float4 saferPower77_g53468 = max( abs( tex2DNode75_g53468 ) , 0.0001 );
				half Wind_Power2223_g53398 = Wind_Power369_g53478;
				float temp_output_167_0_g53468 = Wind_Power2223_g53398;
				float lerpResult168_g53468 = lerp( 1.5 , 0.25 , temp_output_167_0_g53468);
				float4 temp_cast_5 = (lerpResult168_g53468).xxxx;
				float4 break142_g53468 = pow( saferPower77_g53468 , temp_cast_5 );
				half Global_NoiseTex_R34_g53398 = break142_g53468.r;
				half Input_Speed62_g53399 = _MotionSpeed_10;
				float mulTime373_g53399 = _TimeParameters.x * Input_Speed62_g53399;
				half Motion_Variation284_g53399 = 0.0;
				float2 appendResult344_g53399 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53399 = ( _MotionScale_10 * appendResult344_g53399 );
				half2 Sine_MinusOneToOne281_g53399 = sin( ( mulTime373_g53399 + Motion_Variation284_g53399 + Motion_Scale287_g53399 ) );
				float2 temp_cast_6 = (1.0).xx;
				half Input_Turbulence327_g53399 = Global_NoiseTex_R34_g53398;
				float2 lerpResult321_g53399 = lerp( Sine_MinusOneToOne281_g53399 , temp_cast_6 , Input_Turbulence327_g53399);
				half2 Motion_Bending2258_g53398 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53398 ) * Wind_Power_103106_g53398 * Wind_DirectionOS39_g53398 * Global_NoiseTex_R34_g53398 * lerpResult321_g53399 );
				half Interaction_Amplitude4351_g53398 = _InteractionAmplitude;
				float3 Position83_g53477 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53477 = _LayerReactValue;
				float4 lerpResult87_g53477 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53477).xz ) ),temp_output_84_0_g53477, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53477]);
				half4 Global_React_Params4413_g53398 = lerpResult87_g53477;
				float4 break322_g53460 = Global_React_Params4413_g53398;
				half Interaction_Mask66_g53398 = break322_g53460.z;
				float3 appendResult397_g53460 = (float3(break322_g53460.x , 0.0 , break322_g53460.y));
				float3 temp_output_398_0_g53460 = (appendResult397_g53460*2.0 + -1.0);
				float3 temp_output_339_0_g53460 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53460 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4349_g53398 = (temp_output_339_0_g53460).xz;
				half2 Motion_Interaction53_g53398 = ( Interaction_Amplitude4351_g53398 * Motion_Max_Bending1133_g53398 * Interaction_Mask66_g53398 * Interaction_Mask66_g53398 * Interaction_DirectionOS4349_g53398 );
				float2 lerpResult109_g53398 = lerp( Motion_Bending2258_g53398 , Motion_Interaction53_g53398 , ( Interaction_Mask66_g53398 * saturate( Interaction_Amplitude4351_g53398 ) ));
				float temp_output_3572_0_g53398 = saturate( VertexPosition3564_g53398.y );
				half Mesh_Motion_182_g53398 = temp_output_3572_0_g53398;
				float2 break143_g53398 = ( lerpResult109_g53398 * Mesh_Motion_182_g53398 );
				half Motion_Z190_g53398 = break143_g53398.y;
				half Angle44_g53462 = Motion_Z190_g53398;
				half3 VertexPos40_g53465 = ( VertexPosRotationAxis50_g53462 + ( VertexPosOtherAxis82_g53462 * cos( Angle44_g53462 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53462 ) * sin( Angle44_g53462 ) ) );
				float3 appendResult74_g53465 = (float3(0.0 , 0.0 , VertexPos40_g53465.z));
				half3 VertexPosRotationAxis50_g53465 = appendResult74_g53465;
				float3 break84_g53465 = VertexPos40_g53465;
				float3 appendResult81_g53465 = (float3(break84_g53465.x , break84_g53465.y , 0.0));
				half3 VertexPosOtherAxis82_g53465 = appendResult81_g53465;
				half Motion_X216_g53398 = break143_g53398.x;
				half Angle44_g53465 = -Motion_X216_g53398;
				float3 Vertex_Motion_Object833_g53398 = ( VertexPosRotationAxis50_g53465 + ( VertexPosOtherAxis82_g53465 * cos( Angle44_g53465 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53465 ) * sin( Angle44_g53465 ) ) );
				half Global_VertexTex_Size174_g53398 = break322_g53460.w;
				float lerpResult346_g53398 = lerp( 1.0 , Global_VertexTex_Size174_g53398 , _GlobalSize);
				float3 appendResult3480_g53398 = (float3(lerpResult346_g53398 , lerpResult346_g53398 , lerpResult346_g53398));
				half3 Vertex_Size1741_g53398 = appendResult3480_g53398;
				half3 _Vector5 = half3(1,1,1);
				float3 Vertex_SizeFade1740_g53398 = _Vector5;
				half IsInitialized3811_g53398 = _IsInitialized;
				float3 Final_VertexPosition890_g53398 = ( ( ( Vertex_Motion_Object833_g53398 * Vertex_Size1741_g53398 * Vertex_SizeFade1740_g53398 ) - VertexPosition3564_g53398 ) * IsInitialized3811_g53398 );
				
				float3 vertexValue = Final_VertexPosition890_g53398;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif

				v.normal =  v.normal ;

        	    o.clipPos = TransformObjectToHClip(v.vertex.xyz);
        	    return o;
            }

            half4 frag(VertexOutput IN, out float outDepth : SV_Depth ) : SV_TARGET
            {
                UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);

				SurfaceOutput o = (SurfaceOutput)0;
				float4 clipPos = 0;
				float3 worldPos = 0;
				float4 output0 = 0;
				float4 output1 = 0;
				OctaImpostorFragment( o, clipPos, worldPos, IN.UVsFrame199, IN.UVsFrame299, IN.UVsFrame399, IN.octaframe99, IN.viewPos99, output0, output1 );
				float temp_output_3577_0_g53398 = o.Alpha;
				float localCustomAlphaClipAlways4430_g53398 = ( temp_output_3577_0_g53398 );
				float4 break3589_g53398 = output0;
				half Main_Mask_Variation_Or_Metallic3607_g53398 = break3589_g53398.r;
				float lerpResult4049_g53398 = lerp( 0.9 , (Main_Mask_Variation_Or_Metallic3607_g53398*0.5 + 0.5) , _AlphaVariationValue);
				float3 temp_output_3563_0_g53398 = worldPos;
				float3 World_Pos4027_g53398 = temp_output_3563_0_g53398;
				float3 Position82_g53466 = World_Pos4027_g53398;
				float temp_output_84_0_g53466 = _LayerExtrasValue;
				float4 lerpResult88_g53466 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53466).xz ) ),temp_output_84_0_g53466 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53466]);
				float4 break89_g53466 = lerpResult88_g53466;
				half Global_ExtrasTex_Alpha1033_g53398 = break89_g53466.a;
				float lerpResult4053_g53398 = lerp( 1.0 , ( ( lerpResult4049_g53398 - ( 1.0 - Global_ExtrasTex_Alpha1033_g53398 ) ) + 0.1 ) , _GlobalAlpha);
				half Main_Mask_Leaves3712_g53398 = ceil( break3589_g53398.g );
				float lerpResult4075_g53398 = lerp( 1.0 , saturate( lerpResult4053_g53398 ) , Main_Mask_Leaves3712_g53398);
				half Final_Alpha4102_g53398 = lerpResult4075_g53398;
				float Alpha4430_g53398 = Final_Alpha4102_g53398;
				{
				clip(Alpha4430_g53398 - 0.1);
				}
				
				IN.clipPos.zw = clipPos.zw;
				float Alpha = localCustomAlphaClipAlways4430_g53398;
				float AlphaClipThreshold = AlphaClipThreshold;

				#if _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif
				outDepth = IN.clipPos.z;
                return 0;
            }
            ENDHLSL
        }

		
		Pass
		{
			
			Name "SceneSelectionPass"
			Tags { "LightMode"="SceneSelectionPass" }

			ZWrite On
			ColorMask 0

			HLSLPROGRAM
			#define _TRANSMISSION_ASE 1
			#define ASE_SRP_VERSION 100202
			#ifdef UNITY_COLORSPACE_GAMMA//AI_SRP
			#define unity_ColorSpaceDielectricSpec half4(0.220916301, 0.220916301, 0.220916301, 1.0 - 0.220916301)//AI_SRP
			#else//AI_SRP
			#define unity_ColorSpaceDielectricSpec half4(0.04, 0.04, 0.04, 1.0 - 0.04) //AI_SRP
			#endif//AI_SRP

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma multi_compile_instancing

			#pragma vertex vert
			#pragma fragment frag				

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"			

			int _ObjectId;
			int _PassValue;

			#define ai_ObjectToWorld GetObjectToWorldMatrix()
			#define ai_WorldToObject GetWorldToObjectMatrix()
			#define AI_INV_TWO_PI  INV_TWO_PI
			#define AI_PI          PI
			#define AI_INV_PI      INV_PI
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			#pragma shader_feature_local TVE_IS_VEGETATION_SHADER TVE_IS_GRASS_SHADER


			struct GraphVertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};


			struct VertexOutput
			{
				float4 clipPos      : SV_POSITION;
				float4 UVsFrame199 : TEXCOORD0;
				float4 UVsFrame299 : TEXCOORD1;
				float4 UVsFrame399 : TEXCOORD2;
				float4 octaframe99 : TEXCOORD3;
				float4 viewPos99 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			half4 _SubsurfaceColor;
			half4 _MotionHighlightColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _NoiseColorOne;
			half4 _NoiseColorTwo;
			float4 _SubsurfaceDiffusion_Asset;
			float4 _ImpostorGrassColor;
			float4 _ImpostorLeafColor;
			float4 _ImpostorBarkColor;
			half4 _ColorsMaskRemap;
			half4 _EmissiveColor;
			float4 _AI_SizeOffset;
			half4 _OverlayMaskRemap;
			half4 _DetailBlendRemap;
			float4 _NoiseMaskRemap;
			float4 _EmissiveIntensityParams;
			float4 _GradientMaskRemap;
			half4 _SubsurfaceMaskRemap;
			float3 _AI_Offset;
			half _ImpostorGrassSaturationValue;
			half _LayerColorsValue;
			half _ImpostorLeafSaturationValue;
			half _ImpostorBarkSaturationValue;
			half _GlobalSize;
			half _NoiseScaleValue;
			half _NoiseMinValue;
			half _NoiseMaxValue;
			half _LayerReactValue;
			half _InteractionAmplitude;
			half _GlobalColors;
			half _IsTVEAIShader;
			half _ColorsMaskMinValue;
			half _GlobalWetness;
			half _ImpostorSmoothnessValue;
			float _RenderSpecular;
			half _GlobalEmissive;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightNormalValue;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _MotionScale_10;
			half _ColorsMaskMaxValue;
			half _ColorsVariationValue;
			half _MotionSpeed_10;
			float _AI_ShadowBias;
			half _MotionAmplitude_10;
			half _SizeFadeCat;
			half _LayersSpace;
			half _NoiseCat;
			float _MaterialType;
			half _MotionCat;
			half _EmissiveFlagMode;
			half _TranslucencyScatteringValue;
			half _SubsurfaceCat;
			half _DetailMode;
			half _GlobalCat;
			half _TranslucencyIntensityValue;
			half _DetailBlendMode;
			half _IsInitialized;
			half _SizeFadeMessage;
			half _TranslucencyShadowValue;
			half _TranslucencyAmbientValue;
			half _MotionSpace;
			half _TranslucencyHDMessage;
			half _LayerMotionValue;
			half _DetailCat;
			float _SubsurfaceDiffusion;
			float _AI_Clip;
			float _AI_ShadowView;
			half _AlphaVariationValue;
			float _AI_DepthSize;
			float _AI_TextureBias;
			float _AI_Parallax;
			float _AI_ImpostorSize;
			float _AI_FramesY;
			float _AI_FramesX;
			float _AI_Frames;
			half _ImpostorCat;
			half _subsurface_shadow;
			half _IsVegetationShader;
			half _TranslucencyDirectValue;
			float _IsVersion;
			half _EmissiveCat;
			half _PivotsMessage;
			half _TranslucencyNormalValue;
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
			CBUFFER_END

			sampler2D _Albedo;
			sampler2D _Normals;
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			sampler2D TVE_NoiseTex;
			half4 TVE_NoiseParams;
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			sampler2D _Mask;
			sampler2D _Emissive;
			SAMPLER(sampler_Mask);
			SAMPLER(sampler_Emissive);
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];


			float2 VectortoOctahedron( float3 N )
			{
				N /= dot( 1.0, abs( N ) );
				if( N.z <= 0 )
				{
				N.xy = ( 1 - abs( N.yx ) ) * ( N.xy >= 0 ? 1.0 : -1.0 );
				}
				return N.xy;
			}
			
			float3 OctahedronToVector( float2 Oct )
			{
				float3 N = float3( Oct, 1.0 - dot( 1.0, abs( Oct ) ) );
				if(N.z< 0 )
				{
				N.xy = ( 1 - abs( N.yx) ) * (N.xy >= 0 ? 1.0 : -1.0 );
				}
				return normalize( N);
			}
			
			inline void RayPlaneIntersectionUV( float3 normal, float3 rayPosition, float3 rayDirection, inout float2 uvs, inout float3 localNormal )
			{
				float lDotN = dot( rayDirection, normal ); 
				float p0l0DotN = dot( -rayPosition, normal );
				float t = p0l0DotN / lDotN;
				float3 p = rayDirection * t + rayPosition;
				float3 upVector = float3( 0, 1, 0 );
				float3 tangent = normalize( cross( upVector, normal ) + float3( -0.001, 0, 0 ) );
				float3 bitangent = cross( tangent, normal );
				float frameX = dot( p, tangent );
				float frameZ = dot( p, bitangent );
				uvs = -float2( frameX, frameZ );
				if( t <= 0.0 )
				uvs = 0;
				float3x3 worldToLocal = float3x3( tangent, bitangent, normal );
				localNormal = normalize( mul( worldToLocal, rayDirection ) );
			}
			
			inline void OctaImpostorVertex( inout float4 vertex, inout float3 normal, inout float4 uvsFrame1, inout float4 uvsFrame2, inout float4 uvsFrame3, inout float4 octaFrame, inout float4 viewPos )
			{
				float2 uvOffset = _AI_SizeOffset.zw;
				float parallax = -_AI_Parallax; 
				float UVscale = _AI_ImpostorSize;
				float framesXY = _AI_Frames;
				float prevFrame = framesXY - 1;
				float3 fractions = 1.0 / float3( framesXY, prevFrame, UVscale );
				float fractionsFrame = fractions.x;
				float fractionsPrevFrame = fractions.y;
				float fractionsUVscale = fractions.z;
				float3 worldOrigin = 0;
				float4 perspective = float4( 0, 0, 0, 1 );
				if( UNITY_MATRIX_P[ 3 ][ 3 ] == 1 ) 
				{
				perspective = float4( 0, 0, 5000, 0 );
				worldOrigin = ai_ObjectToWorld._m03_m13_m23;
				}
				float3 worldCameraPos = worldOrigin + mul( UNITY_MATRIX_I_V, perspective ).xyz;
				float3 objectCameraPosition = mul( ai_WorldToObject, float4( worldCameraPos, 1 ) ).xyz - _AI_Offset.xyz; 
				float3 objectCameraDirection = normalize( objectCameraPosition );
				float3 upVector = float3( 0,1,0 );
				float3 objectHorizontalVector = normalize( cross( objectCameraDirection, upVector ) );
				float3 objectVerticalVector = cross( objectHorizontalVector, objectCameraDirection );
				float2 uvExpansion = vertex.xy;
				float3 billboard = objectHorizontalVector * uvExpansion.x + objectVerticalVector * uvExpansion.y;
				float3 localDir = billboard - objectCameraPosition; 
				float2 frameOcta = VectortoOctahedron( objectCameraDirection.xzy ) * 0.5 + 0.5;
				float2 prevOctaFrame = frameOcta * prevFrame;
				float2 baseOctaFrame = floor( prevOctaFrame );
				float2 fractionOctaFrame = ( baseOctaFrame * fractionsFrame );
				float2 octaFrame1 = ( baseOctaFrame * fractionsPrevFrame ) * 2.0 - 1.0;
				float3 octa1WorldY = OctahedronToVector( octaFrame1 ).xzy;
				float3 octa1LocalY;
				float2 uvFrame1;
				RayPlaneIntersectionUV( octa1WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame1, /*inout*/ octa1LocalY );
				float2 uvParallax1 = octa1LocalY.xy * fractionsFrame * parallax;
				uvFrame1 = ( uvFrame1 * fractionsUVscale + 0.5 ) * fractionsFrame + fractionOctaFrame;
				uvsFrame1 = float4( uvParallax1, uvFrame1) - float4( 0, 0, uvOffset );
				float2 fractPrevOctaFrame = frac( prevOctaFrame );
				float2 cornerDifference = lerp( float2( 0,1 ) , float2( 1,0 ) , saturate( ceil( ( fractPrevOctaFrame.x - fractPrevOctaFrame.y ) ) ));
				float2 octaFrame2 = ( ( baseOctaFrame + cornerDifference ) * fractionsPrevFrame ) * 2.0 - 1.0;
				float3 octa2WorldY = OctahedronToVector( octaFrame2 ).xzy;
				float3 octa2LocalY;
				float2 uvFrame2;
				RayPlaneIntersectionUV( octa2WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame2, /*inout*/ octa2LocalY );
				float2 uvParallax2 = octa2LocalY.xy * fractionsFrame * parallax;
				uvFrame2 = ( uvFrame2 * fractionsUVscale + 0.5 ) * fractionsFrame + ( ( cornerDifference * fractionsFrame ) + fractionOctaFrame );
				uvsFrame2 = float4( uvParallax2, uvFrame2) - float4( 0, 0, uvOffset );
				float2 octaFrame3 = ( ( baseOctaFrame + 1 ) * fractionsPrevFrame  ) * 2.0 - 1.0;
				float3 octa3WorldY = OctahedronToVector( octaFrame3 ).xzy;
				float3 octa3LocalY;
				float2 uvFrame3;
				RayPlaneIntersectionUV( octa3WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame3, /*inout*/ octa3LocalY );
				float2 uvParallax3 = octa3LocalY.xy * fractionsFrame * parallax;
				uvFrame3 = ( uvFrame3 * fractionsUVscale + 0.5 ) * fractionsFrame + ( fractionOctaFrame + fractionsFrame );
				uvsFrame3 = float4( uvParallax3, uvFrame3) - float4( 0, 0, uvOffset );
				octaFrame = 0;
				octaFrame.xy = prevOctaFrame;
				octaFrame.zw = fractionOctaFrame;
				vertex.xyz = billboard + _AI_Offset.xyz;
				normal.xyz = objectCameraDirection;
				viewPos = 0;
				viewPos.xyz = TransformWorldToView( TransformObjectToWorld( vertex.xyz ) );
			}
			
			inline void OctaImpostorFragment( inout SurfaceOutput o, out float4 clipPos, out float3 worldPos, float4 uvsFrame1, float4 uvsFrame2, float4 uvsFrame3, float4 octaFrame, float4 interpViewPos, out float4 output0, out float4 output1 )
			{
				float depthBias = -1.0;
				float textureBias = _AI_TextureBias;
				float2 fraction = frac( octaFrame.xy );
				float2 invFraction = 1 - fraction;
				float3 weights;
				weights.x = min( invFraction.x, invFraction.y );
				weights.y = abs( fraction.x - fraction.y );
				weights.z = min( fraction.x, fraction.y );
				float4 parallaxSample1 = tex2Dbias( _Normals, float4(uvsFrame1.zw, 0, depthBias) );
				float2 parallax1 = ( ( 0.5 - parallaxSample1.a ) * uvsFrame1.xy ) + uvsFrame1.zw;
				float4 parallaxSample2 = tex2Dbias( _Normals, float4(uvsFrame2.zw, 0, depthBias) );
				float2 parallax2 = ( ( 0.5 - parallaxSample2.a ) * uvsFrame2.xy ) + uvsFrame2.zw;
				float4 parallaxSample3 = tex2Dbias( _Normals, float4(uvsFrame3.zw, 0, depthBias) );
				float2 parallax3 = ( ( 0.5 - parallaxSample3.a ) * uvsFrame3.xy ) + uvsFrame3.zw;
				float4 albedo1 = tex2Dbias( _Albedo, float4(parallax1, 0, textureBias) );
				float4 albedo2 = tex2Dbias( _Albedo, float4(parallax2, 0, textureBias) );
				float4 albedo3 = tex2Dbias( _Albedo, float4(parallax3, 0, textureBias) );
				float4 blendedAlbedo = albedo1 * weights.x + albedo2 * weights.y + albedo3 * weights.z;
				o.Alpha = ( blendedAlbedo.a - _AI_Clip );
				clip( o.Alpha );
				float t = ceil( fraction.x - fraction.y );
				float4 cornerDifference = float4( t, 1 - t, 1, 1 );
				float2 step_1 = ( parallax1 - octaFrame.zw ) * _AI_Frames;
				float4 step23 = ( float4( parallax2, parallax3 ) -  octaFrame.zwzw ) * _AI_Frames - cornerDifference;
				step_1 = step_1 * (1-step_1);
				step23 = step23 * (1-step23);
				float3 steps;
				steps.x = step_1.x * step_1.y;
				steps.y = step23.x * step23.y;
				steps.z = step23.z * step23.w;
				steps = step(-steps, 0);
				float final = dot( steps, weights );
				clip( final - 0.5 );
				o.Albedo = blendedAlbedo.rgb;
				#if defined(AI_HD_RENDERPIPELINE) && ( AI_HDRP_VERSION >= 50702 )
				float4 feat1 = _Features.SampleLevel( SamplerState_Point_Repeat, parallax1, 0);
				o.Diffusion = feat1.rgb;
				o.Features = feat1.a;
				float4 test1 = _Specular.SampleLevel( SamplerState_Point_Repeat, parallax1, 0);
				o.MetalTangent = test1.b;
				#endif
				float4 normals1 = tex2Dbias( _Normals, float4(parallax1, 0, textureBias) );
				float4 normals2 = tex2Dbias( _Normals, float4(parallax2, 0, textureBias) );
				float4 normals3 = tex2Dbias( _Normals, float4(parallax3, 0, textureBias) );
				float4 blendedNormal = normals1 * weights.x  + normals2 * weights.y + normals3 * weights.z;
				float4 output0a = tex2Dbias( _Mask, float4(parallax1, 0, textureBias) );
				float4 output0b = tex2Dbias( _Mask, float4(parallax2, 0, textureBias) );
				float4 output0c = tex2Dbias( _Mask, float4(parallax3, 0, textureBias) );
				output0 = output0a * weights.x  + output0b * weights.y + output0c * weights.z; 
				float4 output1a = tex2Dbias( _Emissive, float4(parallax1, 0, textureBias) );
				float4 output1b = tex2Dbias( _Emissive, float4(parallax2, 0, textureBias) );
				float4 output1c = tex2Dbias( _Emissive, float4(parallax3, 0, textureBias) );
				output1 = output1a * weights.x  + output1b * weights.y + output1c * weights.z; 
				float3 localNormal = blendedNormal.rgb * 2.0 - 1.0;
				float3 worldNormal = normalize( mul( (float3x3)ai_ObjectToWorld, localNormal ) );
				o.Normal = worldNormal;
				float3 viewPos = interpViewPos.xyz;
				#if defined(UNITY_PASS_SHADOWCASTER) // Standard RP fix for deferred path
				float depthOffset = ( ( parallaxSample1.a * weights.x + parallaxSample2.a * weights.y + parallaxSample3.a * weights.z ) - 0.5001 /** 2.0 - 1.0*/ ) /** 0.5*/ * _AI_DepthSize * length( ai_ObjectToWorld[ 2 ].xyz );
				#else
				float depthOffset = ( ( parallaxSample1.a * weights.x + parallaxSample2.a * weights.y + parallaxSample3.a * weights.z ) - 0.5 /** 2.0 - 1.0*/ ) /** 0.5*/ * _AI_DepthSize * length( ai_ObjectToWorld[ 2 ].xyz );
				#endif
				#if ( defined(SHADERPASS) && (SHADERPASS == SHADERPASS_SHADOWS) ) || defined(UNITY_PASS_SHADOWCASTER)
				viewPos.z += depthOffset * _AI_ShadowView;
				viewPos.z += -_AI_ShadowBias;
				#else 
				viewPos.z += depthOffset;
				#endif
				worldPos = mul( UNITY_MATRIX_I_V, float4( viewPos.xyz, 1 ) ).xyz;
				clipPos = mul( UNITY_MATRIX_P, float4( viewPos, 1 ) );
				#if defined(UNITY_PASS_SHADOWCASTER) && !defined(SHADERPASS)
				#if UNITY_REVERSED_Z
				clipPos.z = min( clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE );
				#else
				clipPos.z = max( clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE );
				#endif
				#endif
				clipPos.xyz /= clipPos.w;
				if( UNITY_NEAR_CLIP_VALUE < 0 )
				clipPos = clipPos * 0.5 + 0.5;
			}
			

			VertexOutput vert(GraphVertexInput v)
            {
                VertexOutput o = (VertexOutput)0;
        	    UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				OctaImpostorVertex( v.vertex, v.normal, o.UVsFrame199, o.UVsFrame299, o.UVsFrame399, o.octaframe99, o.viewPos99 );
				float3 worldPosOut99 = mul( UNITY_MATRIX_I_V, float4( o.viewPos99.xyz, 1.0 ) ).xyz;
				float3 temp_output_3563_0_g53398 = worldPosOut99;
				float3 worldToObj3565_g53398 = mul( GetWorldToObjectMatrix(), float4( temp_output_3563_0_g53398, 1 ) ).xyz;
				float3 VertexPosition3564_g53398 = worldToObj3565_g53398;
				half3 VertexPos40_g53462 = VertexPosition3564_g53398;
				float3 appendResult74_g53462 = (float3(VertexPos40_g53462.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53462 = appendResult74_g53462;
				float3 break84_g53462 = VertexPos40_g53462;
				float3 appendResult81_g53462 = (float3(0.0 , break84_g53462.y , break84_g53462.z));
				half3 VertexPosOtherAxis82_g53462 = appendResult81_g53462;
				float Motion_Max_Bending1133_g53398 = 3.14;
				float4x4 break19_g53480 = GetObjectToWorldMatrix();
				float3 appendResult20_g53480 = (float3(break19_g53480[ 0 ][ 3 ] , break19_g53480[ 1 ][ 3 ] , break19_g53480[ 2 ][ 3 ]));
				half3 ObjectData20_g53481 = appendResult20_g53480;
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53481 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53481 = WorldData19_g53481;
				#else
				float3 staticSwitch14_g53481 = ObjectData20_g53481;
				#endif
				float3 temp_output_114_0_g53480 = staticSwitch14_g53481;
				float3 ObjectPosition4422_g53398 = temp_output_114_0_g53480;
				float3 Position83_g53471 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53471 = _LayerMotionValue;
				float4 lerpResult87_g53471 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53471).xz ) ),temp_output_84_0_g53471, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53471]);
				half4 Global_Motion_Params4344_g53398 = lerpResult87_g53471;
				float4 break322_g53478 = Global_Motion_Params4344_g53398;
				half Wind_Power369_g53478 = break322_g53478.z;
				float lerpResult376_g53478 = lerp( 0.1 , 1.0 , Wind_Power369_g53478);
				half Wind_Power_103106_g53398 = lerpResult376_g53478;
				float3 appendResult397_g53478 = (float3(break322_g53478.x , 0.0 , break322_g53478.y));
				float3 temp_output_398_0_g53478 = (appendResult397_g53478*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53478 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53478 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53398 = (temp_output_339_0_g53478).xz;
				float2 panner73_g53468 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4422_g53398).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53468 = tex2Dlod( TVE_NoiseTex, float4( panner73_g53468, 0, 0.0) );
				float4 saferPower77_g53468 = max( abs( tex2DNode75_g53468 ) , 0.0001 );
				half Wind_Power2223_g53398 = Wind_Power369_g53478;
				float temp_output_167_0_g53468 = Wind_Power2223_g53398;
				float lerpResult168_g53468 = lerp( 1.5 , 0.25 , temp_output_167_0_g53468);
				float4 temp_cast_5 = (lerpResult168_g53468).xxxx;
				float4 break142_g53468 = pow( saferPower77_g53468 , temp_cast_5 );
				half Global_NoiseTex_R34_g53398 = break142_g53468.r;
				half Input_Speed62_g53399 = _MotionSpeed_10;
				float mulTime373_g53399 = _TimeParameters.x * Input_Speed62_g53399;
				half Motion_Variation284_g53399 = 0.0;
				float2 appendResult344_g53399 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53399 = ( _MotionScale_10 * appendResult344_g53399 );
				half2 Sine_MinusOneToOne281_g53399 = sin( ( mulTime373_g53399 + Motion_Variation284_g53399 + Motion_Scale287_g53399 ) );
				float2 temp_cast_6 = (1.0).xx;
				half Input_Turbulence327_g53399 = Global_NoiseTex_R34_g53398;
				float2 lerpResult321_g53399 = lerp( Sine_MinusOneToOne281_g53399 , temp_cast_6 , Input_Turbulence327_g53399);
				half2 Motion_Bending2258_g53398 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53398 ) * Wind_Power_103106_g53398 * Wind_DirectionOS39_g53398 * Global_NoiseTex_R34_g53398 * lerpResult321_g53399 );
				half Interaction_Amplitude4351_g53398 = _InteractionAmplitude;
				float3 Position83_g53477 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53477 = _LayerReactValue;
				float4 lerpResult87_g53477 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53477).xz ) ),temp_output_84_0_g53477, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53477]);
				half4 Global_React_Params4413_g53398 = lerpResult87_g53477;
				float4 break322_g53460 = Global_React_Params4413_g53398;
				half Interaction_Mask66_g53398 = break322_g53460.z;
				float3 appendResult397_g53460 = (float3(break322_g53460.x , 0.0 , break322_g53460.y));
				float3 temp_output_398_0_g53460 = (appendResult397_g53460*2.0 + -1.0);
				float3 temp_output_339_0_g53460 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53460 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4349_g53398 = (temp_output_339_0_g53460).xz;
				half2 Motion_Interaction53_g53398 = ( Interaction_Amplitude4351_g53398 * Motion_Max_Bending1133_g53398 * Interaction_Mask66_g53398 * Interaction_Mask66_g53398 * Interaction_DirectionOS4349_g53398 );
				float2 lerpResult109_g53398 = lerp( Motion_Bending2258_g53398 , Motion_Interaction53_g53398 , ( Interaction_Mask66_g53398 * saturate( Interaction_Amplitude4351_g53398 ) ));
				float temp_output_3572_0_g53398 = saturate( VertexPosition3564_g53398.y );
				half Mesh_Motion_182_g53398 = temp_output_3572_0_g53398;
				float2 break143_g53398 = ( lerpResult109_g53398 * Mesh_Motion_182_g53398 );
				half Motion_Z190_g53398 = break143_g53398.y;
				half Angle44_g53462 = Motion_Z190_g53398;
				half3 VertexPos40_g53465 = ( VertexPosRotationAxis50_g53462 + ( VertexPosOtherAxis82_g53462 * cos( Angle44_g53462 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53462 ) * sin( Angle44_g53462 ) ) );
				float3 appendResult74_g53465 = (float3(0.0 , 0.0 , VertexPos40_g53465.z));
				half3 VertexPosRotationAxis50_g53465 = appendResult74_g53465;
				float3 break84_g53465 = VertexPos40_g53465;
				float3 appendResult81_g53465 = (float3(break84_g53465.x , break84_g53465.y , 0.0));
				half3 VertexPosOtherAxis82_g53465 = appendResult81_g53465;
				half Motion_X216_g53398 = break143_g53398.x;
				half Angle44_g53465 = -Motion_X216_g53398;
				float3 Vertex_Motion_Object833_g53398 = ( VertexPosRotationAxis50_g53465 + ( VertexPosOtherAxis82_g53465 * cos( Angle44_g53465 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53465 ) * sin( Angle44_g53465 ) ) );
				half Global_VertexTex_Size174_g53398 = break322_g53460.w;
				float lerpResult346_g53398 = lerp( 1.0 , Global_VertexTex_Size174_g53398 , _GlobalSize);
				float3 appendResult3480_g53398 = (float3(lerpResult346_g53398 , lerpResult346_g53398 , lerpResult346_g53398));
				half3 Vertex_Size1741_g53398 = appendResult3480_g53398;
				half3 _Vector5 = half3(1,1,1);
				float3 Vertex_SizeFade1740_g53398 = _Vector5;
				half IsInitialized3811_g53398 = _IsInitialized;
				float3 Final_VertexPosition890_g53398 = ( ( ( Vertex_Motion_Object833_g53398 * Vertex_Size1741_g53398 * Vertex_SizeFade1740_g53398 ) - VertexPosition3564_g53398 ) * IsInitialized3811_g53398 );
				
				float3 vertexValue = Final_VertexPosition890_g53398;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif

				v.normal =  v.normal ;

        	    o.clipPos = TransformObjectToHClip(v.vertex.xyz);
        	    return o;
            }

			half4 frag(VertexOutput IN, out float outDepth : SV_Depth ) : SV_TARGET
            {
                UNITY_SETUP_INSTANCE_ID(IN);
				SurfaceOutput o = (SurfaceOutput)0;
				float4 clipPos = 0;
				float3 worldPos = 0;
				float4 output0 = 0;
				float4 output1 = 0;
				OctaImpostorFragment( o, clipPos, worldPos, IN.UVsFrame199, IN.UVsFrame299, IN.UVsFrame399, IN.octaframe99, IN.viewPos99, output0, output1 );
				float temp_output_3577_0_g53398 = o.Alpha;
				float localCustomAlphaClipAlways4430_g53398 = ( temp_output_3577_0_g53398 );
				float4 break3589_g53398 = output0;
				half Main_Mask_Variation_Or_Metallic3607_g53398 = break3589_g53398.r;
				float lerpResult4049_g53398 = lerp( 0.9 , (Main_Mask_Variation_Or_Metallic3607_g53398*0.5 + 0.5) , _AlphaVariationValue);
				float3 temp_output_3563_0_g53398 = worldPos;
				float3 World_Pos4027_g53398 = temp_output_3563_0_g53398;
				float3 Position82_g53466 = World_Pos4027_g53398;
				float temp_output_84_0_g53466 = _LayerExtrasValue;
				float4 lerpResult88_g53466 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53466).xz ) ),temp_output_84_0_g53466 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53466]);
				float4 break89_g53466 = lerpResult88_g53466;
				half Global_ExtrasTex_Alpha1033_g53398 = break89_g53466.a;
				float lerpResult4053_g53398 = lerp( 1.0 , ( ( lerpResult4049_g53398 - ( 1.0 - Global_ExtrasTex_Alpha1033_g53398 ) ) + 0.1 ) , _GlobalAlpha);
				half Main_Mask_Leaves3712_g53398 = ceil( break3589_g53398.g );
				float lerpResult4075_g53398 = lerp( 1.0 , saturate( lerpResult4053_g53398 ) , Main_Mask_Leaves3712_g53398);
				half Final_Alpha4102_g53398 = lerpResult4075_g53398;
				float Alpha4430_g53398 = Final_Alpha4102_g53398;
				{
				clip(Alpha4430_g53398 - 0.1);
				}
				
				IN.clipPos.zw = clipPos.zw;
				float Alpha = localCustomAlphaClipAlways4430_g53398;
				float AlphaClipThreshold = AlphaClipThreshold;

				#if _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				outDepth = IN.clipPos.z;
				return float4( _ObjectId, _PassValue, 1.0, 1.0 );
            }
			ENDHLSL
		}

		
        Pass
        {
			
        	Name "Meta"
            Tags { "LightMode"="Meta" }

            Cull Off

            HLSLPROGRAM
            #define _TRANSMISSION_ASE 1
            #define ASE_SRP_VERSION 100202
            #ifdef UNITY_COLORSPACE_GAMMA//AI_SRP
            #define unity_ColorSpaceDielectricSpec half4(0.220916301, 0.220916301, 0.220916301, 1.0 - 0.220916301)//AI_SRP
            #else//AI_SRP
            #define unity_ColorSpaceDielectricSpec half4(0.04, 0.04, 0.04, 1.0 - 0.04) //AI_SRP
            #endif//AI_SRP

            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            

            #pragma vertex vert
            #pragma fragment frag            

			uniform float4 _MainTex_ST;

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

            #pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
            #pragma shader_feature EDITOR_VISUALIZATION

			#define ai_ObjectToWorld GetObjectToWorldMatrix()
			#define ai_WorldToObject GetWorldToObjectMatrix()
			#define AI_INV_TWO_PI  INV_TWO_PI
			#define AI_PI          PI
			#define AI_INV_PI      INV_PI
			#pragma multi_compile __ LOD_FADE_CROSSFADE
			//TVE Injection Defines
			//SHADER INJECTION POINT BEGIN
			//SHADER INJECTION POINT END
			//TVE Pipeline Defines
			#define THE_VEGETATION_ENGINE
			#define TVE_IS_UNIVERSAL_PIPELINE
			#pragma shader_feature_local TVE_IS_VEGETATION_SHADER TVE_IS_GRASS_SHADER


            struct GraphVertexInput
            {
                float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

        	struct VertexOutput
        	{
        	    float4 clipPos      : SV_POSITION;
                float4 UVsFrame199 : TEXCOORD0;
                float4 UVsFrame299 : TEXCOORD1;
                float4 UVsFrame399 : TEXCOORD2;
                float4 octaframe99 : TEXCOORD3;
                float4 viewPos99 : TEXCOORD4;
                float4 ase_texcoord5 : TEXCOORD5;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
        	};

			CBUFFER_START(UnityPerMaterial)
			half4 _SubsurfaceColor;
			half4 _MotionHighlightColor;
			float4 _SubsurfaceDiffusion_asset;
			half4 _NoiseColorOne;
			half4 _NoiseColorTwo;
			float4 _SubsurfaceDiffusion_Asset;
			float4 _ImpostorGrassColor;
			float4 _ImpostorLeafColor;
			float4 _ImpostorBarkColor;
			half4 _ColorsMaskRemap;
			half4 _EmissiveColor;
			float4 _AI_SizeOffset;
			half4 _OverlayMaskRemap;
			half4 _DetailBlendRemap;
			float4 _NoiseMaskRemap;
			float4 _EmissiveIntensityParams;
			float4 _GradientMaskRemap;
			half4 _SubsurfaceMaskRemap;
			float3 _AI_Offset;
			half _ImpostorGrassSaturationValue;
			half _LayerColorsValue;
			half _ImpostorLeafSaturationValue;
			half _ImpostorBarkSaturationValue;
			half _GlobalSize;
			half _NoiseScaleValue;
			half _NoiseMinValue;
			half _NoiseMaxValue;
			half _LayerReactValue;
			half _InteractionAmplitude;
			half _GlobalColors;
			half _IsTVEAIShader;
			half _ColorsMaskMinValue;
			half _GlobalWetness;
			half _ImpostorSmoothnessValue;
			float _RenderSpecular;
			half _GlobalEmissive;
			half _OverlayMaskMaxValue;
			half _OverlayMaskMinValue;
			half _OverlayVariationValue;
			half _LayerExtrasValue;
			half _GlobalOverlay;
			half _MainLightNormalValue;
			half _MainLightScatteringValue;
			half _MainLightAngleValue;
			half _SubsurfaceMaskMaxValue;
			half _SubsurfaceMaskMinValue;
			half _SubsurfaceValue;
			half _MotionScale_10;
			half _ColorsMaskMaxValue;
			half _ColorsVariationValue;
			half _MotionSpeed_10;
			float _AI_ShadowBias;
			half _MotionAmplitude_10;
			half _SizeFadeCat;
			half _LayersSpace;
			half _NoiseCat;
			float _MaterialType;
			half _MotionCat;
			half _EmissiveFlagMode;
			half _TranslucencyScatteringValue;
			half _SubsurfaceCat;
			half _DetailMode;
			half _GlobalCat;
			half _TranslucencyIntensityValue;
			half _DetailBlendMode;
			half _IsInitialized;
			half _SizeFadeMessage;
			half _TranslucencyShadowValue;
			half _TranslucencyAmbientValue;
			half _MotionSpace;
			half _TranslucencyHDMessage;
			half _LayerMotionValue;
			half _DetailCat;
			float _SubsurfaceDiffusion;
			float _AI_Clip;
			float _AI_ShadowView;
			half _AlphaVariationValue;
			float _AI_DepthSize;
			float _AI_TextureBias;
			float _AI_Parallax;
			float _AI_ImpostorSize;
			float _AI_FramesY;
			float _AI_FramesX;
			float _AI_Frames;
			half _ImpostorCat;
			half _subsurface_shadow;
			half _IsVegetationShader;
			half _TranslucencyDirectValue;
			float _IsVersion;
			half _EmissiveCat;
			half _PivotsMessage;
			half _TranslucencyNormalValue;
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
			CBUFFER_END

			sampler2D _Albedo;
			sampler2D _Normals;
			half4 TVE_MotionParams;
			TEXTURE2D_ARRAY(TVE_MotionTex);
			half4 TVE_MotionCoord;
			SAMPLER(samplerTVE_MotionTex);
			float TVE_MotionUsage[9];
			sampler2D TVE_NoiseTex;
			half4 TVE_NoiseParams;
			half4 TVE_ReactParams;
			TEXTURE2D_ARRAY(TVE_ReactTex);
			half4 TVE_ReactCoord;
			SAMPLER(samplerTVE_ReactTex);
			float TVE_ReactUsage[9];
			sampler2D _Mask;
			sampler2D _Emissive;
			SAMPLER(sampler_Mask);
			SAMPLER(sampler_Emissive);
			sampler3D TVE_WorldTex3D;
			half4 TVE_ColorsParams;
			TEXTURE2D_ARRAY(TVE_ColorsTex);
			half4 TVE_ColorsCoord;
			SAMPLER(samplerTVE_ColorsTex);
			float TVE_ColorsUsage[9];
			float4 TVE_MainLightParams;
			half3 TVE_MainLightDirection;
			half4 TVE_OverlayColor;
			half4 TVE_ExtrasParams;
			TEXTURE2D_ARRAY(TVE_ExtrasTex);
			half4 TVE_ExtrasCoord;
			SAMPLER(samplerTVE_ExtrasTex);
			float TVE_ExtrasUsage[9];

			
			float2 VectortoOctahedron( float3 N )
			{
				N /= dot( 1.0, abs( N ) );
				if( N.z <= 0 )
				{
				N.xy = ( 1 - abs( N.yx ) ) * ( N.xy >= 0 ? 1.0 : -1.0 );
				}
				return N.xy;
			}
			
			float3 OctahedronToVector( float2 Oct )
			{
				float3 N = float3( Oct, 1.0 - dot( 1.0, abs( Oct ) ) );
				if(N.z< 0 )
				{
				N.xy = ( 1 - abs( N.yx) ) * (N.xy >= 0 ? 1.0 : -1.0 );
				}
				return normalize( N);
			}
			
			inline void RayPlaneIntersectionUV( float3 normal, float3 rayPosition, float3 rayDirection, inout float2 uvs, inout float3 localNormal )
			{
				float lDotN = dot( rayDirection, normal ); 
				float p0l0DotN = dot( -rayPosition, normal );
				float t = p0l0DotN / lDotN;
				float3 p = rayDirection * t + rayPosition;
				float3 upVector = float3( 0, 1, 0 );
				float3 tangent = normalize( cross( upVector, normal ) + float3( -0.001, 0, 0 ) );
				float3 bitangent = cross( tangent, normal );
				float frameX = dot( p, tangent );
				float frameZ = dot( p, bitangent );
				uvs = -float2( frameX, frameZ );
				if( t <= 0.0 )
				uvs = 0;
				float3x3 worldToLocal = float3x3( tangent, bitangent, normal );
				localNormal = normalize( mul( worldToLocal, rayDirection ) );
			}
			
			inline void OctaImpostorVertex( inout float4 vertex, inout float3 normal, inout float4 uvsFrame1, inout float4 uvsFrame2, inout float4 uvsFrame3, inout float4 octaFrame, inout float4 viewPos )
			{
				float2 uvOffset = _AI_SizeOffset.zw;
				float parallax = -_AI_Parallax; 
				float UVscale = _AI_ImpostorSize;
				float framesXY = _AI_Frames;
				float prevFrame = framesXY - 1;
				float3 fractions = 1.0 / float3( framesXY, prevFrame, UVscale );
				float fractionsFrame = fractions.x;
				float fractionsPrevFrame = fractions.y;
				float fractionsUVscale = fractions.z;
				float3 worldOrigin = 0;
				float4 perspective = float4( 0, 0, 0, 1 );
				if( UNITY_MATRIX_P[ 3 ][ 3 ] == 1 ) 
				{
				perspective = float4( 0, 0, 5000, 0 );
				worldOrigin = ai_ObjectToWorld._m03_m13_m23;
				}
				float3 worldCameraPos = worldOrigin + mul( UNITY_MATRIX_I_V, perspective ).xyz;
				float3 objectCameraPosition = mul( ai_WorldToObject, float4( worldCameraPos, 1 ) ).xyz - _AI_Offset.xyz; 
				float3 objectCameraDirection = normalize( objectCameraPosition );
				float3 upVector = float3( 0,1,0 );
				float3 objectHorizontalVector = normalize( cross( objectCameraDirection, upVector ) );
				float3 objectVerticalVector = cross( objectHorizontalVector, objectCameraDirection );
				float2 uvExpansion = vertex.xy;
				float3 billboard = objectHorizontalVector * uvExpansion.x + objectVerticalVector * uvExpansion.y;
				float3 localDir = billboard - objectCameraPosition; 
				float2 frameOcta = VectortoOctahedron( objectCameraDirection.xzy ) * 0.5 + 0.5;
				float2 prevOctaFrame = frameOcta * prevFrame;
				float2 baseOctaFrame = floor( prevOctaFrame );
				float2 fractionOctaFrame = ( baseOctaFrame * fractionsFrame );
				float2 octaFrame1 = ( baseOctaFrame * fractionsPrevFrame ) * 2.0 - 1.0;
				float3 octa1WorldY = OctahedronToVector( octaFrame1 ).xzy;
				float3 octa1LocalY;
				float2 uvFrame1;
				RayPlaneIntersectionUV( octa1WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame1, /*inout*/ octa1LocalY );
				float2 uvParallax1 = octa1LocalY.xy * fractionsFrame * parallax;
				uvFrame1 = ( uvFrame1 * fractionsUVscale + 0.5 ) * fractionsFrame + fractionOctaFrame;
				uvsFrame1 = float4( uvParallax1, uvFrame1) - float4( 0, 0, uvOffset );
				float2 fractPrevOctaFrame = frac( prevOctaFrame );
				float2 cornerDifference = lerp( float2( 0,1 ) , float2( 1,0 ) , saturate( ceil( ( fractPrevOctaFrame.x - fractPrevOctaFrame.y ) ) ));
				float2 octaFrame2 = ( ( baseOctaFrame + cornerDifference ) * fractionsPrevFrame ) * 2.0 - 1.0;
				float3 octa2WorldY = OctahedronToVector( octaFrame2 ).xzy;
				float3 octa2LocalY;
				float2 uvFrame2;
				RayPlaneIntersectionUV( octa2WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame2, /*inout*/ octa2LocalY );
				float2 uvParallax2 = octa2LocalY.xy * fractionsFrame * parallax;
				uvFrame2 = ( uvFrame2 * fractionsUVscale + 0.5 ) * fractionsFrame + ( ( cornerDifference * fractionsFrame ) + fractionOctaFrame );
				uvsFrame2 = float4( uvParallax2, uvFrame2) - float4( 0, 0, uvOffset );
				float2 octaFrame3 = ( ( baseOctaFrame + 1 ) * fractionsPrevFrame  ) * 2.0 - 1.0;
				float3 octa3WorldY = OctahedronToVector( octaFrame3 ).xzy;
				float3 octa3LocalY;
				float2 uvFrame3;
				RayPlaneIntersectionUV( octa3WorldY, objectCameraPosition, localDir, /*inout*/ uvFrame3, /*inout*/ octa3LocalY );
				float2 uvParallax3 = octa3LocalY.xy * fractionsFrame * parallax;
				uvFrame3 = ( uvFrame3 * fractionsUVscale + 0.5 ) * fractionsFrame + ( fractionOctaFrame + fractionsFrame );
				uvsFrame3 = float4( uvParallax3, uvFrame3) - float4( 0, 0, uvOffset );
				octaFrame = 0;
				octaFrame.xy = prevOctaFrame;
				octaFrame.zw = fractionOctaFrame;
				vertex.xyz = billboard + _AI_Offset.xyz;
				normal.xyz = objectCameraDirection;
				viewPos = 0;
				viewPos.xyz = TransformWorldToView( TransformObjectToWorld( vertex.xyz ) );
			}
			
			inline void OctaImpostorFragment( inout SurfaceOutput o, out float4 clipPos, out float3 worldPos, float4 uvsFrame1, float4 uvsFrame2, float4 uvsFrame3, float4 octaFrame, float4 interpViewPos, out float4 output0, out float4 output1 )
			{
				float depthBias = -1.0;
				float textureBias = _AI_TextureBias;
				float2 fraction = frac( octaFrame.xy );
				float2 invFraction = 1 - fraction;
				float3 weights;
				weights.x = min( invFraction.x, invFraction.y );
				weights.y = abs( fraction.x - fraction.y );
				weights.z = min( fraction.x, fraction.y );
				float4 parallaxSample1 = tex2Dbias( _Normals, float4(uvsFrame1.zw, 0, depthBias) );
				float2 parallax1 = ( ( 0.5 - parallaxSample1.a ) * uvsFrame1.xy ) + uvsFrame1.zw;
				float4 parallaxSample2 = tex2Dbias( _Normals, float4(uvsFrame2.zw, 0, depthBias) );
				float2 parallax2 = ( ( 0.5 - parallaxSample2.a ) * uvsFrame2.xy ) + uvsFrame2.zw;
				float4 parallaxSample3 = tex2Dbias( _Normals, float4(uvsFrame3.zw, 0, depthBias) );
				float2 parallax3 = ( ( 0.5 - parallaxSample3.a ) * uvsFrame3.xy ) + uvsFrame3.zw;
				float4 albedo1 = tex2Dbias( _Albedo, float4(parallax1, 0, textureBias) );
				float4 albedo2 = tex2Dbias( _Albedo, float4(parallax2, 0, textureBias) );
				float4 albedo3 = tex2Dbias( _Albedo, float4(parallax3, 0, textureBias) );
				float4 blendedAlbedo = albedo1 * weights.x + albedo2 * weights.y + albedo3 * weights.z;
				o.Alpha = ( blendedAlbedo.a - _AI_Clip );
				clip( o.Alpha );
				float t = ceil( fraction.x - fraction.y );
				float4 cornerDifference = float4( t, 1 - t, 1, 1 );
				float2 step_1 = ( parallax1 - octaFrame.zw ) * _AI_Frames;
				float4 step23 = ( float4( parallax2, parallax3 ) -  octaFrame.zwzw ) * _AI_Frames - cornerDifference;
				step_1 = step_1 * (1-step_1);
				step23 = step23 * (1-step23);
				float3 steps;
				steps.x = step_1.x * step_1.y;
				steps.y = step23.x * step23.y;
				steps.z = step23.z * step23.w;
				steps = step(-steps, 0);
				float final = dot( steps, weights );
				clip( final - 0.5 );
				o.Albedo = blendedAlbedo.rgb;
				#if defined(AI_HD_RENDERPIPELINE) && ( AI_HDRP_VERSION >= 50702 )
				float4 feat1 = _Features.SampleLevel( SamplerState_Point_Repeat, parallax1, 0);
				o.Diffusion = feat1.rgb;
				o.Features = feat1.a;
				float4 test1 = _Specular.SampleLevel( SamplerState_Point_Repeat, parallax1, 0);
				o.MetalTangent = test1.b;
				#endif
				float4 normals1 = tex2Dbias( _Normals, float4(parallax1, 0, textureBias) );
				float4 normals2 = tex2Dbias( _Normals, float4(parallax2, 0, textureBias) );
				float4 normals3 = tex2Dbias( _Normals, float4(parallax3, 0, textureBias) );
				float4 blendedNormal = normals1 * weights.x  + normals2 * weights.y + normals3 * weights.z;
				float4 output0a = tex2Dbias( _Mask, float4(parallax1, 0, textureBias) );
				float4 output0b = tex2Dbias( _Mask, float4(parallax2, 0, textureBias) );
				float4 output0c = tex2Dbias( _Mask, float4(parallax3, 0, textureBias) );
				output0 = output0a * weights.x  + output0b * weights.y + output0c * weights.z; 
				float4 output1a = tex2Dbias( _Emissive, float4(parallax1, 0, textureBias) );
				float4 output1b = tex2Dbias( _Emissive, float4(parallax2, 0, textureBias) );
				float4 output1c = tex2Dbias( _Emissive, float4(parallax3, 0, textureBias) );
				output1 = output1a * weights.x  + output1b * weights.y + output1c * weights.z; 
				float3 localNormal = blendedNormal.rgb * 2.0 - 1.0;
				float3 worldNormal = normalize( mul( (float3x3)ai_ObjectToWorld, localNormal ) );
				o.Normal = worldNormal;
				float3 viewPos = interpViewPos.xyz;
				#if defined(UNITY_PASS_SHADOWCASTER) // Standard RP fix for deferred path
				float depthOffset = ( ( parallaxSample1.a * weights.x + parallaxSample2.a * weights.y + parallaxSample3.a * weights.z ) - 0.5001 /** 2.0 - 1.0*/ ) /** 0.5*/ * _AI_DepthSize * length( ai_ObjectToWorld[ 2 ].xyz );
				#else
				float depthOffset = ( ( parallaxSample1.a * weights.x + parallaxSample2.a * weights.y + parallaxSample3.a * weights.z ) - 0.5 /** 2.0 - 1.0*/ ) /** 0.5*/ * _AI_DepthSize * length( ai_ObjectToWorld[ 2 ].xyz );
				#endif
				#if ( defined(SHADERPASS) && (SHADERPASS == SHADERPASS_SHADOWS) ) || defined(UNITY_PASS_SHADOWCASTER)
				viewPos.z += depthOffset * _AI_ShadowView;
				viewPos.z += -_AI_ShadowBias;
				#else 
				viewPos.z += depthOffset;
				#endif
				worldPos = mul( UNITY_MATRIX_I_V, float4( viewPos.xyz, 1 ) ).xyz;
				clipPos = mul( UNITY_MATRIX_P, float4( viewPos, 1 ) );
				#if defined(UNITY_PASS_SHADOWCASTER) && !defined(SHADERPASS)
				#if UNITY_REVERSED_Z
				clipPos.z = min( clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE );
				#else
				clipPos.z = max( clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE );
				#endif
				#endif
				clipPos.xyz /= clipPos.w;
				if( UNITY_NEAR_CLIP_VALUE < 0 )
				clipPos = clipPos * 0.5 + 0.5;
			}
			

            VertexOutput vert(GraphVertexInput v)
            {
                VertexOutput o = (VertexOutput)0;
        	    UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				OctaImpostorVertex( v.vertex, v.normal, o.UVsFrame199, o.UVsFrame299, o.UVsFrame399, o.octaframe99, o.viewPos99 );
				float3 worldPosOut99 = mul( UNITY_MATRIX_I_V, float4( o.viewPos99.xyz, 1.0 ) ).xyz;
				float3 temp_output_3563_0_g53398 = worldPosOut99;
				float3 worldToObj3565_g53398 = mul( GetWorldToObjectMatrix(), float4( temp_output_3563_0_g53398, 1 ) ).xyz;
				float3 VertexPosition3564_g53398 = worldToObj3565_g53398;
				half3 VertexPos40_g53462 = VertexPosition3564_g53398;
				float3 appendResult74_g53462 = (float3(VertexPos40_g53462.x , 0.0 , 0.0));
				half3 VertexPosRotationAxis50_g53462 = appendResult74_g53462;
				float3 break84_g53462 = VertexPos40_g53462;
				float3 appendResult81_g53462 = (float3(0.0 , break84_g53462.y , break84_g53462.z));
				half3 VertexPosOtherAxis82_g53462 = appendResult81_g53462;
				float Motion_Max_Bending1133_g53398 = 3.14;
				float4x4 break19_g53480 = GetObjectToWorldMatrix();
				float3 appendResult20_g53480 = (float3(break19_g53480[ 0 ][ 3 ] , break19_g53480[ 1 ][ 3 ] , break19_g53480[ 2 ][ 3 ]));
				half3 ObjectData20_g53481 = appendResult20_g53480;
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				half3 WorldData19_g53481 = ase_worldPos;
				#ifdef TVE_VERTEX_DATA_BATCHED
				float3 staticSwitch14_g53481 = WorldData19_g53481;
				#else
				float3 staticSwitch14_g53481 = ObjectData20_g53481;
				#endif
				float3 temp_output_114_0_g53480 = staticSwitch14_g53481;
				float3 ObjectPosition4422_g53398 = temp_output_114_0_g53480;
				float3 Position83_g53471 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53471 = _LayerMotionValue;
				float4 lerpResult87_g53471 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53471).xz ) ),temp_output_84_0_g53471, 0.0 ) , TVE_MotionUsage[(int)temp_output_84_0_g53471]);
				half4 Global_Motion_Params4344_g53398 = lerpResult87_g53471;
				float4 break322_g53478 = Global_Motion_Params4344_g53398;
				half Wind_Power369_g53478 = break322_g53478.z;
				float lerpResult376_g53478 = lerp( 0.1 , 1.0 , Wind_Power369_g53478);
				half Wind_Power_103106_g53398 = lerpResult376_g53478;
				float3 appendResult397_g53478 = (float3(break322_g53478.x , 0.0 , break322_g53478.y));
				float3 temp_output_398_0_g53478 = (appendResult397_g53478*2.0 + -1.0);
				float3 ase_parentObjectScale = ( 1.0 / float3( length( GetWorldToObjectMatrix()[ 0 ].xyz ), length( GetWorldToObjectMatrix()[ 1 ].xyz ), length( GetWorldToObjectMatrix()[ 2 ].xyz ) ) );
				float3 temp_output_339_0_g53478 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53478 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Wind_DirectionOS39_g53398 = (temp_output_339_0_g53478).xz;
				float2 panner73_g53468 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4422_g53398).xz * TVE_NoiseParams.z ));
				float4 tex2DNode75_g53468 = tex2Dlod( TVE_NoiseTex, float4( panner73_g53468, 0, 0.0) );
				float4 saferPower77_g53468 = max( abs( tex2DNode75_g53468 ) , 0.0001 );
				half Wind_Power2223_g53398 = Wind_Power369_g53478;
				float temp_output_167_0_g53468 = Wind_Power2223_g53398;
				float lerpResult168_g53468 = lerp( 1.5 , 0.25 , temp_output_167_0_g53468);
				float4 temp_cast_5 = (lerpResult168_g53468).xxxx;
				float4 break142_g53468 = pow( saferPower77_g53468 , temp_cast_5 );
				half Global_NoiseTex_R34_g53398 = break142_g53468.r;
				half Input_Speed62_g53399 = _MotionSpeed_10;
				float mulTime373_g53399 = _TimeParameters.x * Input_Speed62_g53399;
				half Motion_Variation284_g53399 = 0.0;
				float2 appendResult344_g53399 = (float2(ase_worldPos.x , ase_worldPos.z));
				float2 Motion_Scale287_g53399 = ( _MotionScale_10 * appendResult344_g53399 );
				half2 Sine_MinusOneToOne281_g53399 = sin( ( mulTime373_g53399 + Motion_Variation284_g53399 + Motion_Scale287_g53399 ) );
				float2 temp_cast_6 = (1.0).xx;
				half Input_Turbulence327_g53399 = Global_NoiseTex_R34_g53398;
				float2 lerpResult321_g53399 = lerp( Sine_MinusOneToOne281_g53399 , temp_cast_6 , Input_Turbulence327_g53399);
				half2 Motion_Bending2258_g53398 = ( ( _MotionAmplitude_10 * Motion_Max_Bending1133_g53398 ) * Wind_Power_103106_g53398 * Wind_DirectionOS39_g53398 * Global_NoiseTex_R34_g53398 * lerpResult321_g53399 );
				half Interaction_Amplitude4351_g53398 = _InteractionAmplitude;
				float3 Position83_g53477 = ObjectPosition4422_g53398;
				float temp_output_84_0_g53477 = _LayerReactValue;
				float4 lerpResult87_g53477 = lerp( TVE_ReactParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ReactTex, samplerTVE_ReactTex, ( (TVE_ReactCoord).zw + ( (TVE_ReactCoord).xy * (Position83_g53477).xz ) ),temp_output_84_0_g53477, 0.0 ) , TVE_ReactUsage[(int)temp_output_84_0_g53477]);
				half4 Global_React_Params4413_g53398 = lerpResult87_g53477;
				float4 break322_g53460 = Global_React_Params4413_g53398;
				half Interaction_Mask66_g53398 = break322_g53460.z;
				float3 appendResult397_g53460 = (float3(break322_g53460.x , 0.0 , break322_g53460.y));
				float3 temp_output_398_0_g53460 = (appendResult397_g53460*2.0 + -1.0);
				float3 temp_output_339_0_g53460 = ( mul( GetWorldToObjectMatrix(), float4( temp_output_398_0_g53460 , 0.0 ) ).xyz * ase_parentObjectScale );
				half2 Interaction_DirectionOS4349_g53398 = (temp_output_339_0_g53460).xz;
				half2 Motion_Interaction53_g53398 = ( Interaction_Amplitude4351_g53398 * Motion_Max_Bending1133_g53398 * Interaction_Mask66_g53398 * Interaction_Mask66_g53398 * Interaction_DirectionOS4349_g53398 );
				float2 lerpResult109_g53398 = lerp( Motion_Bending2258_g53398 , Motion_Interaction53_g53398 , ( Interaction_Mask66_g53398 * saturate( Interaction_Amplitude4351_g53398 ) ));
				float temp_output_3572_0_g53398 = saturate( VertexPosition3564_g53398.y );
				half Mesh_Motion_182_g53398 = temp_output_3572_0_g53398;
				float2 break143_g53398 = ( lerpResult109_g53398 * Mesh_Motion_182_g53398 );
				half Motion_Z190_g53398 = break143_g53398.y;
				half Angle44_g53462 = Motion_Z190_g53398;
				half3 VertexPos40_g53465 = ( VertexPosRotationAxis50_g53462 + ( VertexPosOtherAxis82_g53462 * cos( Angle44_g53462 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g53462 ) * sin( Angle44_g53462 ) ) );
				float3 appendResult74_g53465 = (float3(0.0 , 0.0 , VertexPos40_g53465.z));
				half3 VertexPosRotationAxis50_g53465 = appendResult74_g53465;
				float3 break84_g53465 = VertexPos40_g53465;
				float3 appendResult81_g53465 = (float3(break84_g53465.x , break84_g53465.y , 0.0));
				half3 VertexPosOtherAxis82_g53465 = appendResult81_g53465;
				half Motion_X216_g53398 = break143_g53398.x;
				half Angle44_g53465 = -Motion_X216_g53398;
				float3 Vertex_Motion_Object833_g53398 = ( VertexPosRotationAxis50_g53465 + ( VertexPosOtherAxis82_g53465 * cos( Angle44_g53465 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g53465 ) * sin( Angle44_g53465 ) ) );
				half Global_VertexTex_Size174_g53398 = break322_g53460.w;
				float lerpResult346_g53398 = lerp( 1.0 , Global_VertexTex_Size174_g53398 , _GlobalSize);
				float3 appendResult3480_g53398 = (float3(lerpResult346_g53398 , lerpResult346_g53398 , lerpResult346_g53398));
				half3 Vertex_Size1741_g53398 = appendResult3480_g53398;
				half3 _Vector5 = half3(1,1,1);
				float3 Vertex_SizeFade1740_g53398 = _Vector5;
				half IsInitialized3811_g53398 = _IsInitialized;
				float3 Final_VertexPosition890_g53398 = ( ( ( Vertex_Motion_Object833_g53398 * Vertex_Size1741_g53398 * Vertex_SizeFade1740_g53398 ) - VertexPosition3564_g53398 ) * IsInitialized3811_g53398 );
				
				o.ase_texcoord5.xyz = ase_worldPos;
				
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord5.w = 0;

				float3 vertexValue = Final_VertexPosition890_g53398;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif

				v.normal =  v.normal ;
				
#if !defined( ASE_SRP_VERSION ) || ASE_SRP_VERSION  > 51300                
				o.clipPos = MetaVertexPosition( v.vertex, v.texcoord1.xy, v.texcoord1.xy, unity_LightmapST, unity_DynamicLightmapST );
#else
				o.clipPos = MetaVertexPosition( v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST );
#endif
        	    return o;
            }

            half4 frag(VertexOutput IN, out float outDepth : SV_Depth ) : SV_TARGET
            {
                UNITY_SETUP_INSTANCE_ID(IN);
				SurfaceOutput o = (SurfaceOutput)0;
				float4 clipPos = 0;
				float3 worldPos = 0;
           		float4 output0 = 0;
           		float4 output1 = 0;
           		OctaImpostorFragment( o, clipPos, worldPos, IN.UVsFrame199, IN.UVsFrame299, IN.UVsFrame399, IN.octaframe99, IN.viewPos99, output0, output1 );
           		half3 Main_Albedo_Raw4295_g53398 = o.Albedo;
           		float dotResult4302_g53398 = dot( float3(0.2126,0.7152,0.0722) , Main_Albedo_Raw4295_g53398 );
           		float3 temp_cast_0 = (dotResult4302_g53398).xxx;
           		float4 break3589_g53398 = output0;
           		half Main_Mask_Leaves3712_g53398 = ceil( break3589_g53398.g );
           		float lerpResult4305_g53398 = lerp( _ImpostorBarkSaturationValue , _ImpostorLeafSaturationValue , Main_Mask_Leaves3712_g53398);
           		float3 lerpResult4303_g53398 = lerp( temp_cast_0 , Main_Albedo_Raw4295_g53398 , lerpResult4305_g53398);
           		float4 lerpResult4310_g53398 = lerp( _ImpostorBarkColor , _ImpostorLeafColor , Main_Mask_Leaves3712_g53398);
           		float dotResult4323_g53398 = dot( float3(0.2126,0.7152,0.0722) , Main_Albedo_Raw4295_g53398 );
           		float3 temp_cast_2 = (dotResult4323_g53398).xxx;
           		float3 lerpResult4317_g53398 = lerp( temp_cast_2 , Main_Albedo_Raw4295_g53398 , _ImpostorGrassSaturationValue);
           		#ifdef TVE_IS_GRASS_SHADER
           		float3 staticSwitch4322_g53398 = ( lerpResult4317_g53398 * (_ImpostorGrassColor).rgb );
           		#else
           		float3 staticSwitch4322_g53398 = ( lerpResult4303_g53398 * (lerpResult4310_g53398).rgb );
           		#endif
           		half3 Main_Albedo3817_g53398 = staticSwitch4322_g53398;
           		half3 Blend_Albedo4137_g53398 = Main_Albedo3817_g53398;
           		float3 temp_cast_3 = (_NoiseScaleValue).xxx;
           		float3 temp_output_3563_0_g53398 = worldPos;
           		float3 World_Pos4027_g53398 = temp_output_3563_0_g53398;
           		float temp_output_7_0_g53452 = _NoiseMinValue;
           		half Noise_Mask4030_g53398 = saturate( ( ( tex3D( TVE_WorldTex3D, ( temp_cast_3 * World_Pos4027_g53398 * 0.1 ) ).r - temp_output_7_0_g53452 ) / ( _NoiseMaxValue - temp_output_7_0_g53452 ) ) );
           		float4 lerpResult4044_g53398 = lerp( _NoiseColorTwo , _NoiseColorOne , Noise_Mask4030_g53398);
           		half3 Noise_Tint4031_g53398 = (lerpResult4044_g53398).rgb;
           		float3 _Vector10 = float3(1,1,1);
           		float4x4 break19_g53480 = GetObjectToWorldMatrix();
           		float3 appendResult20_g53480 = (float3(break19_g53480[ 0 ][ 3 ] , break19_g53480[ 1 ][ 3 ] , break19_g53480[ 2 ][ 3 ]));
           		half3 ObjectData20_g53481 = appendResult20_g53480;
           		float3 ase_worldPos = IN.ase_texcoord5.xyz;
           		half3 WorldData19_g53481 = ase_worldPos;
           		#ifdef TVE_VERTEX_DATA_BATCHED
           		float3 staticSwitch14_g53481 = WorldData19_g53481;
           		#else
           		float3 staticSwitch14_g53481 = ObjectData20_g53481;
           		#endif
           		float3 temp_output_114_0_g53480 = staticSwitch14_g53481;
           		float3 ObjectPosition4422_g53398 = temp_output_114_0_g53480;
           		float2 panner73_g53468 = ( _TimeParameters.x * (TVE_NoiseParams).xy + ( (ObjectPosition4422_g53398).xz * TVE_NoiseParams.z ));
           		float4 tex2DNode75_g53468 = tex2D( TVE_NoiseTex, panner73_g53468 );
           		float3 Position83_g53471 = ObjectPosition4422_g53398;
           		float temp_output_84_0_g53471 = _LayerMotionValue;
           		float4 lerpResult87_g53471 = lerp( TVE_MotionParams , SAMPLE_TEXTURE2D_ARRAY( TVE_MotionTex, samplerTVE_MotionTex, ( (TVE_MotionCoord).zw + ( (TVE_MotionCoord).xy * (Position83_g53471).xz ) ),temp_output_84_0_g53471 ) , TVE_MotionUsage[(int)temp_output_84_0_g53471]);
           		half4 Global_Motion_Params4344_g53398 = lerpResult87_g53471;
           		float4 break322_g53478 = Global_Motion_Params4344_g53398;
           		half Wind_Power369_g53478 = break322_g53478.z;
           		half Wind_Power2223_g53398 = Wind_Power369_g53478;
           		float temp_output_167_0_g53468 = Wind_Power2223_g53398;
           		float lerpResult169_g53468 = lerp( 4.0 , 2.0 , temp_output_167_0_g53468);
           		half Global_NoiseTex_H2869_g53398 = pow( abs( tex2DNode75_g53468.a ) , lerpResult169_g53468 );
           		float lerpResult376_g53478 = lerp( 0.1 , 1.0 , Wind_Power369_g53478);
           		half Wind_Power_103106_g53398 = lerpResult376_g53478;
           		float3 worldToObj3565_g53398 = mul( GetWorldToObjectMatrix(), float4( temp_output_3563_0_g53398, 1 ) ).xyz;
           		float3 VertexPosition3564_g53398 = worldToObj3565_g53398;
           		float temp_output_3572_0_g53398 = saturate( VertexPosition3564_g53398.y );
           		half Mesh_Height1524_g53398 = temp_output_3572_0_g53398;
           		half Main_Mask_Variation_Or_Metallic3607_g53398 = break3589_g53398.r;
           		half3 Highlight_Tint3904_g53398 = ( ( (_MotionHighlightColor).rgb * Global_NoiseTex_H2869_g53398 * Wind_Power_103106_g53398 * Mesh_Height1524_g53398 * Main_Mask_Variation_Or_Metallic3607_g53398 ) + float3( 1,1,1 ) );
           		#ifdef TVE_IS_GRASS_SHADER
           		float3 staticSwitch4284_g53398 = Highlight_Tint3904_g53398;
           		#else
           		float3 staticSwitch4284_g53398 = _Vector10;
           		#endif
           		half3 Blend_AlbedoTinted3958_g53398 = ( Blend_Albedo4137_g53398 * Noise_Tint4031_g53398 * staticSwitch4284_g53398 );
           		float dotResult4002_g53398 = dot( Blend_AlbedoTinted3958_g53398 , float3(0.2126,0.7152,0.0722) );
           		float3 temp_cast_7 = (dotResult4002_g53398).xxx;
           		float3 Position58_g53463 = World_Pos4027_g53398;
           		float temp_output_82_0_g53463 = _LayerColorsValue;
           		float4 lerpResult88_g53463 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ColorsTex, samplerTVE_ColorsTex, ( (TVE_ColorsCoord).zw + ( (TVE_ColorsCoord).xy * (Position58_g53463).xz ) ),temp_output_82_0_g53463 ) , TVE_ColorsUsage[(int)temp_output_82_0_g53463]);
           		half Global_ColorsTex_A1701_g53398 = (lerpResult88_g53463).a;
           		half Global_Colors_Influence3998_g53398 = Global_ColorsTex_A1701_g53398;
           		float3 lerpResult4004_g53398 = lerp( Blend_AlbedoTinted3958_g53398 , temp_cast_7 , Global_Colors_Influence3998_g53398);
           		half3 Global_ColorsTex_RGB1700_g53398 = (lerpResult88_g53463).rgb;
           		#ifdef UNITY_COLORSPACE_GAMMA
           		float staticSwitch1_g53450 = 2.0;
           		#else
           		float staticSwitch1_g53450 = 4.594794;
           		#endif
           		half3 Global_Colors3856_g53398 = ( Global_ColorsTex_RGB1700_g53398 * staticSwitch1_g53450 );
           		float lerpResult4092_g53398 = lerp( 1.0 , Main_Mask_Variation_Or_Metallic3607_g53398 , _ColorsVariationValue);
           		half Global_Colors_Value3999_g53398 = ( _GlobalColors * lerpResult4092_g53398 );
           		half Main_Mask_Subsurface_Or_Blend3609_g53398 = break3589_g53398.b;
           		#ifdef TVE_IS_GRASS_SHADER
           		float staticSwitch4275_g53398 = ( 1.0 - Main_Mask_Subsurface_Or_Blend3609_g53398 );
           		#else
           		float staticSwitch4275_g53398 = Main_Mask_Subsurface_Or_Blend3609_g53398;
           		#endif
           		float temp_output_7_0_g53455 = _ColorsMaskMinValue;
           		half Global_Colors_Mask4022_g53398 = ( saturate( ( ( staticSwitch4275_g53398 - temp_output_7_0_g53455 ) / ( _ColorsMaskMaxValue - temp_output_7_0_g53455 ) ) ) * Main_Mask_Leaves3712_g53398 );
           		float3 lerpResult4007_g53398 = lerp( Blend_AlbedoTinted3958_g53398 , ( lerpResult4004_g53398 * Global_Colors3856_g53398 ) , ( Global_Colors_Value3999_g53398 * Global_Colors_Mask4022_g53398 ));
           		float3 lerpResult4086_g53398 = lerp( Blend_Albedo4137_g53398 , lerpResult4007_g53398 , Main_Mask_Leaves3712_g53398);
           		half3 Blend_AlbedoColored3711_g53398 = lerpResult4086_g53398;
           		float3 temp_output_3681_0_g53398 = (_SubsurfaceColor).rgb;
           		float dotResult4019_g53398 = dot( temp_output_3681_0_g53398 , float3(0.2126,0.7152,0.0722) );
           		float3 temp_cast_10 = (dotResult4019_g53398).xxx;
           		float3 lerpResult4018_g53398 = lerp( temp_output_3681_0_g53398 , temp_cast_10 , Global_Colors_Influence3998_g53398);
           		float3 lerpResult4017_g53398 = lerp( temp_output_3681_0_g53398 , ( lerpResult4018_g53398 * Global_Colors3856_g53398 ) , ( Global_Colors_Value3999_g53398 * Global_Colors_Mask4022_g53398 ));
           		half3 Subsurface_Color3656_g53398 = lerpResult4017_g53398;
           		half MainLight_Subsurface4111_g53398 = TVE_MainLightParams.a;
           		half Subsurface_Intensity3684_g53398 = ( _SubsurfaceValue * MainLight_Subsurface4111_g53398 );
           		float temp_output_7_0_g53467 = _SubsurfaceMaskMinValue;
           		half Subsurface_Mask3666_g53398 = ( saturate( ( ( Main_Mask_Subsurface_Or_Blend3609_g53398 - temp_output_7_0_g53467 ) / ( _SubsurfaceMaskMaxValue - temp_output_7_0_g53467 ) ) ) * Main_Mask_Leaves3712_g53398 );
           		half3 Subsurface_Transmission3659_g53398 = ( Subsurface_Color3656_g53398 * Subsurface_Intensity3684_g53398 * Subsurface_Mask3666_g53398 );
           		half3 MainLight_Direction4110_g53398 = TVE_MainLightDirection;
           		float3 normalizeResult3635_g53398 = normalize( ( _WorldSpaceCameraPos - ase_worldPos ) );
           		float dotResult3631_g53398 = dot( -MainLight_Direction4110_g53398 , normalizeResult3635_g53398 );
           		float saferPower3620_g53398 = max( (dotResult3631_g53398*0.5 + 0.5) , 0.0001 );
           		#ifdef UNITY_PASS_FORWARDADD
           		float staticSwitch3636_g53398 = 0.0;
           		#else
           		float staticSwitch3636_g53398 = ( pow( saferPower3620_g53398 , _MainLightAngleValue ) * _MainLightScatteringValue );
           		#endif
           		half Mask_Subsurface_View3614_g53398 = staticSwitch3636_g53398;
           		half3 World_Normal3638_g53398 = o.Normal;
           		float dotResult3625_g53398 = dot( MainLight_Direction4110_g53398 , World_Normal3638_g53398 );
           		float lerpResult4385_g53398 = lerp( 1.0 , saturate( dotResult3625_g53398 ) , _MainLightNormalValue);
           		#ifdef TVE_IS_GRASS_SHADER
           		float staticSwitch4387_g53398 = 1.0;
           		#else
           		float staticSwitch4387_g53398 = lerpResult4385_g53398;
           		#endif
           		#ifdef UNITY_PASS_FORWARDADD
           		float staticSwitch3618_g53398 = 0.0;
           		#else
           		float staticSwitch3618_g53398 = staticSwitch4387_g53398;
           		#endif
           		half Mask_Subsurface_Normal3637_g53398 = staticSwitch3618_g53398;
           		half3 Subsurface_Scattering3702_g53398 = ( Subsurface_Transmission3659_g53398 * Blend_AlbedoColored3711_g53398 * Mask_Subsurface_View3614_g53398 * Mask_Subsurface_Normal3637_g53398 );
           		half3 Albedo_Subsurface3874_g53398 = ( Blend_AlbedoColored3711_g53398 + Subsurface_Scattering3702_g53398 );
           		half3 Global_OverlayColor1758_g53398 = (TVE_OverlayColor).rgb;
           		half Main_AlbedoTex_G3807_g53398 = Main_Albedo_Raw4295_g53398.y;
           		float3 Position82_g53466 = World_Pos4027_g53398;
           		float temp_output_84_0_g53466 = _LayerExtrasValue;
           		float4 lerpResult88_g53466 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY( TVE_ExtrasTex, samplerTVE_ExtrasTex, ( (TVE_ExtrasCoord).zw + ( (TVE_ExtrasCoord).xy * (Position82_g53466).xz ) ),temp_output_84_0_g53466 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g53466]);
           		float4 break89_g53466 = lerpResult88_g53466;
           		half Global_ExtrasTex_Overlay156_g53398 = break89_g53466.b;
           		float temp_output_3774_0_g53398 = ( _GlobalOverlay * Global_ExtrasTex_Overlay156_g53398 );
           		float lerpResult3746_g53398 = lerp( 1.0 , Main_Mask_Variation_Or_Metallic3607_g53398 , _OverlayVariationValue);
           		half Overlay_Commons3739_g53398 = ( temp_output_3774_0_g53398 * lerpResult3746_g53398 );
           		#ifdef TVE_IS_GRASS_SHADER
           		float staticSwitch4267_g53398 = ( ( ( Main_Mask_Subsurface_Or_Blend3609_g53398 * 0.5 ) + Main_AlbedoTex_G3807_g53398 ) * Overlay_Commons3739_g53398 );
           		#else
           		float staticSwitch4267_g53398 = ( ( ( World_Normal3638_g53398.y * 0.5 ) + Main_AlbedoTex_G3807_g53398 ) * Overlay_Commons3739_g53398 );
           		#endif
           		float temp_output_7_0_g53457 = _OverlayMaskMinValue;
           		half Overlay_Mask3762_g53398 = saturate( ( ( staticSwitch4267_g53398 - temp_output_7_0_g53457 ) / ( _OverlayMaskMaxValue - temp_output_7_0_g53457 ) ) );
           		float3 lerpResult3875_g53398 = lerp( Albedo_Subsurface3874_g53398 , Global_OverlayColor1758_g53398 , Overlay_Mask3762_g53398);
           		half3 Final_Albedo4100_g53398 = lerpResult3875_g53398;
           		half IsInitialized3811_g53398 = _IsInitialized;
           		float3 lerpResult3815_g53398 = lerp( float3( 1,0,0 ) , Final_Albedo4100_g53398 , IsInitialized3811_g53398);
           		float3 localLODFadeCustom3987_g53398 = ( lerpResult3815_g53398 );
           		{
           		// TVE Temporary fix for Dither in URP
           		#ifdef LOD_FADE_CROSSFADE
           		LODDitheringTransition(IN.clipPos.xyz, unity_LODFade.x);
           		#endif
           		}
           		#ifdef LOD_FADE_CROSSFADE
           		float3 staticSwitch3989_g53398 = localLODFadeCustom3987_g53398;
           		#else
           		float3 staticSwitch3989_g53398 = lerpResult3815_g53398;
           		#endif
           		
           		float4 temp_output_4421_0_g53398 = ( _EmissiveColor * _EmissiveIntensityParams.x );
           		half Global_ExtrasTex_Emissive4408_g53398 = break89_g53466.r;
           		float lerpResult4417_g53398 = lerp( 1.0 , Global_ExtrasTex_Emissive4408_g53398 , _GlobalEmissive);
           		half3 Final_Emissive4365_g53398 = ( (( temp_output_4421_0_g53398 * output1 )).rgb * lerpResult4417_g53398 );
           		
           		float temp_output_3577_0_g53398 = o.Alpha;
           		float localCustomAlphaClipAlways4430_g53398 = ( temp_output_3577_0_g53398 );
           		float lerpResult4049_g53398 = lerp( 0.9 , (Main_Mask_Variation_Or_Metallic3607_g53398*0.5 + 0.5) , _AlphaVariationValue);
           		half Global_ExtrasTex_Alpha1033_g53398 = break89_g53466.a;
           		float lerpResult4053_g53398 = lerp( 1.0 , ( ( lerpResult4049_g53398 - ( 1.0 - Global_ExtrasTex_Alpha1033_g53398 ) ) + 0.1 ) , _GlobalAlpha);
           		float lerpResult4075_g53398 = lerp( 1.0 , saturate( lerpResult4053_g53398 ) , Main_Mask_Leaves3712_g53398);
           		half Final_Alpha4102_g53398 = lerpResult4075_g53398;
           		float Alpha4430_g53398 = Final_Alpha4102_g53398;
           		{
           		clip(Alpha4430_g53398 - 0.1);
           		}
           		
				IN.clipPos.zw = clipPos.zw;
		        float3 Albedo = staticSwitch3989_g53398;
				float3 Emission = Final_Emissive4365_g53398;
				float Alpha = localCustomAlphaClipAlways4430_g53398;
				float AlphaClipThreshold = 0;

				#if _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif
				outDepth = IN.clipPos.z;
                MetaInput metaInput = (MetaInput)0;
                metaInput.Albedo = Albedo;
                metaInput.Emission = Emission;
                
                return MetaFragment(metaInput);
            }
            ENDHLSL
        }
		
    }
    
	CustomEditor "TVEAIShaderGUI"
	
}
/*ASEBEGIN
Version=18910
1920;0;1920;1029;2191.846;20.90601;1;True;False
Node;AmplifyShaderEditor.TexturePropertyNode;101;-1664,-256;Inherit;True;Property;_Mask;Impostor Baked Masks;3;1;[NoScaleOffset];Create;False;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TexturePropertyNode;394;-1664,-64;Inherit;True;Property;_Emissive;Impostor Emissive Map;4;1;[NoScaleOffset];Create;False;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.AmplifyImpostorNode;99;-1408,-256;Inherit;False;9710;Octahedron;False;True;True;14;18;17;16;5;15;13;8;1;2;12;11;10;7;6;9;19;2;Specular;False;9;0;SAMPLER2D;;False;1;SAMPLER2D;;False;2;SAMPLER2D;;False;3;SAMPLER2D;;False;4;SAMPLER2D;;False;5;SAMPLER2D;;False;6;SAMPLER2D;;False;7;SAMPLER2D;;False;8;SAMPLERSTATE;;False;17;FLOAT4;8;FLOAT4;9;FLOAT4;10;FLOAT4;11;FLOAT4;12;FLOAT4;13;FLOAT4;14;FLOAT4;15;FLOAT3;0;FLOAT3;1;FLOAT3;2;FLOAT3;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT3;7;FLOAT3;16
Node;AmplifyShaderEditor.FunctionNode;367;-1664,512;Inherit;False;Define IS SHADER TYPE;-1;;53486;90bdd02d483309144a404aee7f41383d;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;111;-1664,-640;Half;False;Property;_ImpostorCat;[ Impostor Cat ];0;0;Create;True;0;0;0;True;1;StyledCategory(Impostor Settings, 5, 10);False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;354;-1152,-640;Half;False;Property;_subsurface_shadow;_subsurface_shadow;140;1;[HideInInspector];Create;True;0;0;0;True;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;395;-1408,512;Inherit;False;Define FEATURES UNIVERSAL AI;-1;;53485;ba69d246da7a8ba47a16a174259c237e;0;0;1;FLOAT;529
Node;AmplifyShaderEditor.FunctionNode;393;-768,-640;Inherit;False;Compile Impostors;-1;;53484;1cfd52e266bd86c47a094d0358cb5b93;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;392;-576,-640;Inherit;False;Compile All Shaders;-1;;53483;e67c8238031dbf04ab79a5d4d63d1b4f;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;385;-1024,-256;Inherit;False;Base Impostor;20;;53398;47a437226c28ea34bad309b04e5582cd;32,4299,0,4398,1,4399,1,4400,1,4404,1,4405,1,4406,1,4412,1,4410,1,4020,1,4010,1,3868,1,4338,1,4336,1,3881,1,3891,1,4416,1,4434,1,1745,1,3479,0,3707,1,3697,1,3946,1,3952,0,3947,1,1742,0,3484,0,860,1,3544,1,2260,1,2261,1,4186,0;7;3592;COLOR;0,0,0,0;False;4370;COLOR;0,0,0,0;False;3583;FLOAT3;0,0,0;False;3574;FLOAT3;0,0,0;False;3577;FLOAT;0;False;3563;FLOAT3;0,0,0;False;3964;FLOAT3;0,0,0;False;15;FLOAT3;3597;FLOAT3;3594;FLOAT3;4372;FLOAT;4373;FLOAT;3595;FLOAT;4119;FLOAT;3598;FLOAT;3980;FLOAT3;3974;FLOAT;3973;FLOAT;3975;FLOAT;4334;FLOAT;3593;FLOAT;4335;FLOAT3;534
Node;AmplifyShaderEditor.RangedFloatNode;108;-1408,-640;Half;False;Property;_IsVegetationShader;_IsVegetationShader;141;1;[HideInInspector];Create;True;0;0;0;True;0;False;1;1;1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;390;-592,-256;Float;False;False;-1;2;ASEMaterialInspector;0;1;New Amplify Shader;4e5791d7c677cf540a160f0a09e2385a;True;SceneSelectionPass;0;3;SceneSelectionPass;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;2;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;0;False;-1;False;False;False;False;False;False;False;False;False;True;1;False;-1;False;False;True;1;LightMode=SceneSelectionPass;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;391;-592,-256;Float;False;False;-1;2;ASEMaterialInspector;0;1;New Amplify Shader;4e5791d7c677cf540a160f0a09e2385a;True;Meta;0;4;Meta;1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;2;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=Meta;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;388;-592,-256;Float;False;False;-1;2;ASEMaterialInspector;0;1;New Amplify Shader;4e5791d7c677cf540a160f0a09e2385a;True;ShadowCaster;0;1;ShadowCaster;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;2;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;False;-1;True;3;False;-1;False;True;1;LightMode=ShadowCaster;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;387;-592,-256;Float;False;True;-1;2;TVEAIShaderGUI;0;19;BOXOPHOBIC/The Vegetation Engine/Impostors/Vegetation Subsurface Lit (Octahedorn);4e5791d7c677cf540a160f0a09e2385a;True;Base;0;0;Base;13;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;ImpostorType=Octahedron;True;4;0;False;True;1;1;False;-1;0;False;-1;0;1;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;LightMode=UniversalForward;False;0;;0;0;Standard;11;Material Type,InvertActionOnDeselection;1;Receive Shadows;1;Transmission;1;  Transmission Shadow;0.5,True,354;Translucency;0;  Translucency Strength;1,False,-1;  Normal Distortion;0.5,False,-1;  Scattering;2,False,-1;  Direct;0.9,False,-1;  Ambient;0.1,False,-1;  Shadow;0.5,False,-1;1;_FinalColorxAlpha;0;5;True;True;True;True;True;False;;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;389;-592,-256;Float;False;False;-1;2;ASEMaterialInspector;0;1;New Amplify Shader;4e5791d7c677cf540a160f0a09e2385a;True;DepthOnly;0;2;DepthOnly;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Opaque=RenderType;Queue=Geometry=Queue=0;True;2;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;0;False;-1;False;False;False;False;False;False;False;False;False;True;1;False;-1;False;False;True;1;LightMode=DepthOnly;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.CommentaryNode;301;-1664,384;Inherit;False;1279.438;100;Features;0;;0,1,0.5,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;300;-1664,-384;Inherit;False;1279.896;100;Final;0;;0,1,0.5,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;299;-1664,-768;Inherit;False;1282.438;100;Internal;0;;1,0.252,0,1;0;0
WireConnection;99;0;101;0
WireConnection;99;1;394;0
WireConnection;385;3592;99;8
WireConnection;385;4370;99;9
WireConnection;385;3583;99;0
WireConnection;385;3574;99;1
WireConnection;385;3577;99;6
WireConnection;385;3563;99;7
WireConnection;385;3964;99;16
WireConnection;387;0;385;3597
WireConnection;387;1;385;3594
WireConnection;387;2;385;4372
WireConnection;387;9;385;4119
WireConnection;387;4;385;3598
WireConnection;387;14;385;3974
WireConnection;387;6;385;3593
WireConnection;387;8;385;534
ASEEND*/
//CHKSM=767F718FC76ABD2FC3F754C3EDB2231155980A00
