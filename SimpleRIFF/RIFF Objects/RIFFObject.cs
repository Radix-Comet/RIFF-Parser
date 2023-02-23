using SimpleRIFF.Interfaces;
using SimpleRIFF.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRIFF.RIFF_Objects
{
    public class RIFFObject : IContainerChunk
    {
        public RIFFObject()
        {
            Children = new ChunkCollection(this);
            this.Parent = null;
        }
        public ChunkCollection Children { get; private set; }

        public IContainerChunk? Parent { get; private set; }

        public CharacterCode CharacterCode { get; private set; }
        public CharacterCode FormType { get; private set; }
        public void Read(RIFFStream baseStream)
        {
            CharacterCode = baseStream.ReadCharacterCode();

            var size = baseStream.ReadInt32();

            var initialReadPosition = baseStream.Position;

            FormType = baseStream.ReadCharacterCode();

            while (baseStream.Position < initialReadPosition + size)
            {
                var peekedCharCode = baseStream.PeekCharacterCode();

                if (peekedCharCode.Code == "LIST")
                {
                    RIFFListObject chunk = new RIFFListObject(this);
                    chunk.Read(baseStream);
                    this.Children.Add(chunk);
                }
                else
                {
                    RIFFGenericDataObject chunk = new RIFFGenericDataObject(this);
                    chunk.Read(baseStream);
                    this.Children.Add(chunk);
                }
            }
        }
    }
}
