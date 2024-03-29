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
using BlockchainService.Abstractions.Models;
using Newtonsoft.Json;

namespace BlockchainService.BlockCypher.Models
{
    public class BlockCypherEthereumAddressRecord: EthereumAddressRecord
    {
        [JsonProperty("unconfirmed_balance")]
        public override long UnconfirmedBalance { get => base.UnconfirmedBalance; set => base.UnconfirmedBalance = value; }

        [JsonProperty("total_received")]
        public override long TotalReceived { get => base.TotalReceived; set => base.TotalReceived = value; }

        [JsonProperty("total_sent")]
        public override long TotalSent { get => base.TotalSent; set => base.TotalSent = value; }

        [JsonProperty("n_tx")]
        public override long NumberOfTx { get => base.NumberOfTx; set => base.NumberOfTx = value; }

        [JsonProperty("unconfirmed_n_tx")]
        public override long NumberOfUnconfirmedTx { get => base.NumberOfUnconfirmedTx; set => base.NumberOfUnconfirmedTx = value; }

        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }
    }
}
