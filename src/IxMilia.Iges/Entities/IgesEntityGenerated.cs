﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System.Collections.Generic;
using System.Linq;
using IxMilia.Iges.Directory;

namespace IxMilia.Iges.Entities
{
    public enum IgesEntityType
    {
        Null = 0,
        CircularArc = 100,
        Line = 110,
        Point = 116,
        Direction = 123,
        TransformationMatrix = 124,
        Sphere = 158,
        Torus = 160,
        SubfigureDefinition = 308,
        SingularSubfigureInstance = 408,
    }

    public partial class IgesEntity
    {
        internal static IgesEntity FromData(IgesDirectoryData directoryData, List<string> parameters)
        {
            IgesEntity entity = null;
            switch (directoryData.EntityType)
            {
                case IgesEntityType.CircularArc:
                    entity = new IgesCircularArc();
                    break;
                case IgesEntityType.Direction:
                    entity = new IgesDirection();
                    break;
                case IgesEntityType.Line:
                    entity = new IgesLine();
                    break;
                case IgesEntityType.Null:
                    entity = new IgesNull();
                    break;
                case IgesEntityType.Point:
                    entity = new IgesLocation();
                    break;
                case IgesEntityType.SingularSubfigureInstance:
                    entity = new IgesSingularSubfigureInstance();
                    break;
                case IgesEntityType.Sphere:
                    entity = new IgesSphere();
                    break;
                case IgesEntityType.SubfigureDefinition:
                    entity = new IgesSubfigureDefinition();
                    break;
                case IgesEntityType.Torus:
                    entity = new IgesTorus();
                    break;
                case IgesEntityType.TransformationMatrix:
                    entity = new IgesTransformationMatrix();
                    break;
            }

            if (entity != null)
            {
                entity.PopulateDirectoryData(directoryData);
                entity.ReadParameters(parameters);
            }

            return entity;
        }
    }

