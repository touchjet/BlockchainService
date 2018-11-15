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
using System.Numerics;

namespace BlockchainService.Abstractions.Models
{
    /// <summary>
    /// A TXInput represents an input consumed within a transaction. Typically found within an array in a TX. In most cases, TXInputs are from previous UTXOs, with the most prominent exceptions being attempted double-spend and coinbase inputs.
    /// </summary>
    public class BitcoinTXInput
    {
        /// <summary>
        ///  The previous transaction hash where this input was an output. Not present for coinbase transactions. 
        /// </summary>
        public virtual string PrevHash { get; set; }

        /// <summary>
        ///  The index of the output being spent within the previous transaction. Not present for coinbase transactions.  
        /// </summary>
        public virtual Int64 OutputIndex { get; set; }

        /// <summary>
        ///  The value of the output being spent within the previous transaction. Not present for coinbase transactions. 
        /// </summary>
        public virtual BigInteger OutputValue { get; set; }

        /// <summary>
        ///  The type of script that encumbers the output corresponding to this input.   
        /// </summary>
        public virtual string ScriptType { get; set; }

        /// <summary>
        ///  Raw hexadecimal encoding of the script.   
        /// </summary>
        public virtual string Script { get; set; }

        /// <summary>
        ///  An array of public virtual addresses associated with the output of the previous transaction. 
        /// </summary>
        public virtual List<string> Addresses { get; set; }

        /// <summary>
        ///  Legacy 4-byte sequence number, not usually relevant unless dealing with locktime encumbrances.
        /// </summary>
        public virtual Int64 Sequence { get; set; }

        /// <summary>
        ///  Number of confirmations of the previous transaction for which this input was an output. Currently, only returned in unconfirmed transactions. 
        /// </summary>
        public virtual Int64 Age { get; set; }
    }
}
