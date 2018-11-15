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
namespace BlockchainService.Abstractions.Models
{
    /// <summary>
    /// A Blockchain represents the current state of a particular blockchain.
    /// </summary>
    public class BitcoinBlockchain
    {
        /// <summary>
        /// The name of the blockchain represented, in the form of $COIN.$CHAIN. 
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// The current height of the blockchain; i.e., the number of blocks in the blockchain.   
        /// </summary>
        public virtual Int64 Height { get; set; }

        /// <summary>
        /// The hash of the latest confirmed block in the blockchain; in Bitcoin, the hashing function is SHA256(SHA256(block)). 
        /// </summary>
        public virtual string Hash { get; set; }

        /// <summary>
        /// The time of the latest update to the blockchain; typically when the latest block was added.  
        /// </summary>
        public virtual DateTime Time { get; set; }

        /// <summary>
        /// A rolling average of the fee (in satoshis) paid per kilobyte for transactions to be confirmed within 1 to 2 blocks.
        /// </summary>
        public virtual Int64 HighFeePerKb { get; set; }

        /// <summary>
        /// A rolling average of the fee (in satoshis) paid per kilobyte for transactions to be confirmed within 3 to 6 blocks.
        /// </summary>
        public virtual Int64 MediumFeePerKb { get; set; }

        /// <summary>
        /// A rolling average of the fee (in satoshis) paid per kilobyte for transactions to be confirmed in 7 or more blocks.
        /// </summary>
        public virtual Int64 LowFeePerKb { get; set; }

        /// <summary>
        /// Number of unconfirmed transactions in memory pool (likely to be included in next block).
        /// </summary>
        public virtual Int64 UnconfirmedCount { get; set; }
    }
}
