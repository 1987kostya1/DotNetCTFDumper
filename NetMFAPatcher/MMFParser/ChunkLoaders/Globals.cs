﻿using NetMFAPatcher.chunkloaders;
using NetMFAPatcher.mmfparser;
using NetMFAPatcher.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetMFAPatcher.MMFParser.Data.ChunkList;

namespace NetMFAPatcher.MMFParser.ChunkLoaders
{
    public class GlobalValues : ChunkLoader
    {
        public List<float> items = new List<float>();
        public GlobalValues(Chunk chunk) : base(chunk) { }
        public override void Print(bool ext)
        {
            
        }

        public override void Read()
        {
            var numberOfItems = reader.ReadUInt16();
            var templist = new List<ByteIO>();
            for (int i = 0; i < numberOfItems; i++)
            {
                templist.Add(new ByteIO(reader.ReadBytes(4)));
            }
            foreach (var item in templist)
            {
                var globalType = reader.ReadSByte();
                float newGlobal = 0f;
                if((Constants.ValueType)globalType==Constants.ValueType.Float)
                {
                    newGlobal = item.ReadSingle();
                }
                else if ((Constants.ValueType)globalType == Constants.ValueType.Int)
                {
                    newGlobal = item.ReadInt32();
                }
                else
                {
                    throw new Exception("unknown global type");
                }
                items.Add(newGlobal);               
            }

            
        }
    }
    public class GlobalStrings : ChunkLoader
    {
        public List<string> items = new List<string>();
        public GlobalStrings(Chunk chunk) : base(chunk) { }
        public override void Print(bool ext)
        {

        }

        public override void Read()
        {
            var count = reader.ReadUInt32();
            for (int i = 0; i < count; i++)
            {
                items.Add(reader.ReadAscii());
            }

        }
    }
}
