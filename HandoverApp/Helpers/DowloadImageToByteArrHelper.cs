﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HandoverApp.Helpers
{
	public class DowloadImageToByteArrHelper
	{
        public static async Task<byte[]> Download(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                byte[] fileArray = await client.GetByteArrayAsync(url);
                return fileArray;
            }

        }
    }
}

