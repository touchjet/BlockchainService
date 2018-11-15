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
using Newtonsoft.Json;
using BlockchainService.Abstractions.Models;
using System.Numerics;

namespace BlockchainService.BlockCypher.Models
{
    public class BlockCypherEthereumTX : EthereumTX
    {
        public BlockCypherEthereumTX()
        {
        }

        public BlockCypherEthereumTX(EthereumTX tx)
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
            base.GasUsed = tx.GasUsed;
            base.GasPrice = tx.GasPrice;
            base.RelayedBy = tx.RelayedBy;
            base.Ver = tx.Ver;
            base.Confirmations = tx.Confirmations;
            base.Inputs = tx.Inputs;
            base.Outputs = tx.Outputs;
            base.Confirmed = tx.Confirmed;
            base.ReceiveCount = tx.ReceiveCount;
            base.GasLimit = tx.GasLimit;
            base.ContractCreation = tx.ContractCreation;
            base.BlockHash = tx.BlockHash;
            base.BlockIndex = tx.BlockIndex;
            base.Hex = tx.Hex;
        }

        [JsonProperty("block_height")]
        public override Int64 BlockHeight { get => base.BlockHeight; set => base.BlockHeight = value; }

        [JsonProperty("gas_used")]
        public override BigInteger GasUsed { get => base.GasUsed; set => base.GasUsed = value; }

        [JsonProperty("gas_price")]
        public override BigInteger GasPrice { get => base.GasPrice; set => base.GasPrice = value; }

        [JsonProperty("relayed_by")]
        public override string RelayedBy { get => base.RelayedBy; set => base.RelayedBy = value; }

        [JsonProperty("gas_limit")]
        public override BigInteger GasLimit { get => base.GasLimit; set => base.GasLimit = value; }

        [JsonProperty("contract_creation")]
        public override bool ContractCreation { get => base.ContractCreation; set => base.ContractCreation = value; }

        [JsonProperty("receive_count")]
        public override Int64 ReceiveCount { get => base.ReceiveCount; set => base.ReceiveCount = value; }

        [JsonProperty("block_hash")]
        public override string BlockHash { get => base.BlockHash; set => base.BlockHash = value; }

        [JsonProperty("block_index")]
        public override Int64 BlockIndex { get => base.BlockIndex; set => base.BlockIndex = value; }
    }
}
