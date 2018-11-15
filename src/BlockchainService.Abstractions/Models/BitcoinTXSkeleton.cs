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
using System.Collections.Generic;

namespace BlockchainService.Abstractions.Models
{
    /// <summary>
    /// A TXSkeleton is a convenience/wrapper Object that’s used primarily when Creating Transactions through the New and Send endpoints.
    /// </summary>
    public class BitcoinTXSkeleton
    {
        /// <summary>
        /// A temporary TX, usually returned fully filled but missing input scripts.
        /// </summary>
        public virtual BitcoinTX Tx { get; set; }

        /// <summary>
        /// Array of hex-encoded data for you to sign, one for each input.
        /// </summary>
        public virtual List<string> ToSign { get; set; }

        /// <summary>
        /// Array of signatures corresponding to all the data in tosign, typically provided by you.
        /// </summary>
        public virtual List<string> Signatures { get; set; }

        /// <summary>
        /// Array of public virtual keys corresponding to each signature. In general, these are provided by you, and correspond to the signatures you provide.
        /// </summary>
        public virtual List<string> Pubkeys { get; set; }

        /// <summary>
        /// Optional Array of hex-encoded, work-in-progress transactions; optionally returned to validate the tosign data locally.
        /// </summary>
        public virtual List<string> ToSignTx { get; set; }
    }
}
