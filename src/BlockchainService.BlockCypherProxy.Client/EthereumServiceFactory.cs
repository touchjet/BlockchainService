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
using BlockchainService.Abstractions;

namespace BlockchainService.BlockCypherProxy.Client
{
    public class EthereumServiceFactory : IEthereumServiceFactory
    {
        string _siteUrl;

        public EthereumServiceFactory(string siteUrl)
        {
            _siteUrl = siteUrl;
        }

        public IEthereumService GetService(CoinTypes coinType, bool testNet)
        {
            switch (coinType)
            {
                case CoinTypes.Ethereum:
                    if (!testNet)
                    {
                        return new EthereumService(_siteUrl, "eth", "main");
                    }
                    break;
            }
            throw new ServiceNotAvailableException(coinType, testNet);
        }
    }
}
