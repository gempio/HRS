using HRS.Process.ReservationOperations;
using HRS.Types.AbstractClasses;
using HRS.Types.ConfigClasses;
using HRS.Types.Enums;
using HRS.Types.Exceptions;

namespace HRS.Process.Factories
{
    internal class ReservationOperationFactory
    {
        internal static AReservationOperation ExtractOperation(OperationConfig config)
        {
            switch (config.OperationId)
            {
                case OperationEnum.ProcessPaymentOperation:
                    return new ProcessPaymentOperation(config.CriticalOperation);
                case OperationEnum.RecheckPriceOperation:
                    return new RecheckPriceOperation(config.CriticalOperation);
                case OperationEnum.SendReservationRequestOperation:
                    return new SendReservationRequestOperation(config.CriticalOperation);
                case OperationEnum.SendSuccessEmailOperation:
                    return new SendSuccessEmailOperation(config.CriticalOperation);
                case OperationEnum.StoreReservationOperation:
                    return new StoreReservationOperation(config.CriticalOperation);
                default:
                    throw new InvalidConfigException("Invalid configuration value for operationId:{0}", config.OperationId);
            }
        }
    }
}
