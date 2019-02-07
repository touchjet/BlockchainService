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
using Newtonsoft.Json;

namespace BlockchainService.Abstractions.Models
{
    /// <summary>
    /// An AddressRecord represents a public address on a blockchain, and contains information about the state of balances and transactions related to this address.
    /// </summary>
    public class BitcoinAddressRecord
    {
        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("address")]
        public virtual string Address { get; set; }

        /// <summary>
        /// Balance of confirmed satoshis on this address. This is the difference between outputs and inputs on this address, but only for transactions that have been included into a block (i.e., for transactions whose confirmations > 0).
        /// </summary>
        [JsonProperty("balance")]
        public virtual long Balance { get; set; }

        /// <summary>
        /// Balance of unconfirmed satoshis on this address. Can be negative (if unconfirmed transactions are just spending outputs). Only unconfirmed transactions (haven’t made it into a block) are included.
        /// </summary>
        [JsonProperty("unconfirmed_balance")]
        public virtual long UnconfirmedBalance { get; set; }

        /// <summary>
        /// Total amount of confirmed satoshis received by this address.
        /// </summary>
        [JsonProperty("total_received")]
        public virtual long TotalReceived { get; set; }

        /// <summary>
        /// Total amount of confirmed satoshis sent by this address.
        /// </summary>
        [JsonProperty("total_sent")]
        public virtual long TotalSent { get; set; }

        /// <summary>
        /// Number of confirmed transactions on this address. Only transactions that have made it into a block (confirmations > 0) are counted.
        /// </summary>
        [JsonProperty("n_tx")]
        public virtual long NumberOfTx { get; set; }

        /// <summary>
        /// Number of unconfirmed transactions for this address. Only unconfirmed transactions (confirmations == 0) are counted.
        /// </summary>
        [JsonProperty("unconfirmed_n_tx")]
        public virtual long NumberOfUnconfirmedTx { get; set; }

        /// <summary>
        /// Array of transaction summaries for this address. 
        /// </summary>
        [JsonProperty("txrefs")]
        public virtual List<TXRef> TxRefs { get; set; }
    }
}
