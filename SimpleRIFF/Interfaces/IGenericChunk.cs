using SimpleRIFF.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRIFF.Interfaces
{
    /// <summary>
    /// Generic Chunk Interface
    /// </summary>
    public interface IGenericChunk
    { 
        public IContainerChunk? Parent { get; }

        /// <summary>
        /// The Chunk Identifier
        /// </summary>
        public CharacterCode CharacterCode { get; }
        
        public bool IsRIFF => Parent == null && (CharacterCode.Code == "RIFF" || CharacterCode.Code == "RIFX");
        public bool IsList => CharacterCode.Code == "LIST";

        void Read(RIFFStream baseStream);
    }

}
