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
using System.Numerics;

namespace BlockchainService.Abstractions.Models
{
    /// <summary>
    /// A TXOutput represents an output created by a transaction. Typically found within an array in a TX.
    /// </summary>
    public class EthereumTXOutput
    {
        /// <summary>
        /// Value in this transaction output, in satoshis.
        /// </summary>
        public virtual ulong Value { get; set; }

        /// <summary>
        /// Raw hexadecimal encoding of the encumbrance script for this output.  
        /// </summary>
        public virtual string Script { get; set; }

        /// <summary>
        ///  Addresses that correspond to this output; typically this will only have a single address, and you can think of this output as having “sent” value to the address contained herein. 
        /// </summary>
        public virtual List<string> Addresses { get; set; }
    }
}
