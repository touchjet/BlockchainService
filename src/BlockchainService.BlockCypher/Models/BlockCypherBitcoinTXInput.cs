/*
 * Copyright (C) 2018 Touchjet Limited.
 * 
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/
using System;
using System.Numerics;
using Newtonsoft.Json;
using BlockchainService.Abstractions.Models;

namespace BlockchainService.BlockCypher.Models
{
    public class BlockCypherBitcoinTXInput : BitcoinTXInput
    {
        public BlockCypherBitcoinTXInput()
        {

        }

        public BlockCypherBitcoinTXInput(BitcoinTXInput input)
        {
            if (input == null)
            {
                return;
            }
            base.PrevHash = input.PrevHash;
            base.OutputIndex = input.OutputIndex;
            base.OutputValue = input.OutputValue;
            base.ScriptType = input.ScriptType;
            base.Script = input.Script;
            base.Addresses = input.Addresses;
            base.Sequence = input.Sequence;
            base.Age = input.Age;
        }

        [JsonProperty("prev_hash")]
        public override string PrevHash { get => base.PrevHash; set { 
                base.PrevHash = value; 
            } }

        [JsonProperty("output_index")]
        public override Int64 OutputIndex { get => base.OutputIndex; set => base.OutputIndex = value; }

        [JsonProperty("output_value")]
        public override ulong OutputValue { get => base.OutputValue; set => base.OutputValue = value; }

        [JsonProperty("script_type")]
        public override string ScriptType { get => base.ScriptType; set => base.ScriptType = value; }
    }
}
