// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: modules/planning/proto/spiral_curve_config.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Apollo.Planning {

  /// <summary>Holder for reflection information generated from modules/planning/proto/spiral_curve_config.proto</summary>
  public static partial class SpiralCurveConfigReflection {

    #region Descriptor
    /// <summary>File descriptor for modules/planning/proto/spiral_curve_config.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SpiralCurveConfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjBtb2R1bGVzL3BsYW5uaW5nL3Byb3RvL3NwaXJhbF9jdXJ2ZV9jb25maWcu",
            "cHJvdG8SD2Fwb2xsby5wbGFubmluZyJmChFTcGlyYWxDdXJ2ZUNvbmZpZxIU",
            "CgxzaW1wc29uX3NpemUYASABKAUSGgoSbmV3dG9uX3JhcGhzb25fdG9sGAIg",
            "ASgBEh8KF25ld3Rvbl9yYXBoc29uX21heF9pdGVyGAMgASgFYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Apollo.Planning.SpiralCurveConfig), global::Apollo.Planning.SpiralCurveConfig.Parser, new[]{ "SimpsonSize", "NewtonRaphsonTol", "NewtonRaphsonMaxIter" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SpiralCurveConfig : pb::IMessage<SpiralCurveConfig> {
    private static readonly pb::MessageParser<SpiralCurveConfig> _parser = new pb::MessageParser<SpiralCurveConfig>(() => new SpiralCurveConfig());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SpiralCurveConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Apollo.Planning.SpiralCurveConfigReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SpiralCurveConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SpiralCurveConfig(SpiralCurveConfig other) : this() {
      simpsonSize_ = other.simpsonSize_;
      newtonRaphsonTol_ = other.newtonRaphsonTol_;
      newtonRaphsonMaxIter_ = other.newtonRaphsonMaxIter_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SpiralCurveConfig Clone() {
      return new SpiralCurveConfig(this);
    }

    /// <summary>Field number for the "simpson_size" field.</summary>
    public const int SimpsonSizeFieldNumber = 1;
    private int simpsonSize_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int SimpsonSize {
      get { return simpsonSize_; }
      set {
        simpsonSize_ = value;
      }
    }

    /// <summary>Field number for the "newton_raphson_tol" field.</summary>
    public const int NewtonRaphsonTolFieldNumber = 2;
    private double newtonRaphsonTol_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double NewtonRaphsonTol {
      get { return newtonRaphsonTol_; }
      set {
        newtonRaphsonTol_ = value;
      }
    }

    /// <summary>Field number for the "newton_raphson_max_iter" field.</summary>
    public const int NewtonRaphsonMaxIterFieldNumber = 3;
    private int newtonRaphsonMaxIter_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int NewtonRaphsonMaxIter {
      get { return newtonRaphsonMaxIter_; }
      set {
        newtonRaphsonMaxIter_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SpiralCurveConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SpiralCurveConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (SimpsonSize != other.SimpsonSize) return false;
      if (NewtonRaphsonTol != other.NewtonRaphsonTol) return false;
      if (NewtonRaphsonMaxIter != other.NewtonRaphsonMaxIter) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (SimpsonSize != 0) hash ^= SimpsonSize.GetHashCode();
      if (NewtonRaphsonTol != 0D) hash ^= NewtonRaphsonTol.GetHashCode();
      if (NewtonRaphsonMaxIter != 0) hash ^= NewtonRaphsonMaxIter.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (SimpsonSize != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(SimpsonSize);
      }
      if (NewtonRaphsonTol != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(NewtonRaphsonTol);
      }
      if (NewtonRaphsonMaxIter != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(NewtonRaphsonMaxIter);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (SimpsonSize != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SimpsonSize);
      }
      if (NewtonRaphsonTol != 0D) {
        size += 1 + 8;
      }
      if (NewtonRaphsonMaxIter != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(NewtonRaphsonMaxIter);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SpiralCurveConfig other) {
      if (other == null) {
        return;
      }
      if (other.SimpsonSize != 0) {
        SimpsonSize = other.SimpsonSize;
      }
      if (other.NewtonRaphsonTol != 0D) {
        NewtonRaphsonTol = other.NewtonRaphsonTol;
      }
      if (other.NewtonRaphsonMaxIter != 0) {
        NewtonRaphsonMaxIter = other.NewtonRaphsonMaxIter;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            SimpsonSize = input.ReadInt32();
            break;
          }
          case 17: {
            NewtonRaphsonTol = input.ReadDouble();
            break;
          }
          case 24: {
            NewtonRaphsonMaxIter = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
