using SimpleRIFF.Interfaces;
using SimpleRIFF.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRIFF.RIFF_Objects
{
    public class RIFFGenericDataChunk : IDataChunk
    {
        public RIFFGenericDataChunk(IContainerChunk parent, CharacterCode characterCode)
        {
            this.Parent = parent;
            this.CharacterCode = characterCode;
        }
        public IContainerChunk? Parent { get; internal set; }

        public CharacterCode CharacterCode { get; set; }

        public byte[] Data { get; set; } = Array.Empty<byte>();

        public void Read(RIFFStream baseStream)
        {
            CharacterCode = baseStream.ReadCharacterCode();

            var size = baseStream.ReadInt32();

            Data = new byte[size];

            baseStream.Read(Data, 0, size);
        }
    }
}
