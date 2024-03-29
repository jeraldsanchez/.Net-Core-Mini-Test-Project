﻿using Microsoft.AspNetCore.Hosting;
using Sample_Proj.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Proj.Services
{
    public class DataProcessService : IDataProcessService
    {
        private readonly IWebHostEnvironment _env;
        public DataProcessService(
            IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<HashSet<Tuple<string, string, string>>> GetAllFileName(ClientSettings clientSettings)
        {
            #region Declare Variables
            string contentRootPath = String.Empty;
            char ch = '.';
            string[] actualValue;
            string extension = String.Empty;
            string[] allowedFileName = null;
            HashSet<Tuple<string, string, string>> hashTuple = new HashSet<Tuple<string, string, string>>();
            #endregion

            #region Transform Data
            ch = Convert.ToChar(clientSettings.Delimiter);
            contentRootPath = @$"{_env.ContentRootPath}/{clientSettings.FileDirectoryPath}";
            extension = $"*.{clientSettings.ExtensionFile.ToString()}";
            allowedFileName = clientSettings.FileName.ToString().Split(',');
            #endregion

            DirectoryInfo d = new DirectoryInfo(contentRootPath);
            FileInfo[] Files = d.GetFiles(extension);
            foreach (FileInfo file in Files)
            {
                string fileName = file.Name;
                if (fileName.Contains(clientSettings.Delimiter))
                {
                    actualValue = fileName.Split(new char[] { ch }, 2);
                    if (allowedFileName.Contains(actualValue[0]))
                    {
                        hashTuple.Add(new Tuple<string, string, string>(fileName, actualValue[0], actualValue[1]));
                    }
                }
            }

            return hashTuple;
        }
    }
}
