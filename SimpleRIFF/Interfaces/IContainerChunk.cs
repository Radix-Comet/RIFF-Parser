using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRIFF.Interfaces
{
    /// <summary>
    /// For Chunks that can contain subchunks, AKA only 'LIST' and 'RIFF'/'RIFX'
    /// </summary>
    public interface IContainerChunk : IGenericChunk
    {
        public ChunkCollection Children { get; }
    }
}
