/**
 * Autogenerated by Thrift Compiler (0.13.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */

using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Collections;

using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;


namespace Jaeger.Thrift
{

  public partial class Process : TBase
  {
    private List<Tag> _tags;

    public string ServiceName { get; set; }

    public List<Tag> Tags
    {
      get
      {
        return _tags;
      }
      set
      {
        __isset.tags = true;
        this._tags = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool tags;
    }

    public Process()
    {
    }

    public Process(string serviceName) : this()
    {
      this.ServiceName = serviceName;
    }

    public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_serviceName = false;
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String)
              {
                ServiceName = await iprot.ReadStringAsync(cancellationToken);
                isset_serviceName = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.List)
              {
                {
                  TList _list16 = await iprot.ReadListBeginAsync(cancellationToken);
                  Tags = new List<Tag>(_list16.Count);
                  for(int _i17 = 0; _i17 < _list16.Count; ++_i17)
                  {
                    Tag _elem18;
                    _elem18 = new Tag();
                    await _elem18.ReadAsync(iprot, cancellationToken);
                    Tags.Add(_elem18);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default: 
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
        if (!isset_serviceName)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var struc = new TStruct("Process");
        await oprot.WriteStructBeginAsync(struc, cancellationToken);
        var field = new TField();
        field.Name = "serviceName";
        field.Type = TType.String;
        field.ID = 1;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteStringAsync(ServiceName, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
        if (Tags != null && __isset.tags)
        {
          field.Name = "tags";
          field.Type = TType.List;
          field.ID = 2;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.Struct, Tags.Count), cancellationToken);
            foreach (Tag _iter19 in Tags)
            {
              await _iter19.WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteListEndAsync(cancellationToken);
          }
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object that)
    {
      var other = that as Process;
      if (other == null) return false;
      if (ReferenceEquals(this, other)) return true;
      return System.Object.Equals(ServiceName, other.ServiceName)
        && ((__isset.tags == other.__isset.tags) && ((!__isset.tags) || (TCollections.Equals(Tags, other.Tags))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        hashcode = (hashcode * 397) + ServiceName.GetHashCode();
        if(__isset.tags)
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Tags);
      }
      return hashcode;
    }

    public override string ToString()
    {
      var sb = new StringBuilder("Process(");
      sb.Append(", ServiceName: ");
      sb.Append(ServiceName);
      if (Tags != null && __isset.tags)
      {
        sb.Append(", Tags: ");
        sb.Append(Tags);
      }
      sb.Append(")");
      return sb.ToString();
    }
  }

}