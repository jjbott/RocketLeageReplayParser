﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueReplayParser
{
    public class BitReader
    {
        BitArray _bits;
        int _position = 0;

        public BitReader(byte[] bytes)
        {
            _bits = new BitArray(bytes);
        }

        public BitReader(bool[] bits)
        {
            _bits = new BitArray(bits);
        }

        public bool ReadBit()
        {
            _position++;
            return _bits[7-_position];
        }

        public byte[] ReadBitsAsBytes(int numBits)
        {
            var bytes = new byte[(int)Math.Ceiling((numBits / 8.0))];
            var selectedBits = new bool[numBits];
            for(int i = 0; i < numBits; ++i)
            {
                selectedBits[i] = _bits[_position + i];
            }
            _position += numBits;
            var ba = new BitArray(selectedBits);
            ba.CopyTo(bytes, 0);
            return bytes;
        }

    }
}
