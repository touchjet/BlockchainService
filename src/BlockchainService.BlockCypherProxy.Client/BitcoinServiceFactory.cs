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
using BlockchainService.Abstractions;

namespace BlockchainService.BlockCypherProxy.Client
{
    public class BitcoinServiceFactory : IBitcoinServiceFactory
    {
        string _siteUrl;

        public BitcoinServiceFactory(string siteUrl)
        {
            _siteUrl = siteUrl;
        }

        public IBitcoinService GetService(CoinTypes coinType, bool testNet)
        {
            switch (coinType)
            {
                case CoinTypes.Bitcoin:
                    return new BitcoinService(_siteUrl, "btc", testNet ? "test" : "main");
                case CoinTypes.Dogecoin:
                    if (!testNet)
                    {
                        return new BitcoinService(_siteUrl, "doge", "main");
                    }
                    break;
                case CoinTypes.Litecoin:
                    if (!testNet)
                    {
                        return new BitcoinService(_siteUrl, "ltc", "main");
                    }
                    break;
            }
            throw new ServiceNotAvailableException(coinType, testNet);
        }
    }
}
