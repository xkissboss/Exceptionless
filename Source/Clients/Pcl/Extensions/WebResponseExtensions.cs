﻿#region Copyright 2014 Exceptionless

// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
//     http://www.apache.org/licenses/LICENSE-2.0

#endregion

using System;
using System.IO;
using System.Net;

namespace Exceptionless.Extensions {
    internal static class WebResponseExtensions {
        public static bool IsSuccessStatusCode(this HttpWebResponse response) {
            if (response != null && response.StatusCode >= HttpStatusCode.OK)
                return response.StatusCode <= (HttpStatusCode)299;

            return false;
        }

        public static string GetResponseText(this WebResponse response) {
            try {
                using (response) {
                    using (var stream = response.GetResponseStream()) {
                        using (var reader = new StreamReader(stream)) {
                            return reader.ReadToEnd();
                        }
                    }
                }
            } catch (Exception) {
                return null;
            }
        }
    }
}