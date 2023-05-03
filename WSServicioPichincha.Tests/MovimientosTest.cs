using Moq;
using System.Collections.Generic;
using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Business.Services;
using WSServicioPichincha.Controllers;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Tests
{
    public class MovimientosTest
    {

        Mock<IMovimientosService> _mockIMovimientosService;
        Mock<IRepository<Movimientos>> _mockIRepositoryMovimientos;
        Mock<IRepository<Cuenta>> _mockIRepositoryCuenta;
        Mock<IRepository<Cliente>> _mockIRepositoryCliente;
        Mock<IRepository<Persona>> _mockIRepositoryPersona;
        Movimientos movimientos;
        [OneTimeSetUp]
        public void Setup()
        {
            _mockIMovimientosService = new Mock<IMovimientosService>();
            _mockIRepositoryMovimientos = new Mock<IRepository<Movimientos>>();
            _mockIRepositoryCuenta = new Mock<IRepository<Cuenta>>();
            _mockIRepositoryCliente = new Mock<IRepository<Cliente>>();
            _mockIRepositoryPersona = new Mock<IRepository<Persona>>();
            movimientos = new Movimientos()
            {
                Valor = 100,
                Saldo = 10000
            };
        }

        [Test]
        public void TestSaveMovimientos()
        {
            _mockIMovimientosService.Setup(x => x.Save(It.IsAny<Movimientos>())).ReturnsAsync(new Movimientos());
            MovimientosController MovimientosController = new MovimientosController(_mockIMovimientosService.Object);
            Assert.DoesNotThrowAsync(async () => await MovimientosController.Post(movimientos));
        }
        [Test]
        public void TestUpdateMovimientos()
        {
            _mockIMovimientosService.Setup(x => x.Update(It.IsAny<Movimientos>())).ReturnsAsync(new Movimientos());
            MovimientosController MovimientosController = new MovimientosController(_mockIMovimientosService.Object);
            Assert.DoesNotThrowAsync(async () => await MovimientosController.Put(movimientos));
        }
        [Test]
        public void TestDeleteMovimientos()
        {
            _mockIMovimientosService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(new Movimientos());
            MovimientosController MovimientosController = new MovimientosController(_mockIMovimientosService.Object);
            Assert.DoesNotThrowAsync(async () => await MovimientosController.Delete(1));
        }
        [Test]
        public void TestSaveMovimientosService()
        {
            _mockIRepositoryCuenta.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Cuenta());
            _mockIRepositoryMovimientos.Setup(x => x.GetAll()).ReturnsAsync(new List<Movimientos>()
            {
                movimientos
            });
            _mockIMovimientosService.Setup(x => x.Save(movimientos)).ReturnsAsync(movimientos);
            
            MovimientosService MovimientosService = new MovimientosService(_mockIRepositoryMovimientos.Object, _mockIRepositoryCuenta.Object,
                _mockIRepositoryCliente.Object, _mockIRepositoryPersona.Object);
            Assert.DoesNotThrowAsync(async () => await MovimientosService.Save(movimientos));
        }
        [Test]
        public void TestUpdateMovimientosService()
        {
            _mockIMovimientosService.Setup(x => x.Update(It.IsAny<Movimientos>())).ReturnsAsync(new Movimientos());
            _mockIRepositoryCuenta.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Cuenta());
            MovimientosService MovimientosService = new MovimientosService(_mockIRepositoryMovimientos.Object, _mockIRepositoryCuenta.Object,
                _mockIRepositoryCliente.Object, _mockIRepositoryPersona.Object);
            Assert.DoesNotThrowAsync(async () => await MovimientosService.Update(movimientos));
        }
        [Test]
        public void TestDeleteMovimientosService()
        {
            _mockIMovimientosService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(new Movimientos());
            MovimientosService MovimientosService = new MovimientosService(_mockIRepositoryMovimientos.Object, _mockIRepositoryCuenta.Object,
                _mockIRepositoryCliente.Object, _mockIRepositoryPersona.Object);
            Assert.DoesNotThrowAsync(async () => await MovimientosService.Delete(1));
        }
    }
}