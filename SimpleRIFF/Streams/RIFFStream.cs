using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRIFF.Streams
{
    public class RIFFStream : Stream
    {
        public enum Endianess
        {
            Little,
            Big
        }

        public RIFFStream(Stream baseStream, Endianess streamEndianess = Endianess.Little)
        {
            BaseStream = baseStream;
            StreamEndianess = streamEndianess;
        }

        public Stream BaseStream { get; set; }

        public Endianess StreamEndianess { get; private set; }
        
        public override bool CanRead => BaseStream.CanRead;

        public override bool CanSeek => BaseStream.CanSeek;

        public override bool CanWrite => BaseStream.CanWrite;

        public override long Length => BaseStream.Length;

        public override long Position { get => BaseStream.Position; set => BaseStream.Position = value; }

        public override void Flush()
        {
            BaseStream.Flush();
        }

        
        public override int Read(byte[] buffer, int offset, int count)
        {
            return BaseStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return BaseStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            BaseStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            BaseStream.Write(buffer, offset, count);
        }


        public CharacterCode ReadCharacterCode()
        {
            byte[] buffer = new byte[4];
            BaseStream.Read(buffer, 0, 4);
            return new CharacterCode(buffer);
        }
        public CharacterCode PeekCharacterCode()
        {
            byte[] buffer = new byte[4];
            BaseStream.Read(buffer, 0, 4);
            BaseStream.Position -= 4;
            return new CharacterCode(buffer);
        }
        public int ReadInt32()
        {
            byte[] buffer = new byte[4];
            BaseStream.Read(buffer, 0, 4);

            if (StreamEndianess == Endianess.Big)
                Array.Reverse(buffer);

            return ((int)buffer[0]) | ((int)buffer[1] << 8) | ((int)buffer[2] << 16) | ((int)buffer[3] << 24);
        }

        public void WriteInt32(int value)
        {
            byte[] buffer = new byte[4]
                {
                    (byte)((value & 0x000000FF) >> 00),
                    (byte)((value & 0x0000FF00) >> 08),
                    (byte)((value & 0x00FF0000) >> 16),
                    (byte)((value & 0xFF000000) >> 24)
                };
            if (StreamEndianess == Endianess.Big)
                Array.Reverse(buffer);

            Write(buffer, 0, 4);
        }
    }
}
