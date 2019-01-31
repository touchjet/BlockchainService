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

namespace BlockchainService.Abstractions.Models
{
    /// <summary>
    /// A TX represents the current state of a particular transaction from either a Block within a Blockchain, or an unconfirmed transaction that has yet to be included in a Block. Typically returned from the Unconfirmed Transactions and Transaction Hash endpoints.
    /// </summary>
    public class BitcoinTX
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
        ///  The likelihood that this transaction will make it to the next block; reflects the preference level miners have to include this transaction.Can be high, medium or low.
        /// </summary>
        public virtual string Preference { get; set; }

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
        ///  Time when transaction can be valid. Can be interpreted in two ways: if less than 500 million, refers to block height. If more, refers to Unix epoch time.
        /// </summary>
        public virtual Int64 LockTime { get; set; }

        /// <summary>
        ///  Number of subsequent blocks, including the block the transaction is in. Unconfirmed transactions have 0 confirmations. 
        /// </summary>
        public virtual Int64 Confirmations { get; set; }

        /// <summary>
        ///  TXInput Array
        /// </summary>
        public virtual List<BitcoinTXInput> Inputs { get; set; }

        /// <summary>
        ///  TXOutput Array
        /// </summary>
        public virtual List<BitcoinTXOutput> Outputs  { get; set; }

        /// <summary>
        ///  Returns true if this transaction has opted in to Replace-By-Fee (RBF), either true or not present.You can read more about Opt-In RBF here.
        /// </summary>
        public virtual bool OptInRbf { get; set; }

        /// <summary>
        ///  The percentage chance this transaction will not be double-spent against, if unconfirmed.For more information, check the section on Confidence Factor.
        /// </summary>
        public virtual double Confidence { get; set; }

        /// <summary>
        ///  Time at which transaction was included in a block; only present for confirmed transactions. 
        /// </summary>
        public virtual DateTime Confirmed { get; set; }

        /// <summary>
        ///  Number of peers that have sent this transaction to BlockCypher; only present for unconfirmed transactions.
        /// </summary>
        public virtual Int64 ReceiveCount { get; set; }

        /// <summary>
        ///  Address BlockCypher will use to send back your change, if you constructed this transaction.If not set, defaults to the address from which the coins were originally sent.
        /// </summary>
        public virtual string ChangeAddress { get; set; }


        /// <summary>
        ///  Hash of the block that contains this transaction; only present for confirmed transactions.
        /// </summary>
        public virtual string BlockHash { get; set; }

        /// <summary>
        ///  Canonical, zero-indexed location of this transaction in a block; only present for confirmed transactions.
        /// </summary>
        public virtual Int64 BlockIndex { get; set; }

        /// <summary>
        ///  Returned if this transaction contains an OP_RETURN associated with a known data protocol. Data protocols currently detected: blockchainid; openassets; factom; colu; coinspark; omni
        /// </summary>
        public virtual string DataProtocol  { get; set; }

        /// <summary>
        ///  Hex-encoded bytes of the transaction, as sent over the network. 
        /// </summary>
        public virtual string Hex  { get; set; }
    }
}
