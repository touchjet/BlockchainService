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
    /// A Contract represents an embedded contract on the Ethereum blockchain, and is used with both creating and executing contracts in our Contract API. All the fields below are generally optional, but may be required depending on the particular contract endpoint you’re using.
    /// </summary>
    public class EthereumContract
    {
        /// <summary>
        /// Solidity code of this contract; required when creating a contract.
        /// </summary>
        public string Solidity { get; set; }

        /// <summary>
        /// Parameters for either contract creation or method execution.
        /// </summary>
        public List<string> Params { get; set; }

        /// <summary>
        /// Named contract(s) to publish; necessary to specify when first creating a contract.
        /// </summary>
        public List<string> Publish { get; set; }

        /// <summary>
        /// Private key associated with a funded Ethereum external account used to publish a contract or execute a method.
        /// </summary>
        public string Private { get; set; }

        /// <summary>
        /// Maximum amount of gas to use in contract creation or method execution.
        /// </summary>
        public ulong GasLimit { get; set; }

        /// <summary>
        /// Amount (in wei) to transfer; can be used when creating a contract or calling a method.
        /// </summary>
        public ulong Value { get; set; }

        /// <summary>
        /// Name of contract as published.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Hex-encoded binary compilation of this contract.
        /// </summary>
        public string Bin { get; set; }

        /// <summary>
        /// Hex-encoded address of this contract.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///  Timestamp when this contract was confirmed in the Ethereum blockchain. 
        /// </summary>
        public virtual DateTime Created { get; set; }

        /// <summary>
        /// Hex-encoded transaction hash that created this contract.
        /// </summary>
        public string CreationTxHash { get; set; }

        /// <summary>
        /// If this is a response from a calling a contract method, this array of results may appear if the method returns any.
        /// </summary>
        public List<string> Results { get; set; }

    }
}
