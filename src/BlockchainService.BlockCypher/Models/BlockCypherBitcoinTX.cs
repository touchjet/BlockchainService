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
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using BlockchainService.Abstractions.Models;

namespace BlockchainService.BlockCypher.Models
{
    public class BlockCypherBitcoinTX : BitcoinTX
    {
        public BlockCypherBitcoinTX()
        {
        }

        public BlockCypherBitcoinTX(BitcoinTX tx)
        {
            if (tx == null)
            {
                return;
            }
            base.BlockHeight = tx.BlockHeight;
            base.Hash = tx.Hash;
            base.Addresses = tx.Addresses;
            base.Total = tx.Total;
            base.Fees = tx.Fees;
            base.Size = tx.Size;
            base.Preference = tx.Preference;
            base.RelayedBy = tx.RelayedBy;
            base.Ver = tx.Ver;
            base.LockTime = tx.LockTime;
            base.Confirmations = tx.Confirmations;
            BlockCypherInputs = tx.Inputs;
            BlockCypherOutputs = tx.Outputs;
            base.OptInRbf = tx.OptInRbf;
            base.Confidence = tx.Confidence;
            base.Confirmed = tx.Confirmed;
            base.ReceiveCount = tx.ReceiveCount;
            base.ChangeAddress = tx.ChangeAddress;
            base.BlockHash = tx.BlockHash;
            base.BlockIndex = tx.BlockIndex;
            base.DataProtocol = tx.DataProtocol;
            base.Hex = tx.Hex;
        }

        [JsonProperty("block_height")]
        public override Int64 BlockHeight { get => base.BlockHeight; set => base.BlockHeight = value; }

        [JsonProperty("relayed_by")]
        public override string RelayedBy { get => base.RelayedBy; set => base.RelayedBy = value; }

        [JsonProperty("lock_time")]
        public override Int64 LockTime { get => base.LockTime; set => base.LockTime = value; }

        [JsonProperty("inputs")]
        public List<BitcoinTXInput> BlockCypherInputs { get; set; }

        [JsonIgnore]
        public override List<BitcoinTXInput> Inputs { get => BlockCypherInputs; set => BlockCypherInputs = value; }
 
        [JsonProperty("outputs")]
        public List<BitcoinTXOutput> BlockCypherOutputs { get; set; }

        [JsonIgnore]
        public override List<BitcoinTXOutput> Outputs { get => BlockCypherOutputs; set => BlockCypherOutputs = value; }

        [JsonProperty("opt_in_rbf")]
        public override bool OptInRbf { get => base.OptInRbf; set => base.OptInRbf = value; }

        [JsonProperty("receive_count")]
        public override Int64 ReceiveCount { get => base.ReceiveCount; set => base.ReceiveCount = value; }

        [JsonProperty("change_address")]
        public override string ChangeAddress { get => base.ChangeAddress; set => base.ChangeAddress = value; }

        [JsonProperty("block_hash")]
        public override string BlockHash { get => base.BlockHash; set => base.BlockHash = value; }

        [JsonProperty("block_index")]
        public override Int64 BlockIndex { get => base.BlockIndex; set => base.BlockIndex = value; }

        [JsonProperty("data_protocol")]
        public override string DataProtocol { get => base.DataProtocol; set => base.DataProtocol = value; }
    }
}
