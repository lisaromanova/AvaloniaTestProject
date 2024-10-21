using System;
using System.Collections.Generic;
using ReactiveUI;
using System.Linq;
using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;

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

        string searchText;
        int indexDiscount;
        int indexSort;
        string textCount;
        public int IndexDiscount { get => indexDiscount; set { indexDiscount = value; Filtr(); } }
        public int IndexSort { get => indexSort; set { indexSort = value; Filtr(); } }
        public string SearchText { get => searchText; set { searchText = value; Filtr(); }  }
        public string TextCount { get => textCount; set => this.RaiseAndSetIfChanged(ref textCount, value); }

    void Filtr()
        {
            ServiceList = DBConnect.Services.ToList();
            switch (indexDiscount)
            {
                case 1:
                    ServiceList = ServiceList.Where(s => s.Discount >= 0 && s.Discount < 0.05).ToList();
                    break;
                case 2:
                    ServiceList = ServiceList.Where(s => s.Discount >= 0.05 && s.Discount < 0.15).ToList();
                    break;
                case 3:
                    ServiceList = ServiceList.Where(s => s.Discount >= 0.15 && s.Discount < 0.30).ToList();
                    break;
                case 4:
                    ServiceList = ServiceList.Where(s => s.Discount >= 0.30 && s.Discount < 0.70).ToList();
                    break;
                case 5:
                    ServiceList = ServiceList.Where(s => s.Discount >= 0.70 && s.Discount < 1).ToList();
                    break;
            }
            if (indexSort != -1)
            {
                switch (indexSort)
                {
                    case 0:
                        ServiceList = ServiceList.OrderBy(s => s.Costnew).ToList();
                        break;
                    case 1:
                        ServiceList = ServiceList.OrderByDescending(s => s.Costnew).ToList();
                        break;

                }
            }
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                ServiceList = ServiceList.Where(s => s.Title.Contains(searchText)).ToList();
            }
            TextCount = ServiceList.Count.ToString() + " из " + DBConnect.Services.ToList().Count.ToString();
        }
    }
}