    /// <summary>
    /// IgesNull class
    /// </summary>
    public partial class IgesNull : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Null; } }

        // properties

        public IgesNull()
            : base()
        {
        }

        protected override void ReadParameters(List<string> parameters)
        {
        }

        protected override void WriteParameters(List<object> parameters)
        {
        }
    }

    /// <summary>
    /// IgesCircularArc class
    /// </summary>
    public partial class IgesCircularArc : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.CircularArc; } }

        // properties
        public double PlaneDisplacement { get; set; }
        public IgesPoint Center { get; set; }
        public IgesPoint StartPoint { get; set; }
        public IgesPoint EndPoint { get; set; }

        // custom properties
        public IgesPoint ProperCenter
        {
            get
            {
                return new IgesPoint(Center.X, Center.Y, PlaneDisplacement);
            }
        }

        public IgesPoint ProperStartPoint
        {
            get
            {
                return new IgesPoint(StartPoint.X, StartPoint.Y, PlaneDisplacement);
            }
        }

        public IgesPoint ProperEndPoint
        {
            get
            {
                return new IgesPoint(EndPoint.X, EndPoint.Y, PlaneDisplacement);
            }
        }

        public IgesCircularArc()
            : base()
        {
            this.PlaneDisplacement = 0.0;
            this.Center = IgesPoint.Origin;
            this.StartPoint = IgesPoint.Origin;
            this.EndPoint = IgesPoint.Origin;
        }

        protected override void ReadParameters(List<string> parameters)
        {
            int index = 0;
            this.PlaneDisplacement = Double(parameters[index++]);
            this.Center.X = Double(parameters[index++]);
            this.Center.Y = Double(parameters[index++]);
            this.StartPoint.X = Double(parameters[index++]);
            this.StartPoint.Y = Double(parameters[index++]);
            this.EndPoint.X = Double(parameters[index++]);
            this.EndPoint.Y = Double(parameters[index++]);
        }

        protected override void WriteParameters(List<object> parameters)
        {
            parameters.Add(this.PlaneDisplacement);
            parameters.Add(this.Center.X);
            parameters.Add(this.Center.Y);
            parameters.Add(this.StartPoint.X);
            parameters.Add(this.StartPoint.Y);
            parameters.Add(this.EndPoint.X);
            parameters.Add(this.EndPoint.Y);
        }
    }

    /// <summary>
    /// IgesLine class
    /// </summary>
    public partial class IgesLine : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Line; } }

        // properties
        public IgesPoint P1 { get; set; }
        public IgesPoint P2 { get; set; }

        // custom properties
        public override int LineCount
        {
            get
            {
                return 1;
            }
        }

        public IgesBounding Bounding
        {
            get
            {
                return (IgesBounding)FormNumber;
            }
            set
            {
                FormNumber = (int)value;
            }
        }

        public IgesLine()
            : base()
        {
            this.P1 = IgesPoint.Origin;
            this.P2 = IgesPoint.Origin;
        }

        protected override void ReadParameters(List<string> parameters)
        {
            int index = 0;
            this.P1.X = Double(parameters[index++]);
            this.P1.Y = Double(parameters[index++]);
            this.P1.Z = Double(parameters[index++]);
            this.P2.X = Double(parameters[index++]);
            this.P2.Y = Double(parameters[index++]);
            this.P2.Z = Double(parameters[index++]);
        }

        protected override void WriteParameters(List<object> parameters)
        {
            parameters.Add(this.P1.X);
            parameters.Add(this.P1.Y);
            parameters.Add(this.P1.Z);
            parameters.Add(this.P2.X);
            parameters.Add(this.P2.Y);
            parameters.Add(this.P2.Z);
        }
    }

    /// <summary>
    /// IgesLocation class
    /// </summary>
    public partial class IgesLocation : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Point; } }

        // properties
        public IgesPoint Location { get; set; }

        public IgesLocation()
            : base()
        {
            this.Location = IgesPoint.Origin;
        }

        protected override void ReadParameters(List<string> parameters)
        {
            int index = 0;
            this.Location.X = Double(parameters[index++]);
            this.Location.Y = Double(parameters[index++]);
            this.Location.Z = Double(parameters[index++]);
        }

        protected override void WriteParameters(List<object> parameters)
        {
            parameters.Add(this.Location.X);
            parameters.Add(this.Location.Y);
            parameters.Add(this.Location.Z);
        }
    }

    /// <summary>
    /// IgesDirection class
    /// </summary>
    public partial class IgesDirection : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Direction; } }

        // properties
        public IgesVector Direction { get; set; }

        public IgesDirection()
            : base()
        {
            this.Direction = IgesVector.ZAxis;
        }

        protected override void ReadParameters(List<string> parameters)
        {
            int index = 0;
            this.Direction.X = Double(parameters[index++]);
            this.Direction.Y = Double(parameters[index++]);
            this.Direction.Z = Double(parameters[index++]);
        }

        protected override void WriteParameters(List<object> parameters)
        {
            parameters.Add(this.Direction.X);
            parameters.Add(this.Direction.Y);
            parameters.Add(this.Direction.Z);
        }
    }

    /// <summary>
    /// IgesTransformationMatrix class
    /// </summary>
    public partial class IgesTransformationMatrix : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.TransformationMatrix; } }

        // properties
        public double R11 { get; set; }
        public double R12 { get; set; }
        public double R13 { get; set; }
        public double T1 { get; set; }
        public double R21 { get; set; }
        public double R22 { get; set; }
        public double R23 { get; set; }
        public double T2 { get; set; }
        public double R31 { get; set; }
        public double R32 { get; set; }
        public double R33 { get; set; }
        public double T3 { get; set; }

        public IgesTransformationMatrix()
            : base()
        {
            this.R11 = 0.0;
            this.R12 = 0.0;
            this.R13 = 0.0;
            this.T1 = 0.0;
            this.R21 = 0.0;
            this.R22 = 0.0;
            this.R23 = 0.0;
            this.T2 = 0.0;
            this.R31 = 0.0;
            this.R32 = 0.0;
            this.R33 = 0.0;
            this.T3 = 0.0;
        }

        protected override void ReadParameters(List<string> parameters)
        {
            int index = 0;
            this.R11 = Double(parameters[index++]);
            this.R12 = Double(parameters[index++]);
            this.R13 = Double(parameters[index++]);
            this.T1 = Double(parameters[index++]);
            this.R21 = Double(parameters[index++]);
            this.R22 = Double(parameters[index++]);
            this.R23 = Double(parameters[index++]);
            this.T2 = Double(parameters[index++]);
            this.R31 = Double(parameters[index++]);
            this.R32 = Double(parameters[index++]);
            this.R33 = Double(parameters[index++]);
            this.T3 = Double(parameters[index++]);
        }

        protected override void WriteParameters(List<object> parameters)
        {
            parameters.Add(this.R11);
            parameters.Add(this.R12);
            parameters.Add(this.R13);
            parameters.Add(this.T1);
            parameters.Add(this.R21);
            parameters.Add(this.R22);
            parameters.Add(this.R23);
            parameters.Add(this.T2);
            parameters.Add(this.R31);
            parameters.Add(this.R32);
            parameters.Add(this.R33);
            parameters.Add(this.T3);
        }
    }

    /// <summary>
    /// IgesSphere class
    /// </summary>
    public partial class IgesSphere : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Sphere; } }

        // properties
        public double Radius { get; set; }
        public IgesPoint Center { get; set; }

        public IgesSphere()
            : base()
        {
            this.Radius = 0.0;
            this.Center = IgesPoint.Origin;
        }

        protected override void ReadParameters(List<string> parameters)
        {
            int index = 0;
            this.Radius = Double(parameters[index++]);
            this.Center.X = Double(ReadParameterOrDefault(parameters, index++, "0.0"));
            this.Center.Y = Double(ReadParameterOrDefault(parameters, index++, "0.0"));
            this.Center.Z = Double(ReadParameterOrDefault(parameters, index++, "0.0"));
        }

        protected override void WriteParameters(List<object> parameters)
        {
            parameters.Add(this.Radius);
            if (Center.X != 0.0) parameters.Add(this.Center.X);
            if (Center.Y != 0.0) parameters.Add(this.Center.Y);
            if (Center.Z != 0.0) parameters.Add(this.Center.Z);
        }
    }

    /// <summary>
    /// IgesTorus class
    /// </summary>
    public partial class IgesTorus : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.Torus; } }

        // properties
        public double RingRadius { get; set; }
        public double DiscRadius { get; set; }
        public IgesPoint Center { get; set; }
        public IgesVector Normal { get; set; }

        public IgesTorus()
            : base()
        {
            this.RingRadius = 0.0;
            this.DiscRadius = 0.0;
            this.Center = IgesPoint.Origin;
            this.Normal = IgesVector.ZAxis;
        }

        protected override void ReadParameters(List<string> parameters)
        {
            int index = 0;
            this.RingRadius = Double(parameters[index++]);
            this.DiscRadius = Double(parameters[index++]);
            this.Center.X = Double(ReadParameterOrDefault(parameters, index++, "0.0"));
            this.Center.Y = Double(ReadParameterOrDefault(parameters, index++, "0.0"));
            this.Center.Z = Double(ReadParameterOrDefault(parameters, index++, "0.0"));
            this.Normal.X = Double(ReadParameterOrDefault(parameters, index++, "0.0"));
            this.Normal.Y = Double(ReadParameterOrDefault(parameters, index++, "0.0"));
            this.Normal.Z = Double(ReadParameterOrDefault(parameters, index++, "1.0"));
        }

        protected override void WriteParameters(List<object> parameters)
        {
            parameters.Add(this.RingRadius);
            parameters.Add(this.DiscRadius);
            if (Center.X != 0.0) parameters.Add(this.Center.X);
            if (Center.Y != 0.0) parameters.Add(this.Center.Y);
            if (Center.Z != 0.0) parameters.Add(this.Center.Z);
            if (Normal.X != 0.0) parameters.Add(this.Normal.X);
            if (Normal.Y != 0.0) parameters.Add(this.Normal.Y);
            if (Normal.Z != 1.0) parameters.Add(this.Normal.Z);
        }
    }

    /// <summary>
    /// IgesSubfigureDefinition class
    /// </summary>
    public partial class IgesSubfigureDefinition : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.SubfigureDefinition; } }

        // properties
        public int Depth { get; set; }
        public string Name { get; set; }
        private int EntityCount { get; set; }

        // custom properties
        public List<IgesEntity> Entities
        {
            get
            {
                return SubEntities;
            }
        }

        public IgesSubfigureDefinition()
            : base()
        {
            this.Depth = 0;
            this.Name = null;
            this.EntityCount = 0;
        }

        protected override void ReadParameters(List<string> parameters)
        {
            int index = 0;
            this.Depth = Integer(parameters[index++]);
            this.Name = String(parameters[index++]);
            this.EntityCount = Integer(parameters[index++]);
            for (int i = 0; i < EntityCount; i++)
            {
                this.SubEntityIndices.Add(Integer(parameters[index++]));
            }

        }

        protected override void WriteParameters(List<object> parameters)
        {
            parameters.Add(this.Depth);
            parameters.Add(this.Name);
            parameters.Add(this.Entities.Count);
            parameters.AddRange(this.SubEntityIndices.Cast<object>());
        }
    }

    /// <summary>
    /// IgesSingularSubfigureInstance class
    /// </summary>
    public partial class IgesSingularSubfigureInstance : IgesEntity
    {
        public override IgesEntityType EntityType { get { return IgesEntityType.SingularSubfigureInstance; } }

        // properties
        public IgesVector Offset { get; set; }
        public double Scale { get; set; }

        // custom properties
        public IgesEntity Subfigure
        {
            get
            {
                return SubEntities.Count == 0 ? null : SubEntities[0];
            }
            set
            {
                if (SubEntities.Count == 0) SubEntities.Add(value);
                else SubEntities[0] = value;
            }
        }

        public IgesSingularSubfigureInstance()
            : base()
        {
            this.Offset = IgesVector.Zero;
            this.Scale = 1.0;
        }

        protected override void ReadParameters(List<string> parameters)
        {
            int index = 0;
            for (int i = 0; i < 1; i++)
            {
                this.SubEntityIndices.Add(Integer(parameters[index++]));
            }

            this.Offset.X = Double(parameters[index++]);
            this.Offset.Y = Double(parameters[index++]);
            this.Offset.Z = Double(parameters[index++]);
            this.Scale = Double(ReadParameterOrDefault(parameters, index++, "1.0"));
        }

        protected override void WriteParameters(List<object> parameters)
        {
            parameters.AddRange(this.SubEntityIndices.Cast<object>());
            parameters.Add(this.Offset.X);
            parameters.Add(this.Offset.Y);
            parameters.Add(this.Offset.Z);
            if (Scale != 1.0) parameters.Add(this.Scale);
        }
    }

}
