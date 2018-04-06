//------------------------------------------------------------------------------
// This file is part of MistLand project in Nirvana.
// Copyright © 2016-2016 Nirvana Technology Co., Ltd.
// All Right Reserved.
//------------------------------------------------------------------------------

#ifndef SHADERREQUIREMENT_INCLUDED
#define SHADERREQUIREMENT_INCLUDED

#ifdef REQUIRE_PS_WORLD_POSITION
#   ifndef REQUIRE_VS_WORLD_POSITION
#   define REQUIRE_VS_WORLD_POSITION
#   endif
#endif

#ifdef REQUIRE_VS_WORLD_POSITION
#   define CALCULATE_WORLD_POSITION worldPosition = mul(unity_ObjectToWorld, v.vertex);
#else
#   define CALCULATE_WORLD_POSITION
#endif

#ifdef REQUIRE_VS_WORLD_NORMAL
#   define CALCULATE_WORLD_NORMAL worldNormal = UnityObjectToWorldNormal(v.normal);
#else
#   define CALCULATE_WORLD_NORMAL
#endif

#ifdef REQUIRE_PS_WORLD_POSITION
#   define SHADER_REQUIREMENT_COORDS(idx) \
        float4 worldPosition : TEXCOORD##idx;
#else
#   define SHADER_REQUIREMENT_COORDS(idx)
#endif

#ifdef REQUIRE_PS_WORLD_POSITION
#   define SHADER_TRANSFER_REQUIREMENT(o) \
        o.worldPosition = worldPosition;
#else
#   define SHADER_TRANSFER_REQUIREMENT(o)
#endif

#define CALCULATE_REQUIREMENT \
    float4 worldPosition; \
    half3 worldNormal; \
    CALCULATE_WORLD_POSITION \
    CALCULATE_WORLD_NORMAL

#endif