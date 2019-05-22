﻿using BoincManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoincManagerWindows.ViewModels
{
    class HostViewModel : BindableBase, IFilterableViewModel
    {
        public int Id { get; }

        private string name;
        public string Name { get => name; private set => SetProperty(ref name, value); }

        private string ipAddress;
        public string IpAddress { get => ipAddress; private set => SetProperty(ref ipAddress, value); }

        private int port;
        [Range(0, 65535, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Port { get => port; private set => SetProperty(ref port, value); }

        private string password;
        public string Password { get => password; private set => SetProperty(ref password, value); }

        private string boincVersion;
        public string BoincVersion { get => boincVersion; private set => SetProperty(ref boincVersion, value); }

        private string operatingSystem;
        public string OperatingSystem { get => operatingSystem; private set => SetProperty(ref operatingSystem, value); }
        
        private bool connected;
        public bool Connected { get => connected; private set => SetProperty(ref connected, value); }

        private string status;
        public string Status { get => status; set => SetProperty(ref status, value); }

        public HostViewModel(Host host)
        {
            Id = host.Id;
            Name = host.Name;
            IpAddress = host.IpAddress;
            Port = host.Port;
            Password = host.Password;
        }

        public void Update(string name, string ipAddress, int port, string password)
        {
            Name = name;
            IpAddress = ipAddress;
            Port = port;
            Password = password;
        }

        public IEnumerable<string> GetContentsForFiltering()
        {
            yield return Name;
            yield return IpAddress;
            yield return BoincVersion;
            yield return OperatingSystem;
            yield return Status;
        }

        public static IEnumerable<string> GetLiveFilteringProperties()
        {
            yield return nameof(Name);
            yield return nameof(IpAddress);
            yield return nameof(BoincVersion);
            yield return nameof(OperatingSystem);
            yield return nameof(Status);
        }
    }
}
