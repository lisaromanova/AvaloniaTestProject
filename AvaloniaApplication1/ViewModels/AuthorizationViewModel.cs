using System;
using System.Collections.Generic;
using ReactiveUI;
using System.Linq;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.ViewModels
{
	public class AuthorizationViewModel : ReactiveObject
	{
        AvaloniaTestBaseContext DBConnect;
        List<Service> serviceList;
        public AuthorizationViewModel(AvaloniaTestBaseContext dBConnect)
        {
            DBConnect = dBConnect;
            serviceList = DBConnect.Services.ToList();
        }

        public List<Service> ServiceList { get => serviceList; set => this.RaiseAndSetIfChanged(ref serviceList, value); }
    }
}