﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace IxMilia.Iges.Entities
{
    [Flags]
    public enum IgesDepthClipping
    {
        None = 0x00,
        BackClipping = 0x01,
        FrontClipping = 0x02,
        FrontAndBackClipping = BackClipping | FrontClipping
    }

    public class IgesPerspectiveView : IgesViewBase
    {
        public IgesPerspectiveView()
            : this(0, 0.0, IgesVector.Zero, IgesPoint.Origin, IgesPoint.Origin, IgesVector.Zero, 0.0, 0.0, 0.0, 0.0, 0.0, IgesDepthClipping.None, 0.0, 0.0)
        {
        }

        public IgesPerspectiveView(
            int viewNumber,
            double scaleFactor,
            IgesVector viewPlaneNormal,
            IgesPoint referencePoint,
            IgesPoint centerOfProjection,
            IgesVector upVector,
            double viewPlaneDistance,
            double leftClippingCoordinate,
            double rightClippingCoordinate,
            double bottomClippingCoordinate,
            double topClippingCoordinate,
            IgesDepthClipping depthClipping,
            double backClippingCoordinate,
            double frontClippingCoordinate)
            : base(viewNumber, scaleFactor)
        {
            this.FormNumber = 1;
            this.ViewPlaneNormal = viewPlaneNormal;
            this.ViewReferencePoint = referencePoint;
            this.CenterOfProjection = centerOfProjection;
            this.ViewUpVector = upVector;
            this.ViewPlaneDistance = viewPlaneDistance;
            this.ClippingWindowLeftCoordinate = leftClippingCoordinate;
            this.ClippingWindowRightCoordinate = rightClippingCoordinate;
            this.ClippingWindowBottomCoordinate = bottomClippingCoordinate;
            this.ClippingWindowTopCoordinate = topClippingCoordinate;
            this.DepthClipping = depthClipping;
            this.ClippingWindowBackCoordinate = backClippingCoordinate;
            this.ClippingWindowFrontCoordinate = frontClippingCoordinate;
        }

        public IgesVector ViewPlaneNormal { get; set; }
        public IgesPoint ViewReferencePoint { get; set; }
        public IgesPoint CenterOfProjection { get; set; }
        public IgesVector ViewUpVector { get; set; }
        public double ViewPlaneDistance { get; set; }
        public double ClippingWindowLeftCoordinate { get; set; }
        public double ClippingWindowRightCoordinate { get; set; }
        public double ClippingWindowBottomCoordinate { get; set; }
        public double ClippingWindowTopCoordinate { get; set; }
        public IgesDepthClipping DepthClipping { get; set; }
        public double ClippingWindowBackCoordinate { get; set; }
        public double ClippingWindowFrontCoordinate { get; set; }

        protected override int ReadParameters(List<string> parameters)
        {
            var nextIndex = base.ReadParameters(parameters);
            this.ViewPlaneNormal.X = Double(parameters, nextIndex);
            this.ViewPlaneNormal.Y = Double(parameters, nextIndex + 1);
            this.ViewPlaneNormal.Z = Double(parameters, nextIndex + 2);
            this.ViewReferencePoint.X = Double(parameters, nextIndex + 3);
            this.ViewReferencePoint.Y = Double(parameters, nextIndex + 4);
            this.ViewReferencePoint.Z = Double(parameters, nextIndex + 5);
            this.CenterOfProjection.X = Double(parameters, nextIndex + 6);
            this.CenterOfProjection.Y = Double(parameters, nextIndex + 7);
            this.CenterOfProjection.Z = Double(parameters, nextIndex + 8);
            this.ViewUpVector.X = Double(parameters, nextIndex + 9);
            this.ViewUpVector.Y = Double(parameters, nextIndex + 10);
            this.ViewUpVector.Z = Double(parameters, nextIndex + 11);
            this.ViewPlaneDistance = Double(parameters, nextIndex + 12);
            this.ClippingWindowLeftCoordinate = Double(parameters, nextIndex + 13);
            this.ClippingWindowRightCoordinate = Double(parameters, nextIndex + 14);
            this.ClippingWindowBottomCoordinate = Double(parameters, nextIndex + 15);
            this.ClippingWindowTopCoordinate = Double(parameters, nextIndex + 16);
            this.DepthClipping = (IgesDepthClipping)Integer(parameters, nextIndex + 17);
            this.ClippingWindowBackCoordinate = Double(parameters, nextIndex + 18);
            this.ClippingWindowFrontCoordinate = Double(parameters, nextIndex + 19);
            return nextIndex + 20;
        }

        protected override void WriteParameters(List<object> parameters)
        {
            base.WriteParameters(parameters);
            parameters.Add(ViewPlaneNormal.X);
            parameters.Add(ViewPlaneNormal.Y);
            parameters.Add(ViewPlaneNormal.Z);
            parameters.Add(ViewReferencePoint.X);
            parameters.Add(ViewReferencePoint.Y);
            parameters.Add(ViewReferencePoint.Z);
            parameters.Add(CenterOfProjection.X);
            parameters.Add(CenterOfProjection.Y);
            parameters.Add(CenterOfProjection.Z);
            parameters.Add(ViewUpVector.X);
            parameters.Add(ViewUpVector.Y);
            parameters.Add(ViewUpVector.Z);
            parameters.Add(ViewPlaneDistance);
            parameters.Add(ClippingWindowLeftCoordinate);
            parameters.Add(ClippingWindowRightCoordinate);
            parameters.Add(ClippingWindowBottomCoordinate);
            parameters.Add(ClippingWindowTopCoordinate);
            parameters.Add((int)DepthClipping);
            parameters.Add(ClippingWindowBackCoordinate);
            parameters.Add(ClippingWindowFrontCoordinate);
        }
    }
}
