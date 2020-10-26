//
// Radial Blur adapted from: 
// https://halisavakis.com/my-take-on-shaders-radial-blur
//
Shader "Hidden/RadialBlur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        // determines how many times the main texture will be sampled
        _Samples("Samples", Range(4, 32)) = 16
        // determines how intense the effect is going to be
        _EffectAmount("Effect amount", float) = 1
        // determines the center around which the radial blur will occur,
        // in screen space coordinates, now it is hard-coded to be center.
        _CenterX("Center X", float) = 0.5
        _CenterY("Center Y", float) = 0.5
        // determines the radius of the area that is unaffected by the blur.
        _Radius("Radius", float) = 10
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
             
            #include "UnityCG.cginc"
 
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
             
            sampler2D _MainTex;
            float _Samples;
            float _EffectAmount;
            float _CenterX;
            float _CenterY;
            float _Radius;
            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = fixed4(0,0,0,0);
                /** 
                 * for the current pixel, find its distance from the defined center,
                 * by subtracting the center of blur from the uv coordinates of the current pixel,
                 * the result vector is the direction incidate which way to offset each sample.
                 */
                float2 dist = i.uv - float2(_CenterX, _CenterY);
                // Sampling the camera's main texture a bunch of times,
                // result of each sampling will be added together.
                for(int j = 0; j < _Samples; j++) {
                    float scale = 1 - _EffectAmount * (j / _Samples)* (saturate(length(dist) / _Radius));
                    col += tex2D(_MainTex, dist * scale + float2(_CenterX, _CenterY));
                }
                col /= _Samples;
                return col;
            }
            ENDCG
        }
    }
}
