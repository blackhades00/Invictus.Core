// <copyright file="Service.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Net;
using System.Threading;
using Invictus.Core.Invictus.LogService;
using Newtonsoft.Json.Linq;

namespace Invictus.Core.Invictus.Framework.API
{
    /// <summary>
    /// JsonParser Class.
    /// </summary>
    class Service
    {

        public static JObject GetActivePlayerData()
        {
            if (IsLiveGameRunning())
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://127.0.0.1:2999/liveclientdata/activeplayer");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    try { return JObject.Parse(reader.ReadToEnd()); }
                    catch (Exception Ex)
                    {
                        LogService.Logger.Log("Error parsing ActivePlayerData from API.",Logger.eLoggerType.Fatal);
                        throw new Exception("PlayerDataParseFailedException");
                    }
                }
            }
            else
            {
                LogService.Logger.Log("Error parsing ActivePlayerData from API.",Logger.eLoggerType.Fatal);
                throw new Exception("PlayerDataParseFailedException");
            }
        }

        public static JArray GetAllPlayerData()
        {
            if (IsLiveGameRunning())
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create("https://127.0.0.1:2999/liveclientdata/playerlist");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    try { return JArray.Parse(reader.ReadToEnd()); }
                    catch (Exception ex)
                    {
                        LogService.Logger.Log("Error parsing AllPlayerData from API.",Logger.eLoggerType.Fatal);
                        throw new Exception("AllPlayerDataParseFailedException");
                    }
                }
            }
            else
            {
                LogService.Logger.Log("Error parsing AllPlayerData from API.",Logger.eLoggerType.Fatal);
                throw new Exception("AllPlayerDataParseFailedException");
            }
        }

        public static JObject GetGameStatsData()
        {
            if (IsLiveGameRunning())
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create("https://127.0.0.1:2999/liveclientdata/gamestats");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    try { return JObject.Parse(reader.ReadToEnd()); }
                    catch (Exception ex)
                    {
                        LogService.Logger.Log("Error parsing GameSats from API.",Logger.eLoggerType.Fatal);
                        throw new Exception("GameDataParseFailedException");
                    }
                }
            }
            else
            {
                LogService.Logger.Log("Error parsing GameSats from API.",Logger.eLoggerType.Fatal);
                throw new Exception("GameDataParseFailedException");
            }
        }

        public static bool IsLiveGameRunning()
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("https://127.0.0.1:2999/liveclientdata/allgamedata");
            ServicePointManager.ServerCertificateValidationCallback += delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true; // **** Always accept
            };

            request.Method = "GET";

            bool flag = false;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(10000);
                Environment.Exit(0);
            }

            return flag;
        }
    }
}
