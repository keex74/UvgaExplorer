// <copyright file="PngImageProperties.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace LibUvgaFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using static System.Net.Mime.MediaTypeNames;

    /// <summary>
    /// Implements a class that can decode properties about PNG images.
    /// </summary>
    public class PngImageProperties
    {
        /// <summary>
        /// Gets a value indicating whether the data is a valid PNG image.
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the data is supported in UVGA files.
        /// </summary>
        /// <remarks>Checks BPP and color type.</remarks>
        public bool IsSupported { get; private set; }

        /// <summary>
        /// Gets the image width.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the image height.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets the color type in the image.
        /// </summary>
        public PngColorType ColorType { get; private set; }

        /// <summary>
        /// Gets the bits per sample in the image.
        /// </summary>
        public int ColorBits { get; private set; }

        /// <summary>
        /// Gets the horizontal resolution in DPI.
        /// </summary>
        public int DPIx { get; private set; } = 96;

        /// <summary>
        /// Gets the vertical resolution in DPI.
        /// </summary>
        public int DPIy { get; private set; } = 96;

        /// <summary>
        /// Parse the png image data from the given image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns>The PNG properties.</returns>
        public static PngImageProperties Parse(UvgaImageContent image)
        {
            var data = image.PngImageData.ToArray();
            return Parse(data);
        }

        /// <summary>
        /// Parse the image data from the given byte data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The PNG properties.</returns>
        public static PngImageProperties Parse(IReadOnlyCollection<byte> data)
        {
            var dataArr = data.ToArray();
            return Parse(dataArr);
        }

        /// <summary>
        /// Parse the image data from the given byte data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The PNG properties.</returns>
        public static PngImageProperties Parse(byte[] data)
        {
            var res = new PngImageProperties
            {
                IsValid = false,
            };

            var pngHeader = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 };
            if (!pngHeader.SequenceEqual(data.Take(pngHeader.Length)))
            {
                return res;
            }

            using var ms = new MemoryStream(data);
            using var br = new BinaryReader(ms);

            var chunks = new List<Chunk>();
            try
            {
                // Skip signature
                ms.Seek(pngHeader.Length, SeekOrigin.Begin);
                while (ms.Position < (ms.Length - 12))
                {
                    var offset = (int)ms.Position;
                    var chunkLength = (int)BE(br.ReadUInt32());
                    var typePos = ms.Position;
                    var chunkType = BE(br.ReadUInt32());
                    var chunkData = new byte[chunkLength];
                    ms.Read(chunkData, 0, chunkData.Length);
                    var crc = BE(BE(br.ReadUInt32()));
                    var chunkStr = System.Text.Encoding.ASCII.GetString(data, (int)typePos, 4);

                    var chunk = new Chunk(offset, chunkLength, chunkType, chunkStr, chunkData, crc);
                    chunks.Add(chunk);
                }
            }
            catch (Exception)
            {
                return res;
            }

            Chunk ihdr = chunks.FirstOrDefault(c => c.Type == "IHDR");
            if (ihdr.Type != "IHDR")
            {
                return res;
            }

            res.IsValid = true;
            SetHeaderProperties(ihdr, res);

            Chunk phys = chunks.FirstOrDefault(c => c.Type == "pHYs");
            if (phys.Type == "pHYs")
            {
                SetPhysDimensions(phys, res);
            }

            return res;
        }

        private static void SetHeaderProperties(Chunk header, PngImageProperties result)
        {
            using var msChunk = new MemoryStream(header.Data);
            using var brChunk = new BinaryReader(msChunk);
            var width = BE(brChunk.ReadInt32());
            var height = BE(brChunk.ReadInt32());
            var bitdepth = brChunk.ReadByte();
            var colorType = brChunk.ReadByte();
            var compression = brChunk.ReadByte();
            var filter = brChunk.ReadByte();
            var interlace = brChunk.ReadByte();
            result.Width = width;
            result.Height = height;
            result.ColorBits = bitdepth;
            result.ColorType = colorType switch
            {
                0 => PngColorType.Grayscale,
                2 => PngColorType.RGB,
                3 => PngColorType.Palette,
                4 => PngColorType.GrayscaleAlpha,
                6 => PngColorType.RGBA,
                _ => PngColorType.Invalid,
            };

            if (result.ColorType == PngColorType.Invalid)
            {
                result.IsValid = false;
            }

            result.IsSupported = result.ColorType == PngColorType.RGB && bitdepth == 8;
        }

        private static void SetPhysDimensions(Chunk header, PngImageProperties result)
        {
            using var msChunk = new MemoryStream(header.Data);
            using var brChunk = new BinaryReader(msChunk);
            var resX = BE(brChunk.ReadUInt32());
            var resY = BE(brChunk.ReadUInt32());
            var unit = brChunk.ReadByte();

            if (unit == 1)
            {
                result.DPIx = (int)Math.Round(resX * 0.0254M);
                result.DPIy = (int)Math.Round(resY * 0.0254M);
            }
            else
            {
                // Only the aspect ration can be used
                var ar = (decimal)resX / resY;
                result.DPIx = 96;
                result.DPIy = (int)(96M / ar);
            }
        }

        private static uint BE(uint v)
        {
            var b3 = (v >> 24) & 0xFF;
            var b2 = (v >> 16) & 0xFF;
            var b1 = (v >> 8) & 0xFF;
            var b0 = (v >> 0) & 0xFF;
            return (b0 << 24) | (b1 << 16) | (b2 << 8) | b3;
        }

        private static int BE(int v)
        {
            var bytes = BitConverter.GetBytes(v);
            var rev = bytes.Reverse().ToArray();
            return BitConverter.ToInt32(rev, 0);
        }

        private readonly struct Chunk(int offset, int length, uint typeInt, string type, byte[] data, uint cRC)
        {
            public readonly int Offset = offset;
            public readonly int Length = length;
            public readonly uint TypeInt = typeInt;
            public readonly string Type = type;
            public readonly byte[] Data = data;
            public readonly uint CRC = cRC;
        }
    }
}
