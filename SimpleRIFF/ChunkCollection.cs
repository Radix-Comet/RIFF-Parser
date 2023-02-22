using SimpleRIFF.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRIFF
{
    public class ChunkCollection : ICollection<IGenericChunk>
    {
        private List<IGenericChunk> _chunks = new();
        private IContainerChunk? _hostContainer = null;

        public ChunkCollection(IContainerChunk host)
        {
            _hostContainer = host;
        }
        public int Count => ((ICollection<IGenericChunk>)_chunks).Count;

        public bool IsReadOnly => ((ICollection<IGenericChunk>)_chunks).IsReadOnly;

        public void Add(IGenericChunk item)
        {
            item.Parent = _hostContainer;
            ((ICollection<IGenericChunk>)_chunks).Add(item);
        }

        public void Clear()
        {
            ((ICollection<IGenericChunk>)_chunks).Clear();
        }

        public bool Contains(IGenericChunk item)
        {
            return ((ICollection<IGenericChunk>)_chunks).Contains(item);
        }

        public void CopyTo(IGenericChunk[] array, int arrayIndex)
        {
            ((ICollection<IGenericChunk>)_chunks).CopyTo(array, arrayIndex);
        }

        public IEnumerator<IGenericChunk> GetEnumerator()
        {
            return ((IEnumerable<IGenericChunk>)_chunks).GetEnumerator();
        }

        public bool Remove(IGenericChunk item)
        {
            return ((ICollection<IGenericChunk>)_chunks).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_chunks).GetEnumerator();
        }
    }
}
