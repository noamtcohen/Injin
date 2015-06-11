using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Injin
{
    public class Fabricator
    {
        private Dictionary<string, InstanceInfo> _config;
        private readonly string _pathToConfig;

        public Fabricator(string pathToConfig)
        {
            _pathToConfig = pathToConfig;

            var watcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(pathToConfig),
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = Path.GetFileName(pathToConfig),
            };

            watcher.Changed += (sender,arg) =>
            {
                LoadConfig();
            };

            watcher.EnableRaisingEvents = true;

            LoadConfig();
        }

        public T Fabricate<T>()
        {
            var instanceInfo = _config[typeof (T).FullName];
            return (T) Activator.CreateInstance(instanceInfo.AssemblyName, instanceInfo.TypeName).Unwrap();
        }

        private void LoadConfig()
        {
            using (var fs = new FileStream(_pathToConfig, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs))
                    _config = JsonConvert.DeserializeObject<Dictionary<string, InstanceInfo>>(sr.ReadToEnd());   
        }

        class InstanceInfo
        {
            public string AssemblyName { get; set; }
            public string TypeName { get; set; }
        }
    }
}
