using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.ConfigClasses;
using HRS.Types.Models;
using HRS.Types.Exceptions;
using HRS.Types.Enums;

namespace HRS.DataAccessLayer.OperationDALs
{
    public class ConfigDAL
    {
        public List<OperationConfig> RetrieveConfig(Reservation reservation)
        {
            switch (reservation.Hotel.HotelId)
            {
                case 1: return GetHotel1Config();
                case 2: return GetHotel2Config();
                case 3: return GetHotel3Config();
                default: throw new UnrecognizedHotelException("Hotel not recognized.");
            }
        }

        private List<OperationConfig> GetHotel1Config()
        {
            var temp = new List<OperationConfig>();

            temp.Add(new OperationConfig(OperationEnum.RecheckPriceOperation, true));
            temp.Add(new OperationConfig(OperationEnum.ProcessPaymentOperation, true));
            temp.Add(new OperationConfig(OperationEnum.SendReservationRequestOperation, true));
            temp.Add(new OperationConfig(OperationEnum.SendSuccessEmailOperation, true));
            temp.Add(new OperationConfig(OperationEnum.StoreReservationOperation, true));

            return temp;
        }

        private List<OperationConfig> GetHotel2Config()
        {
            var temp = new List<OperationConfig>();

            temp.Add(new OperationConfig(OperationEnum.RecheckPriceOperation, true));
            temp.Add(new OperationConfig(OperationEnum.ProcessPaymentOperation, true));
            temp.Add(new OperationConfig(OperationEnum.SendReservationRequestOperation, false));
            temp.Add(new OperationConfig(OperationEnum.SendSuccessEmailOperation, true));
            temp.Add(new OperationConfig(OperationEnum.StoreReservationOperation, true));

            return temp;
        }
        
        private List<OperationConfig> GetHotel3Config()
        {
            var temp = new List<OperationConfig>();

            temp.Add(new OperationConfig(OperationEnum.RecheckPriceOperation, true));
            temp.Add(new OperationConfig(OperationEnum.ProcessPaymentOperation, true));
            temp.Add(new OperationConfig(OperationEnum.SendSuccessEmailOperation, true));
            temp.Add(new OperationConfig(OperationEnum.StoreReservationOperation, true));

            return temp;
        }
    }
}
