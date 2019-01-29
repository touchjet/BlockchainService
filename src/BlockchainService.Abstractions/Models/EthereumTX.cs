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
    /// A TX represents the current state of a particular transaction from either a Block within a Blockchain, or an unconfirmed transaction that has yet to be included in a Block. Typically returned from the Unconfirmed Transactions and Transaction Hash endpoints.
    /// </summary>
    public class EthereumTX
    {
        /// <summary>
        /// Height of the block that contains this transaction.If this is an unconfirmed transaction, it will equal -1. 
        /// </summary>
        public virtual Int64 BlockHeight { get; set; }

        /// <summary>
        /// The hash of the transaction.While reasonably unique, using hashes as identifiers may be unsafe.  
        /// </summary>
        public virtual string Hash { get; set; }

        /// <summary>
        ///  Array of bitcoin public virtual addresses involved in the transaction. 
        /// </summary>
        public virtual List<string> Addresses { get; set; }

        /// <summary>
        ///  The total number of satoshis exchanged in this transaction. 
        /// </summary>
        public virtual ulong Total { get; set; }

        /// <summary>
        ///  The total number of fees—in satoshis—collected by miners in this transaction. 
        /// </summary>
        public virtual ulong Fees { get; set; }

        /// <summary>
        ///  The size of the transaction in bytes. 
        /// </summary>
        public virtual Int64 Size { get; set; }

        /// <summary>
        ///  The amount of gas used by this transaction. 
        /// </summary>
        public virtual ulong GasUsed { get; set; }

        /// <summary>
        ///  The price of gas—in wei—in this transaction. 
        /// </summary>
        public virtual ulong GasPrice { get; set; }

        /// <summary>
        ///  Address of the peer that sent BlockCypher’s servers this transaction.
        /// </summary>
        public virtual string RelayedBy { get; set; }

        /// <summary>
        ///  Time this transaction was received by the blockchain service servers. 
        /// </summary>
        public virtual DateTime Received { get; set; }

        /// <summary>
        ///  Version number, typically 1 for Bitcoin transactions. 
        /// </summary>
        public virtual Int64 Ver { get; set; }

        /// <summary>
        ///  Number of subsequent blocks, including the block the transaction is in. Unconfirmed transactions have 0 confirmations. 
        /// </summary>
        public virtual Int64 Confirmations { get; set; }

        /// <summary>
        ///  TXInput Array
        /// </summary>
        public virtual List<EthereumTXInput> Inputs { get; set; }

        /// <summary>
        ///  TXOutput Array
        /// </summary>
        public virtual List<EthereumTXOutput> Outputs { get; set; }

        /// <summary>
        ///  Time at which transaction was included in a block; only present for confirmed transactions. 
        /// </summary>
        public virtual DateTime Confirmed { get; set; }

        /// <summary>
        ///  Number of peers that have sent this transaction to BlockCypher; only present for unconfirmed transactions.
        /// </summary>
        public virtual Int64 ReceiveCount { get; set; }

        /// <summary>
        ///  If creating a transaction, can optionally set a higher default gas limit (useful if your recepient is a contract). If not set, default is 21000 gas for external accounts and 80000 for contract accounts.
        /// </summary>
        public virtual ulong GasLimit { get; set; }

        /// <summary>
        ///  If true, this transaction was used to create a contract and contract account. Note that the contract address (in the outputs field) will be blank until the transaction is confirmed.
        /// </summary>
        public virtual bool ContractCreation { get; set; }

        /// <summary>
        ///  Hash of the block that contains this transaction; only present for confirmed transactions.
        /// </summary>
        public virtual string BlockHash { get; set; }

        /// <summary>
        ///  Canonical, zero-indexed location of this transaction in a block; only present for confirmed transactions.
        /// </summary>
        public virtual Int64 BlockIndex { get; set; }

        /// <summary>
        ///  Hex-encoded bytes of the transaction, as sent over the network. 
        /// </summary>
        public virtual string Hex { get; set; }
    }
}
