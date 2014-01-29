using System;
using System.Runtime.Serialization;

namespace Deploy.DataContracts
{
    [DataContract]
    public class DeployInfo : IDisposable
    {
        [DataMember]
        public string FileName;

        [DataMember]
        public long Length;

        [DataMember]
        public byte TeamId;

        [DataMember]
        public byte PlayerId;

        [DataMember]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream == null) return;
            FileByteStream.Close();
            FileByteStream = null;
        }
    }

    [DataContract]
    public class CancelDeployRequest
    {
        [DataMember]
        public string FileName;
    }

    [DataContract]
    public class UnDeployRequest
    {
        [DataMember]
        public byte PlayerId;
    }

    [DataContract]
    public class TeamUnDeployRequest
    {
        [DataMember]
        public byte TeamId;
    }
}