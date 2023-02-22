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
        public string CharacterCode { get; }

    }

}
