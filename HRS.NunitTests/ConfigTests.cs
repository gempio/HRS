using System;
using System.Collections.Generic;
using HRS.DataAccessLayer.OperationDALs;
using HRS.NunitTests.TestDataClasses;
using HRS.Process.Validators;
using HRS.Types.ConfigClasses;
using HRS.Types.Models;
using NUnit.Framework;

namespace HRS.NunitTests
{
    [TestFixture]
    public class ConfigTests
    {
        private List<Hotel> _hotels;
        private ConfigDAL _configDal;
        private Reservation _reservation;

        [SetUp]
        public void SetUp()
        {
            _hotels = TestHotelsData.GetTestHotels();
            _configDal = new ConfigDAL();
            _reservation = new Reservation();
        }

        [Test]
        public void ShouldPassOnValidConfig()
        {
            _reservation.Hotel = _hotels[0];
            List<OperationConfig> config = _configDal.RetrieveConfig(_reservation);
            Assert.DoesNotThrow(() => ConfigValidator.ValidateConfig(_hotels[0], config));
        }

        [Test]
        public void ShouldThrowOnNonCriticalRequestSubmit()
        {
            _reservation.Hotel = _hotels[1];
            List<OperationConfig> config = _configDal.RetrieveConfig(_reservation);
            Assert.Throws<InvalidOperationException>(() => ConfigValidator.ValidateConfig(_hotels[1], config));
        }

        [Test]
        public void ShouldThrowOnMissingRequestSubmit()
        {
            _reservation.Hotel = _hotels[2];
            List<OperationConfig> config = _configDal.RetrieveConfig(_reservation);
            Assert.Throws<InvalidOperationException>(() => ConfigValidator.ValidateConfig(_hotels[2], config));
        }
    }
}