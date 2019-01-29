﻿/*
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
using System.Collections.Generic;
using System.Linq;

namespace BlockchainService.BlockCypher.Models
{
    public class BlockCypherBitcoinAddressRecord : BitcoinAddressRecord
    {
        [JsonProperty("txrefs")]
        public List<BlockCypherTXRef> BlockCypherTXs { get; set; }

        [JsonIgnore]
        public override List<TXRef> TxRefs
        {
            get
            {
                return BlockCypherTXs?.Select(v => new TXRef
                {
                    BlockHeight = v.BlockHeight,
                    Hash = v.Hash,
                    Value = v.InputN == -1 ? v.Value : -v.Value,
                    Balance = v.Balance,
                    Confirmed = v.Confirmed
                }).ToList();
            }
            set
            {
                BlockCypherTXs = value.Select(v => new BlockCypherTXRef
                {
                    BlockHeight = v.BlockHeight,
                    Hash = v.Hash,
                    Balance = v.Balance,
                    Confirmed = v.Confirmed,
                    Value = v.Value > 0 ? v.Value : -v.Value,
                    InputN = v.Value > 0 ? -1 : 0,
                    OutputN = v.Value < 0 ? -1 : 0
                }).ToList();
            }
        }

        [JsonProperty("unconfirmed_balance")]
        public override ulong UnconfirmedBalance { get => base.UnconfirmedBalance; set => base.UnconfirmedBalance = value; }

        [JsonProperty("total_received")]
        public override ulong TotalReceived { get => base.TotalReceived; set => base.TotalReceived = value; }

        [JsonProperty("total_sent")]
        public override ulong TotalSent { get => base.TotalSent; set => base.TotalSent = value; }

        [JsonProperty("n_tx")]
        public override Int64 NumberOfTx { get => base.NumberOfTx; set => base.NumberOfTx = value; }

        [JsonProperty("unconfirmed_n_tx")]
        public override Int64 NumberOfUnconfirmedTx { get => base.NumberOfUnconfirmedTx; set => base.NumberOfUnconfirmedTx = value; }

        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }
    }
}
