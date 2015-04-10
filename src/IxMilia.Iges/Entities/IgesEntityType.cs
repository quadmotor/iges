﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace IxMilia.Iges.Entities
{
    public enum IgesEntityType
    {
        Null = 0,
        CircularArc = 100,
        CompositeCurve = 102,
        Plane = 108,
        Line = 110,
        Point = 116,
        Direction = 123,
        TransformationMatrix = 124,
        Sphere = 158,
        Torus = 160,
        GeneralNote = 212,
        // 304
        SubfigureDefinition = 308,
        TextDisplayTemplate = 312,
        ColorDefinition = 314,
        AssociativityInstance = 402,
        // 406 form 1
        View = 410
    }
}
