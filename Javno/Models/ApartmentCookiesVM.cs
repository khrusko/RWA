using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Javno.Models
{
	public class ApartmentCookiesVM
	{
  private const char DEL = '|';
		public int FilterRooms { get; set; }
		public int FilterAdults { get; set; }
		public int FilterChildren { get; set; }
		public int FilterCity { get; set; }
		public int Order { get; set; }

  public string CookiePrepare()
  {
   return $"{FilterRooms}{DEL}{FilterAdults}{DEL}{FilterChildren}{DEL}{FilterCity}{DEL}{Order}";
  }

  public static ApartmentCookiesVM CookieRead(string cookieParams)
  {
   if (String.IsNullOrEmpty(cookieParams))
   {
    return null;
   }
   string[] testing = cookieParams.Split(DEL);
   if (testing.Length != 5)
    return null;
   return new ApartmentCookiesVM
   {
    FilterRooms = int.Parse(testing[0]),
    FilterAdults = int.Parse(testing[1]),
    FilterChildren = int.Parse(testing[2]),
    FilterCity = int.Parse(testing[3]),
    Order = int.Parse(testing[4])
   };
  }
 }
}