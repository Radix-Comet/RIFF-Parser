using SimpleRIFF.Interfaces;
using SimpleRIFF.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRIFF.RIFF_Objects
{
    public class RIFFListObject : IContainerChunk
    {
        public RIFFListObject()
        {
            Children = new ChunkCollection(this);
        }
        public ChunkCollection Children { get; private set; }

        public IContainerChunk? Parent => throw new NotImplementedException();

        public CharacterCode CharacterCode => throw new NotImplementedException();

        public void Read(RIFFStream baseStream)
        {
            CharacterCode = baseStream.ReadCharacterCode();

            var size = baseStream.ReadInt32();

            Data = new byte[size];

            baseStream.Read(Data, 0, size);
        }

        public void Read(RIFFStream baseStream)
        {
            throw new NotImplementedException();
        }
    }
}
