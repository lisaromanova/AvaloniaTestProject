using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models
{
    public partial class Service
    {
        public string myString
        {
            get
            {
                string str = Costnew.ToString();
                str += " рублей за ";
                int min = Durationinseconds / 60;
                str += min.ToString();
                str += " минут";
                return str;
            }
        }
        public double Costnew
        {
            get
            {
                double c = Math.Round(Cost, 0);
                c *= (1 - (double)Discount);
                c = Math.Round(c, 0);
                return c;
            }
        }
        public static Visibility AdminButtons
        {
            get
            {
                return adminButton;
            }
            set
            {
                adminButton = value;
            }

        }
        public string PriceVisibility
        {
            get
            {
                if (Discount == 0)
                {
                    return "Collapsed";
                }
                else
                {
                    return "Visible";
                }
            }
        }
        public string PriceDisc
        {
            get
            {
                return Math.Round(Cost, 0).ToString();
            }
        }
        public string Sk
        {
            get
            {
                return "* скидка " + (Discount * 100).ToString() + "%";
            }
        }
        public string ColorBack
        {
            get
            {
                if (Discount == 0)
                {
                    return "White";
                }
                else
                {
                    return "#FFE7FABF";
                }
            }
        }
        public BitmapImage ImageNew
        {
            get
            {
                return new BitmapImage(new Uri(Environment.CurrentDirectory + MainImagePath, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
