using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRIFF
{
    public struct CharacterCode
    {
        public CharacterCode()
        {

        }

        public CharacterCode(byte[] data)
        {
            if (data.Length > 4)
                _data = data;
        }

        private byte[] _data = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

        public string Code
        {
            get => _data.ToString()!;
            set
            {
                _data[0] = (byte)value[0];
                _data[1] = (byte)value[1];
                _data[2] = (byte)value[2];
                _data[3] = (byte)value[3];
            }

        }

        public override bool Equals(object? obj)
        {
            // Can't be the same if we are null can we?
            if (obj == null)
                return false;

            // Can't be the same if we aren't the same type can we?
            if (obj.GetType() != typeof(CharacterCode)) 
                return false;

            if (this._data == ((CharacterCode)obj)._data)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_data, Code);
        }

        public override string ToString() => $"{_data[0]}{_data[1]}{_data[2]}{_data[3]}";

        public static bool operator ==(CharacterCode left, CharacterCode right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CharacterCode left, CharacterCode right)
        {
            return !(left == right);
        }
    }
}
