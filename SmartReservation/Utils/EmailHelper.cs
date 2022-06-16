﻿using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SmartReservation.Utils
{
    public class EmailHelper
    {
        public static string ResetPasswordEmail(Dictionary<string, string> template, string emailFile, IWebHostEnvironment webHostEnvironment)
        {
            string body;
            var contentRootPath = $"{webHostEnvironment.ContentRootPath}//{emailFile}";

            using (var reader = new StreamReader(contentRootPath))
            {
                body = reader.ReadToEnd();
            }

            return template.Aggregate(body, (current, item) => current.Replace($"{{{item.Key}}}", item.Value));
        }
    }
}
