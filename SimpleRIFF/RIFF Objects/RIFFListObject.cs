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
        public RIFFListObject(IContainerChunk parent)
        {
            Children = new ChunkCollection(this);
            this.Parent = parent;
        }
        public ChunkCollection Children { get; private set; }

        public IContainerChunk? Parent { get; internal set; }

        public CharacterCode CharacterCode { get; private set; }

        public CharacterCode ListType { get; private set; }
        public void Read(RIFFStream baseStream)
        {
            CharacterCode = baseStream.ReadCharacterCode();

            var size = baseStream.ReadInt32();

            var initialReadPosition = baseStream.Position;

            ListType = baseStream.ReadCharacterCode();

            Console.WriteLine($"Starting read at {initialReadPosition.ToString("X")}, expected end is ${(initialReadPosition + size).ToString("X")}, reported size of {size.ToString("X")}");
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
