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
using Newtonsoft.Json;

namespace BlockchainService.BlockCypher.Models
{
    public class BlockCypherBitcoinBlockchain : Abstractions.Models.BitcoinBlockchain
    {
        [JsonProperty("high_fee_per_kb")]
        public override Int64 HighFeePerKb { get => base.HighFeePerKb; set => base.HighFeePerKb = value; }

        [JsonProperty("medium_fee_per_kb")]
        public override Int64 MediumFeePerKb { get => base.MediumFeePerKb; set => base.MediumFeePerKb = value; }

        [JsonProperty("low_fee_per_kb")]
        public override Int64 LowFeePerKb { get => base.LowFeePerKb; set => base.LowFeePerKb = value; }

        [JsonProperty("unconfirmed_count")]
        public override Int64 UnconfirmedCount { get => base.UnconfirmedCount; set => base.UnconfirmedCount = value; }
    }
}
