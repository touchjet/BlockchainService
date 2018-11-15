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
using Newtonsoft.Json;
using BlockchainService.Abstractions.Models;

namespace BlockchainService.BlockCypher.Models
{
    public class BlockCypherBitcoinTXOutput : BitcoinTXOutput
    {
        public BlockCypherBitcoinTXOutput()
        {

        }

        public BlockCypherBitcoinTXOutput(BitcoinTXOutput input)
        {
            if (input == null)
            {
                return;
            }
            base.Value = input.Value;
            base.Script = input.Script;
            base.Addresses = input.Addresses;
            base.ScriptType = input.ScriptType;
            base.SpentBy = input.SpentBy;
            base.DataHex = input.DataHex;
            base.DataString = input.DataString;
        }

        [JsonProperty("script_type")]
        public override string ScriptType { get => base.ScriptType; set => base.ScriptType = value; }

        [JsonProperty("spent_by")]
        public override string SpentBy { get => base.SpentBy; set => base.SpentBy = value; }

        [JsonProperty("data_hex")]
        public override string DataHex { get => base.DataHex; set => base.DataHex = value; }

        [JsonProperty("data_string")]
        public override string DataString { get => base.DataString; set => base.DataString = value; }
    }
}
