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
using System.Numerics;

namespace BlockchainService.Abstractions.Models
{
    public class TXRef
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
        ///  The value transfered by this input/output in wei exchanged in the enclosing transaction. 
        /// </summary>
        public virtual ulong Value { get; set; }

        /// <summary>
        ///  The past balance of the parent address the moment this transaction was confirmed. Not present for unconfirmed transactions. 
        /// </summary>
        public virtual ulong Balance { get; set; }

        /// <summary>
        ///  Time at which transaction was included in a block; only present for confirmed transactions. 
        /// </summary>
        public virtual DateTime Confirmed { get; set; }
    }
}
