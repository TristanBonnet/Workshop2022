// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/NewSurfaceShader"
{
	Properties
	{
		_EdgeLength ( "Edge length", Range( 2, 50 ) ) = 15
		_T_Watson_Final_Watson_BaseMap("T_Watson_Final_Watson_BaseMap", 2D) = "white" {}
		_T_Watson_Final_Watson_MaskMap("T_Watson_Final_Watson_MaskMap", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "Tessellation.cginc"
		#pragma target 4.6
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc tessellate:tessFunction 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _T_Watson_Final_Watson_BaseMap;
		uniform float4 _T_Watson_Final_Watson_BaseMap_ST;
		uniform sampler2D _T_Watson_Final_Watson_MaskMap;
		uniform float4 _T_Watson_Final_Watson_MaskMap_ST;
		uniform float _EdgeLength;

		float4 tessFunction( appdata_full v0, appdata_full v1, appdata_full v2 )
		{
			return UnityEdgeLengthBasedTess (v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
		}

		void vertexDataFunc( inout appdata_full v )
		{
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_T_Watson_Final_Watson_BaseMap = i.uv_texcoord * _T_Watson_Final_Watson_BaseMap_ST.xy + _T_Watson_Final_Watson_BaseMap_ST.zw;
			o.Albedo = tex2D( _T_Watson_Final_Watson_BaseMap, uv_T_Watson_Final_Watson_BaseMap ).rgb;
			float2 uv_T_Watson_Final_Watson_MaskMap = i.uv_texcoord * _T_Watson_Final_Watson_MaskMap_ST.xy + _T_Watson_Final_Watson_MaskMap_ST.zw;
			float4 tex2DNode5 = tex2D( _T_Watson_Final_Watson_MaskMap, uv_T_Watson_Final_Watson_MaskMap );
			o.Metallic = tex2DNode5.r;
			o.Smoothness = tex2DNode5.b;
			o.Occlusion = tex2DNode5.g;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17400
7;288;1540;641;2202.558;714.3076;2.179733;True;True
Node;AmplifyShaderEditor.SamplerNode;4;-529.1976,-310.3734;Inherit;True;Property;_T_Watson_Final_Watson_BaseMap;T_Watson_Final_Watson_BaseMap;5;0;Create;True;0;0;False;0;-1;None;ce446ac80484ec54faf87a0c84a96467;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;5;-530.4597,-103.3907;Inherit;True;Property;_T_Watson_Final_Watson_MaskMap;T_Watson_Final_Watson_MaskMap;6;0;Create;True;0;0;False;0;-1;None;f114eac71bdb5b54bbff99fcf42ec219;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;35,-247;Float;False;True;-1;6;ASEMaterialInspector;0;0;Standard;Custom/NewSurfaceShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;True;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;0;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;0;0;4;0
WireConnection;0;3;5;1
WireConnection;0;4;5;3
WireConnection;0;5;5;2
ASEEND*/
//CHKSM=16905D5BD0ABD20F877BCC50B27B44FF9B08362D