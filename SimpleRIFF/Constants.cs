namespace SimpleRIFF
{
    public static class Constants
    {
        public static class CharacterCodes
        {
            /// <summary>
            ///  Specifies a RIFF file in Little-Endian byte format
            /// </summary>
            public const string RIFFLittleEndianCode = "RIFF";

            /// <summary>
            ///  Specifies a RIFF file in Big-Endian byte format
            /// </summary>
            public const string RIFFBigEndianCode = "RIFX";

            /// <summary>
            /// Specifies a list chunk
            /// </summary>
            public const string ListCode = "LIST";
        }
    }
}