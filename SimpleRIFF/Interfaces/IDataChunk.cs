using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRIFF.Interfaces
{
    /// <summary>
    /// For Chunks that can contain data
    /// </summary>
    public interface IDataChunk : IGenericChunk
    {
        public byte[] Data { get; }

    }
}
